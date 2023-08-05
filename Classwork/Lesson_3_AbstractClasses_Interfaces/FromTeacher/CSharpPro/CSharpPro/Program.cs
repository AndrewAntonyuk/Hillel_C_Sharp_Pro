using System.Text;

//class назва_класа
//{
//    // вміст класу
//}

namespace Lesson
{
    // v1
    class Person
    {
        public string name;   // ім'я
        public int age;                     // вік
        public Company company;

        public Person()
        {
            name = "Undefined";
            age = 18;
            company = new Company();
        }

        public void Print()
        {
            Console.WriteLine($"Name: {name}  Age: {age} Company: {company.title}");
        }
    }

    class Company
    {
        public string title = "Unknown";
    }


    public class Program
    {
        public static void Main()  // точка входа в программу, программа стартует с этой функции (метода)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // v1
            //Person tom = new Person();  // створення об'єкта класу Person

            //// Отримуємо значення полів у змінні
            //string personName = tom.name;
            //int personAge = tom.age;
            //Console.WriteLine($"Имя: {personName}  Возраст {personAge}");   // Имя: Undefined  Возраст: 0

            //// встановлюємо нові значення полів
            //tom.name = "Tom";
            //tom.age = 37;

            //// звертаємось до методу Print
            //tom.Print();    // Ім'я: Tom Вік: 37

            // v2
            //PersonV2 tom = new PersonV2(); // Виклик першого конструктора без параметрів
            //PersonV2 bob = new PersonV2("Bob"); //виклик 2-го конструктора з одним параметром
            //PersonV2 sam = new PersonV2("Sam", 25); // Виклик 3-го конструктора з двома параметрами

            //tom.Print(); // Ім'я: Невідомо Вік: 18
            //bob.Print(); // Ім'я: Bob Вік: 18
            //sam.Print(); // Ім'я: Sam Вік: 25

            // v3
            //PersonV3 sam = new("Sam", 25);
            //sam.Print();          // Ім'я: Tom Вік: 37

            ////
            //var vasya = new PersonV3("Sam", 25);

            // v4
            //var vasya = new PersonV4();
            //vasya.Print();

            //var vasya1 = new PersonV4("Vasya");
            //vasya1.Print();

            // v5
            //var user = new PersonV4 { name = "Test", age = 33 };
            //user.Print();

            //var user_1 = new Person
            //{
            //    name = "Vasya",
            //    age = 33,
            //    company = new Company
            //    {
            //        title = "Test Company",
            //    }
            //};

            //user_1.Print();

            /*
                За допомогою ініціалізації об'єктів можна надавати значення всім доступним полям і властивостям об'єкта в момент створення. 
                При використанні ініціалізації слід враховувати наступні моменти:

                За допомогою ініціалізатора ми можемо встановити значення лише доступних із позакласу полів та властивостей об'єкта. 
                Наприклад, у прикладі вище поля name і age мають модифікатор доступу public, тому вони доступні будь-якої частини програми.

                Ініціалізатор виконується після конструктора, тому якщо і в конструкторі, і в ініціалізаторі встановлюються значення тих самих полів і властивостей, 
                то значення, що встановлюються в конструкторі, замінюються значеннями з ініціалізатора.
             */

            // Деконструктори
            //var person = new PersonV4("Tom", 33);

            //(string name, int age) = person;

            //Console.WriteLine(name);    // Tom
            //Console.WriteLine(age);     // 33

            /*
            Типи значень:

            Цілочисленні типи (byte, sbyte, short, ushort, int, uint, long, ulong)

            Типи з плаваючою комою (float, double)

            Тип decimal

            Тип bool

            Тип char

            Перерахування enum

            Структури (struct)

            Посилальні типи: (ссылочные типы данных)

            Тип object

            Тип string

            Класи (class)

            Інтерфейси (interface)

            Делегати (delegate)
            */

            // упаковка и распаковка данных
            int number = 10;
            Console.WriteLine(number);
            object my_number = number; // упаковка
            Console.WriteLine(my_number);
            int number_from_object = (int)my_number; // распаковка
            Console.WriteLine(number_from_object);

            // распаковка (можем распаковать только в исходный значимый тип данных)
            //float number_from_object_1 = (float)my_number; 
            //Console.WriteLine(number_from_object_1);
        }
    }
}




