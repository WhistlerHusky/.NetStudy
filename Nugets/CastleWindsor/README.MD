# Castle Windsor
## 1. Logging with Log4Net
정확한 이유는 알 수 없지만, Log4netFactory가 제대로 작동안함. 
그래서 Asp.Net Boilerplate 프로젝트 안 두개 파일 복사해서 사용.
* Log4NetLoggerFactory.cs
* Log4NetLogger.cs

매번 등록하는 코드 까먹으니 여기에 정리
```csharp
Register(
    Classes.FromAssembly(context.Assembly)//해당 어셈블리가 있는 모든 클래스들중
        .IncludeNonPublicTypes() // None public 타입까지 포함(일반적이진 않음..)해서
        .BasedOn<ITransientDependency>() //ITransientDependency 을 구현한 모든 클래스 중
        .If(type => !type.GetTypeInfo().IsGenericTypeDefinition) //Generic 타입 제외하고
        .WithService.Self()// 등록
        .WithService.DefaultInterfaces()//만약 한 인터페이스에 여러개가 서비스가 중복될 경우 인터페이스와 이름이 동일한거 우선으로 Resolve
        .LifestyleTransient()//매 트랜젝션마다 해당 서비스(인스턴스)를 새로 생성.
    );
```
