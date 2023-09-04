//#region simple LINQ to Object

////string[] people = {"Tom", "Bob", "Sam", "Tim", "Tomas", "Bill"};

////Console.WriteLine("People with name started at T:");

////people.Where(persone => persone.ToUpper().StartsWith("T"))?
////        .ToList()?
////        .ForEach(persone =>Console.WriteLine(persone));

//////Or

////var peopleStartedWithT = people.Where(p => p.ToUpper().StartsWith("T"));

////Console.WriteLine(peopleStartedWithT?.Aggregate("", (p1, p2)  => $"{p1}\n{p2}"));
//#endregion

//#region operators of requests
////string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

////var selectedPeople = from p in people
////                     where p.ToUpper().StartsWith("T")
////                     orderby p
////                     select p;

////Console.WriteLine(selectedPeople.Aggregate((a, b) => $"{a}\n{b}"));
//#endregion

//#region methods
////string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

////var selectedPeople = people.Where(p => p
////                    .ToUpper().StartsWith("T"))
////                     .OrderByDescending(p => p);

////Console.WriteLine(selectedPeople.Aggregate((a, b) => $"{a}\n{b}"));
//#endregion

//#region simple examples
////var people = new List<Person>
////{
////    new Person("John", 32),
////    new Person("Bazz", 16),
////    new Person("Linda", 25),
////    new Person("Ashe", 20),
////    new Person("Rachel", 27)
////};

//////Collection of names by operator
////var namesOp = from person in people
////              orderby person.Age
////              select person.Name;
////Console.WriteLine(namesOp.Aggregate((p1, p2) => $"{p1}\n{p2}"));
////Console.WriteLine();

//////Collection of names by methods
////var namesMet = people
////    .OrderBy(p => p.Name)
////    .Select(p => p.Name);
////Console.WriteLine(namesMet.Aggregate((p1, p2) => $"{p1}\n{p2}"));
////Console.WriteLine();

//////Collection with additional math during select
////var objWithMath = from person in people
////                  select new
////                  {
////                      FirstName = person.Name,
////                      Year = DateTime.Now.Year - person.Age
////                  };

////objWithMath.ToList().ForEach(p => Console.WriteLine($"{p.FirstName} --- {p.Year}"));
////Console.WriteLine();

//////Collection with additional math and vars during select v2
////var objWithMath2 = from person in people
////                   let name = $"Pn. {person.Name}"
////                   let year = DateTime.Now.Year - person.Age
////                   select new
////                   {
////                       FirstName = name,
////                       Year = year
////                   };

////objWithMath2.ToList().ForEach(p => Console.WriteLine($"{p.FirstName} --- {p.Year}"));
////Console.WriteLine();

//////Collection with additional math and vars during select v3
////var objWithMath3 = people    
////    .Select(p => new
////    {
////        FirstName = $"Pn. {p.Name}",
////        Year = DateTime.Now.Year - p.Age
////    })
////    .OrderBy(p => p.FirstName);

////objWithMath3.ToList().ForEach(p => Console.WriteLine($"{p.FirstName} --- {p.Year}"));
////Console.WriteLine();
//#endregion

//#region actions with different suppliers
////var courses = new List<Course> {new Course("C#"), new Course("Java"), new Course("JS")};
////var students = new List<Student> { new Student("John"), new Student("Linda") };

////var setCourse = from student in students
////                from course in courses
////                select new Student(student.Name)
////                {
////                    Course = course
////                };

////setCourse.ToList().ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

//////Or
////var setCourse2 = from student in students
////                from course in courses
////                select new 
////                {
////                    FirstName = student.Name,
////                    CurrentCourse = course.Name
////                };

////setCourse2.ToList().ForEach(p => Console.WriteLine($"[Name: {p.FirstName}; current course: {p.CurrentCourse}]"));
////Console.WriteLine();
//#endregion

//#region SelectMany() and agregate some objects
////var companies = new List<Company>
////{
////    new Company("Microsoft"){ Employees = new List<Person> {new Person("Tom", 42), new Person("Bob", 54)}},
////    new Company("Google"){ Employees = new List<Person> {new Person("Sam", 24), new Person("Mike", 21), new Person("Bob", 54)} }
////};

////var employees = companies.SelectMany(comp => comp.Employees);

////employees.ToList().ForEach(e => Console.WriteLine(e));
////Console.WriteLine();

