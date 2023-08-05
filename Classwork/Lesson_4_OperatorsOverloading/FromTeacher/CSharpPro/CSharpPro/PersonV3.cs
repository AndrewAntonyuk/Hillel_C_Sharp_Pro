namespace CSharpPro
{
    // Ключове слово this представляє посилання на поточний екземпляр/об'єкт класу.
    public class PersonV3
    {
        public string name;
        public int age;
        public PersonV3() { name = "Undefined"; age = 18; }
        public PersonV3(string name)
        {
            this.name = name;
            age = 18;
        }
        public PersonV3(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void Print() => Console.WriteLine($"Name: {name}  Age: {age}");
    }
}
