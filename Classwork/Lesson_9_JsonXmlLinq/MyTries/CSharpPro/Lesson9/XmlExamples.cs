//#region base actions with System.Xml
////using System.Xml;

////string fileNameStudent = @"../../../TestXml/students.xml";
////string fileNameStarWars = @"../../../TestXml/starwars.xml";
////Directory.CreateDirectory(Path.GetDirectoryName(fileNameStudent) ?? "");

//#region create base xml for reading in first examples
////XmlDocument doc = new XmlDocument();
////XmlNode xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
////XmlElement root = doc.CreateElement("students");

////XmlElement adam = doc.CreateElement("student");
////XmlAttribute adamName = doc.CreateAttribute("name");
////XmlElement adamAge = doc.CreateElement("age");
////XmlElement adamCourse = doc.CreateElement("course");

////XmlText adamNameText = doc.CreateTextNode("Adam");
////XmlText adamAgeTxt = doc.CreateTextNode("18");
////XmlText adamCourseTxt = doc.CreateTextNode("C# language");

////adamName.AppendChild(adamNameText);
////adamAge.AppendChild(adamAgeTxt);
////adamCourse.AppendChild(adamCourseTxt);

////adam.Attributes.Append(adamName);
////adam.AppendChild(adamAge);
////adam.AppendChild(adamCourse);

////XmlElement rick = doc.CreateElement("student");
////XmlAttribute rickName = doc.CreateAttribute("name");
////XmlElement rickAge = doc.CreateElement("age");
////XmlElement rickCourse = doc.CreateElement("course");

////XmlText rickNameText = doc.CreateTextNode("Rick");
////XmlText rickAgeTxt = doc.CreateTextNode("19");
////XmlText rickCourseTxt = doc.CreateTextNode("Java language");

////rickName.AppendChild(rickNameText);
////rickAge.AppendChild(rickAgeTxt);
////rickCourse.AppendChild(rickCourseTxt);

////rick.Attributes.Append(rickName);
////rick.AppendChild(rickAge);
////rick.AppendChild(rickCourse);

////XmlElement bill = doc.CreateElement("student");
////XmlAttribute billName = doc.CreateAttribute("name");
////XmlElement billAge = doc.CreateElement("age");
////XmlElement billCourse = doc.CreateElement("course");

////XmlText billNameText = doc.CreateTextNode("Bill");
////XmlText billAgeTxt = doc.CreateTextNode("18");
////XmlText billCourseTxt = doc.CreateTextNode("Java language");

////billName.AppendChild(billNameText);
////billAge.AppendChild(billAgeTxt);
////billCourse.AppendChild(billCourseTxt);

////bill.Attributes.Append(billName);
////bill.AppendChild(billAge);
////bill.AppendChild(billCourse);

////root.AppendChild(adam);
////root.AppendChild(rick);
////root.AppendChild(bill);

////doc.AppendChild(xmlDeclaration);
////doc.AppendChild(root);

////doc.Save(fileNameStudent);
//#endregion

//#region base actions
////XmlDocument xmlDocument = new XmlDocument();
////xmlDocument.Load(fileNameStudent);

////XmlElement? root = xmlDocument.DocumentElement;
////List<Student> students = new List<Student>();

////if (root != null)
////{
////    Console.WriteLine("Data about students dirrectly from Xml-nodes:");
////    foreach (XmlNode node in root.ChildNodes)
////    {
////        XmlNode? attr = node?.Attributes?.GetNamedItem("name");
////        Console.WriteLine("Name: " + attr?.Value);

////        Student student = new Student();
////        student.Name = attr?.Value;

////        foreach (XmlNode chNode in node.ChildNodes)
////        {
////            if (chNode.Name == "age")
////            {
////                Console.WriteLine($"Age: {chNode.InnerText}");
////                student.Age = int.Parse(chNode.InnerText);
////            }

////            if (chNode.Name == "course")
////            {
////                Console.WriteLine($"Course: {chNode.InnerText}");
////                student.Course = chNode.InnerText;
////            }
////        }
////        students.Add(student);
////        Console.WriteLine();
////    }
////}

