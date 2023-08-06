namespace CSharpPro
{
    public class PersonV2
    {
        public string name;
        public int age;
        public PersonV2() { name = "Undefined"; age = 18; }      // 1 конструктор
        public PersonV2(string n) { name = n; age = 18; }         // 2 конструктор
        public PersonV2(string n, int a) { name = n; age = a; }   // 3 конструктор

        public void Print()
        {
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }
}
