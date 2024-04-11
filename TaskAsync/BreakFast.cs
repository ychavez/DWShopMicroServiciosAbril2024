using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAsync
{
    public class BreakFast
    {
        public static void Run()
        {
            CalentarSarten();
            PrenderCafeter();
            CalentarHuevito();
            CalentarTocino();
            TostarPan();
            Servir();
        }


        public static async Task RunAsync()
        {
            var sartenTask = CalentarSartenAsync();
            var prenderCafeteraTask = PrenderCafeterAsync();
            var pan = TostarPanAsync();
            await sartenTask;
            var huevito = CalentarHuevitoAsync();
            var tocino = CalentarTocinoAsync();
            await prenderCafeteraTask;
            await tocino;
            await huevito;
            await tocino;
            await pan;
            await ServirAsync();
        }
        private static void CalentarSarten()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Sarten caliente");
        }

        private async static Task CalentarSartenAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Sarten caliente");

        }

        private static void PrenderCafeter()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Cafe listo");
        }

        private static async Task PrenderCafeterAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Cafe listo");
        }


        private static void CalentarHuevito()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Huevito listo");
        }

        private static async Task CalentarHuevitoAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Huevito listo");
        }

        private async static Task CalentarTocinoAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Tocino listo");

        }


        private static void CalentarTocino()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Tocino listo");

        }

        private static void TostarPan()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Pan listo");

        }


        private static async Task TostarPanAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Pan listo");

        }

        private static void Servir()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Servido!!");

        }


        private static async Task ServirAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Servido!!");

        }
    }
}