////Console.WriteLine("Data about students from objects (data read from Xml to objects):");
////students.ForEach(stud => Console.WriteLine(stud));

//////Append new student
////XmlDocument xDoc = new XmlDocument();
////xDoc.Load(fileNameStudent);
////XmlElement? xRoot = xDoc.DocumentElement;
////XmlNode? xFirstNode = xRoot?.FirstChild;
////XmlComment xComment = xDoc.CreateComment("All students");
////xDoc.InsertBefore(xComment, xRoot);

////XmlNode nicole = xDoc.CreateNode(XmlNodeType.Element, "student", null);
////XmlAttribute nicoleName = xDoc.CreateAttribute("name");
////XmlElement nicoleAge = xDoc.CreateElement("age");
////XmlNode nicoleCourse = xDoc.CreateNode(XmlNodeType.Element, "course", null);

////XmlText? nicoleNameText = xDoc.CreateTextNode("Nicole");
////nicoleName?.AppendChild(nicoleNameText);

////nicoleAge.InnerText = "27";
////nicoleCourse.InnerText = "C#";

////nicole?.Attributes?.Append(nicoleName);
////nicole?.AppendChild(nicoleAge);
////nicole?.AppendChild(nicoleCourse);

////xRoot?.InsertBefore(nicole, xFirstNode);
////xDoc.AppendChild(xRoot);
////xDoc.Save(fileNameStudent);
//#endregion

//#region create Xml doc
////XmlDocument xDoc = new XmlDocument();
////XmlNode xHeader = xDoc.CreateNode(XmlNodeType.Comment, "Star wars", null);
////xHeader.Value = fileNameStudent;

////xDoc.AppendChild(xDoc.CreateXmlDeclaration("1.0", "UTF-8", null));
////xDoc.AppendChild(xHeader);

////XmlElement xRoot = xDoc.CreateElement("command");

////XmlNode xAnakin = xDoc.CreateNode(XmlNodeType.Element, "persone", null);
////XmlNode xAnakinName = xDoc.CreateNode(XmlNodeType.Attribute, "name", null);
////XmlNode xAnakinAge = xDoc.CreateNode(XmlNodeType.Element, "age", null);
////XmlNode xAnakinPosition = xDoc.CreateNode(XmlNodeType.Element, "position", null);
////XmlNode xAnakinEnemy = xDoc.CreateNode(XmlNodeType.Element, "enemy", null);

////xAnakinName.Value = "Anakin";
////xAnakinAge.InnerText = "25";
////xAnakinPosition.InnerText = "Dark";
////xAnakinEnemy.InnerText = "Luke";

////xAnakin?.Attributes?.Append((XmlAttribute)xAnakinName);
////xAnakin?.AppendChild(xAnakinAge);
////xAnakin?.AppendChild(xAnakinPosition);
////xAnakin?.AppendChild(xAnakinEnemy);

////XmlNode xSky = xDoc.CreateNode(XmlNodeType.Element, "persone", null);
////XmlAttribute xSkyName = xDoc.CreateAttribute("name");
////XmlElement xSkyAge = xDoc.CreateElement("age");
////XmlNode xSkyPosition = xDoc.CreateNode(XmlNodeType.Element, "position", null);
////XmlNode xSkyEnemy = xDoc.CreateNode(XmlNodeType.Element, "enemy", null);

////XmlText xSkyNameText = xDoc.CreateTextNode("Sky");
////XmlText xSkyAgeText = xDoc.CreateTextNode("125");
////XmlText xSkyPositionText = xDoc.CreateTextNode("Green");
////XmlText xSkyEnemyText = xDoc.CreateTextNode("Alf");

////xSkyName.AppendChild(xSkyNameText);
////xSkyAge.AppendChild(xSkyAgeText);
////xSkyPosition.AppendChild(xSkyPositionText);
////xSkyEnemy.AppendChild(xSkyEnemyText);

////xSky?.Attributes?.Append(xSkyName);
////xSky?.AppendChild(xSkyAge);
////xSky?.AppendChild(xSkyPosition);
////xSky?.AppendChild(xSkyEnemy);

