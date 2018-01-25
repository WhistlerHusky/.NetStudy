# Runner

# 1. 실행하기
.NetStudy.Core 프로젝트에 있는 해당 interface를 구현하는 모든 클래스는 Console.Application인 NetStudy.Runner 프로젝트에서 실행가능.
```csharp
public interface IRunner
{
    void Run();
}
```

예를들어 VariantRunner 클래스의 경우
```csharp
public class VariantRunner : IRunner
```

아래와 같이 실행가능
```csharp
class Program
{
    static void Main(string[] args)
    {
        IRunner runner = new VariantRunner();
        runner.Run();
    }
}
```