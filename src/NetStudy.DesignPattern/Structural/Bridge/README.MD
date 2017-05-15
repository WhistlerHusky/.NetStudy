# Brdige pattern

 블로그나, 위키를 봐도, 딱히 맘에드는 정의가 없다...
제일 많이 사용된 문구는 **추상화된 부분(추상클래스/인터페이스)과 구현한 클래스를 서로 다른 클래스 계층구조에 집어 넣음으로써 그 둘을 모두 변경할수 있다** 정도?
내가 봤을땐 Strategy pattern을 좀더 유연하게 만든걸로 보인다.

 이번에 브릿지 패턴을 공부하면서 내가 이전에 만들었던 Stragety패턴은 사실은 Bridge 패턴이라는걸 깨달았다,
스트레터지는 행동관련 패턴으로,마린이 총을쏘고, 레이저건을 쏘고, 즉 어떤총을 쏘느냐에 관한 행동에 중점을 둔 패턴이고, 이를 좀더 유연하게 하려고, Smart marine과 Stupid marine으로 분류하면서, Bridge 패턴이 된것이였다...
```cs
class Marine 
{
	IWeapon _weapon;
    SetWeapon(IWeapon weapon)
    {
    	_weapon = weapon;
    }
}
```
이렇게 하면 Strategy패턴이고, 이를 좀더 유연하게 마린뿐아니라 파이어벳이나, 다른 타입의 마린을 더 추가 할수 있게 하면 그것이 Bridge 패턴이 되는것이다.

```cs

class Marine : AttackableUnit
{
	IWeapon _weapon;
    SetWeapon(IWeapon weapon)
    {
    	_weapon = weapon;
    }
    
    Attach(Unit unit)
    {
    	if (_weapon.GetType().Name.Contains("Gun"))
        {
        	_weapon.Fire(unit);
            _weapon.Fire(unit);
        }
        else if (_weapon.GetType().Name.Contains("Flamethrower "))
        {
        	Console.Write($"Marine cannot use {_weapon.GetType().Name}");
        }
    }
}
class Firebat : AttackableUnit
{
	IWeapon _weapon;
    
    SetWeapon(IWeapon weapon)
    {
    	_weapon = weapon;
    }
	Attach(Unit unit)
    {
    	if (_weapon.GetType().Name.Contains("Gun"))
    	{
	    	Console.Write($"FireBat cannot use {_weapon.GetType().Name}");
	    }
	    else if (_weapon.GetType().Name.Contains("Flamethrower "))
	    {
	    	_weapon.Fire(unit)
		}
    }
}
```
이번엔 행동이 아니라, 마린이냐 파이어뱃이냐, 생성에 좀더 중점을 둔걸 알수있다, 그래서 Bridge pattern은 생성과 관련된 패턴이다.

스타크래프트의 경우 마린은 오직 총만 가지고 전투를 하지만 ,스페셜 포스 같은 경우, 저격수가 저격총을 이용하다가, 돌격총으로 바꿀수도 있고, 리니지의 경우 기사가 검을 들고 사냥하다가, 활을 들고 사냥을 할수도 있다. 물론 기사가 활을 들고 사냥하면 데미지가 낮게 나온다. 이런걸 구현할때 편할듯 하다.

```cs
class Knight : AttackableUnit
{
	SetWeapon(IWeapon weapon)
    {
    	_weapon = weapon;
    
    	if (weapon.GetType().Name.Contains("활"))
        {
        	_attachSpeed = 2000; //활공격은 2초에 한번 공격
        }
        else
        {
        	_attachSpeed = 1000; //다른 무기는 1초에 한번 공격
        }
    }
}
```
