using Task_1_Play;

namespace Lesson_7_GarbageCollector
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Test();

            Console.WriteLine();
            Console.WriteLine("Test of destructor:");

            GC.Collect();
            Console.ReadLine();
        }

        private static void Test()
        {
            #region header
            Console.WriteLine("Tests for play");
            Console.WriteLine("=====================");
            Console.WriteLine();

            Person _authorOHT = new Person("Ivan", "Karpovych", "Tobilevych");
            Play _oneHundredThousands = new Play("The One hundred Tausends",
                                                   PlayTypes.Tragicomedy,
                                                   1889,
                                                   _authorOHT);
            #endregion

            #region test of functions
            _oneHundredThousands.Run();
            _oneHundredThousands.Pause();
            #endregion
        }
    }
}