////XmlNode xWalker = xDoc.CreateNode(XmlNodeType.Element, "persone", null);
////XmlAttribute xWalkerName = xDoc.CreateAttribute("name");
////XmlElement xWalkerAge = xDoc.CreateElement("age");
////XmlNode xWalkerPosition = xDoc.CreateNode(XmlNodeType.Element, "position", null);
////XmlNode xWalkerEnemy = xDoc.CreateNode(XmlNodeType.Element, "enemy", null);

////XmlText xWalkerNameText = xDoc.CreateTextNode("Walker");
////XmlText xWalkerAgeText = xDoc.CreateTextNode("5");
////XmlText xWalkerPositionText = xDoc.CreateTextNode("Soft");
////XmlText xWalkerEnemyText = xDoc.CreateTextNode("Archer");

////xWalkerName.AppendChild(xWalkerNameText);
////xWalkerAge.AppendChild(xWalkerAgeText);
////xWalkerPosition.AppendChild(xWalkerPositionText);
////xWalkerEnemy.AppendChild(xWalkerEnemyText);

////xWalker?.Attributes?.Append(xWalkerName);
////xWalker?.AppendChild(xWalkerAge);
////xWalker?.AppendChild(xWalkerPosition);
////xWalker?.AppendChild(xWalkerEnemy);

////xRoot?.AppendChild(xAnakin);
////xRoot?.AppendChild(xSky);
////xRoot?.AppendChild(xWalker);

////xDoc?.AppendChild(xRoot);
////xDoc.Save(fileNameStarWars);
//#endregion

//#region delete element
////XmlDocument xmlDocument = new XmlDocument();
////xmlDocument.Load(fileNameStarWars);

////XmlElement xRootElement = xmlDocument.DocumentElement;
////XmlNode xFirstNode = xRootElement?.FirstChild;

////if (xFirstNode != null) xRootElement.RemoveChild(xFirstNode);

////xmlDocument.Save(fileNameStarWars);
//#endregion

//#region XPath tryies
////XmlDocument xmlDoc = new XmlDocument();
////xmlDoc.Load(fileNameStudent);

////XmlElement? xRoot = xmlDoc.DocumentElement;

////XmlNodeList? xAllNodes = xRoot?.SelectNodes("*");
////if (xAllNodes != null)
////{
////    Console.WriteLine("All nodes in Xml:");
////    foreach (XmlNode xmlNode in xAllNodes)
////    {
////        Console.WriteLine(xmlNode.OuterXml);
////    }
////    Console.WriteLine();
////}

////XmlNodeList? xStudentNodes = xRoot?.SelectNodes("student");
////if (xStudentNodes != null)
////{
////    Console.WriteLine("Student nodes in Xml:");
////    foreach (XmlNode xmlNode in xStudentNodes)
////    {
////        Console.WriteLine("Name: " + xmlNode.SelectSingleNode("@name")?.Value);
////        Console.WriteLine("Age: " + xmlNode.SelectSingleNode("age")?.InnerText);
////    }
////    Console.WriteLine();
////}

////XmlNodeList? xCSharpNodes = xRoot?.SelectNodes("student[course = 'C# language']");
////if (xCSharpNodes != null)
////{
////    Console.WriteLine("Students of C# course in Xml:");
////    foreach (XmlNode xmlNode in xCSharpNodes)
////    {
////        Console.WriteLine("Name: " + xmlNode.SelectSingleNode("@name")?.Value);
////        Console.WriteLine("Course: " + xmlNode.SelectSingleNode("course")?.InnerText);
////    }
////    Console.WriteLine();
////}

////XmlNodeList? xLangNodes = xRoot?.SelectNodes("//student/course");
////if (xLangNodes != null)
////{
////    Console.WriteLine("Courses in Xml:");
////    foreach (XmlNode xmlNode in xLangNodes)
////    {
////        Console.WriteLine("Course: " + xmlNode.InnerText);
////    }
////    Console.WriteLine();
////}
//#endregion 
//#endregion

//#region LINQ to XML

////using System.Xml.Linq;

////string fileNameCars = @"../../../TestXml/cars.xml";
////string fileNameStudent = @"../../../TestXml/students.xml";
////Directory.CreateDirectory(Path.GetDirectoryName(fileNameCars) ?? "");

