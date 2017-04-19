using System;
using System.Diagnostics;
using Pilots.Variant;

namespace Pilots
{
    class Program
    {
        static void Main(string[] args)
        {
            IRunner runner = new VariantRunner();
            runner.Run();
        }
    }
}