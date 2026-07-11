#include <iostream>
#include <time.h>

#pragma region 자료형 + 변수 선언
/*
 ▶ 자료형 (Data Type)

 - 자료의 형태를 지정하며 변수의 종류를 의미한다고 할 수 있다. (기초 자료형)

 - 데이터가 메모리에 저장되는 형태와 처리되는 방식을 명시하는 역할과 컴퓨터에게 여러 형태의 자료를 저장하기 위함.

 ● 변수란
 
 - 변할 수 있는 숫자나 데이터를 의미한다.
	ㄴ 컴퓨터로 하여금 값을 저장 할 수 있는 메모리 공간에 붙는 이름이다.

- 변수를 이용하면 특정 값을 저장 후 해당 값을 여러가지 연산을 처리하는 것이 가능하다.


 ▶ C/C++ 언어에서 지원하는 자료형 종류

 - 정수형 : 소수점이 없는 수를 표현하기 위한 자료형
	ㄴ short : 2 바이트 크기를 지니는 자료형 (범위 : -32767 ~ 32767(8))
	ㄴ int : 4 바이트 (범위 : -21억 ~ 21억)
	ㄴ long : 4 ~ 8 바이트
	ㄴ long long : 8 바이트

 - 실수형 : 소수점이 존재하는 수를 표현하기 위한 자료형
	ㄴ float : 4 바이트 (일반적으로 6 ~ 7 자리까지 표현 가능)
	ㄴ double : 8 바이트 (일반적으로 15 ~ 16 자리까지 표현 가능)
	ㄴ long double : 8 ~ 16 (소수점 18자리 이상)

 - 문자형 : 문자를 표현하기 위한 자료형
	ㄴ char : 1 바이트 (정수를 담고 있음 / 아스키 코드)

 - 논리형 : 참 또는 거짓을 판별하는 자료형
	ㄴ bool : 1 바이트 (0은 거짓, 1은 참)
		ㄴ C++ 언어는 참 또는 거짓을 나타내는 키워드로 참 또는 거짓을 표현하는 것이 가능하다. (true / false)


 ● signed

 - C/C++ 자료형은 기본적으로 음수를 표현하는 것이 가능하다.

 - 다만 경우에 따라서 음수를 표현하지 않고 양수를 좀 더 크게 표현할 수 있다.

 - singed / unsinged
	ㄴ singed : 기본적인 정수 타입은 signed가 기본이다.
	ㄴ unsigned : 음수를 표현하지 않지만 같은 비트 수에서 양수 표현 범위를 2배까지 늘릴 수 있다.


 ▶ 변수 선언

 - 값을 저장할 수 있는 메모리 공간에 이름을 정의하는 것을 뜻한다.

 - 자료형의 선언하고 빈칸 뒤에 변수 이름을 작성하여 변수 선언한다.

 - 변수는 (1)선언과 동시에 초기화 과정을 진행하거나 (2)선언만 해두고 이후 할당할 수 있다. (기본)

 Ex)
	변수 형태(종류) 변수명;
	ㄴ int num;
	ㄴ 대입 연산자 → 결합 방향은 오른쪽에서 왼쪽으로 
	ㄴ int num_2 = 20;

 - 변수의 선언으로 인해서 num_2 라는 이름으로 메모리 공간이 할당
	ㄴ =20은 단순히 20을 저장하는게 아니라 num_2가 의미하는 메모리 공간에 20을 넣어라 라는 의미다.


*/
#pragma endregion

// 개발자로 생각해볼 문제점도 있고 / 컴퓨터도 싫어함
//	ㄴ 효율적인가..? 를 고민해봐야 함
//	ㄴ std에는 cout, endl 뿐만 아니라 다양한 기능들이 있다.
// using 지시자 : 지정한 네임스페이스의 모든 명칭을 이 선언이 있는 영역으로 가져와 지정없이 명칭을 바로 사용 가능

// 추론 + 논리 사고를 키우는 과정이 지금은 매우 중요하다.

// 1
using namespace std;

// 2 ← 필요부분만 따로 사용하여 메모리 낭비를 방지한다.
using std::cout;
using std::endl;
using std::cin;


