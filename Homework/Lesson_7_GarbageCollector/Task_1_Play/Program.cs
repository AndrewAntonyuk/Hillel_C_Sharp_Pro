using Task_1_Play;

namespace Lesson_7_GarbageCollector
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                Test();

                Console.WriteLine();
                Console.WriteLine("Test of destructor:");

                GC.Collect();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e.Message);
            }
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

            Person _authorUndef = null;
            Play _withoutAuthor = new Play("Witcher",
                                            PlayTypes.UndefinedType,
                                            1992,
                                            _authorUndef);
            #endregion

            #region test of functions
            _oneHundredThousands.Run();
            _oneHundredThousands.Pause();

            _withoutAuthor.Run();
            _withoutAuthor.Pause();
            #endregion
        }
    }
}