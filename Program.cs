using System;
using System.Threading.Tasks;
using System.Linq;

class Program
{
    static async Task Main()
    {
        int numTasks = 10;  // Anzahl der Tasks 

        var tasks = Enumerable.Range(1, numTasks)        // Eine Sequenz von Tasks erstellen, die eine Verzogerung hat(100ms)

                               .Select(taskId => MyCallableAsync(taskId))
                               .ToArray();

        await Task.WhenAll(tasks);  // auf  Alle Tasks warten, bis sie abgeschlossen sind
    }
    // Asynchrone Methode, die einen Task mit einer Verzogerung erstel
    static async Task MyCallableAsync(int taskId)
    {
        Console.WriteLine($"Task {taskId} started by thread: {Environment.CurrentManagedThreadId}");
        await Task.Delay(100);
        Console.WriteLine($"Task {taskId} completed by thread: {Environment.CurrentManagedThreadId}");
    }
}



/*

using System;
using System.Threading.Tasks;

class Program
{

    static async Task Main()
    {
        int numTasks = 10;
        var tasks = new Task[numTasks];

        for (int i = 0; i < numTasks; i++)
        {
            int taskId = i + 1;
            tasks[i] = MyCallableAsync(taskId); // Eine asynchrone Methode aufrufen und den resultierenden Task dem Array hinzufugen
        }

        await Task.WhenAll(tasks);
    }

    static async Task MyCallableAsync(int taskId)
    {
        Console.WriteLine($"Task {taskId} started by thread: {Environment.CurrentManagedThreadId}");
        await Task.Delay(100);
        Console.WriteLine($"Task {taskId} completed by thread: {Environment.CurrentManagedThreadId}");
    }
    
}
*/
