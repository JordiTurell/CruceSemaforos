using Semaforos.Models;
using System;
using System.Timers;

namespace Semaforos
{
    class Program
    {
        static Semaforo semaforo1 = new Semaforo();
        static Semaforo semaforo2 = new Semaforo();
        static Timer timer = new Timer();

        static void Main(string[] args)
        {
            Initial();
            
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void Initial()
        {
            semaforo1.red = true;
            semaforo1.orange = false;
            semaforo1.green = false;

            semaforo2.green = true;
            semaforo2.orange = false;
            semaforo2.red = false;

            timer.Interval = 300000;
            Console.WriteLine("Semaforo 1 rojo - Semaforo 2 Verde");
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (semaforo2.green)
            {
                Console.WriteLine("Paso el semaforo 2 a ambar el semaforo 1 sigue en rojo");
                semaforo2.orange = true;
                semaforo2.green = false;
                Console.WriteLine("Cambio el intervalo del timer de X a 1segundo");
                timer.Interval = 1000;

            }else if (semaforo2.orange)
            {
                Console.WriteLine("Paso el semaforo 2 a rojo i el semaforo 1 a verde");
                semaforo2.red = true;
                semaforo2.orange = false;
                semaforo1.green = true;
                semaforo1.red = false;

                Console.WriteLine("Cambio el intervalo del timer para los 5 minutos");
                timer.Interval = 300000;
            }else if (semaforo1.green)
            {
                Console.WriteLine("Paso el semaforo 1 a ambar y el 2 lo dejo a rojo");
                semaforo1.green = false;
                semaforo1.orange = true;
                Console.WriteLine("Cambiamos el intervalo para el ambar");
                timer.Interval = 1000;
            }else if (semaforo1.orange)
            {
                Console.WriteLine("Paso el semaforo 1 a rojo y el 2 a verde.");
                semaforo1.orange = false;
                semaforo1.red = true;
                semaforo2.green = true;
                Console.WriteLine("Cambiamos el intervalo del timer a los 5 minutos");
                timer.Interval = 300000;
            }

        }
    }
}
