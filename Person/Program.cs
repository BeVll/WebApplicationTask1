using Newtonsoft.Json;

public interface IPersonDisplay
{
    public void Show(Person person);
}
public interface IPersonSave
{
    public void SaveToFile(string fileName, Person person);
}

public interface IPersonService
{
    public void SavePerson(Person person);
    Person[] LoadPerson();
}

public class PersonService : IPersonService
{
    private string _filePath;
    public PersonService(string filePath)
    {
        _filePath = filePath;
    }

    public Person[] LoadPerson()
    {
        List<Person> persons = new List<Person>();
        if (!File.Exists(_filePath))
        {
            return persons.ToArray();
        }
        using (StreamReader sr = new StreamReader(_filePath))
        {
            while (!sr.EndOfStream) {
                string line = sr.ReadLine();
                var parts = line.Split(',');

                if (parts.Length != 4) continue;
                Person person = new Person
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    DateOfBirthday = DateTime.Parse(parts[2]),
                    AddInformation = parts[3]
                };
                persons.Add(person); 
            }
        }
        return persons.ToArray();
    }

    public void SavePerson(Person person)
    {
        using (StreamWriter file = new StreamWriter(_filePath))
        {
            file.WriteLine($"{person.FirstName},{person.LastName},{person.DateOfBirthday},{person.AddInformation}");
        }
    }
}

public class PersonDisplay : IPersonDisplay
{
    public void Show(Person person)
    {
        Console.WriteLine("FIO: " + person.FirstName + " " + person.LastName);
        Console.WriteLine("Birhday: " + person.DateOfBirthday.ToLongDateString());
        Console.WriteLine("Add Info: " + person.AddInformation);
    }
}
public class PersonSave : IPersonSave
{
    public void SaveToFile(string fileName, Person person)
    {
        using (StreamWriter file = new StreamWriter(fileName))
        {
            file.WriteLine(person.FirstName + " " + person.LastName);
            file.WriteLine(person.DateOfBirthday.ToLongDateString());
            file.WriteLine(person.AddInformation);
        }
    }
}

public class PersonConroller
{
    private readonly IPersonService _personService;
    public PersonConroller(IPersonService personService)
    {
        _personService = personService;
    }
    public void AddPerson()
    {
        Console.WriteLine("Enter firstname:");
        var firstName = Console.ReadLine();
        Console.WriteLine("Enter lastname:");
        var lastName = Console.ReadLine();
        Console.WriteLine("Enter date of birthday:");
        var dateOfBirthday = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter Add information:");
        var addInfo = Console.ReadLine();

        Person person = new Person
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirthday = dateOfBirthday,
            AddInformation = addInfo
        };
        _personService.SavePerson(person);
    }
    public void ListPersons()
    {
        var persons = _personService.LoadPerson();
        foreach(var person in persons)
        {
            new PersonDisplay().Show(person);
        }
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirthday { get; set; }
    public string AddInformation { get; set; }
    
    public Person()
    {

    }
    
}

internal class Program
{
    static void Main(string[] args)
    {
        var filePath = @"C://personList.txt";
        PersonService ps = new PersonService(filePath);
        PersonConroller personConroller = new PersonConroller(ps);

        while (true)
        {
            Console.WriteLine("Choose an action");
            Console.WriteLine("1. AddPerson");
            Console.WriteLine("2. Show all persons");
            Console.WriteLine("3. Exit");
            Console.Write("Select: ");
            var yourChoise = Console.ReadLine();

            switch (yourChoise)
            {
                case "1":
                    personConroller.AddPerson();
                    break;
                case "2":
                    Console.Clear();
                    personConroller.ListPersons();
                    break;
                case "3":
                    return;
                default:
                    Console.Write("Try again");
                    break;

            }
            
            Console.Write("\nEnter key for continue");
            Console.ReadKey();
            Console.Clear();
        }
       
    }
}
