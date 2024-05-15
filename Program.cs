﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<Task<string>> tasks = new List<Task<string>>();
        int numTasks = 10;

        for (int i = 1; i <= numTasks; i++)
        {
            int taskId = i;
            tasks.Add(Task.Run(async () => await MyCallable($"Task {taskId}", taskId * 100).ConfigureAwait(false)));
        }

        Task.WhenAll(tasks).GetAwaiter().GetResult();

        foreach (var task in tasks)
        {
            Console.WriteLine(task.Result);
        }
    }

    static async Task<string> MyCallable(string taskName, int computationTime)
    {
        Console.WriteLine($"Task {taskName} started by thread: {Environment.CurrentManagedThreadId}");
        await Task.Delay(computationTime);
        return $"Task {taskName} completed by thread: {Environment.CurrentManagedThreadId}";
    }

    
}