//#region Create file v1
////XDocument xDocument = new XDocument();
////XComment xComment = new XComment("All cars in the park");
////XElement xRoot = new XElement("cars");

////XElement ferrari = new XElement("car");
////XAttribute ferrariName = new XAttribute("name", "Ferrari");
////XElement ferrariMaxSpeed = new XElement("maxspeed", "350.0");
////XElement ferrariType = new XElement("type", "Sportcar");

////ferrari.Add(ferrariName);
////ferrari.Add(ferrariMaxSpeed);
////ferrari.Add(ferrariType);

////XElement bugatti = new XElement("car");
////XAttribute bugattiName = new XAttribute("name", "Bugatti GTX 354");
////XElement bugattiMaxSpeed = new XElement("maxspeed", "431.5");
////XElement bugattiType = new XElement("type", "Sportcar");

////bugatti.Add(bugattiName);
////bugatti.Add(bugattiMaxSpeed);
////bugatti.Add(bugattiType);

////XElement bmw = new XElement("car");
////XAttribute bmwName = new XAttribute("name", "BMW");
////XElement bmwMaxSpeed = new XElement("maxspeed", "180.25");
////XElement bmwType = new XElement("type", "Crossover");

////bmw.Add(bmwName);
////bmw.Add(bmwMaxSpeed);
////bmw.Add(bmwType);

////xDocument.Add(xComment);

////xRoot.Add(ferrari);
////xRoot.Add(bugatti);
////xRoot.Add(bmw);

////xDocument.Add(xRoot);
////xDocument.Save(fileNameCars);
//#endregion

//#region create file v2
////XDocument xDocument = new XDocument(new XElement("cars", 
////    new XElement("car", 
////        new XAttribute("name", "Ferrari"),
////        new XElement("maxspeed", "350.0"),
////        new XElement("type", "Sportcar")),
////    new XElement("car",
////        new XAttribute("name", "Buggatti GTX 751"),
////        new XElement("maxspeed", "451.25"),
////        new XElement("type", "Sportcar")),
////    new XElement("car",
////        new XAttribute("name", "BMW X7"),
////        new XElement("maxspeed", "180.5"),
////        new XElement("type", "Crossover"))));

////xDocument.Save(fileNameCars);
//#endregion

//#region filter of elements v1
////XDocument xDocument = XDocument.Load(fileNameCars);

////XElement? xRoot = xDocument.Root;

////if(xRoot != null)
////{
////    foreach(XElement xElement in xRoot.Elements())
////    {
////        XAttribute? xAttrName = xElement.Attribute("name");
////        XElement? xElementMaxSpeed = xElement.Element("maxspeed");
////        XElement? xElementType = xElement.Element("type");

////        Console.WriteLine($"Name: {xAttrName?.Value}");
////        Console.WriteLine($"Max. speed: {xElementMaxSpeed?.Value}");
////        Console.WriteLine($"Type of car: {xElementType?.Value}");

////        Console.WriteLine();
////    }
////}
//#endregion

//#region filter of elements v2
////XDocument xDocument = XDocument.Load(fileNameCars);

////XElement? xRoot = xDocument.Element("cars");

////if (xRoot != null)
////{
////    foreach (XElement xElement in xRoot.Elements())
////    {
////        XAttribute? xAttrName = xElement.Attribute("name");
////        XElement? xElementMaxSpeed = xElement.Element("maxspeed");
////        XElement? xElementType = xElement.Element("type");

////        Console.WriteLine($"Name: {xAttrName?.Value}");
////        Console.WriteLine($"Max. speed: {xElementMaxSpeed?.Value}");
////        Console.WriteLine($"Type of car: {xElementType?.Value}");

////        Console.WriteLine();
////    }
////}
//#endregion

//#region filter of elements v3
////XDocument xDocument = XDocument.Load(fileNameStudent);

////var studentsJava = xDocument.Element("students")?
////    .Elements("student")
////    .Where(s => s.Element("course")?.Value == "Java language")
////    .Select(s => new
////    {
////        name = s.Attribute("name")?.Value,
////        age = s.Element("age")?.Value,
////        course = s.Element("course")?.Value
////    });

