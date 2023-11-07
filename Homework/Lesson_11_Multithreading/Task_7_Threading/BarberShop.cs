using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Task_7_Threading
{
    public class BarberShop
    {
        private const int _MAX_BARBERS = 1;
        private const int _MAX_WAITING_CLIENTS = 10;
        private const int _MAX_WAITING_CHAIRS = 3;

        private Semaphore barberSemaphore = new Semaphore(_MAX_BARBERS, _MAX_BARBERS);
        private Semaphore clientSemaphore = new Semaphore(1, _MAX_WAITING_CHAIRS);

        //private Thread[] barberThreads = new Thread[_MAX_BARBERS];
        private Thread barberThread;// = new Thread();
        private Thread[] clientThreades = new Thread[_MAX_WAITING_CLIENTS];

        private int counterCurrent = _MAX_WAITING_CHAIRS;
        private Mutex mutex = new Mutex();
        private int total = 0;

        private ConcurrentQueue<string> waitingQue = new ConcurrentQueue<string>();

        public void DoWork()
        {
            for (int i = 0; i < _MAX_WAITING_CLIENTS; i++)
            {
                clientThreades[i] = new Thread(ClientWork);
                clientThreades[i].Name = $"Client {i}";
                clientThreades[i].Start();
            }

            barberThread = new Thread(BarberWork);
            barberThread.Name = $"Barber";
            barberThread.Start();
        }

        private void BarberWork()
        {
            int delayingTime = new Random().Next(1000, 2000);
            Console.WriteLine("Barber is sleeping (it's waiting for the new client)");
            Console.WriteLine();

            while (true)
            {
                mutex.WaitOne();
                if (counterCurrent < _MAX_WAITING_CHAIRS)
                {
                    barberSemaphore.WaitOne();

                    string client;
                    waitingQue.TryDequeue(out client);

                    Console.WriteLine($"{client} is waking up barber");
                    Console.WriteLine($"Barber is cutting hair {client}....");
                    Console.WriteLine();
                    
                    counterCurrent++;                    

                    Thread.Sleep(delayingTime);
                    Console.WriteLine($"Barber finished haircutting {client}");
                    Console.WriteLine($"Barber goes sleep");
                    Console.WriteLine();

                    barberSemaphore.Release();
                }
                mutex.ReleaseMutex();
            }
        }

        private void ClientWork()
        {
            while (total < _MAX_WAITING_CLIENTS)
            {
                int delayingTime = new Random().Next(3000, 9000);
                total++;

                Console.WriteLine($"{Thread.CurrentThread.Name} is going to barbershop");
                Console.WriteLine();

                Thread.Sleep(delayingTime);

                mutex.WaitOne();

                if (counterCurrent > 0)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} is entering to barbershop (free chairs = {counterCurrent})");
                    clientSemaphore.WaitOne();

                    waitingQue.Enqueue(Thread.CurrentThread.Name);
                    counterCurrent--;
                    Console.WriteLine($"{Thread.CurrentThread.Name} is waiting for haircutting....");
                    Console.WriteLine();

                    clientSemaphore.Release();
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} is leaving barbershop without haircutting");
                    Console.WriteLine();
                }

                mutex.ReleaseMutex();
            }
        }
    }
}