//////The same just with operators
////var employees1 = from company in companies
////                 from employee in company.Employees
////                 select employee;

////employees1.ToList().ForEach(e => Console.WriteLine(e));
////Console.WriteLine();

//////The same just with new objects
////var employees2 = companies.SelectMany(com => com.Employees,
////                                        (com, emp) => new 
////                                        {
////                                            NameEmployee = emp.Name, 
////                                            NameCompany = com.Name
////                                        });

////employees2.ToList().ForEach(e => Console.WriteLine($"[Employee name: {e.NameEmployee}; company name: {e.NameCompany}]"));
////Console.WriteLine();

//////The same just with new objects with operators
////var employees3 = from company in companies
////                 from employee in company.Employees
////                 select new
////                 {
////                     NameEmployee = employee.Name,
////                     NameCompany = company.Name
////                 };

////employees3.ToList().ForEach(e => Console.WriteLine($"[Employee name op: {e.NameEmployee}; company name op: {e.NameCompany}]"));
////Console.WriteLine();
//#endregion

//#region filters
////string[] people = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };

////var selectedPeople = people.Where(p => p.Length == 3 && p.ToLower().StartsWith("t"));
//////.Where(p => p.ToLower().StartsWith("t"));
////selectedPeople.ToList().ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

//////The same with operators
////var selectedPeople1 = from p in people
////                      where p.Length == 3 && !p.ToLower().StartsWith("t")
////                      //where p.ToLower().StartsWith("t")
////                      select p;

////selectedPeople1.ToList().ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

////int[] numbers = { -2, 1, 4, 55, 82, 17, 11, 64, 96 };

////var evenNumbers = numbers.Where(n => n % 2 == 0 && n > 10);

////evenNumbers.ToList().ForEach(n => Console.WriteLine(n));
////Console.WriteLine();

//////The same with operators
////var evenNumbersOp = from n in numbers
////                    where n % 2 == 0 && n > 10
////                    select n;
////evenNumbersOp.ToList().ForEach(n => Console.WriteLine(n));
////Console.WriteLine();

////var companies = new List<Company>
////{
////    new Company("Microsoft"){ Employees = new List<Person> {new Person("Tom", 42), new Person("Bob", 54)}},
////    new Company("Google"){ Employees = new List<Person> {new Person("Sam", 24), new Person("Mike", 21), new Person("Bob", 54)}},
////    new Company("Apple") { Employees = new List<Person>  {new Person("Radg", 25), new Person("Bob", 47), new Person("Katty", 31)}}
////};

////var selectedCompanies = from c in companies
////                        where c.Name.ToLower().StartsWith("m")
////                        select c;

////selectedCompanies.ToList().ForEach(c => Console.WriteLine(c));
////Console.WriteLine();

////var selectedBobCompanies = from c in companies
////                           from e in c.Employees
////                           where e.Name.ToLower().StartsWith("b")
////                           select c;

////selectedBobCompanies.ToList().ForEach(c => Console.WriteLine(c));
////Console.WriteLine();

////var selectedBobCompanies1 = from c in companies
////                            from e in c.Employees
////                            where e.Name.ToLower().StartsWith("b")
////                            where c.Name.Length >= 6
////                            select c;

////selectedBobCompanies1.ToList().ForEach(c => Console.WriteLine(c));
////Console.WriteLine();

////var selectedEmployees = companies.SelectMany(c => c.Employees,
////    (c, e) => new { employee = e, company = c })
////    .Where(c => c.company.Name.Length <= 7 && c.employee.Name.ToLower() == "bob")
////    .Select(c => c.employee);

////selectedEmployees.ToList().ForEach(e => Console.WriteLine(e));
////Console.WriteLine();

//////TypeOf() test
////var diffPeople = new List<Person>
////{
////    new Student("Ashrak"),
////    new Person("Bill", 36),
////    new Person("John", 45),
////    new Student("Rachal"),
////    new Student("Rorck")
////}; 

////var students = diffPeople.OfType<Student>().ToList();

////students.ForEach(s => Console.WriteLine(s));
////Console.WriteLine();
//#endregion

//#region sorting
////int[] numbers = { 98, -25, 2, 0, 54, 63, 7};

////var sortedNums = from n in numbers
////                 orderby n
////                 descending
////                 select n;

////sortedNums.ToList().ForEach(n => Console.WriteLine(n));
////Console.WriteLine();

////string[] peopleS = {"John", "Sam", "Jurgen", "Neo" };