////if (studentsJava != null)
////{
////    Console.WriteLine("Students of Java language:");
////    studentsJava.ToList().ForEach(s => Console.WriteLine($"[Name: {s?.name}; age: {s?.age}; course: {s?.course}]"));
////    Console.WriteLine();
////}

////var studentsOlder = xDocument.Element("students")?
////    .Elements("student")
////    .Where(s => int.Parse(s.Element("age")?.Value ?? "0") > 18)
////    .Select(s => new
////    {
////        name = s.Attribute("name")?.Value,
////        age = s.Element("age")?.Value,
////        course = s.Element("course")?.Value
////    });

////if (studentsOlder != null)
////{
////    Console.WriteLine("Students older than 18:");
////    studentsOlder.ToList().ForEach(s => Console.WriteLine($"[Name: {s?.name}; age: {s?.age}; course: {s?.course}]"));
////    Console.WriteLine();
////}

////var nicole = xDocument.Element("students")?
////    .Elements("student")
////    .FirstOrDefault(s => s?.Attribute("name")?.Value == "Nicole");

////if(nicole != null)
////{
////    Console.WriteLine("Student witn name Nicole:");
////    Console.WriteLine($"[Name: {nicole.Attribute("name")?.Value}; age: {nicole.Element("age")?.Value}; course: {nicole.Element("course")?.Value}]");
////    Console.WriteLine();}
//#endregion

//#region add elements to file
////XDocument? xDocument = XDocument.Load(fileNameCars);

////XElement? xRoot = xDocument?.Root;
////if (xRoot != null)
////{
////    xRoot.Add(new XElement("car",
////                    new XAttribute("name", "Lada"),
////                    new XElement("maxspeed", "120.5"),
////                    new XElement("type", "Blackhorse")));

////    xDocument?.Save(fileNameCars);
////}

////Console.WriteLine(xDocument?.ToString());
//#endregion

//#region change element in file
////XDocument? xDocument = XDocument.Load(fileNameCars);

////XElement? xLada = xDocument?.Root?
////                            .Elements("car")?
////                            .FirstOrDefault(c => c.Attribute("name")?.Value == "Lada");
////if (xLada != null)
////{
////    xLada.Attribute("name")?.SetValue("Lada XXX");
////    xLada.Element("maxspeed")?.SetValue("175.5");

////    var typeElement = xLada.Element("type");
////    if (typeElement != null) typeElement.Value = "Offroad";

////    xDocument?.Save(fileNameCars);
////}

////Console.WriteLine(xDocument?.ToString());
//#endregion

//#region change element in file
////XDocument? xDocument = XDocument.Load(fileNameCars);

////XElement? xLada = xDocument?.Element("cars")?
////                            .Elements("car")?
////                            .FirstOrDefault(c => c.Attribute("name")?.Value == "Lada XXX");
////if (xLada != null)
////{
////    xLada.Remove();
////    xDocument?.Save(fileNameCars);
////}

////Console.WriteLine(xDocument?.ToString());
//#endregion
//#endregion

//#region serialization Xml System.Xml.Serialization

//using System.Collections.ObjectModel;
//using System.Xml.Serialization;

//string fileNameCars = @"../../../TestXml/cars.xml";
//string fileNameStudent = @"../../../TestXml/studentsSer.xml";
//string fileNameEmployee = @"../../../TestXml/employee.xml";
//Directory.CreateDirectory(Path.GetDirectoryName(fileNameCars) ?? "");

//#region base serialization
////Student jeck = new Student("Jack", 21, "C# language");
////XmlSerializer serializer = new XmlSerializer(typeof(Student));

////serializer.Serialize(Console.Out, jeck);
//#endregion

//#region file serialize/deserialize simple objects
////Student jack = new Student("Jack", 21, "C# language");
////XmlSerializer serializer = new XmlSerializer(typeof(Student));

////using (FileStream fs = new FileStream(fileNameStudent, FileMode.OpenOrCreate))
////{
////    serializer.Serialize(fs, jack);
////    Console.WriteLine("Data has been serialized");
////}

