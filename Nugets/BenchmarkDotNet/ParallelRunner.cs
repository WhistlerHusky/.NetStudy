//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Attributes.Columns;
//using BenchmarkDotNet.Attributes.Exporters;
//using BenchmarkDotNet.Attributes.Jobs;
//using NetStudy.Core;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using BenchmarkDotNet.Running;

//namespace BenchmarkDotNet
//{
//    public class ParallelRunner: IRunner
//    {
//        public void Run()
//        {
//            var numbers = Enumerable.Range(1, 1000).ToList();
//            var f = new ForeachTest();
//        }
//    }

//    [CoreJob, ClrJob, MonoJob]
//    [RPlotExporter, RankColumn]
//    public class ForeachTest
//    {

//        [Benchmark]
//        public void RunParallelForeach(IList<int> numbers)
//        {
//            Parallel.For(0, numbers.Count(), x => Console.Write(numbers[x]));
//        }

//        [Benchmark]
//        public void RunNormalForeach(IList<int> numbers)
//        {
//            for (int i = 0; i < numbers.Count(); i++)
//            {
//                Console.Write(numbers[i]);
//            }
//        }
//    }
//}
