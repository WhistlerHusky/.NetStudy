# Cracking the Coding Interview: 189 Programming Questions and Solutions 5th 
간단하게 각 챕터별 정리

## 1 The Interview Process
### Why?
인터뷰 과정에 내가 사용한 자료구조, 알고리즘, 로직 등에 관해서 Interviewer가 왜 그 방법을 사용했는지에 대해 물어볼것이다.
그러니 문제 풀이에 집중하면서도 내가 해당문제를 어떻게, 왜 그렇게 해결해 왔으면 앞으로도 어떻게 해결해 나갈껏인지 머리속으로 정리를 해야한다.

#### Whiteboards
Whiteboards에 코드를 작성할땐 컴파일이 안되도 되니깐 사소한 오타나, 잘 기억나지 않는 함수명을 정확히 적으려고 하지말고, 큰 그림을 잘 표현하려고 노력하는게 더 중요하다.

#### It's All Relative
몇명의 지원자가 비슷한 시기에 인터뷰를 보던, Interviewer가 interviewee를 판단할때, 그동안 인터뷰했던 모든 interviewee와 비교해서 잘하고 못하고를 비교한다. 그럼으로 어려운 질문을 받았을때, 상대적으로 쉬운 질문을 받은사람과 비교되는게 아니라, 동일한 질문을 받았던 다른사람들과 비교가 되니 부담을 가질필요가 없다.


## 2 Behind the Scenes
인터뷰는 보통 2가지 형태로 진행됨
On-site interview round, 3~6명정도의 사람과 대면하는 인터뷰 이중 1명과는 점심을 같이 먹음(기술적인건 물어보지않음, 회사에 따라 합격했을경우 매니저 될 사람일수도 있음)
Phone Screening, 휴대폰으로 전화하면서 같은 화면을 보면서 코딩을 하면서 interviewer와 대화하면서.

## 3 Special Situations

## 4 Before the Interview

###Employment History
10년 이하 경력은 왠만하면 레쥬메 한장으로 해결하고, 내가 했떤 모던일을 하나씩 하나씩 전부 나열할꺼없이, 무엇을해고, 어떻게 했는지 그리고 그 결과는 어땟는지만 간략하게 적는다.

e.g.
#### 1. Reduced object rendering time by 75% by implementing distributed caching, leading to a 10% reduc­tion in log-in time
#### 2. increased average match accuracy from 1.2 to 1.5 by implementing a new comparison algorithm based on winddiff

### Projects
3~4개 정도의 가장 중요한 프로젝트와 어떤언어, 어떤 기술이 사용되었는지, 혼자한건지, 팀프로젝튼지
그리고 인터뷰 기간중에 이 프로젝트에 대해선 내가 구현한 파트 모든걸 설명할수 있어야함.

사용할수 있는 언어를 적을때 배웠지만 잘 모르면 그냥 적지말고, 어느정도 알고있으면 레벨도 같이 표시

e.g.
#### 1. Languages: Java (expert}, C++ (proficient), JavaScript (prior experience). 

미국지원할때는(캐나다도 마찬가지) 성별, 나이, 결혼유무등 불필요한거 적지말것

언어는 3~4개까지 배워둘것 1,2개만 배운상태면 다른 언어 습득력이 늦을꺼라고 예상할수도 있거나,
다른 언어로 쉽게 할 수있는것을 한 언어만 고집해서 힘들게 한다고 생각할수도 있음.
비슷한 언어끼리는 서로 섞이지 않게 배우는게 좋음

### What are your weaknesses?
매번 나오는질문, 내가 부족한점이 먼지, 그리고 어떤 노력을 하는지 설명하면될듯!

### What questions should you ask the interviewer?
최소 아래 3가지 분류로 준비해가서 꼭 질문할것, 하,,,,첨 캐나다 왔을때 생각난다 ㅠㅠ

#### 1. Genuine Questions e.g. 왜 이 회사에 지원했고, 지금까지 이 회사에서 겪었던거중 힘든거 같은질문
#### 2. Insightful Questions e.g. 해당 회사에서 사용한 기술에 대해 왜 사용했는지, 왜 다른 기술대신 이 기술을 사용했는지
#### 3. Passion Questions e.g. 이 회사에 내가 지원하면 어떤 기술과, 어떤 사람들과 같이 일할수있는지 와 같은 질문

### Responding to Behavioral Questions
#### 1. 거만하지 않고, 명확하게 답하기
#### 2. 너무 디테일하게 하지않고, 적당히 추상화 해서 말하고, Interviewer가 원하면 좀더 깊이있게 대답할것
#### 3. 팀이 무엇을 했는지보다, 본인이 무엇을 했는지 위주로
#### 4. Give Structured Answers

### So, tell me about yourse
이건 안물어보는 회사가 없다.
1. 은근히 내가 잘한거 흘려 말하기

## 4. Big O
(이부분은 틈날때마다 반복해서 볼것 페이지 책 38p, pdf 49p)
몰랐던것들

#### 1. 똑같은 배열을 가지고 두개의 반복문이 중척되면 (N2)이고, 서로 다른 배열(a,b)을 가지고 반복문이 중첩되면
O(ab) 이다. 이건 잘 기억해두자, 알고리즘이 복잡해지면 모든배열을 N으로 대처하다보면 a*b를 N2으로 말하는 실수가 발생한다.
문제를 풀때는 각 배열마다 고유의 이름(a,b 혹은 m,n)을 주면 이런 실수를 줄일수있다. 이부분 이해안되고 까먹었으면 PDF 49p 8번문제 참고해서 다시 이해할것

#### 2. 세개의 중첩된 반복문에 서로다른 배열 (a,b 그리고 10000개 중복)이 있어도 이건 O(ab) 이고 10000개는 상수로 취급받는다.
#### 3. for(int i = 0 ; i < A.Length / 2; i++) 이라고 해도 O(n)으로 표기 O(n/2) 라고 안함.