////using (FileStream fs = new FileStream(fileNameStudent, FileMode.OpenOrCreate))
////{
////    Student? jackRestored = serializer.Deserialize(fs) as Student;
////    Console.WriteLine("Restored student");
////    Console.WriteLine(jackRestored);
////}
//#endregion

//#region file serialize/deserialize collections
////List<Student> students = new List<Student>() { new Student("Jack", 21, "C# language"),
////                                               new Student("Linda", 18, "Java language"),
////                                               new Student("Nicole", 19, "Java language"),
////                                               new Student("Marshal", 25, "C# language"),
////                                               new Student("Colonel", 18, "C# language")};

////XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

////using (FileStream fs = new FileStream(fileNameStudent, FileMode.OpenOrCreate))
////{
////    serializer.Serialize(fs, students);
////    Console.WriteLine("Data has been serialized");
////}

////using (FileStream fs = new FileStream(fileNameStudent, FileMode.OpenOrCreate))
////{
////    List<Student>? studentsRestored = serializer.Deserialize(fs) as List<Student>;
////    Console.WriteLine("Restored students:");
////    studentsRestored?.ForEach(student => Console.WriteLine(student));
////}
//#endregion

//#region file serialize/deserialize included collections
////Company microsoft = new Company("Microsoft", "Software development");
////Company apple = new Company("Apple", "Software development");

////List<Employee> employees = new List<Employee>() { new Employee("Jack", 41, "C# Developer"){ Company = microsoft},
////                                                  new Employee("Linda", 18, "Java Developer"){ Company = microsoft},
////                                                  new Employee("Nicole", 19, "Java Developer"){ Company = apple},
////                                                  new Employee("Marshal", 25, "C# Developer") { Company = microsoft },
////                                                  new Employee("Colonel", 35, "C# Developer") { Company = apple }};
 
////XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));

////using (FileStream fs = new FileStream(fileNameEmployee, FileMode.OpenOrCreate))
////{
////    serializer.Serialize(fs, employees);
////    Console.WriteLine("Data has been serialized");
////}

////List<Employee>? employeesRestored;
////using (FileStream fs = new FileStream(fileNameEmployee, FileMode.OpenOrCreate))
////{
////     employeesRestored = serializer.Deserialize(fs) as List<Employee>;
////    Console.WriteLine("Restored employees:");
////    employeesRestored?.ForEach(employee => Console.WriteLine(employee));
////}

////Console.WriteLine();

////Console.WriteLine("Employees from Microsoft:");
////employeesRestored?.Where(employee => employee?.Company?.Name == "Microsoft")?
////                   .ToList()?
////                   .ForEach(e => Console.WriteLine(e));

////Console.WriteLine();

////Console.WriteLine("Employees older than 18:");
////var employeesOlder18 = from e in employeesRestored
////                       where e?.Age > 18
////                       orderby e?.Name
////                       select e;

////employeesOlder18.ToList()
////    .ForEach(e => Console.WriteLine(e));
//#endregion
//#endregion

//public class Student
//{
//    public string? Name { get; set; }
//    public int? Age { get; set; }
//    public string? Course { get; set; }

//    public Student()
//    {
//    }

//    public Student(string? name, int? age, string? course)
//    {
//        Name = name;
//        Age = age;
//        Course = course;
//    }

//    public override string ToString()
//    {
//        return $"[Name: {Name}; age: {Age}; course: {Course}]";
//    }
//}

//public class Employee
//{
//    public string Name { get; set; } = "Undef name";
//    public int? Age { get; set;}
//    public string? Position { get; set; }
//    public Company? Company { get; set; }

//    public Employee()
//    {
//    }
//    public Employee(string name, int? age, string? position)
//    {
//        Name = name;
//        Age = age;
//        Position = position;
//    }

//    public override string? ToString()
//    {
//        return $"[Name: {Name}; age: {Age}; position: {Position}; company: {Company?.ToString()}]";
//    }
//}

//public class Company
//{
//    public string Name { get; set; } = "Undef company";
//    public string? Description { get; set; }

//    public Company() { }

//    public Company(string name, string? description)
//    {
//        Name = name;
//        Description = description;
//    }

//    public override string? ToString()
//    {
//        return $"[Name: {Name}; description: {Description}]";
//    }
//}