using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using NetStudy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Xml;

namespace NetStudy.InDepth.CSharpScripting
{
    public class CSharpScriptingRunner : IRunner
    {
        public void Run()
        {
            var scriptOptions = ScriptOptions.Default.AddReferences(typeof(XmlDocument).Assembly).AddReferences(typeof(ScriptHost).Assembly)
                .AddImports("System.Xml", "System");

            var scriptWithUsing = @"using System; Console.WriteLine(""Hello World with Using"")";
            var scriptWithoutUsing = @"Console.WriteLine(""Hello World without Using!"")";
            var scriptFunctionWithHardCodedParameters= @"int Add(int x, int y) { return x+y; } Add(1, 4)";
            var scriptFunctionWithoutHardCodedParameters = @"int Add(int x, int y) { return x+y; } Add(Left, Right)";

            Task.Run(async () =>
                {
                    await CSharpScript.EvaluateAsync<int>(scriptWithUsing);
                    await CSharpScript.EvaluateAsync<int>(scriptWithoutUsing, scriptOptions);

                    var result = CSharpScript.EvaluateAsync<int>(scriptFunctionWithHardCodedParameters).Result;
                    Console.WriteLine(result);

                    //Anonymous type does not work here.
                    var result2 = CSharpScript.EvaluateAsync<int>(scriptFunctionWithoutHardCodedParameters, null, new ScriptHost { Left = 5, Right = 10 }).Result;
                    Console.WriteLine(result2);
                }
            ).Wait();

            //DynamicFilter
            var dynamicFilter = @"x => x.Left > 5";
            IList<ScriptHost> sh = new List<ScriptHost>
            {
                new ScriptHost{Left = 1, Right = 1},
                new ScriptHost{Left = 3, Right = 1},
                new ScriptHost{Left = 5, Right = 1},
                new ScriptHost{Left = 7, Right = 1},
                new ScriptHost{Left = 9, Right = 1},
            };
            Task.Run(async () => 
            {
                var filter = await CSharpScript.EvaluateAsync<Func<ScriptHost, bool>>(dynamicFilter, scriptOptions);
                var results = sh.Where(filter);
                foreach (var result in results)
                {
                    var result2 = CSharpScript.EvaluateAsync<int>(scriptFunctionWithoutHardCodedParameters, scriptOptions, result).Result;
                    Console.WriteLine(result2);
                }

            }).Wait();
        }
    }

    public class ScriptHost
    {
        public int Left { get; set; }
        public int Right { get; set; }
    }
}
