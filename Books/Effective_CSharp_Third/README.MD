# Effective C# Third Edition
간단하게 각 챕터별 정리

## Part 1 C# Language Idioms
### 1. Prefer Implicitly Typed Local Variables

var 키워드 사용시 주의해야 할 점에 대한 정리

```csharp
var foo = new MyType(); //이건 언제나 괜찮다.
var thing = AccountFactory.CreateSavingsAccount();//이것도 대충 예상가능하니 Not bad.
var HighestSellingProduct = someObject.DoSomeWork(anotherParameter);//이건 함수명이 애매모호 하지만, 변수명을 보고 알수있다. 네이밍이 중요한 이유!
var result = someObject.DoSomeWork(anotherParameter);// 이건 지양하자, 함수명도, 변수명도 애매모호 어떤타입인지 알수없다.
```
사실 위 2,3번째도 Account와 Product를 상속하는 또다른 클래스가 있을수 있기 때문에 무조건 괜찮은건 아니다.

var 키워드 사용에 특히 중요시 해야될께 Built-in numeric types (int, long, float, double, decimal) 등등 사용할때

```csharp
var f = GetMagicNumber();
var total = 100 * f / 6;
Console.WriteLine($"Declared Type: {total.GetType().Name}, Value: {total}");
```
숫자가 돌아오는건 알지만 어떤 Type이 돌아오는지 알수 없고 리턴 타입에 의해 소수점 이하가 생략되거나, 제대로 표시가 안될수도 있다.
이럴땐 차라리 명시적으로 리턴타입을 선언해 가독성에 좋다.

```csharp
public IEnumerable <string> FindCustomersStartingWith1(string start)
{
    IEnumerable<string> q = 
        from c in db.Customers 
        select c.ContactName;

    var q2 = q.Where(s => s.StartsWith(start));
    return q2;
}
```
위 코드를 보고 문제점이 먼지 생각해보자.
아마 IEnumerable와  IQueryable 의 차이점을 모른다면 구글링 해서 알아봐야한다.
Database를 다루면서 위 둘의 차이점을 모르는건 치명적!
여기서 명시적으로 타입을 IEnumerable로 했는데 차라리 var로 두는게 더 좋았을껏이다.

### 2. Prefer readonly to const
이건 예전에 읽어봐서 딱히 다시 읽어보진 않았지만, 기억에 맞다면
const는 컴파일 타임에 저장되기 때문에 추후 값이 변경될 경우 해당 lib를 사용하는 다른 프로젝트 모두 다시 컴파일 해줘야 하지만,
readonly는 런타임이기 때문에 해당 lib를 사용하는 다른프로젝트가 영향을 받지않는다.
아마 원주율 같은 3.14과 같은 불편의 값은 const하고 사이트 주소와 같이 변경이 가능한건 readonly로 하는게 좋다.

### 3. Prefer the is or as Operators to Cast
캐스팅할때 is 혹은 as를 더 사용하라는 내용.

### 4. Replace string.Format() with Interpolated Strings
string.Format() 사용하지말고 $ 마크 사용하라는거.

### 5. Prefer FormattableString for Culture-SpecificStrings
특정 지역별로 다른 결과가 나올수 있으니, 해당 프로그램이 세계적으로 사용될꺼 같으면 FormattableString를 사용하라는 내용

### 6. Avoid String-ly Typed APIs
변수명을 하드코딩하지말고 nameof를 최대한 사용할것, 그럼 IDE에서 변수명 변경해도, 같이 변경됨.
"특정변수명" 은 변수명 변경에 같이 변경되지 않음.

### 7. Express Callbacks with Delegates
Action<> 은 리턴타입이 없고 여러개의 파라메터를 가질수 있음
Func<>은 여러개의 파라메터와 한개의 리턴값을 가짐. 마지막에 들어오는게 리턴타입
Predicate\<T\>는 하나의 파라메터만 가지고 리턴은 boolean 타입 한마디로 func<T,bool>이랑 동일

### 8. Use the Null Conditional Operator for Event Invocations
예전엔 이벤트 호출하기전에 event가 null인지 아래와 같이 확인후에 호출했는데
```csharp
if (eventA != null)
    eventA.Invok(this, something);
```

