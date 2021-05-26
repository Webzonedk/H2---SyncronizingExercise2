using System;
using System.Threading;
namespace SyncronizingExercise2
{
    class Program
    {

        static int counter;
        static object _lock = new();
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Stars);
            Thread thread2 = new Thread(HashTags);
            thread1.Start();
            Thread.Sleep(100);
            thread2.Start();
        }

        static void Stars()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    int i;
                    for (i = 0; i < 60; i++)
                    {
                        Console.Write("*");

                    }
                    counter += i;
                    Console.WriteLine(" " + counter);
                }
                finally
                {
                    Thread.Sleep(1000);
                    Monitor.Exit(_lock);
                };
            };
        }



        static void HashTags()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    int i;
                    for (i = 0; i < 60; i++)
                    {
                        Console.Write("#");

                    }
                    counter += i;

                    Console.WriteLine(" " + counter);
                }
                finally
                {
                    Thread.Sleep(400);
                    Monitor.Exit(_lock);
                };
            }
        }
    }
}
