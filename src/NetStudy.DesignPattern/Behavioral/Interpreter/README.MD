# Interpreter pattern

말 그대로 문법 또는 표현을 평가하기 위한 패턴, 특정 context를 interpret 하는것을 여러 expression 인터페이스를 구현하는것을 수반한다.

```csharp
public interface Expression
{
    int Interpret(int mineral);
    
    int CreateUnit(ref int mineral);
}
```

먼저 사용자가 어떻게 수식을 해석할건지 알고있어야한다.
여기서는 가능하면 비싼 유닛을 만들수 있는 만큼 만들고, 남은 금액으로 다음 비싼 유닛,,,,식으로 해석을 지정했다.
```csharp
IList<Expression> list = new List<Expression>();
	list.Add(new BattleCruiserExpression());
    list.Add(new DropshipExpression());
    list.Add(new MarinExpression());
```

int Interpret(int) 메소드는 그냥 주어진 미네랄도 각 유닛을 만들수 있는 수만 구하고,
int CreateUnit(int) 은 실제로 주어진 미네랄도 각 유닛을 만들수 있는 수와, 그리고 남은 미네랄 (ref int)을 돌려준다.
```csharp
public class BattleCruiserExpression : Expression
{
    private const int RequiredMineral = 250;

    public int Interpret(int mineral)
    {
        return mineral / RequiredMineral;
    }

    public int CreateUnit(ref int mineral)
    {
        var count = mineral / RequiredMineral;
        mineral = mineral % RequiredMineral;

        return count;
    }
}
```
결과는 아래와 같이 나온다.
```csharp
With 650 mienrals
If you create only,
    BattleCruiser, then 2 can be created
    Dropship, then 6 can be created
    Marin, then 13 can be created

If you create as many as possible from BattleCruiser -> Dropship -> Marin
Current mineral: 650
    2 BattleCruiser
Current mineral: 150
    1 Dropship
Current mineral: 50
    1 Marin

Current Mineral 0
Press any key to continue . . .
```