지금은 그냥 단순히 ? 사용하면됨. 단! ?. 뒤에 바로 ()사용 못하니 Invoke() 해야함
```csharp
    eventA?.Invoke(this, something);
```

### 9. Minimize Boxing and Unboxing
이건 당연한거고.

### 10. Use the new Modifier Only to React to Base Class Updates
아직 new로 base class 함수 덮어사용한 경우가 한번도 없고, 본 적도 없음...


## Part 2 .NET Resource Management
호,,내가 좋아하는 파트다!

### 11. Understand .NET Resource Management
GC에 대한 설명 GC0, GC1, GC2 이건 CLR VIA C#에서 읽은내용

몰랐던 내용
GC 이후에 살아남은 object를 한떼 모으고 콜렉트 된 메모리들은 연속으로 배열시켜준다.(마치 디스크 조각 모음 처럼)

### 12. Prefer Member Initializers to Assignment Statements
왠만하면 생성자에서 new하지말고 아래와같이 하는게 편하다.

```csharp
public class MyClass
{
    private List<string> labels = new List<string>();
}
```

생성자에서 해야할 경우, 여러개의 생성자가 되면 일일이 base 생성자를 호출하던지, 혹은 까먹고 초기화 안해줄수도있다.

기본값으로 초기화되는 값은 굳이 초기화 하지않는다. 0, null

### 13. Use Proper Initialization for Static Class Members
static class 초기화 잘 하라는 내용...

### 14. Minimize Duplicate Initialization Logic
여러개의 생성자 안에 중복 코드가 존재할경우 this()사용하는 방법으로 중복코드를 최소화 하라는 내용
```csharp
public class MyClass{
    private List<ImportantData> coll;
    private string name;
    public MyClass() : this(0, "")
    {
    }
    public MyClass(int initialCount) : 
        this(initialCount, string.Empty)
    {
    }
    public MyClass(int initialCount, string name)
    {        
        coll = (initialCount > 0) 
            ? new List<ImportantData>(initialCount) 
            : new List<ImportantData>();
        this.name = name
    }
}
```

### 15. Avoid Creating Unnecessary Objects
동일한 세팅으로 계속 반복 사용되는건 계속 생성하고, 파괴하지 말고, 멤버변수로 만들어서 사용.
```csharp
private readonly Font myFont = new Font("Arial", 10.0f);
protected override void OnPaint(PaintEventArgs e)
{
    e.Graphics.DrawString(DateTime.Now.ToString(), myFont, Brushes.Black, new PointF (0, 0));
    base.OnPaint(e);
}
```
위 방법은 일단 객체가 무조건 하나가 생성이 되는데 Lazy evalution 사용하면
아래와같이 최소 한번이라도 사용될때 객체 생성 가능. (다만 계속 사용하면 검사를 계속 하게 됨으로,,,뭐 좀 손해일수도)
```csharp
private static Brush blackBrush; 
public static Brush Black
{    
    get    
    {        
        if (blackBrush == null)
            blackBrush = new SolidBrush(Color.Black);
        
        return blackBrush;
    }
}
```
StringBuilder 잘 사용할것.

### 16. Never Call Virtual Functions in Constructors
책에는 왜 사용하면 안되는지 내용이 설명이 자세히 나옴.
C# 특성상, 베이스 클래스 생성자가 호출되기전에 자식 클래스들의 모든 메소드와 멤버 변수가 다 생성되기 때문에,
만약 베이스 클래스 생성자에서 호출하는 가상함수가, 자식 클래스에서 override 되었을 경우 자식 클래스의 함수가 호출되어
예상치 못한 시나리오 발생가능.

### 17. Implement the Standard Dispose Pattern
 unmannaged memory 사용시, IDispose 통해서 꼭 메모리 해제 할것.
만약 해당 클래스가 다른 클래스의 베이스 클래스가 될 수 있다면. protected virutal 로 선언해서 상속받는 클래스도
해당 클래스내에 존재하는 unmannaged memory 해제하고 base클래스의 Dispose 호출하게끔.


## Part 3 Working with Generics




