using JetBrains.Annotations;
using NetStudy.Core;
using System;

namespace Resharper_Test
{
    public class ResharperRunner : IRunner
    {
        public void Run()
        {
            string s = null;
            ParameterShouldNotBeNull("Test");
            //Warning meesage
            ParameterShouldNotBeNull(s);
        }

        public void ParameterShouldNotBeNull([NotNull] string input)
        {
            Console.WriteLine(input);
        }
    }
}