#### 4. 아래껀 무조건 책보고 다시 암기할것
```csharp
int sum(Node node) { 
 if (node == null) { 
    return 0; 
 } 
 return sum(node.left) + node.value + sum(node.right); 
} 
```
보통의 재귀함수는 이런경우 2N으로 지수승이 되지만, 노드는 어찌되었든 Node 갯수만큼(N) 돌기 때문에
O(N)이다.

5~8까진 책만 읽느라 정리못함.

## 9. Interview Questions
### Trees and Graphs
#### Tries (Prefix Trees)
내용 보고 뭔지 이해했는데, 학부때 배웠는지 안배웠는지 기억이 안남.
(책에서도 보통 알고리즘 책에서 아주 짧게 설명하고 끝난다고 나옴) 근데 문제에서 이와 관련된 내용은 많이 봐서 정리
n-ary tree이고 주로 각 노드에 1개의 Character가 저장되고, 그 자식 노드를 따라가면 단어가 완성됨. 완성된 단어는 자식으로 끝을 표현하는 내용을 가짐
책에서는 * 가 사용됨었음. 만약 M->A->N->Y 가 있으면
N의 자식으로 Y도 있고 * 도 있어서 MAN이 하나의 단어가 되고 또한 그 아래 Y까지 가면 MANY라는 단어도 됨(물론 Y도 * 자식을 가질꺼임)
처음 글짜 M의 자식으로 Y를 넣어도 MY라는 단어가 완성되고, 이 Y는 N의 자식Y랑은 서로 다른 노드임(그리고 이 Y도 물론 * 자식을 가져서 MY라는 단어가 완성됨)

Tree에서 Pre-order가 DFS이지만 Graph에서 이를 사용하려면 이미 방문한 곳을 체크하는 메카니즘이 필요, 그렇지 않으면 무한루프빠짐.
root.visited 라는 boolean 을 두면 이를 피할수 있음.

Breath-First-Search 와 Bidirectional Search
이건 그림 한장으로 이해하면 빠를듯.

![screenshot](https://raw.github.com/WhistlerHusky/.NetStudy/master/Books/CrackingTheCodingInterviews/images/BFSvsBidirectionalSearch.png)

BFS는 4번을 돌아야 t를 만나는데, B-S는 각 목적지와, 출발지에서 동시에 출발하기 때문에 2번씩 돌면 교점이 생김(교점이 생긴다는 말은 지나가는 통로)

### Bit Manipulation
2의 보수법으로 음수를 표현하는 방법
1. 모든 비트를 뒤집는다. 예를 들어 양수가 00100000 였다면 11011111 (1의 보수)
2. 여기에 1을 더한다. 예를 들어 11011111였다면 11100000
e.g. 00100000(32)을 2의 보수법에 따라 음수로 인코딩한 값은 11100000(-32)이다.
     
\>> 1 두배 작아지고, \<< 1 두배 크진다.
C#에서는 >>> 없지만 자바와 C같은데서 \>>> 짜리도 있다. 이 경우 -의 경우에 앞에 sign 비트가 0으로 바뀌어서 양수로 바뀌어 버린다.
이를 두고, Logical Right Shift한다. 

sign을 그대로 가지면서 이동하는것을 Arithmetic Right Shift 라고한다.
 
특정 번째 비트 가져오는것과 설정하는법
```csharp
boolean getBit(int num, inti) 
{ 
    return ((num & (1 << i)) !=  0);
} 

int setBit(int num, inti) 
{  
    return num | (1 << i);
} 

int clearBit(int num, int i)  
{
    int mask = ~(1 << i); 
    return num & mask; 
} 
```

### Object-Oriented Design
OOD 관련 어떤일을 하는 클래스를 만들어라 하면
1. Core Objects를 만들고
2. Objects끼리의 관계를 분석하고
3. 각 Object에 필욜한 Action을 넣으라
4. 

### Recursion and Dynamic Programming
DP는 보통 재귀혹은 반복함수의 값을 Cache(memoization) 해서 사용하는 문제.

Recursive call을 Tree로 표현하면 이해하는데 큰 도움이 됨.

DP문제는Top-Down(재귀)나 Bottom-Up(반복문)으로 해결됨

### System Design and Scalability

#### Handling the Questions
1. <b>Communicate</b> : Interviewer가 내가 설명하는걸 이해하고 있는지 놓치는게 없는지, 잘 맞춰서 진행
2. <b>Go broad first</b> : 나무보단 숲을 먼저 설명하고, 그담 필요한 부분에 대해서만 나무까지 설명
3. <b>Use the whiteboard</b> : Whiteboard에 적어가면서 설명하면 Interviewer가 내 설명을 놓치거나, 잘 이해 안되는부분도 다시 보면서 이해가 될수있음
4. <b> Acknowledge interviewer concerns</b> :  내 설명에 의문을 가진 Interviewer 뭔가 의문을 제시하거나, 하면 왜 그런 의문을 제시했을것인지, 내가 한 설명에 오류가 있을수 있음을 인정하라
5. <b> Be careful about assumptions</b> : 가정하지마라,
6. <b> State your assumptions explicitly</b> : 뭔가 가정할꺼면, 분명하게 말하라, Interviewer가 듣고 잘못된걸 지적해주면 보다 일찍 문제를 발견할수있다.
7. <b> Estimate when necessary</b> : 현재 갖고 있지 않은 정보에 대한 질문일경우, 그 정보에 관련이 있는 정보를 가지고 추측해서 사용하라.
8. <b> Drive</b> : Interviewer에게 끌려가지말고, 내가 대화를 끌고가야한다.


