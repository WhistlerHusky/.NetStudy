# Variant
## 1. Covariant
	Covariant는 흔히 generic에서 부모 클래스 타입 변수로, 자식 클래스의 실 객체 를 담을수 있는것을 말함.
```csharp
IEnumerable<object> covariant = new List<string>();
```
이게 가능한게 IEnumerable이 아래와 같이 정의되어 있기 때문에
```csharp
public interface IEnumerable<out T> : IEnumerable
{
	IEnumerator<T> GetEnumerator();
}
```
주목해서 봐야할것은 out 키워드!
부모의 변수 타입(object)가 자식의 변수타입을 담기만 하고 실제 사용은 하지 않기 때문에 가능!

## 2. Contravariant
Contravariant는 covariant와 반대로 자식 클래스 타입 변수로, 부모 클래스의 실 객체를 담을수 있는것을 말함.
만약 아래와같은 ObjectComparable generic 클래스가 있을경우.
```csharp
public class ObjectComparable<T> : IComparable<T>
{
    public int CompareTo(object obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        if (!(obj is ObjectComparable<T>)) throw new ArgumentException($"Object must be of type {nameof(ObjectComparable<T>)}");
        return CompareTo((ObjectComparable<T>) obj);
    }

    public int CompareTo(T other)
    {
        return 0;
    }
}
```
 아래와 같이 사용가능
```csharp
IComparable<string> comparable = new ObjectComparable<object>();
```
이는 IComparable이 아래와 같이 정의되어있기 때문
```csharp
public interface IComparable<in T>
{
	int CompareTo(T other);
}
```
여기서 주목해야될껀 in 키워드!
여기서 좀 헷갈렸는데, 생각해보면 자식 클래스는 부모클래스가 할 수 있는 모든것을 할 수 있기 때문에, 부모가 어떤 비교를하던
자식도 비교를 할 수 있기 때문에 가능 하다고 생각하면 좀더 쉽게 이해가 된다.
