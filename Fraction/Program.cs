using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

public class Fraction
{
    public int Numerator;
    public int Denominator;

    public Fraction(int numerator, int dominator)
    {
        Numerator = numerator;
        Denominator = dominator;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
    public static Fraction operator + (Fraction a, Fraction b)
    {
        int numerator = a.Numerator*b.Denominator + b.Numerator*a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }
    public static Fraction operator -(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }
    public static Fraction operator *(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Numerator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }
    public static Fraction operator /(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Denominator;
        int denominator = a.Denominator * b.Numerator;
        return new Fraction(numerator, denominator);
    }

}

public class FractionConroller : Controller
{
    
    public void AddFirstFraction(int num, int dem, FractionModel fm)
    {
       fm.SetFirstFraction(num, dem);
    }
    public void AddSecondFraction(int num, int dem, FractionModel fm)
    {
        fm.SetSecondFraction(num, dem);
    }
    public void Calculate(FractionModel fm,string oper)
    {
        fm.Calculate(oper);
    }
}

public class FractionModel
{
    private Fraction _FirstFraction;
    private Fraction _SecondFraction;
    
    public void SetFirstFraction(int numerator, int dominator)
    {
        _FirstFraction.Numerator = numerator;
        _FirstFraction.Denominator = dominator;
    }
    public void SetSecondFraction(int numerator, int dominator)
    {
        _SecondFraction.Numerator = numerator;
        _SecondFraction.Denominator = dominator;
    }
    public Fraction Calculate(string operation)
    {
        if (_FirstFraction != null && _SecondFraction != null)
        {
            switch (operation)
            {
                case "+":
                    return _FirstFraction + _SecondFraction;
                    break;
                case "-":
                    return _FirstFraction - _SecondFraction;
                    break;
                case "*":
                    return _FirstFraction * _SecondFraction;
                    break;
                case "/":
                    return _FirstFraction / _SecondFraction;
                    break;
            }
        }
        return null;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        

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
                    
                    break;
                case "2":
                    
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