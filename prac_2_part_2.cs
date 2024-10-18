using System;
using System.Data;

public enum Operation
{
    Add,
    Subtract,
    Multiply,
    Divide,
    Power,
    SquareRoot
}

public class Calculator
{
    public static double DoOperation(Operation op, double a, double b = 0)
    {
        switch (op)
        {
            case Operation.Add:
                return a + b;
            case Operation.Subtract:
                return a - b;
            case Operation.Multiply:
                return a * b;
            case Operation.Divide:
                if (b == 0)
                    throw new DivideByZeroException("Деление на ноль невозможно.");
                return a / b;
            case Operation.Power:
                return Math.Pow(a, b);
            case Operation.SquareRoot:
                if (a < 0)
                    throw new ArgumentOutOfRangeException("Невозможно вычислить квадратный корень из отрицательного числа.");
                return Math.Sqrt(a);
            default:
                throw new ArgumentException("Неизвестная операция.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите 2 числа, которые хотите сложить: ");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Сложение: " + Calculator.DoOperation(Operation.Add, a, b));

        Console.WriteLine("Введите 2 числа, которые хотите вычесть: ");
        double c = Convert.ToDouble(Console.ReadLine());
        double d = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Вычитание: " + Calculator.DoOperation(Operation.Subtract, c, d));

        Console.WriteLine("Введите 2 числа, которые хотите умножить: ");
        double e = Convert.ToDouble(Console.ReadLine());
        double f = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Умножение: " + Calculator.DoOperation(Operation.Multiply, e, f));

        Console.WriteLine("Введите 2 числа, которые хотите разделить");
        double g = Convert.ToDouble(Console.ReadLine());
        double h = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Деление: " + Calculator.DoOperation(Operation.Divide, g, h));

        Console.WriteLine("Введите основание и показатель, чтобы вовзвести в степень: ");
        double i = Convert.ToDouble(Console.ReadLine());
        double j = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Возведение в степень: " + Calculator.DoOperation(Operation.Power, i, j));

        Console.WriteLine("Введите число, из которого вы хотите извлечь квадратный корень");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Квадратный корень: " + Calculator.DoOperation(Operation.SquareRoot, x));
    }
}

