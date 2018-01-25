# Iterator pattern

Iterator 패턴은 일련의 순서를 가진 데이터 집합에 대하여 순차적인 접근을 지원하는 패턴이다.

예를들어 Array, List, Dictionary 등 다양한 종류의 collection에 한가지 인터페이스를 통해 접근할수 있게 해주는 패턴.

```csharp
public interface Iterator
{
    Unit First();
    Unit Next();
    bool IsDone();
    Unit CurrentItem();
}
```

아래와 같이 각자 다른 3가지 collection에 동일한 Iterator 인터페이스 만으로 순환을 하면서 값을 보여줌.
```csharp
Unit[] marins = new Unit[3];
marins[0] = new StupidMarine{ Name = "StupidMarine1" };
marins[1] = new StupidMarine{ Name = "StupidMarine2" };
marins[2] = new StupidMarine{ Name = "StupidMarine3" };

Iterator iterator = new UnitArrayIterator(marins);
Display(iterator);

IList<Unit> firebats = new List<Unit>
{
    new FireBat{Name = "FireBat1"},
    new FireBat{Name = "FireBat2"},
    new FireBat{Name = "FireBat3"},
};

iterator = new UnitListIterator(firebats);
Display(iterator);

IDictionary<int, Unit> medics = new Dictionary<int, Unit>
{
    {0 , new Medic{Name = "Medic1"}},
    {1 , new Medic{Name = "Medic2"}},
    {2 , new Medic{Name = "Medic3"}},
};

iterator = new UnitDictionaryIterator(medics);
Display(iterator);
```