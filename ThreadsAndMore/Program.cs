// See https://aka.ms/new-console-template for more information
using ThreadsAndMore.Invoker;
using AutoResetEvent = ThreadsAndMore.Invoker.AutoResetEvent;
using ManualResetEvent = ThreadsAndMore.Invoker.ManualResetEvent;
using Monitor = ThreadsAndMore.Invoker.Monitor;
using Mutex = ThreadsAndMore.Invoker.Mutex;
using Semaphore = ThreadsAndMore.Invoker.Semaphore;

//Read an input from the user
Console.WriteLine("Enter your choice: ");
Console.WriteLine("1 for Lock");
Console.WriteLine("2 for Monitor");
Console.WriteLine("3 for ManualResetEvent");
Console.WriteLine("4 for AutoResetEvent");
Console.WriteLine("5 for Mutex");
Console.WriteLine("6 for Semaphore");
while (true)
{
    string? choice = Console.ReadLine();
    if (choice == null)
    {
        Console.WriteLine("Invalid choice");
        return;
    }

    Base invoker = choice switch
    {
        "1" => new Lock(),
        "2" => new Monitor(),
        "3" => new ManualResetEvent(),
        "4" => new AutoResetEvent(),
        "5" => new Mutex(),
        "6" => new Semaphore(),
        _ => throw new ArgumentException("Invalid choice")
    };
    invoker.Invoke();
    Thread.Sleep(10001);
    Console.WriteLine("Enter your choice: ");
}

// Mutex mx = new Mutex();
// object _lock = new object();
// // Create a function to print odd numbers from a given set of numbers
// void PrintOddNumbers(int[] numbers)
// {
//     foreach (var number in numbers)
//     {
//         mx.WaitOne();
//         if (number % 2 != 0)
//         {
//             Console.WriteLine(number);
//         }
//         mx.ReleaseMutex();
//     }
// }
//
// // Create a function to print even numbers from a given set of numbers
// void PrintEvenNumbers(int[] numbers)
// {
//     foreach (var number in numbers)
//     {
//         mx.WaitOne();
//         if (number % 2 == 0)
//         {
//             Console.WriteLine(number);
//         }
//         mx.ReleaseMutex();
//     }
// }
// int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
// Thread oddThread = new Thread(() => PrintOddNumbers(numbers));
// Thread evenThread = new Thread(() => PrintEvenNumbers(numbers));
// oddThread.Start();
// evenThread.Start();