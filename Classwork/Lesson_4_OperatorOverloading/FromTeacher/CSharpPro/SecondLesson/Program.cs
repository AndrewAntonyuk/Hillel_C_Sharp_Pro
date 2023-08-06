using SecondLesson.oop;
using SecondLesson.static_examples;
using System.Numerics;
using System.Text;

namespace SecondLesson
{
    public class Car
    {
        public const string model = "test-model";
        public readonly string name = "test-name";

        public Car(string car_name) 
        {
            name = car_name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {name} model: {model}");
        }
    }

    public class Program
    {
        public static (int sum, double average) GetArrCalculations(int[] numbers)
        {
            var result = (sum: 0, average: .0);

            foreach (var number in numbers)
            {
                result.sum += number;
            }

            result.average = Convert.ToDouble(result.sum) / numbers.Length;

            return result;
        }

        public static void Main()  // точка входа в программу, программа стартует с этой функции (метода)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ////////////////////////////////////////////////////////////////////
            // пример с кортежем (tuple)
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples

            //var tupleResult = GetArrCalculations(new int[] { 1, 2, 3, 4, 6 });
            //Console.WriteLine(tupleResult);
            //Console.WriteLine($"Sum: {tupleResult.sum} Avg: {tupleResult.average}");

            ////////////////////////////////////////////////////////////////////
            // Структури

            // Створення об'єкта структури
            // Ініціалізація за допомогою конструктора

            /*
            Для використання структури її необхідно ініціалізувати. Для ініціалізації створення об'єктів структури, 
            як і у випадку класів, застосовується виклик конструктура з оператором new. Навіть якщо в коді структури не визначено жодного конструктора, 
            проте має як мінімум один конструктор - конструктор за замовчуванням, який генерується компілятором. Конструктор не приймає параметрів і 
            створює об'єкт структури зі значеннями за замовчуванням.
            */

            //PersonV1 tom = new PersonV1(); // Виклик конструктора
            //                           // або так
            //                           // Person tom = new ();

            //tom.name = "Tom"; // Змінюємо значення за замовчуванням у полі name

            //tom.Print();

            // Безпосередня ініцілізація полів

            // Якщо всі поля структури доступні
            // (як і з полями структури Person, який мають модифікатор public),
            // структуру можна ініціалізувати без виклику конструктора. 

            // У цьому випадку необхідно надати значення всім полям структури
            // перед отриманням значень полів і зверненням до методів структури. Наприклад:

            //PersonV1 sam; // не викликаємо конструктор
            //              // ініціалізація полів
            //sam.name = "Sam";
            //sam.age = 37;

            //sam.Print(); // Ім'я: Sam Вік: 37

            ////
            //var vasya = new PersonV1();
            //vasya.Print();

            //
            //PersonV2 p1 = new();
            //PersonV2 p2 = new("Bob");
            //PersonV2 p3 = new("Sam", 25);

            //p1.Print(); // Ім'я: Tom Вік: 1
            //p2.Print(); // Ім'я: Bob Вік: 1
            //p3.Print(); // Ім'я: Sam Вік: 25

            ////
            //// Ініціалізатор структури
            //PersonV2 p4 = new PersonV2 { name = "Tom", age = 22 };

            //p4.Print();

            //// Копіювання структури за допомогою with
            //// Якщо нам необхідно скопіювати в один об'єкт структури значення з
            //// іншого з невеликими змінами, ми можемо використовувати оператор with:

            //PersonV2 person_tom = new PersonV2 { name = "Tom", age = 22 };
            //PersonV2 person_bob = person_tom with { name = "Bob" };
            //person_bob.Print();

            ////////////////////////////////////////////////////////////////////
            ///// // readonly vs const - разница?

            //var my_car = new Car("Toyota");
            //my_car.ShowInfo();

            ////////////////////////////////////////////////////////////////////
            ////// Статичнi поля та класи
            //Console.WriteLine(PersonV3.retirementAge);

            //var person = new PersonV3(50);
            //person.Print();
            //PersonV3.CheckRetirementStatus(person);

            ////
            //Console.WriteLine(MathOperations.Add(5, 4));         // 9
            //Console.WriteLine(MathOperations.Subtract(5, 4));    // 1
            //Console.WriteLine(MathOperations.Multiply(5, 4));    // 20

            ////////////////////////////////////////////////////////////////////
            // ООП

