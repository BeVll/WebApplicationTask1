//using Newtonsoft.Json;

public interface IAnimalDisplay
{
    public void Show(Animal person);
}
public interface IAnimalSave
{
    public void SaveToFile(string fileName, Animal person);
}

public interface IAnimalService
{
    public void Save(Animal person);
    Animal[] Load();
}

public class AnimaService : IAnimalService
{
    private string _filePath;
    public AnimaService(string filePath)
    {
        _filePath = filePath;
    }

    public Animal[] Load()
    {
        List<Animal> animals = new List<Animal>();
        if (!File.Exists(_filePath))
        {
            return animals.ToArray();
        }
        using (StreamReader sr = new StreamReader(_filePath))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                var parts = line.Split(',');

                if (parts.Length != 4) continue;
                Animal animal = new Animal
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    DateOfBirthday = DateTime.Parse(parts[2]),
                    Sound = parts[3]
                };
                animals.Add(animal);
            }
        }
        return animals.ToArray();
    }

    public void Save(Animal person)
    {
        using (StreamWriter file = new StreamWriter(_filePath))
        {
            file.WriteLine($"{person.FirstName},{person.LastName},{person.DateOfBirthday},{person.Sound}");
        }
    }
}

public class AnimalDisplay : IAnimalDisplay
{
    public void Show(Animal person)
    {
        Console.WriteLine("Name: " + person.FirstName + " " + person.LastName);
        Console.WriteLine("Birhday: " + person.DateOfBirthday.ToLongDateString());
        Console.WriteLine("this animal say:  " + person.Sound);
    }
}
public class AnimalSave : IAnimalSave
{
    public void SaveToFile(string fileName, Animal person)
    {
        using (StreamWriter file = new StreamWriter(fileName))
        {
            file.WriteLine(person.FirstName + " " + person.LastName);
            file.WriteLine(person.DateOfBirthday.ToLongDateString());
            file.WriteLine(person.Sound);
        }
    }
}

public class AnimalController
{
    private readonly IAnimalService _personService;
    public AnimalController(IAnimalService personService)
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

        Animal person = new Animal
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirthday = dateOfBirthday,
            Sound = addInfo
        };
        _personService.Save(person);
    }
    public void ShowList()
    {
        var persons = _personService.Load();
        foreach (var person in persons)
        {
            new AnimalDisplay().Show(person);
        }
    }
}

public class Animal
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirthday { get; set; }
    public string Sound { get; set; }

    public Animal()
    {

    }

}

internal class Program
{
    static void Main(string[] args)
    {
        var filePath = @"C://personList.txt";
        AnimaService ps = new AnimaService(filePath);
        AnimalController personConroller = new AnimalController(ps);

        while (true)
        {
            Console.WriteLine("Choose an action");
            Console.WriteLine("1. Add animal");
            Console.WriteLine("2. Show all animals");
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
                    personConroller.ShowList();
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
