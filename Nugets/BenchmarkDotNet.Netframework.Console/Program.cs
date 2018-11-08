using BenchmarkDotNet.Running;

namespace BenchmarkDotNet.Netframework.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ForeachTest>();
        }
    }
}
