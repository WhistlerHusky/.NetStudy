# Domain Driven Design

## Chapter 1. Crunching Knowledge

### Extracting a Hidden Concept

보통 부킹 받을때 Cancle 될껄 대비해서 10% 더 추가 부킹을 받는다고 가정하자,
아래와같이 특정 Model안에 해당 로직이 들어가 버리면, 나중에 찾아서 고치기도 쉽지않고,
여러 개발자들중 해당 로직이 있는지 조차 모르게 되는 경우가 허다해진다.
![screenshot](https://raw.github.com/WhistlerHusky/BookSummaries/master/DomainDrivenDesign/Images/voyage.png)
```csharp
public int makeBooking(Cargo cargo, Voyage voyage) {
double maxBooking = voyage.capacity() * 1.1; //<<---이부분
if ((voyage.bookedCargoSize() + cargo.size()) > maxBooking)
return –1;
   int confirmation = orderConfirmationSequence.next();
   voyage.addCargo(cargo, confirmation);
   return confirmation;
}
```
 아래와 같이 Policy를 [Strategy Pattern](https://github.com/WhistlerHusky/.NetStudy/tree/master/src/NetStudy.DesignPattern/Behavioral/Strategy)
을 이용해서 넣어주면 추후 확장하기 편하고, 팀원들이 하나하나 함수를 찾아보지 않고 멤버변수만 봐도 이런게 있구나 알수있다.
![screenshot](https://raw.github.com/WhistlerHusky/BookSummaries/master/DomainDrivenDesign/Images/voyage2.png)
```csharp
public int makeBooking(Cargo cargo, Voyage voyage) {
if (!overbookingPolicy.isAllowed(cargo, voyage)) return –1;
int confirmation = orderConfirmationSequence.next();
voyage.addCargo(cargo, confirmation);
return confirmation;
}
```
OverbookingPolicy라는 클래스에는 아래와 같은 함수가 포함될껏이다.
```csharp
The new Overbooking Policy class contains this method:
public boolean isAllowed(Cargo cargo, Voyage voyage) {
return (cargo.size() + voyage.bookedCargoSize()) <=
(voyage.capacity() * 1.1);
}
```


