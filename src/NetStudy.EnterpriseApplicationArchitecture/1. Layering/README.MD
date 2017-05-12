# Layering
프로그래밍을 공부하다보면 많이 접하는 용어로 복잡한 소프트웨어 시스템을 논리적으로 여러개의 계층으로 나누는것을 말한다.
이렇게 계층을 나누는 이유는, 서로 연관있는 코드를 한군데 묶고, 서로 연관 없는 코드를 분리하여, 유지보수에 유리하며,
추후에 업뎃이 필요해도, 필요한 부분의 레이어만 추가 혹은 제거, 교체 하면 유지보수가 편해진다.
예를들어 뷰를 담당하는 Layer를 추후에 다른 뷰 Layer로 변경을 해도, 해당 뷰를 관리하는 Layer만 바꾸거나, 다른걸 추가하면, 같은 Data를
다른 화면으로 보여줄수있다.

##3-Tier vs 3-Layer Architecture
3-Tier 과 3-Layer이 흔히 교체가능한 단어로 사용되는데, 정확히 말하면 다르다.

1. 3-Tier
3-Tier은 일반적으로 물리적인 분리를 말한다. Database, network 등등

2. 3-Layer
3-Layer은 일반적으로 논리적인 분리를 말하며, 이 Layer들은 하나의 시스템안에 포함된다.

3. 3-Tier and 3-Layer
이론적으로 3개의 Tier은, 필요한 만큼 Layer을 가질수 있지만, 보통 일반적으로 3개의 Layer을 가진다.(이래서 헷갈린다)
    1. Data Access Layer
    일반적으로 Database와 관련된 코드를 작성하는 곳으로, 최하위 레이어로, 다른 레이어의 존재를 알지 못한다.
    바꿔 말해, 다른 레이어를 Reference 참조할 일이 없다.
    2. Business Layer
    Database에서 가져온 데이터를 어떻게 가공할껀지 비지니스 코드가 작성되는 곳으로, Data Aaccess Layer에 접근하기 위해
    Reference가 필요하다. 바꿔마해 Data Access Layer의 존재를 알고있다. 하지만 다른 레이어의 존재를 알지 못한다.
    3. Presentation Layer
    최상위 레이어로 유저에게 화면을 보여주고, 유저가 입력을 하면 인풋을 받아들이는 역할로 상위 레이어 Business layer의 존재를 알고있다.
    구조에 의해서 Data Access Layer의 존재를 모를수도, 알수도 있다.

4. Layer 사용의 장점
	1. 하나의 Layer를 이해하는데, 다른 Layer를 알 필요가 없다.
	2. 하나의 Layer를 다른 Layer로 비교적 쉽게 교체가능하다.
	3. Dependency를 줄일수있다.
	4. Layer은 표준으로 만들기 쉽다. (IP, TCP)
	5. 하나의 Layer을 제대로 만들면 이를 사용하는 상위 계층 Layer을 얼마든지 만들수 있다. (TCP/IP) 위에 FTP, SSH, HTTP가 존재하듯

5. Layer 사용의 단점
	1. Layer은 완벽하게 캡슐화 되어있지 않을때 cascading change를 요구한다.(화면에 추가로 다른 정보를 보여줘야 할 경우, 1. Database에 해당 데이터 추가, Business Layer에 해당 데이터를 가져오는 로직 추가, Resentation Layer에 이를 보여주는 코드 추가, 총 3개의 수정이 필요)

	2. 너무많은 Layer은 프로그램 성능저하의 원인이 될수있다.
	3. 어떤 책임이 어느 Layer에 포함되어야 하는지 결정하는게 쉽지않다.