////var sortedPeopleS = from p in peopleS
////                   orderby p
////                   select p;

////sortedPeopleS.ToList().ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

////var people = new List<Person>
////{
////    new Person("Jhon", 32),
////    new Person("Bazz", 16),
////    new Person("Linda", 25),
////    new Person("Ashe", 20),
////    new Person("Rachel", 27)
////};

////var sortedPeople = from p in people
////                   orderby p.Name
////                   select p;

////sortedPeople.ToList().ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

////var sortedPeople1 = from p in people
////                   orderby p.Age
////                   descending
////                   select p;

////sortedPeople1.ToList().ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

////var sortedPeople2 = people.OrderBy(p => p.Name).ToList();

////sortedPeople2.ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

////var sortedPeople3 = from p in people
////                    orderby p.Age
////                    select p;

////sortedPeople3.ToList().ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

//////Sort with custom comparrer
////var sortedPeopleCompar = people.OrderByDescending(p => p, new CustomPersonComparrer()).ToList();
////sortedPeopleCompar.ForEach(p => Console.WriteLine(p));
////Console.WriteLine();
//#endregion

//#region union, crossection and difference of collections
////string[] soft = {"Microsoft", "Google", "Apple", "Meta", "Google", "Meta" };
////string[] hard = { "Apple", "Intel", "IBM", "Intel", "Intel", "Microsoft"};

////var resultIntersect = soft.Intersect(hard).OrderBy(o => o).ToList();
////resultIntersect.ForEach(r => Console.WriteLine(r));
////Console.WriteLine();

////var resultUnion = soft.Union(hard).OrderBy(o => o).ToList(); //Only unique values put to result collection
////resultUnion.ForEach(r => Console.WriteLine(r));
////Console.WriteLine();    

////var resultUnique = soft.Distinct().OrderBy(o => o).ToList();
////resultUnique.ForEach(r => Console.WriteLine(r));
////Console.WriteLine();

////var resultExcept = soft.Except(hard).OrderBy(o => o).ToList();
////resultExcept.ForEach(r => Console.WriteLine(r));
////Console.WriteLine();

////List<Person> employeesSoft = new List<Person> 
////{ 
////    new Person("Sam", 25),
////    new Person("Abram", 41),
////    new Person("Linda", 36),
////    new Person("Josh", 19),
////    new Person("Rosen", 28)
////};

////List<Person> employeesHard = new List<Person>
////{
////    new Person("Rom", 30),
////    new Person("Alik", 22),
////    new Person("Linda", 20),
////    new Person("Rex", 31),
////    new Person("Roben", 39)
////};

////var employees = employeesSoft.Union(employeesHard)
////    .OrderBy(o => o.Age)
////    .OrderBy(o=>o.Name)    
////    .ToList();

////employees.ForEach(r => Console.WriteLine(r));
////Console.WriteLine();
//#endregion

//#region aggregation
////int[] numbers = { 1, 2, 3, 4, 5 };
////Console.WriteLine("Work with int:");
////Console.WriteLine($"Result of Aggregate + : {numbers.Aggregate((n1, n2) => n1 + n2)}");
////Console.WriteLine($"Result of Aggregate - : {numbers.Aggregate((n1, n2) => n1 - n2)}");
////Console.WriteLine($"Result of Aggregate to string : {numbers.Aggregate("Text:",(n1, n2) => $"{n1} {n2}")}");
////Console.WriteLine($"Result of Counts : {numbers.Count()}");
////Console.WriteLine($"Result of Counts(i > 2 && i%2 == 0) : {numbers.Count(i => i>2 && i%2 ==0)}");
////Console.WriteLine($"Result of Sum : {numbers.Sum()}");
////Console.WriteLine($"Result of Min : {numbers.Min()}");
////Console.WriteLine($"Result of Max : {numbers.Max()}");
////Console.WriteLine($"Result of Average : {numbers.Average()}");
////Console.WriteLine();

