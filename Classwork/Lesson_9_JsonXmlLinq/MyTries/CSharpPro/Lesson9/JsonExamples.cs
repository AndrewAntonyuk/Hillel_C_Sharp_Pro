//using System.Text.Json;
//using System.Text.Json.Serialization;


//#region simple example
//Person tom = new Person("Tom", 37);
//string jsonTom = JsonSerializer.Serialize(tom);
//Console.WriteLine(jsonTom);

//Person? tomRestored = JsonSerializer.Deserialize<Person>(jsonTom);
//Console.WriteLine($"[Name: {tomRestored?.Name}; age: {tomRestored?.Age}]");
//#endregion

//#region file example
//string fileNamePerson = @"..\..\..\TestJson\person.json";
//string fileNameEmployee = @"..\..\..\TestJson\employee.json";
//string fileNameCompany = @"..\..\..\TestJson\company.json";

//Directory.CreateDirectory(Path.GetDirectoryName(fileNamePerson) ?? "");

//using (FileStream fs = new FileStream(fileNamePerson, FileMode.OpenOrCreate))
//{
//    var options = new JsonSerializerOptions
//    {
//        WriteIndented = true,
//        IgnoreReadOnlyFields = true,
//        DefaultIgnoreCondition = JsonIgnoreCondition.Never
//    };

//    Person adam = new Person("Adam", 28);
//    JsonSerializer.Serialize(fs, adam, options);
//    Console.WriteLine("Data has been created!");
//}

//using (FileStream fs = new FileStream(fileNamePerson, FileMode.OpenOrCreate))
//{
//    Person? adamRestored = JsonSerializer.Deserialize<Person>(fs);
//    Console.WriteLine(adamRestored?.ToString());
//}

//using (FileStream fs = new FileStream(fileNameEmployee, FileMode.OpenOrCreate))
//{
//    var options = new JsonSerializerOptions
//    {
//        WriteIndented = true,
//        IgnoreReadOnlyFields = false,
//        DefaultIgnoreCondition = JsonIgnoreCondition.Never
//    };

//    Employee adam = new Employee("Adam", null);
//    JsonSerializer.Serialize(fs, adam, options);
//    Console.WriteLine("Data has been created!");
//}

//using (FileStream fs = new FileStream(fileNameEmployee, FileMode.OpenOrCreate))
//{
//    Employee? adamRestored = JsonSerializer.Deserialize<Employee>(fs);
//    Console.WriteLine(adamRestored?.ToString());
//}

//using (FileStream fs = new FileStream(fileNameCompany, FileMode.OpenOrCreate))
//{
//    var options = new JsonSerializerOptions
//    {
//        WriteIndented = true,
//        IgnoreReadOnlyFields = false,
//        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
//    };

//    Company apple = new Company("Apple", "Electronic development")
//    {
//        Employees = new[] { new Employee("Stewe", 32),
//                            new Employee("Jhon", 25),
//                            new Employee("Rodger", 30)}.ToList()
//    };

//    JsonSerializer.Serialize(fs, apple, options);
//    Console.WriteLine("Data has been created!");
//}

//using (FileStream fs = new FileStream(fileNameCompany, FileMode.OpenOrCreate))
//{
//    Company? appleRestored = JsonSerializer.Deserialize<Company>(fs);
//    Console.WriteLine(appleRestored?.ToString());
//}
//#endregion

//record Person(string Name, int Age)
//{
//    public override string? ToString()
//    {
//        return $"[Name: {Name}; age: {Age}]";
//    }
//}

//class Employee
//{
//    [JsonPropertyName("TestName")]
//    public string? Name { get; }
//    //[JsonIgnore]
//    public int? Age { get; set; }

//    public Employee(string? name, int? age)
//    {
//        Name = name;
//        Age = age;
//    }

//    public override string? ToString()
//    {
//        return $"[Name: {Name}; age: {Age}]";
//    }
//}

//class Company
//{
//    [JsonPropertyName("company")]
//    public string? Name { get; }
//    public string? Type { get; set; }

//    [JsonPropertyName("employees")]
//    public List<Employee>? Employees { get; set; }

//    public Company(string? name, string? type)
//    {
//        Name = name;
//        Type = type;
//    }

//    public override string? ToString()
//    {
//        return $"[Name: {Name}; type: {Type}; employees:\n{Employees?.Aggregate("", (e1, e2) => e1 + e2)}]";
//    }
//}