            // v1
            // var st = new State();
            //try
            //{
            //    var per = new Person();
            //    Console.WriteLine(per.Name);  // отработает get;
            //    per.Name = "Vasya";  // отработает set;
            //    Console.WriteLine(per.Name);
            //    Console.WriteLine(per.Age);
            //    per.Age = 33;
            //    Console.WriteLine(per.Age);
            //    per.Age = 330;
            //    Console.WriteLine(per.CompanyName);
            //    // per.CompanyName = "qqqq"; // не работает так как readonly свойство (только для чтения)
            //    per.FirstName = "Petrov";
            //    // Console.WriteLine(per.FirstName); // не работает так как writeonly свойство (только для записи)
            //    Console.WriteLine(per.TestInfo);
            //    // per.TestInfo = "test"; // error так как init
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            //////
            //var vasya = new Person();
            //Console.WriteLine(vasya.Hobby); // get
            //vasya.Hobby = "some hobby"; // set
            //Console.WriteLine(vasya.Hobby); // get

            ////
            //Console.WriteLine(vasya.Name); // get
            //vasya.Name = "Vasya"; // set
            //Console.WriteLine(vasya.Name); // get

            //Console.WriteLine(vasya.Age); // get
            //vasya.Age = 200; // set
            //Console.WriteLine(vasya.Age); // get
            //vasya.Age = 30; // set
            //Console.WriteLine(vasya.Age); // get

            // v2
            //var emp1 = new Employee("Micro", "Vasya", "Work", "More Work");
            //Console.WriteLine(emp1.Name);
            //emp1.ShowInfo();
            //Console.WriteLine(emp1.Company);
            //Person pers1 = emp1; // сужающее приведение к типу базового класса
            //// Console.WriteLine(pers1.Company);
            //// Console.WriteLine(emp1.Hobby); // нет доступа так как наследуемое поле protected
            //// доступно ТОЛЬКО в пределах класса наследника Employee

            // v3
            //var iphone = new SmartPhone("Iphone 123", 123.5m, 456.6);
            //Console.WriteLine();
            //iphone.Print();

            //PhoneBase anyPhone = iphone;
            //anyPhone.Print();
            // так как наш метод переопределен в классе SmartPhone
            // то в случае если экземпляр класса SmartPhone привести к типу базового класса PhoneBase -
            // реализация этого метода будет подтягиваться с дочернего класса SmartPhone

            // но если наш метод перекрыт в классе SmartPhone (через new)
            // то в случае если экземпляр класса SmartPhone привести к типу базового класса PhoneBase -
            // реализация этого метода будет подтягиваться с базового класса PhoneBase, а реализация из дочернего - потеряется

            // пример с карандашами

            //var greenPencil = new Pencil(name: "Green-pencil", material: "Metal", cost: 12.5m, color: "Green", manufacturer: "manufacturer-1");
            ////greenPencil.ShowPencilInfo();
            ////greenPencil.Draw();

            //var bluePencil = new Pencil("Blue-pencil", 12.3m, "wood", "blue", "manufacturer-2");
            ////bluePencil.ShowPencilInfo();
            ////bluePencil.Draw();

            //var pencils = new List<Pencil> { greenPencil, bluePencil };

            //var myPenal = new Penal(pencils);
            //myPenal.ShowPensils();

            //Console.WriteLine("\n-------------------------------------\n");

            //myPenal.AddPencil(new Pencil("Black-pencil", 11.3m, "wood", "black", "manufacturer-2"));
            //myPenal.ShowPensils();

            //Console.WriteLine("\n-------------------------------------\n");

            //myPenal.RemovePencil(bluePencil);
            //myPenal.ShowPensils();

            ////////////////////////
            ///
            IGraphic graphic = null;

            // создаем IGraphic реализация ConsoleApp
            graphic = new ConsoleApp();

            // Это полиморфизм мы вызываем метод ShowText у интерфейса IGraphic
            // В реальности вызовется ShowText у класса кто реализовал интерфейс IGraphic
            graphic.ShowText("Hello");

            // создаем IGraphic реализация Phone
            graphic = new Phone();

            // Это полиморфизм мы вызываем метод ShowText у интерфейса IGraphic
            // В реальности вызовется ShowText у класса кто реализовал интерфейс IGraphic
            graphic.ShowText("Hello");
        }
    }
}
