# Troubleshooting 
.Net 하면서 경험한 문제 해결 정리

## ASP.NET Core

### 1. Start up logging
IIS에 웹 publish한 이후에 index.html 페이지 뜨기도 전에 에러나서, Log 확인해야할때
UseStting, CaptureStartupErrors 추가해주고 publish 하고, index.html 접속하면 명확하게 에러를 알수있음.

<b>물론 에러해결후에는 다시 주석처리!<b>
```csharp
public static void Main(string[] args)
{
    var host = new WebHostBuilder()
        .UseKestrel(opt => opt.AddServerHeader = false)
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        //.UseSetting("detailedErrors", "true")
        //.CaptureStartupErrors(true)
        .Build();

    host.Run();
}
```



