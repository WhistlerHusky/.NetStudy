using BenchmarkDotNet.Attributes;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BenchmarkDotNet.Netframework.Console
{
    public class ForeachTest
    {
        public int[] numbers;
        public int[] numbers2;
        private long totalSize = 0;
        private long totalSize2 = 0;

        [GlobalSetup]
        public void Setup()
        {
            numbers = Enumerable.Range(1, 10).ToArray();
            numbers2 = Enumerable.Range(1, 10).ToArray();
        }

        [Benchmark]
        public void RunParallelForeach()
        {
            String[] files = Directory.GetFiles($@"c:\windows");
            Parallel.For(0, files.Length,
                index => {
                    FileInfo fi = new FileInfo(files[index]);
                    //Interlocked.Add(ref totalSize, size);
                });
        }

        [Benchmark]
        public void RunNormalForeach()
        {
            String[] files = Directory.GetFiles($@"c:\windows");
            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                //totalSize2 += size;
            }
        }
    }
}
