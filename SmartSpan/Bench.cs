using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace SmartSpan
{
    [MemoryDiagnoser(false)]

    public class Bench
    {

        //private IEnumerable<int> _items;

        //[GlobalSetup]
        //public void Setup()
        //{
        //    _items = Enumerable.Range(1,2000).ToArray();
        //}

        //[Benchmark]
        //public int MaxClassic() 
        //{
        //    int biggest = int.MinValue;

        //    foreach (int item in _items)
        //    {

        //        if ( item> biggest)
        //            biggest = item;
        //    }
        //    return biggest;
        //}

        //[Benchmark]
        //public int Max() => _items.Max();

        //[Benchmark]
        //public int Min() => _items.Min();


        //[Benchmark]
        //public double Avg() => _items.Average();




        public static readonly string _dateAsText = "10 04 2024";


        [Benchmark]
        public (int day, int month, int year) DatewithString() 
        {
        
            var dayAsText = _dateAsText.Substring(0,2);
            var monthAsText = _dateAsText.Substring(3,2);
            var yearAsText = _dateAsText.Substring(6);


            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);

            return (day, month, year);
        }



        [Benchmark]
        public (int day, int month, int year) DatewithStringSpan()
        {

            ReadOnlySpan<char> dateSpan = _dateAsText;
            var dayAsText = dateSpan.Slice(0, 2);
            var monthAsText = dateSpan.Slice(3, 2);
            var yearAsText = dateSpan.Slice(6);

            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);

            return (day, month, year);
        }


    }
}
