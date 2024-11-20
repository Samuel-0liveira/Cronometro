using System;
using System.Diagnostics;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Qual contagem deseja fazer?");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("(1) - Progressiva");
            Console.WriteLine("(2) - Regressiva");
            Console.WriteLine("(0) - Sair");
            int option = int.Parse(Console.ReadLine()!);

            switch(option)
            {
                case 1:
                    Count(1);
                    break;
                case 2:
                    Count(2);
                    break;
                case 0:
                    System.Environment.Exit(0);
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void Count(int option)
        {
            Console.Clear();
            
            Console.WriteLine("Quanto tempo deseja contar?");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("S = Segundo - 10s = 10 segundos");
            Console.WriteLine("M = Minuto - 1m = 1 minuto");
            Console.WriteLine("0s = Menu anterior");
            string data = Console.ReadLine()!.ToLower();
            
            char type = char.Parse(data.Substring(data.Length - 1,1));
            int time = int.Parse(data.Substring(0, data.Length - 1));

            int multiplier = 1;

            if (type == 'm')
            {
                multiplier = 60;
            }

            if (time == 0)
            {
                Menu();
            }

            PreStart(time * multiplier, option);
        }

        static void PreStart(int time, int option)
        {
            Console.Clear();

            Console.WriteLine("Ready....");
            Thread.Sleep(1000);

            Console.WriteLine("Set....");
            Thread.Sleep(1000);

            Console.WriteLine("GO!");
            Thread.Sleep(2500);

            Start(time, option);
        }

        static void Start(int time, int option)
        {
            int currentTime = 0;

            if (option == 1)
            {
                while(currentTime != time)
                {
                    Console.Clear();
                    currentTime++;
                    Console.WriteLine(currentTime);
                    Thread.Sleep(1000);
                }
            } else if (option == 2) {
                currentTime = time;

                while(currentTime != 0)
                {
                    Console.Clear();
                    Console.WriteLine(currentTime);
                    currentTime--;
                    Thread.Sleep(1000);
                }
            }
            
            Console.Clear();
            Console.WriteLine("Stopwatch finalizado.");
            Thread.Sleep(2500);

            Menu();
        }
    }
}