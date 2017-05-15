# Facade pattern
여러개의 클래스들이 밀접한 관계를 가지고 있으며 전체적으로 하나의 열할을 수행할때, 그 역할을 대표하기 위한 클래스를 정의하고,
외부 Client들이 일일이 각 클래스를 직접 다루지 않더라도 대표 클래스를 통하여 원하는 기능을 제공받을수 있도록 만든 방식.

e.g.
집에있는 각종 전자기구 전원을 조절한다고 가정하자.
외출할때마다 오븐, TV, 전등, 라디오, 보일러 등등 하나 하나 전원 버튼을 누르는것 보다 그냥 간단히
외출 버튼 하나만 누르면 자동으로 다 전원이 나가면 얼마나 편한가?
그리고 겨울이 되면(수정이 필요하게되면) 외출후에 집에들어오면 추우니깐 외출버튼으로 보일러 끄는것보단, 온도를 낮추게끔 하면 되니깐,
그리고 만약 이런 외출기능이 휴대폰에도 있고, 태블릿에도 있고, 실제 벽에 붙은 버튼에도 있다고 하더라도 기능은 한군대서만 수정을 하면된다.

또 다른 예는 스타크래프트에서는 매번 유닛을 생성할때마다 확인해야되는게 3가지가 있다. 바로 미네랄, 가스 그리고 인구 수 이다.
유닛을 생성하는 종족마다 2, 3개정도씩 있다.(저그는 한군데)
특정 유닛 생성공장마다 아래와 같은 코드를 중복 하는것보단,
```cs
UnitType unitType = InputUnitNumber();

var requiredSupplyNumber = UnitHelper.GetSupplyNumber(unitType);

if (StarcraftResources.CurrentSupplyNumber + requiredSupplyNumber > 200)
{
    Console.WriteLine("Supply limmit cannot exceed 200");
    break;
}

var requiredMinerals = UnitHelper.GetRequiredMinerals(unitType);
if (StarcraftResources.CurrentMinerals < requiredMinerals)
{
    Console.WriteLine("Not enough minerals");
    break;
}

var requiredGas = UnitHelper.GetRequiredGas(unitType);
if (StarcraftResources.CurrentGas < requiredGas)
{
    Console.WriteLine("Not enough gas");
    break;
}

var unit = UnitFactory.CreateUnit(unitType);
Console.WriteLine($"{unit.GetType().Name} is created");

StarcraftResources.CurrentGas -= requiredGas;
StarcraftResources.CurrentMinerals -= requiredMinerals;
StarcraftResources.CurrentSupplyNumber += requiredSupplyNumber;

Console.WriteLine();
```
Facade 클래스를 하나 만들어두고.
```cs
public class StarcraftFacade
{
    public Unit CreateUnit(UnitType unitType)
    {
        var requiredSupplyNumber = UnitHelper.GetSupplyNumber(unitType);

        if (StarcraftResources.CurrentSupplyNumber + requiredSupplyNumber > 200)
        {
            Console.WriteLine("Supply limmit cannot exceed 200");
            return null;
        }

        var requiredMinerals = UnitHelper.GetRequiredMinerals(unitType);
        if (StarcraftResources.CurrentMinerals < requiredMinerals)
        {
            Console.WriteLine("Not enough minerals");
            return null;
        }

        var requiredGas = UnitHelper.GetRequiredGas(unitType);
        if (StarcraftResources.CurrentGas < requiredGas)
        {
            Console.WriteLine("Not enough gas");
            return null;
        }

        var unit = UnitFactory.CreateUnit(unitType);
        Console.WriteLine($"{unit.GetType().Name} is created");

        StarcraftResources.CurrentGas -= requiredGas;
        StarcraftResources.CurrentMinerals -= requiredMinerals;
        StarcraftResources.CurrentSupplyNumber += requiredSupplyNumber;

        return unit;
    }
}
```
아래와 같이 호출하는게 편하다.
```cs
StarcraftFacade facade = new StarcraftFacade();

while (true)
{
    UnitType unitType = InputUnitNumber();

	Unit unit = facade.CreateUnit(unitType);
    if (unit == null)
    {
        break;
    }
	else
	{
		...
	}
}
```
이렇게 해주면 추후에 미네랄, 가스 그리고 인구수 뿐만아니라, 또다른 자원이 추가 되더라도, 각 공장마다 추가할 필요없이,

StarcraftFacade 클래스에만 추가해주면된다.
