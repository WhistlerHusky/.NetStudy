# Domain Driven Design Quick
Domain Driven Design의 요점 판으로 InfoQ에서 무료로 패포중인 책
DDD를 원서로 첨부터 읽는데 조금 붕뜬 구름 잡는 느낌이여서 이책을 먼저 읽기로함.

## Chapter 1. What Is Domain-Driven Design
Developer, Software specialist그리고 Domain Expert(해당 프로젝트의 프로세스를 잘 아는 사람 e.g. 차에 관한 프로그램을 만든다면 차에 대해 잘 아는사람)간 도메인을 중심으로 두고 커뮤니케이션 하며, 서로 피드백을 주고 받으면서 개발 하는 방법론.


## Chapter 2. The Ubiquitous Language 
Developer, Software specialist 그리고 Domain Expert간 소통하기 위한 통일된 언어를 사용하는거.
보통 개발자는 개발전문적인 용어를, Domain Expert도 본인만 잘 아는 전문 용어를 사용해서 의사소통에 혼돈을 가져오기 때문에 Model을 중심으로 같은 용어를 사용하는것.
여기에 포함된 사람들은 모델링을 할때 최대한 이 용어에 신경어 쓰면서 대화를 이루어 가야한다. 매번 용어가 변경되면 혼돈을 가져올 수 있다.

* 모델 수가 적을땐 UML이 유용할 수 있지만, 너무 많으면 복잡해짐
* 하나의 다이어그램 안에 관련된 모델을 넣어서 묵는 방법

## Chapter 3. Model Driven Design
디자인 할땐 모델을 중심으로 디자인하고, Software specilist 뿐만 아니라 Developer도 디자인에 참여를 하는게 좋다.

일반적으로 DDD는 아래 4가지 Conceptual Layers 가진다.

* User Interface (Presentation Layer) - Responsible  for  presenting  information  to  the  user and interpreting user commands. 

* Application Layer - This  is  a  thin  layer  which  coordinates  the  application activity.  It  does  not  contain  business  logic.  It  do
es  not hold  the  state  of  the  business  objects,  but  it  can hold the state of an application task progress. 
* Domain Layer - This  layer  contains  information  about  the  domain.  This is  the  heart  of  the  business  software.  The  state  ofbusiness   objects   is   held   here.   Persistence   of   the 
business objects and possibly their state is delegated to the infrastructure layer. 
* Infrastructure Layer -This  layer  acts  as  a  supporting  library  for  all  the other layers.   It   provides   communication   between   layers, implements  persistence  for  business  objects,  contains supporting libraries for the user interface layer, etc. 

### Aggregates
하나의 유닛으로 취급가능한 여러 도메인들의 집합.
![screenshot](https://raw.github.com/WhistlerHusky/BookSummaries/master/DomainDrivenDesignQuick/Images/aggregates.png)

밖에서는 Customer을 통해서만 접근 하게 해야함. <B>UML에서 사용되는 Aggregate와는 다른 뜻<B>

### Factories
일반적으로 ojbect A를 생성하기위해, 그 object안에 있는 또다른 object B,C,D에 대한 생성 방법을 알게되면 이건
Encapsulation 위반이 됨 e.g. 커스트머 클래스내에서 Address가 어떻게 생성되는지 알게되면 이는 캡슐화 위반.
하지만 생성 방법을 알아야 하는 일이 비일비재하게 발생되기 때문에 생성에 관한 지식을 모두 Factory로 위임(위반)시킴. 
바꿔말하면 생성에 관한게 변경되면 Factory도 업데이트 해줘야함. 여기서 나온 Design pattern 2가지가 
Factory pattern 과, Abstract Factroy pattern.

### Repositories
원래 DDD Repository는 주로 이미 존재하는 domain 을 data로 맵핑하는 단계에서 사용하기 위함인데, 요즘은 이게 좀더 확장되어 보통 CRUD를 하기 위해 사용됨
Factory는 항상 뭔가를 새로 생성하는것이고, Repository는 주 입무는 불러오는거, 없으면 새로 만들어서 리턴도 가능


## Chapter 4. Refactoring Toward Deeper Insight
추후에 리팩토링을 생각하더라도 처음 코딩하면서 최대한 Flexible하게 하지않으면 나중에 리팩토링이 상당히 힘들어 지고, 심지어 리팩토링 과정에 문제가 발생할수도 있음
가능하면 테스트 케이스를 작성해서 리팩토링 이후에 문제 발생시 바로 발견가능하게 하는게 좋음. 

Domain level 코드가 Application level로 올라가야 할 경우
e.g. 고객 신용을 체크하는데,  고객의 어카운트에 남은 잔액, 이전 신용카드 사용 내역 등등 고객정보뿐 아니라, 다른 도메인의 정보도 필요로 할 경우 이 코드 검사는 Application level(service)로 올라가야함.


## Chatper 5. Preserving Model Integrity 

## Chatper 6. DDD Matters Today: An interview with Eric Evans
딱히 기억해야 될만큼 중요한 내용 못찾겠음.



