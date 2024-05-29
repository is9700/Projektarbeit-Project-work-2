using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<Task<string>> tasks = new List<Task<string>>();  // Eine Liste von Tasks erstellen, die eine Zeichenfolge zurückgeben
        int numTasks = 10;

        for (int i = 1; i <= numTasks; i++)//Eine Schleife durchlaufen, um Tasks zu erstellen und der Liste hinzuzufügen
        {
            int taskId = i;
            tasks.Add(Task.Run(async () => await MyCallable($"Task {taskId}", taskId * 100).ConfigureAwait(false)));   // Einen asynchronen Task starten und der Liste hinzufugen(Lambda)
        }

        Task.WhenAll(tasks).GetAwaiter().GetResult();   // Warten, bis alle Tasks abgeschlossen sind

        foreach (var task in tasks)//Output
        {
            Console.WriteLine(task.Result);
        }
    }

    static async Task<string> MyCallable(string taskName, int computationTime)//Eine asynchrone Methode definieren
    {
        Console.WriteLine($"Task {taskName} started by thread: {Environment.CurrentManagedThreadId}");
        await Task.Delay(computationTime);
        return $"Task {taskName} completed by thread: {Environment.CurrentManagedThreadId}";
    }

    
}
