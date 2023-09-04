namespace Lesson9
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            //int[] numbers = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };
            int[] numbers = { };
            var result = numbers.ElementAtOrDefault(2);

            //foreach (int i in result)
                Console.WriteLine(result);

            int Square(int n) => n * n;

        }
    }
}