////List<Person> employees = new List<Person>
////{
////    new Person("Sam", 25),
////    new Person("Abram", 41),
////    new Person("Linda", 36),
////    new Person("Josh", 19),
////    new Person("Rosen", 28)
////};
////Console.WriteLine("Work with Person:");
////Console.WriteLine($"Result of sum of Aggregate age: {employees?.Aggregate(0, ( total, next) => total + next?.Age ?? 0, res => $"Total age: {res}")}");
////Console.WriteLine($"Result of sum of Aggregate name: {employees?.Aggregate("All employees:", (text, word) => $"{text} {word?.Name ?? ""}")}");
////Console.WriteLine($"Result of max of Aggregate age: {employees?.Aggregate(0, (max, next) => next?.Age > max ? next?.Age ?? 0: max)}");
////Console.WriteLine($"Result of min of Aggregate age: {employees?.Aggregate(int.MaxValue, (min, next) => next?.Age < min ? next?.Age ?? 0 : min)}");
////Console.WriteLine($"Result of average of Aggregate age: {employees?.Aggregate(0.0, (total, next) =>  total + next?.Age ?? 0, res => res / employees.Count)}");
////Console.WriteLine($"Result of sum of Aggregate name: {employees?.Aggregate("All employees:", (text, word) => $"{text} {word?.Name ?? ""}")}");
////Console.WriteLine($"Result of Sum age : {employees?.Sum(e => e.Age)}");
////Console.WriteLine($"Result of Min age : {employees?.Min(e => e.Age)}");
////Console.WriteLine($"Result of Max age : {employees?.Max(e => e.Age)}");
////Console.WriteLine($"Result of Average age : {employees?.Average(e => e.Age)}");
//#endregion

//#region Skip and Take
////string[] people = { "Tom", "Sam", "Bob", "Mike", "Kate" };

////var takenPeople = people.Skip(2)
////                        .ToList();
////takenPeople.ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

////var takenFirstPeople = people.SkipLast(2)
////                             .ToList();
////takenFirstPeople.ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

//////people from started with M
////var peopleAfterM = people.SkipWhile(p => !p.ToLower()
////                                           .StartsWith("m"))
////                         .ToList();

////people[2] = "Martin";

////peopleAfterM.ForEach(p => Console.WriteLine(p));
////Console.WriteLine();

////var takenFirstPeople1 = people.Take(3)
////                              .ToList();
////takenFirstPeople1.ForEach(person => Console.WriteLine(person));
////Console.WriteLine();

////var takenLastPeople = people.TakeLast(3)
////                            .ToList();
////takenLastPeople.ForEach(person => Console.WriteLine(person));
////Console.WriteLine();

////var takenBeforeMi = people.TakeWhile(p => !p.ToLower()
////                                            .StartsWith("mi"))
////                          .ToList();
////takenBeforeMi.ForEach(person => Console.WriteLine(person));
////Console.WriteLine();

////var takenSkippedPeople = people.SkipWhile(p => !p.ToLower()
////                                                 .StartsWith("m"))
////                                .Take(2)
////                                .ToList();
////takenSkippedPeople.ForEach(Console.WriteLine);
////Console.WriteLine();
//#endregion

//#region grouping by key
////var companies = new List<Company>
////{
////    new Company("Microsoft"){ Employees = new List<Person> {new Person("Tom", 42), new Person("Bob", 54)}},
////    new Company("Apple"){ Employees = new List<Person> {new Person("Linda", 24), new Person("Bob", 54), new Person("Sam", 25)}},
////    new Company("IBM"){ Employees = new List<Person> {new Person("Tom", 42), new Person("Rodger", 39)}},
////    new Company("Google"){ Employees = new List<Person> {new Person("Sam", 24), new Person("Mike", 21), new Person("Bob", 24)} }
////};

////var companiesWithSam = from company in companies
////                       from employee in company.Employees
////                       group company by employee.Name;

////companiesWithSam.ToList().ForEach(c => Console.WriteLine($"Key: {c.Key}\nCompanies: {c.Aggregate("", (c1, c2) => $"{c1} {c2}")}\n"));

////var companiesByEmployees = companies.SelectMany(company => company.Employees, (comp, emp) => new { comp, emp })
////                                  .GroupBy(objKey => objKey.emp.Name, objVal => objVal.comp)
////                                  .ToList();

////companiesByEmployees.ForEach(c => Console.WriteLine($"Key: {c.Key}\n" +
////    $"Companies: {c.Aggregate("", (c1, c2) => $"{c1} {c2}")}\n"));
////Console.WriteLine();

////var companiesByEmployees54 = companies.SelectMany(company => company.Employees, (comp, emp) => new { comp, emp })
////                                  .Where(o => o.emp.Age >= 24)
////                                  .OrderByDescending(o => o.emp.Age)
////                                  .GroupBy(key => key.emp.Name, val => val.comp)
////                                  .ToList();

