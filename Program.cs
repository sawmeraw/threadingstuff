using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Xml.XPath;

Func<string, string, string> AddString = (str1, str2) => str1 + str2;

Parallel.Invoke(() => Console.WriteLine("Hello"), () => Console.WriteLine("World"));
Console.WriteLine("Done");

static void ParallelInvoke(Action[] actions)
{
    if (actions.Length < 10)
    {
        var tasks = from action in actions select Task.Run(action);
        Task.WhenAll(tasks);
    }
    else
    {
        Parallel.ForEach(actions, action => action.Invoke());
    }

}

static void WriteToConsole<T>(IEnumerable<T> source, Action<T> action)
{
    foreach (var item in source)
    {
        action(item);
    }
}

void PrintMessage(string message1, string message2)
{
    Console.WriteLine(message1);
    Console.WriteLine(message2);
}

Action<string, string> printAction = PrintMessage;
printAction("hello", "world");

public delegate void PrintMessageDelegate(string message);

