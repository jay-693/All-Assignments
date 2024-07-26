class temp
{
    public static int a;

    public static void method(out int b)
    {

        Thread.Sleep(5000);
        b = 10;
        Console.WriteLine(b);
    }


    static void Main(string[] args)
    {
        Thread t = new Thread(() => method(out a));
        t.Start();
        Console.WriteLine(a);
        Console.WriteLine("--------");

    }
}