////companiesByEmployees54.ForEach(c => Console.WriteLine($"Key: {c.Key}\n" +
////    $"Companies: {c.Aggregate("", (c1, c2) => $"{c1} {c2}")}\n"));

////List<Country> countries = new List<Country>
////{
////    new Country("USA")
////    {
////        Companies = new List<Company>
////        {
////            new Company("Microsoft"){ Employees = new List<Person> {new Person("Tom", 42), new Person("Bob", 54)}},
////            new Company("Apple"){ Employees = new List<Person> {new Person("Linda", 24), new Person("Bob", 54), new Person("Sam", 25)}},
////            new Company("IBM"){ Employees = new List<Person> {new Person("Tom", 42), new Person("Rodger", 39)}},
////            new Company("Google"){ Employees = new List<Person> {new Person("Sam", 24), new Person("Mike", 21), new Person("Bob", 24)} }
////        }
////    },

////    new Country("England")
////    {
////        Companies = new List<Company>
////        {
////            new Company("Arsenal"){ Employees = new List<Person> {new Person("Lisa", 21), new Person("Rodger", 52)}},
////            new Company("United"){ Employees = new List<Person> {new Person("Osil", 27), new Person("Bob", 41), new Person("Samir", 27)}},
////            new Company("Fagry"){ Employees = new List<Person> {new Person("Tom", 39), new Person("Rodger", 21)}}
////        }
////    },

////    new Country("Spain")
////    {
////        Companies = new List<Company>
////        {
////            new Company("Barsa"){ Employees = new List<Person> {new Person("Olly", 28), new Person("Rodger", 30)}},
////            new Company("Real"){ Employees = new List<Person> {new Person("Bruno", 25), new Person("Bobula", 45), new Person("Jasmin", 27)}},
////            new Company("UFG"){ Employees = new List<Person> {new Person("Timon", 18), new Person("Girby", 51)}}
////        }
////    }
////};

////countries.ForEach(c => Console.WriteLine(c));
////Console.WriteLine();

////var selectedCountries = (from country in countries
////                        from company in country.Companies
////                        from employee in company.Employees
////                        where employee.Age > 30
////                        group country by employee.Name).ToList();

////selectedCountries.ForEach(c => Console.WriteLine($"Key: {c.Key}\nCountries:\n{c.Aggregate("", (res, curr) => $"{res} {curr?.ToString() ?? ""}")}"));
////Console.WriteLine();

////var selectedCountries1 = countries.SelectMany(c => c.Companies, (country, company) => new { country, company})
////                                  .SelectMany(e => e.company.Employees, (count, emp) => new {Country = count.country, Empl = emp })
////                                  .Where(o => o.Empl.Age > 30 && o.Empl.Name.StartsWith("B"))
////                                  .GroupBy(obj => obj.Empl.Name, obj => obj.Country)
////                                  .ToList();

////selectedCountries1.ForEach(c => Console.WriteLine($"Key: {c.Key}\nCountries:\n{c.Aggregate("", (res, curr) => $"{res} {curr?.ToString() ?? ""}")}"));
////Console.WriteLine();
//#endregion

//#region included requests
////Student[] students =
////{
////    new Student("Ali") {Course = new Course("Java"), Age = 21},
////    new Student("Linda") {Course = new Course("C#"), Age = 18},
////    new Student("John") {Course = new Course("C#"), Age = 19},
////    new Student("Lisa") {Course = new Course("Java"), Age = 22},
////    new Student("Gabi") {Course = new Course("CS"), Age = 20},
////    new Student("Ron") {Course = new Course("CS"), Age = 24}
////};

////var selectedStudents = (from student in students
////                       group student by student?.Course?.Name into grp
////                       select new
////                       {
////                           Name = grp.Key,
////                           Count = grp.Count(),
////                           Students = from s in grp select s
////                       }).ToList();

////selectedStudents.ForEach(s => Console.WriteLine($"Course name: {s.Name}; quantity: {s.Count}\n" +
////    $"{s.Students.Aggregate("", (res, next) => $"{res} {next}")}"));
////Console.WriteLine();

//////The same with methods
////var selectStudents1 = students.GroupBy(stud => stud?.Course?.Name)
////    .Select(grp => new
////    {
////        Name = grp.Key,
////        Count = grp.Count(),
////        Students = grp.Select(s => s)
////    })
////    .OrderBy(o => o.Name)
////    .ToList();

