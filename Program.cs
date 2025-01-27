// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using System.Text.RegularExpressions;



namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Formatos aceitos: ");
            Console.WriteLine("- '01s' para segundos");
            Console.WriteLine("- '01m' para minutos");
            Console.WriteLine("- '01h' para horas");
            Console.WriteLine("- '01m01s' para minutos e segundos");
            Console.WriteLine("- '01h01m01s' para horas, minutos e segundos");
            

            Console.WriteLine("- '0' para sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            string data = Console.ReadLine().ToLower();

            if(data == "0")
                System.Environment.Exit(0);

            // Processa o input para converter para segundos
            int totalTimeInSeconds = ProcessInput(data);

            PreStart(totalTimeInSeconds);
        }

        static int ProcessInput(string data)
        {
            int seconds = 0;
            MatchCollection matches = Regex.Matches(data, @"(\d{2}[hms])");
            //regex para pegar 2 digitos seguidos de h, m ou s

            foreach(Match match in matches)
            {
                GroupCollection groups = match.Groups;
                string value = groups[0].Value;
                int number = int.Parse(value.Substring(0, 2));
                if(value.EndsWith("h"))
                    seconds += number * 3600;
                if(value.EndsWith("m"))
                    seconds += number * 60;
                if(value.EndsWith("s"))
                    seconds += number;
            }

            // Se não houver nenhuma correspondência, o formato é inválido
            if (matches.Count == 0)
            {
                return 0;
            }
            return seconds;
        }

        static void PreStart(int time)
        {
            Console.Clear();
            Thread.Sleep(250);
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(250);
            Start(time);
        }

        static void Start(int time)
        {
            int currentTime = 0;
            while(currentTime != time)
            {   
                Console.Clear();
                currentTime++;
                int hours = currentTime / 3600;
                int minutes = (currentTime % 3600) / 60;
                int seconds = currentTime % 60;
                Console.WriteLine($"Time: {hours:D2}:{minutes:D2}:{seconds:D2}");
                Thread.Sleep(1000); // garante que o programa vai esperar 1 segundo
                //é preciso importar a biblioteca System.Threading
            }

                Console.Clear();
                Console.WriteLine("Stopwatch finalizado");
                Thread.Sleep(150);
                Menu();
        }
    }
}
;