using System;

class A
{
    private int a;
    private int b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public double ComputeQuotient()
    {
        return b != 0 ? (double)a / b : double.NaN;
    }

    public double ComputeExpression()
    {
        return Math.Sqrt(Math.Pow(a, 3) + b);
    }

    public void DisplayValues()
    {
        Console.WriteLine($"a: {a}, b: {b}");
    }
}

class Program
{
    static void Main(string[] args)
    {

        A obj = new A(10, 5);

        obj.DisplayValues();
        double quotient = obj.ComputeQuotient();
        Console.WriteLine($"Частное a и b: {(quotient == double.NaN ? "Деление на ноль" : quotient.ToString())}");
        Console.WriteLine($"Значение выражения √(a^3 + b): {obj.ComputeExpression()}");
    }
}