////selectStudents1.ForEach(s => Console.WriteLine($"Course name: {s.Name}; quantity: {s.Count}\n" +
////    $"{s.Students.Aggregate("", (res, next) => $"{res} {next}")}"));
////Console.WriteLine();
//#endregion

//#region join of collections (Join(), GroupJoin(), Zip())
////Student[] students =
////{
////    new Student("Ali") {Course = new Course("Java"), Age = 21},
////    new Student("Linda") {Course = new Course("C#"), Age = 18},
////    new Student("John") {Course = new Course("C#"), Age = 19},
////    new Student("Lisa") {Course = new Course("Java"), Age = 22},
////    new Student("Gabi") {Course = new Course("CS"), Age = 20},
////    new Student("John") {Course = new Course("CS"), Age = 24}
////};

////var employees = new List<Person>
////{
////    new Person("John", 32),
////    new Person("Bazz", 16),
////    new Person("Lisa", 25),
////    new Person("Linda", 20),
////    new Person("John", 27)
////};

////var people = (from student in students
////              join employee in employees on student.Name equals employee.Name
////              select new
////              {
////                  name = student.Name,
////                  course = student.Course,
////                  year = DateTime.Now.Year - employee.Age
////              }).ToList();

////people.ForEach(p => Console.WriteLine($"Name: {p?.name}; course: {p?.course}; year: {p?.year}"));
////Console.WriteLine();

////var people1 = students.Join(employees,
////    s => s.Name,
////    e => e.Name,
////    (stud, emp) => new
////    {
////        name = stud.Name,
////        course = stud.Course,
////        year = DateTime.Now.Year - emp.Age
////    })
////    .ToList();

////people1.ForEach(p => Console.WriteLine($"Name: {p?.name}; course: {p?.course}; year: {p?.year}"));
////Console.WriteLine();

////var people2 = students.GroupJoin(employees,
////                                s => s.Name,
////                                e => e.Name,
////                                (stud, emp) => new
////                                {
////                                    name = stud.Name,
////                                    course = stud.Course,
////                                    employees = emp.Where(o => o.Age < 30)
////                                })
////                                .ToList();

////people2.ForEach(p => Console.WriteLine($"Name: {p?.name}; course: {p?.course}\nemployees: {p?.employees.Aggregate("", (res, next) => $"{res} {next?.ToString()}")}"));
////Console.WriteLine();

////Student[] studentsWOCourse =
////{
////    new Student("Ali"),
////    new Student("Linda"),
////    new Student("John"),
////    new Student("Lisa"),
////    new Student("Gabi"),
////    new Student("John")
////};

////List<Course> courses = new List<Course>
////{
////     new Course("Java"),
////     new Course("C#"),
////     new Course("C#"),
////     new Course("Java"),
////     new Course("CS"),
////     new Course("CS")
////};

////var studentsWithCourses = studentsWOCourse.Zip(courses).ToList();

////studentsWithCourses.ForEach(s => Console.WriteLine(s));
//#endregion

//#region Check All(), Any(), Contains(), get elements (First(), Last(), ..OrDefault())
////using System.Diagnostics.CodeAnalysis;
////using System.Linq;

////Student[] students =
////{
////    new Student(null) {Course = new Course("Java"), Age = 21},
////    new Student("Linda") {Course = new Course("C#"), Age = 18},
////    new Student("John") {Course = new Course("C#"), Age = 19},
////    new Student("Lisa") {Course = new Course("Java"), Age = 22},
////    new Student("Gabi") {Course = new Course("CS"), Age = 20},
////    new Student("John") {Course = new Course("Delphi"), Age = 24}
////};

////Student[] studentsEmpty =
////{
////};

////Console.WriteLine($"All students start with A: {students.All(o => o?.Name?.ToLower().StartsWith("a") ?? false)}");
////Console.WriteLine($"Any student has course of C#: {students.Any(o => o?.Course?.Name?.ToLower() == "c#")}");
////Console.WriteLine($"Any student has course of Delphi: {students.Any(o => o?.Course?.Name?.ToLower() == "delphi")}");

////Console.WriteLine($"Student contain john 24 year old: {students?.Contains(new Student("john") { Age = 24} )}");
////Console.WriteLine($"Student contain jOhn 24 year old: {students?.Contains(new Student("jOhn") { Age = 24}, new CustomStudentComparer())}");

