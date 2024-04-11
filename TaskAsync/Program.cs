using System.Diagnostics;

namespace TaskAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //List<Task> breakfasts = new List<Task>();

            //var clientes = Enumerable.Range(0, 10_000);

            //var semaphore = new SemaphoreSlim(100);


            
                Parallel.For(0, 1000, x =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Hola {x}");
                });
            

            //breakfasts = clientes.Select(async b =>
            //{
            //    await semaphore.WaitAsync();
            //    try
            //    {
            //        await BreakFast.RunAsync();
            //    }
            //    finally
            //    {

            //        semaphore.Release();
            //    }

            //}).ToList();



            //await Task.WhenAll(breakfasts);

            stopwatch.Stop();

            Console.WriteLine($"Pasaron {stopwatch.ElapsedMilliseconds} milisegundos");
        }
    }
}
