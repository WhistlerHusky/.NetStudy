# Lock

Lock에 사용하는 객체는 오직 Reference type만 사용가능
그 이유는 Reference type은 RTTI(RunTime Type Information) 과 Object Header필드를 따로 가지는데 이 Object Header에 현재 사용중인 
Thread Id의 정보(Sync block)가 담김
## Referecne type

[4B] [4B] [4B] [4B] [4B]

 OH  RTTI Instance Fields

## Referecne type
[4B] [4B] [4B] [4B] [4B]
Instance Fields
