using BenchmarkDotNet.Running;

namespace SmartSpan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Bench>();
        }
    }
}