////Console.WriteLine($"First student: {students?.First()}");
////Console.WriteLine($"First student C#: {students?.First(s => s?.Course?.Name?.ToLower() == "c#")}");
////Console.WriteLine($"Last student C#: {students?.Last(s => s?.Course?.Name?.ToLower() == "c#")}");
//////There is Exception
//////Console.WriteLine($"First student in empty array: {studentsEmpty?.First()}");
//////Console.WriteLine($"First student C++: {students?.First(s => s?.Course?.Name?.ToLower() == "c++")}");
//////Console.WriteLine($"Last student in empty array: {studentsEmpty?.Last()}");
//////Console.WriteLine($"Last student C++: {students?.Last(s => s?.Course?.Name?.ToLower() == "c++")}");
////Console.WriteLine($"First or default student in empty array: {studentsEmpty?.FirstOrDefault()}");
////Console.WriteLine($"First or default student C++: {students?.FirstOrDefault(s => s?.Course?.Name?.ToLower() == "c++")}");
////Console.WriteLine($"Last or default student in empty array: {studentsEmpty?.LastOrDefault()}");
////Console.WriteLine($"Last or default student C++: {students?.LastOrDefault(s => s?.Course?.Name?.ToLower() == "c++")}");
////Console.WriteLine($"First or default student COBOL: {students?.FirstOrDefault(s => s?.Course?.Name?.ToLower() == "cobol", new Student("UndefStudent"))}");
//#endregion

//class Person
//{
//    public string Name { get; set; } = "UndefPerson";
//    public int? Age { get; set; }

//    public Person()
//    {
//    }

//    public Person(string name, int? age)
//    {
//        Name = name;
//        Age = age;
//    }

//    public override string? ToString()
//    {
//        return $"[Name: {Name}; age: {Age}]";
//    }

//    public override bool Equals(object? obj)
//    {
//        return obj is Person person &&
//               Name == person.Name;
//    }

//    public override int GetHashCode()
//    {
//        return HashCode.Combine(Name);
//    }
//}

//class Company
//{
//    public string Name { get; set; } = "UndefCompany";
//    public List<Person>? Employees { get; set; }

//    public Company(string name)
//    {
//        Name = name;
//    }

//    public override string? ToString()
//    {
//        return $"[Name: {Name}; employees: {Employees?.Aggregate("", (e1, e2) => $"{e1}{e2}")}]";
//    }
//}

//class Country
//{
//    public string Name { get; set; } = "UndefCountry";

//    public List<Company>? Companies { get; set; }

//    public Country(string name)
//    {
//        Name = name;
//    }

//    public override string? ToString()
//    {
//        return $"[Country name: {Name}; companies: {Companies?.Aggregate("", (res, curr) => $"{res} {curr?.ToString()}")}]";
//    }
//}

//class Student : Person
//{
//    public new string Name { get; set; } = "UndefStudent";
//    public Course? Course { get; set; }

//    public Student(string name)
//    {
//        Name = name;
//    }

//    public override string? ToString()
//    {
//        return $"[Name: {Name}; age: {Age}; course: {Course?.ToString()}]";
//    }

//    public override bool Equals(object? obj)
//    {
//        return obj is Student student &&
//               base.Equals(obj) &&
//               Age == student.Age &&
//               Name == student.Name;
//    }

//    public override int GetHashCode()
//    {
//        return HashCode.Combine(base.GetHashCode(), Name);
//    }
//}

//class Course
//{
//    public string Name { get; set; } = "UndefCourse";

//    public Course(string name)
//    {
//        Name = name;
//    }

//    public override string? ToString()
//    {
//        return $"[Course name: {Name}]";
//    }
//}

//class CustomPersonComparer : IComparer<Person>
//{
//    public int Compare(Person? x, Person? y)
//    {
//        int lengthNameX = x?.Name?.Length ?? 0;
//        int lengthNameY = y?.Name?.Length ?? 0;

//        return lengthNameX - lengthNameY;
//    }
//}

//class CustomStudentComparer : IEqualityComparer<Student>
//{
//    public bool Equals(Student? x, Student? y)
//    {
//        return x?.Name?.ToLower() == y?.Name.ToLower() && 
//               x?.Age == y?.Age;    
//    }

//    public int GetHashCode([DisallowNull] Student obj)
//    {
//        return obj?.Name?.ToLower().GetHashCode() ?? -1;
//    }
//}
