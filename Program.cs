// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Start(6);
        }

        static void Start(int time)
        {
            int currentTime = 0;
            while(currentTime != time)
            {   
                Console.Clear();
                currentTime++;
                Console.WriteLine("Time: " + currentTime);
                Thread.Sleep(1000); // garante que o programa vai esperar 1 segundo
                //é preciso importar a biblioteca System.Threading
            }

                Console.Clear();
                Console.WriteLine("Stopwatch finalizado");
        }
    }
}
