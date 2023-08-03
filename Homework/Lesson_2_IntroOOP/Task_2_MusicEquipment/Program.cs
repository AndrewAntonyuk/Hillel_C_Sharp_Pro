using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_MusicEquipment.MusicInstruments;

namespace Task_2_MusicEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicInstrument[] instruments = { new Cello(), new Trombone(), new Ukulele(), new Violin() };

            try
            {
                foreach (var instr in instruments)
                {
                    instr.show();
                    instr.desc();
                    instr.history();
                    instr.sound();

                    Console.WriteLine("=============================");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
