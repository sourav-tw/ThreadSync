// See https://aka.ms/new-console-template for more information

using ThreadsAndMore;
using ThreadsAndMore.ConcreteStrategy;
using ThreadsAndMore.Invoker;
using ThreadsAndMore.Processor;
using AutoResetEvent = ThreadsAndMore.Invoker.AutoResetEvent;
using ManualResetEvent = ThreadsAndMore.Invoker.ManualResetEvent;
using Monitor = ThreadsAndMore.Invoker.Monitor;
using Mutex = System.Threading.Mutex;
using Semaphore = ThreadsAndMore.Invoker.Semaphore;

//Lock Sync Strategy
//Base invoker = new Lock();
// Base invoker = new Monitor();
// Base invoker = new ManualResetEvent();
// Base invoker = new AutoResetEvent();
// Base invoker = new ThreadsAndMore.Invoker.Mutex();
Base invoker = new Semaphore();
invoker.Invoke();

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