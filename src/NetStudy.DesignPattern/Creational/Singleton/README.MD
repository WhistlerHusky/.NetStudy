# Singleton pattern
이 글은 C# in depth 의 저자 Jon Skeet 의 블로그를 번역한 수준
## 1. 5가지 Singleton pattern
1. Not thread-safe
```csharp
public sealed class Singleton
{
    private static Singleton instance=null;

    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            if (instance==null) 
            {
            	//멀티 스레드가 동시에 여기 들어오게 될 경우 문제 발생.
                instance = new Singleton();
            }
            return instance;
        }
    }
}
```
2. Simple thread-safety
```csharp
public sealed class Singleton
{
    private static Singleton instance = null;
    private static readonly object padlock = new object();

    Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            lock (padlock) //매번 인스턴스 가지로 올때마다 락을 걸고 풀어야함.
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
```
3. Double-check locking
```csharp
public sealed class Singleton
{
    private static Singleton instance = null;
    private static readonly object padlock = new object();

    Singleton()
    {
    }
	// 이패턴의 문제점은 딱히 문제점 같지 않아 보이지만 저자는 추천하지 않는다.
    // 그나마 문제점으로 꼽은게 Java에서는 사용 불가능 하단다.(1.5버전 이하)
    // 위 2번 보다 조금 더 성능이 좋단다. 하지만 아래 보다 좋지 않단다.(그래,,이게 큰 이유겠지)
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }
}
```
4. not quite as lazy, but thread-safe without using locks
```csharp
public sealed class Singleton
{
	// 이 패턴의 문제점은 다른 예제들과 다르게 lazy하지 않다.
    // 단점은 만약 다른 static memeber가 있을경우, 그 멤버에 접근하려고 해도,
    // instance가 생성이 된다. 바꿔말해 초반에 프로그램 실행할때, 굳이 instance가 아니라,
    // 다른 static memeber에 접근해도, instance가 생성이 되기 때문에 초반 실행에 과부화 발생이 가능하다.
    // 장점은 매번 instance가 생성되었는지 체크하는 코드가 없기 때문에 빠르다.
    private static readonly Singleton instance = new Singleton();

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static Singleton()
    {
    }

    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            return instance;
        }
    }
}
```
위 코드와 동일하지만 Auto-property 를 적용하면 아래와같이 작성가능(동일한 코드임)
```csharp
public sealed class Singleton
{
	public static Singleton Instance { get; } = new Singleton();
    static Singleton()
    {
    }
    private Singleton()
    {
    }
}
```
5. Fully lazy instantiation
```csharp
public sealed class Singleton
{
    private Singleton()
    {
    }
	// 4번에서의 문제점인 instance가 아닌 다른 static member 접근에도 instance가 생성되는걸
    // 방지하기위해 innerclass로 instance를 생성하는 방법이다.
    // 단점은 코드가 복잡해졌다.
    public static Singleton Instance { get { return Nested.instance; } }
        
    private class Nested
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Nested()
        {
        }

        internal static readonly Singleton instance = new Singleton();
    }
}
```
6.using .NET 4's Lazy<T> type
```csharp
public sealed class Singleton
{
	// .NET 4.0 이상 버전을 사용하면 이와 같은 코드로 작성 가능.
    // 코드도 단순하고, 성능도 좋다, 심지어 인스턴스가 생성 되었는지 IsValueCreated property로 확인도 가능하다.
    // 하지만 Lazy<> Generic 이 어떻게 구현되었는지는 모른다...궁금하면 파헤쳐 봐야한다...배보다 배꼽이다!
    private static readonly Lazy<Singleton> lazy =
        new Lazy<Singleton>(() => new Singleton());
    
    public static Singleton Instance { get { return lazy.Value; } }

    private Singleton()
    {
    }
}
```

성능 문제
저자는 4번을 사용하는걸 추천하는듯 하다. 아마,,,왠만해서는 초반에 실행되더라도, 저거 실행하는데 프로그램이 느려질 정도면,
그건 내가봐도 다른게 문제지, 저 싱글턴이 문제가 되진 않을듯하다