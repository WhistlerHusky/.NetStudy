# Proxy pattern
어떤 제어를 하는 객체를 위해 대리자 혹은 위임자 (Proxy)를 제공한다.

Proxy 의 종류에는 여러개가 있는것 같은데 자주 이용되는 4가지가있다.

##1. Remote proxy
객체가 다른 주소공간에 있다는걸 숨기기 위해 로컬 오브젝트를 제공한다.
흔한 예가, 클라이언트와 서버다.
클라이언트와 서버에 동일한 메소드가 있고, 클라이언트에서 함수를 호출하면, 서버로 해당 호출을 요청하고,(파라메터를 통해)
리턴된 값을 다시 클라이언트에 보여준다.
클라이언트 GetUserAge()
```cs
public int GetUserAge()
{
    Thread.Sleep(1000);
    
    //서버 접속이 여기서 이루어 진다고 가정.
    IUserAge userAge = new ServerBattleNet();

    return userAge.GetUserAge();
}
```
서버 GetUserAge()
```cs
public int GetUserAge()
{
    return new Random().Next(10,20);
}
```
##2. Virtual proxy
실제 해당 객체를 상용 할 때(혹은 할 수 있을때) 까지 생성과 초기화에 들어가는 전체 비용을 물지않음
즉, 생성이나 관리가 어렵거나, 비용이 비싼 객체를 꼭 필요할 때만 생성(Lazy)
```cs
public class BattleNet : IBattleNet
{
    private bool _connected;

    public BattleNet()
    {
        ConnectToBattleNet(); //생성과 동시에 배틀넷 접속 시도
    }

    public void ConnectToBattleNet()
    {
        // 커넥션에 3초가 걸린다.
        Thread.Sleep(3000);

        _connected = true;

        Console.WriteLine("BattleNet connected");
    }
    		.
            .
            .
            생략
}
```
하지만 싱글모드만 하고싶은 사람에겐 괜히 3초라는 시간 낭비가 발생한다.
이때 프록시를 두면,
```cs
public class ProxyBattleNet : IBattleNet
{
    private IBattleNet _battle;

    public void ConnectToBattleNet() //유저가 ConnectToBattleNet 버튼을 클릭하기 전까지 BattleNet 접속을 미룰수있다.
    {
    	if (_battle == null)
        {
        	_battle = new BattleNet();
         }
    }
    		.
            .
            .
            생략
}

```
##3. Protection proxy
객체에 대한 접근을 가로채서 중간에 권한 점검을 수행할 수 있음.(나이 제한)
```cs
public class BattleNet : IBattleNet
{
	public bool Login(string id, string password) //원래는 나이제한 검색 알고리즘이 없음.
    {
    	if (_connected == false)
        {
        	Console.WriteLine("Battlent is not connected");
        }
        if (id == "starcraft" && password == "battlenet")
        {
        	return true;
        }

		return false;
    }
    		.
            .
            .
            생략
}
```
하지만 Proxy에서 점검 가능
```cs
public class ProxyBattleNet : IBattleNet
{
    private IBattleNet _battle;
			.
            .
            .
            중략
    public bool Login(string id, string password)
    {
        var age = GetUserAge();

        //Protection proxy
        if (age < 16)
        {
            Console.WriteLine($"{age} is too young to play this game");
            return false;
        }
        else
        {
            if (_battle == null)
            {
                //Virtual proxy
                ConnectToBattleNet();
            }

			//실제 로그인 실행
            _battle.Login(id, password);

            return true;
        }
    }
    
    private int GetUserAge()
    {
        Thread.Sleep(1000);

        return new Random().Next(10,20);
    }
}

```

##4. Smart reference proxy
가비지 콜렉터 같은걸 구현할수 있음, 실제 해당객체를 가르키는 포인터 수를 확인하고, 포인터가 없어지면 해당 객체를 릴리즈.
아마 아래와 비슷하게 구현될듯...
```cs
public class ProxyBattleNet : IBattleNet
{
    private int count;

    private BattleNet _battle;

    public void ConnectToBattleNet()
    {
        if (_battle == null)
        {
            _battle = new BattleNet();
            count = 1;
        }
        else
        {
            count++;
        }
    }
    public void DisconnectFromBattleNet()
	{
    	if (count == 1)
    	{
        	_battle.DisconnectFromBattleNet();
    	}
        else
        {
        	count--;
        }
    }

    		.
            .
            .
            생략
}
```
BattleNet class
```cs
public class BattleNet : IBattleNet, IDisposable
{
			.
            .
            .
            중략

    public void DisconnectFromBattleNet()
    {
        Dispose();
    }

    public void Dispose()
    {
        //메모리 정리
    }
}
```