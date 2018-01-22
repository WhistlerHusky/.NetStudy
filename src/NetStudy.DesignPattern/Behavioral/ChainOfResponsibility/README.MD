# Chain of responsibility
 각 class 마다 책임이 있고 이런 class들이 연결되어 있어 class A 가 책임을 못 질 것 같으면 다음 class B에게 책임이 넘겨주는 구조를 말한다
 회사에서 물건을 구입할때 디렉터(Director), 부사장, 사장이 각각 결정할수 있는 구매 금액이 있을것이다.
 처음에 디렉터에게 구매요청이 오면, 디렉터가 자신의 권한 안에서 해결이 가능한 금액이면 (10000원) 디렉터가 결정을 하고, 그렇지 않을경우 부사장에게 결정(책임)을 떠넘긴다. 그리고 그 금액이 20000원 이하 일 경우 부사장이 결정을 하고, 그렇지 않으면 다시 사장에게 책임을 떠넘긴다.

먼저 책임 연대가 있는 클래스군을 생성한다.
```csharp
public abstract class Approver
{
    protected decimal _maxAmount;
    public Approver NextApprover { get; set; }//여기서 책임 연대 객체군을 묶는다!
    public abstract void ProcessRequest(Purchase purchase);
}
```

```csharp
public class Director : Approver
{
    public Director()
    {
        _maxAmount = 10000;
    }

    public override void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount < _maxAmount)
        {
            Console.WriteLine(
                $"purchase:{purchase.PurchaseNumber} has been Approved by {GetType().Name} - amount:{purchase.Amount}");
        }
        else if (null != NextApprover)
        {
            NextApprover.ProcessRequest(purchase);
        }
        else
        {
            Console.WriteLine($"{GetType().Name} cannot process purchase number:{purchase.PurchaseNumber} because it's amount is more than {_maxAmount}");
        }
    }
}

```
VicePresident와 President는 Director class와 코드가 거의 동일하니 핵심 부분만
```csharp
public VicePresident()
{
    _maxAmount = 20000;
}

public override void ProcessRequest(Purchase purchase)
{
    if (purchase.Amount < _maxAmount)
    {
        Console.WriteLine(
            $"purchase:{purchase.PurchaseNumber} has been Approved by {GetType().Name} - amount:{purchase.Amount}");
    }
			.
			.
			.
}
```
Vicepresident는 maxAmount가 20000, President는 3만이다.

```csharp
Approver director = new Director();
Approver vicePresident = new VicePresident();
Approver President = new President();

director.NextApprover = vicePresident;
vicePresident.NextApprover = President;

var purchase = new Purchase { PurchaseNumber = 1, Amount = 5000};
director.ProcessRequest(purchase);
//output : purchase:1 has been Approved by Director - amount:5000

purchase = new Purchase { PurchaseNumber = 2, Amount = 15000 };
director.ProcessRequest(purchase);
//output : purchase:2 has been Approved by VicePresident - amount:15000

purchase = new Purchase { PurchaseNumber = 3, Amount = 25000 };
director.ProcessRequest(purchase);
//output : purchase:3 has been Approved by President - amount:25000

purchase = new Purchase { PurchaseNumber = 4, Amount = 35000 };
director.ProcessRequest(purchase);
//output : President said this request should be approved in a board meeting
```