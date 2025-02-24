
using System.Data.Common;
using System.Diagnostics;

public class Hmm
{
    static async Task MakeCoffee()
    {
        Console.WriteLine("Making a coffee");
        await Task.Delay(2000);
        Console.WriteLine("Coffee is ready!");
    }

    static async Task BoilWater()
    {
        Console.WriteLine("Boiling Water");
        await Task.Delay(3000);
        Console.WriteLine("Boiled water");
    }

    static async Task Run(string[] args)
    {
        var sw = new Stopwatch();
        sw.Start();
        // await Task.WhenAll(MakeCoffee(), BoilWater());
        await MakeCoffee();
        await BoilWater();
        sw.Stop();
        Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds}");
    }
}