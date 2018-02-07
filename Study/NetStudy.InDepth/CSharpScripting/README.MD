# C# Scripting
Scripting 이용해서 다이나믹하게 코딩가능.
어디 마땅히 사용할만한 상황은 아직 안보이지만, 만약 사이트에서 사용자에게
LINQ 쿼리를 직접 짜서 날리도록 하고싶을때 사용하면 유용할듯.
```csharp
//DynamicFilter
var scriptOptions = ScriptOptions.Default
                        .AddReferences(typeof(XmlDocument).Assembly)
                        .AddReferences(typeof(ScriptHost).Assembly)
                        .AddImports("System.Xml", "System");

IList<ScriptHost> sh = new List<ScriptHost>
{
    new ScriptHost{Left = 1, Right = 1},
    new ScriptHost{Left = 3, Right = 1},
    new ScriptHost{Left = 5, Right = 1},
    new ScriptHost{Left = 7, Right = 1},
    new ScriptHost{Left = 9, Right = 1},
};

var dynamicFilter = @"x => x.Left > 5";```

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