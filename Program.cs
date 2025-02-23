using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class Restaurant
{
    public string MakeTea()
    {
        var water = BoilWater();
        Console.WriteLine("take the cups out.");
        Console.WriteLine("Put tea in the cups.");

        var tea = $"pour {water} in cups";
        return tea;
    }

    public string BoilWater()
    {
        Console.WriteLine("start the kettle");
        Console.WriteLine("Waiting for kettle");
        Task.Delay(2000).GetAwaiter().GetResult();
        Console.WriteLine("Kettle finished boiling");
        return "water";
    }
}


public class RestaurantAsync
{
    public async Task<string> MakeTeaAsync()
    {
        var boilingWater = BoilWaterAsync();
        Console.WriteLine("take the cups out.");
        Console.WriteLine("Put tea in the cups.");
        var water = await boilingWater;
        var tea = $"pour {water} in cups";
        return tea;
    }

    public async Task<string> BoilWaterAsync()
    {
        Console.WriteLine("start the kettle");
        Console.WriteLine("Waiting for kettle");
        await Task.Delay(2000);
        Console.WriteLine("Kettle finished boiling");
        return "water";
    }
}

public class ThreadingStuff
{
    static string[] files = { "file1.txt", "file2.txt", "file3.txt", "file4.txt", "file5.txt", "file6.txt" };
    static async Task<string> UploadFileAsync(string fileName)
    {
        Console.WriteLine($" Async Uploading {fileName}");
        await Task.Delay(2000);
        Console.WriteLine($"Finished Async uploading {fileName}");
        return fileName + "-uploaded";
    }

    static string UploadFilesThreaded(string fileName)
    {
        Console.WriteLine($"Uploading, {fileName}");
        Thread.Sleep(2000);
        Console.WriteLine($" Finished Uploading, {fileName}");
        return fileName + "-uploaded";
    }

    public static async Task Main()
    {

        List<Task<string>> tasks = new List<Task<string>>();
        foreach (var file in files)
        {
            tasks.Add(UploadFileAsync(file));
        }
        Console.WriteLine("--------");
        string[] urls = await Task.WhenAll(tasks);

        foreach (var url in urls)
        {
            Console.WriteLine($"Received URL: {url}");
            Console.WriteLine(url);
        }
    }

}