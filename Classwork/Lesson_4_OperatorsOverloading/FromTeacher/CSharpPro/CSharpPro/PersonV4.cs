namespace CSharpPro
{
    // Ланцюжок виклику конструкторів
    public class PersonV4
    {
        public string name;
        public int age;
        public PersonV4() : this("Неизвестно")    // 1 конструктор
        {
            Console.WriteLine("1 конструктор");
        }
        public PersonV4(string name) : this(name, 18) // 2 конструктор
        {
            Console.WriteLine("2 конструктор");
        }
        public PersonV4(string name, int age)     // 3 конструктор
        {
            this.name = name;
            this.age = age;
            Console.WriteLine("3 конструктор");
        }
        public void Print() => Console.WriteLine($"Name: {name}  Age: {age}");

        // Деконструктори

        /*
        Деконструктори (не плутати з деструкторами) дозволяють виконати декомпозицію об'єкта окремі частини.
        */

        public void Deconstruct(out string personName, out int personAge)
        {
            personName = name;
            personAge = age;
        }
    }
}