void main()
{
	// std::abs
	
	std::cout << "" << std::endl;

	/*cout << endl;*/

#pragma region 예시 출력
	//bool 자료형 및 true false는 정수가 와야 할 위치에 오게되면 각각 1과 0으로 반환될 뿐 정수 0과 1이 아니다.

	/// 1
	int TestNumA = true;
	/// 0
	int TestNumB = false;
	int TestResult = TestNumA + TestNumB;

	// 1
	cout << "bollean : " << TestResult << endl;

	cout << endl;

	// 변수 초기화 방법
	//	ㄴ 다양한 방법이 있지만 일반적으로는 자료형 + 변수 이름으로 선언 가능

	// 1. 선언 이후 값 할당
	int num0;
	num0 = 10;

	// 2. 선언과 동시에 초기화
	int num1 = 3;
	int num2 = 6;

	/*int num3;
	int num4;
	int num5;*/

	int num6, num7, num8;
	num6 = num7 = num8 = 100;


	// sizeof() 키워드를 이용하면 변수 또는 자료형의 크기를 계산하는 것이 가능하다.
	cout << "정수 1 사이즈 " << sizeof(1) << endl; // 4
	cout << "정수 2 사이즈 " << sizeof(2) << endl; // 4
	cout << "true 1 사이즈 " << sizeof(true) << endl; // 1
	cout << "false 1 사이즈 " << sizeof(false) << endl; // 1

	cout << endl;

	int nValue = 0;
	// C++ 스타일
	cout << "숫자를 입력하시오 : ";
	cin >> nValue;

	cout << "내가 입력한 숫자 : " << nValue << endl;
	cout << endl;

	// C 스타일
	printf("정수 입력 : ");
	scanf_s("%d", &nValue);
	printf("내가 입력한 숫자 : %d", nValue);
	cout << endl;

	cout << endl;


	short ValueA = 10;
	int ValueB = 20;
	long ValueC = 30;
	long long ValueD = 40;

	// C 언어
	printf("C 언어 short : %hd, %d\n", ValueA, sizeof(ValueA)); // << 타입 불일치 경고 / 불필요한 메모리 사용
	printf("C 언어 int : %d, %zu\n", ValueB, sizeof(ValueB));
	printf("C 언어 long : %ld, %zu\n", ValueC, sizeof(ValueC));
	printf("C 언어 long long : %lld, %zu\n", ValueD, sizeof(ValueD));

	cout << endl;

	// C++
	cout << "C++ short : " << ValueA << ", " << "사이즈 : " << sizeof(ValueA) << endl;
	cout << "C++ short : " << ValueB << ", " << "사이즈 : " << sizeof(ValueB) << endl;
	cout << "C++ short : " << ValueC << ", " << "사이즈 : " << sizeof(ValueC) << endl;
	cout << "C++ short : " << ValueD << ", " << "사이즈 : " << sizeof(ValueD) << endl;

	cout << endl;


#pragma endregion

	// ※ 4일차 시작
	// C 언어 출력 및 서식
#pragma region 서식 문자
 /*
  ▶ 서식문자
  - 서식 문자는 문자열을 출력 또는 입력을 받을 때 해당 서식 문자의 자리를 다른 수로 대체하기 위한 자리 매김 역할을 하는 문자를 의미한다.

  - 서식 문자를 이용하면 고정되어 있지 않는 문자열을 출력 또는 입력 받는 것이 가능하다.

  → 프로그래밍 언어
  ※ 로우 레벨 언어 vs 하이 레벨 언어 (C vs C++ / C#)

  ● 서식 문자의 종류

  - %hd : short <<
  - %hu : u short
  - %d : int형 정수 <<
  - %ld : long형 정수
  - %lld : long long형 정수
  - %c : char형 문자를 대체하는 용도 <<
  - %s : 문자열 입력 (char 배열) <<
  - %f : lfoat형 실수를 대체하는 용도 <<
  - %lf : double형 실수를 대체하는 용도
  - %zu : size_of 출력용 <<

  → 서식문자에선 필요에 의해서 사용하는 심화
  - %e
  - %g
  - %u
  - %o
  - %x


  → 써야하는 상황이 생긴다.
  ● 특수문자

  - \n : 개행
  - \t : 수평 탭
  - \v : 수직 탭
  - \\ : \
  - \' : '
  - \" : "
  - \? : ?
  - \0 : null 문자


 */
#pragma endregion

	cout << "오늘 날씨가 \"매우 덥다.\" " << endl;

	// cout (printf()) / cin (scanf())

	printf("환영합니다 \n");

	// 무조건 지키기
	// c + F5 : 빠르게 테스트 / F5 : 버그를 메모리 단위 혹은 CPU 단위까지 확인하며 고치고 싶을 때

#pragma region 변수 표기법
/*
 ▶ 변수 표기법

 - 변수 표기법은 프로그래머에게 아주 중요하다.

 1. 헝가리안

 - 예전 절차지향적 방식으로 코딩할 때 이 변수가 어떤 자료형인지 알기 위하여 변수 앞에 자료형 형태를 명시함 (주로 약자를 붙인다.)

 Ex)
	int number → nNumber
	float ValuA → fValueA

 - C#의 경우, 경우에 따라 o를 붙이기도 한다.

 - 표기법은 대부분 내가 사용을 안한다고 하더라도 규약 / 규칙 정도는 알아둬야 한다. → 협업, 같이하는 일

 - 엔진에서는 사용되는 추세


 2. 카멜 << 메인 표기법

 - 객체지향적 방식의 코딩으로 전환되며 가독성을 위해 나온 표기법 (단어의 앞글자를 대문자로)

 Ex)
	int playerselctnumber → playerSelctNumber


 3. 파스칼 케이스

 - 앞글자를 대문자로 표기

 Ex)
	int playerselctnumber → PlayerSelctNumber

 
 4. 스네이크

 - 단어를 _로 끊어서 표기한다. → 주로 헝가리안 / 파스칼과 혼용되는 경우가 많음

 Ex)
	int playerselctnumber → Player_Selct_Number


 ● 표기법을 활용한 변수 이름의 특징

 - 기본적으로 변수의 이름은 알파벳 /숫자 /언더바로 구성이 된다.

 - 3가지만 기억하면 좋다.
 ㄴ 1. 변수의 이름은 숫자로 시작할 수 없다.
 ㄴ 2. 키워드도 변수 이름으로 사용할 수 없다.
 ㄴ 3. 이름 사이에 공백이 삽입될 수 없다.

 Q1.
	1. int Num100;
	2. int Num101;
	3. int _Num102;
	4. int 5Num;    X
	5. int Num ber;    X
	6. int bool;    X
	7. int @Value;    X

 Q2.
	1. int printf; << 사용은 되나 안쓰는게 좋음
	2. int _Line_01;
	3. int __Value__;
	4. int class;    X
	5. int new-user;    X


*/
#pragma endregion

	 // 랜덤 시드

	 // C++11 ↓

	 // rand() : 랜덤 함수 → 랜덤한 숫자를 반환 한다. (불안전 난수)
	 // RAND_MAX → (int)32767
	 // ㄴ (int) : 형변화 (데이터 타입이 바뀐다)

	 // '/' : 나누기 (몫 : 남긴다.		나머지 : 버린다.)
	 // '%' : 나누기 (몫 : 버린다.		나머지 : 남긴다.)

	// rand()는 의사 난수를 생성하는 함수이자 이 의사 난수는 사실 특정 시드를 바탕으로 수열을 만들어낸 일종의 계산
	// ㄴ 별도로 시드를 설정하지 않으면 내부적으로 기본 시드로 시작을 한다. (1)
	// 매번 프로그램을 실행해도 항상 동일한 랜덤 결과가 나온다.
	// 매번 다른 난수 수열을 만드려면 현재 시간을 기반으로 시드를 생성하는 것이 좋다.
	// ㄴ 이렇게 해두면 프로그램 실행 시점마다 시드가 달라져서 rand()의 결과 패턴도 매번 달라진다.

	// ※ srand(time(NULL)) << 시드를 설정해줌


	int numR;

	// 0 1 2 3 4
	numR = rand() % 5;

	cout << numR << endl;
	
	// 게임에서 많이 사용한다.

	// 무기 데미지
	// 20 ~ 25
	int weaponA = 0;

	weaponA = rand() % 6 + 20;

	cout << "무기의 데미지 값 : " << weaponA << endl;



}