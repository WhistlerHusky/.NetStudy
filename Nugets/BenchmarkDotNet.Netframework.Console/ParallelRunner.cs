using BenchmarkDotNet.Attributes;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BenchmarkDotNet.Netframework.Console
{
    public class ForeachTest
    {
        [Benchmark]
        public void RunParallelForeach()
        {
            String[] files = Directory.GetFiles($@"c:\windows");
            Parallel.For(0, files.Length,
                index => {
                    new FileInfo(files[index]);
                });
        }

        [Benchmark]
        public void RunNormalForeach()
        {
            String[] files = Directory.GetFiles($@"c:\windows");
            foreach (var file in files)
            {
                 new FileInfo(file);
            }
        }
    }
}
