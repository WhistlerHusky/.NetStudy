# Specification pattern
> In computer programming, the specification pattern is a particular software design pattern, whereby business rules can be recombined by chaining the business rules together using boolean logic. The pattern is frequently used in the context of domain-driven design.

https://en.wikipedia.org/wiki/Specification_pattern

```csharp
var specs = new SmartMarinSpecification().And(new DoubleGunSpecification());
```
이렇게 특정 스펙을 만족하는지 And, Or, AndNot, OrNot, Not 등과 같은 비지니스 로직을 Chain 형태로 묶어서 Boolean logic을 확인 할 수 있다.

