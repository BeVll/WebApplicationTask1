//using Newtonsoft.Json;

public interface IFigureDisplay
{
    public void Show(Figure figure);
}
public interface IFigureSave
{
    public void SaveToFile(string fileName, Figure figure);
}

public interface IFigureService
{
    public void Save(Figure figure);
    Figure[] Load();
}

public class FigureService : IFigureService
{
    private string _filePath;
    public FigureService(string filePath)
    {
        _filePath = filePath;
    }

    public Figure[] Load()
    {
        List<Figure> animals = new List<Figure>();
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

                if (parts.Length != 3) continue;
                Figure animal = new Figure
                {
                    Name = parts[0],
                    CountAngle = parts[1],
                    Image = parts[2]
                };
                animals.Add(animal);
            }
        }
        return animals.ToArray();
    }

    public void Save(Figure person)
    {
        using (StreamWriter file = new StreamWriter(_filePath))
        {
            file.WriteLine($"{person.Name},{person.CountAngle},{person.Image}");
        }
    }
}

public class FigureDisplay : IFigureDisplay
{
    public void Show(Figure person)
    {
        Console.WriteLine("Name: " + person.Name);
        Console.WriteLine("Birhday: " + person.CountAngle);
        Console.WriteLine("Image" + person.Image);
    }
}
public class FigureSave : IFigureSave
{
    public void SaveToFile(string fileName, Figure person)
    {
        using (StreamWriter file = new StreamWriter(fileName))
        {
            file.WriteLine(person.Name);
            file.WriteLine(person.CountAngle);
            file.WriteLine(person.Image);
        }
    }
}

public class FigureController
{
    private readonly IFigureService _figureService;
    public FigureController(IFigureService personService)
    {
        _figureService = personService;
    }
    public void AddFigure()
    {
        Console.WriteLine("Enter name:");
        var firstName = Console.ReadLine();
        Console.WriteLine("Enter count angle:");
        var lastName = Console.ReadLine();
        Console.WriteLine("img:");
        var addInfo = Console.ReadLine();

        Figure person = new Figure
        {
            Name = firstName,
            CountAngle = lastName,
            Image = addInfo
        };
        _figureService.Save(person);
    }
    public void ShowList()
    {
        var persons = _figureService.Load();
        foreach (var person in persons)
        {
            new FigureDisplay().Show(person);
        }
    }
}

public class Figure
{
    public string Name { get; set; }
    public string CountAngle { get; set; }
    public string Image { get; set; }

    public Figure()
    {

    }

}

internal class Program
{
    static void Main(string[] args)
    {
        var filePath = @"C://personList.txt";
        FigureService ps = new FigureService(filePath);
        FigureController personConroller = new FigureController(ps);

        while (true)
        {
            Console.WriteLine("Choose an action");
            Console.WriteLine("1. Add figure");
            Console.WriteLine("2. Show all figures");
            Console.WriteLine("3. Exit");
            Console.Write("Select: ");
            var yourChoise = Console.ReadLine();

            switch (yourChoise)
            {
                case "1":
                    personConroller.AddFigure();
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
