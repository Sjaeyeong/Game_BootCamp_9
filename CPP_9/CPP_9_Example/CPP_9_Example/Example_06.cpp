#include <iostream>
// 문자열 → 아.. 문자열 또는 문자에 관한 그 무언가의 기능이 있는 헤더구나...
#include <string>

using namespace std;

#pragma region 함수
/*

 ▶ 함수란?

 - 구조적 프로그래밍의 대표적인 문법 중 하나

 - 미리 정해진 동작을 수행하는 코드 묶음이다.
	ㄴ 어떤 처리를 미리 함수로 만들어 두면 반복적으로 재사용할 수 있다.

 - 함수를 사용하는 이유
	ㄴ 중복 로직 제거 / 관리 용이함 / 가독성 ↑ / 편리함

 ● 함수를 선언하는 방법

 반환 자료형 함수이름 (입력 자료형 인자)
 { ← 함수 시작

	함수 내용

} ← 함수 끝

 - 함수 이름 : 말 그대로 함수의 이름인데.. (함수를 실행할 때 사용이 된다. (호출))
 - 인자 : 함수가 처리할 작업에 필요한 재료들 (생략이 가능)
 - 반환 자료형 : 함수가 돌려주는 결과값의 자료형 (return)
 - 함수 내용 : { } 안에 실제 코드가 존재한다.

 ※ 같은 범위에서 같은 이름 + 같은 매개변수 형태의 함수는 중복 정의할 수 없다.
	ㄴ 같은 공간에서 동일한 이름의 함수를 n개 이상 선언하는 것은 불가능
	ㄴ ★ 다만, 차후 배우게될 함수 오버로딩을 이용하면 같은 이름을 사용할 수 있다.

 ▷ void형 함수란?

 - 반환할 값이 없는 함수

 - 함수의 입력 또는 출력이 없을 경우 void 키워드를 통해 해당 함수가 입출력이 없음을 명시해야 한다.


 - 우리가 알게 모르게 사용한 함수들
	ㄴ rand() : 랜덤값을 뽑는 함수
	ㄴ Sleep(1000) : 1초간 멈추게 만드는 함수

 - 1차적으로 알 수 있는 합리적 의심 → 함수인가? 함수같은데...?

 ※ 함수 선언은 기본적으로 main 함수 위쪽에 작성한다.


 ▷ C/C++ 언어의 함수 선언이 필요한 이유

 - C/C++ 언어의 컴파일러는 기본적으로 파일의 내용을 위에서 아래로 해석한다.
	ㄴ 이때 컴파일러가 이미 지나친 라인에서 포함되어 있지 않은 함수를 호출 할 경우 컴파일러가 이에 대한 내용을 모르기 때문에 에러가 발생한다.

 - 그렇기 때문에 함수의 선언을 통해서 컴파일러에게 해당 함수가 파일 어딘가에 존재한다는 여부를 알려줘야 한다.

 - 함수의 선언과 정의는 반드시 같은 위치에 있을 필요는 없다.
	ㄴ 함수의 선언은 여러번 가능하지만, 함수의 정의는 하나만 존재해야 한다.

 - 함수의 이름은 팀 규칙에 맞게 짓는것이 아주 좋다.
	ㄴ 카멜이 맞긴한데... → UE → C# => 파스칼



*/
#pragma endregion

#pragma region 함수 선언
void ExampleFunction_A();
// 인트형을 받지만 반환하지 않는다.
void ExampleFunction_B(int numA);
void ExampleFunction_C(int numA, int numB);

// 문자열 함수
void PrintString(string str);
string CombineString(string strA, string strB);
bool CompareStrings(string strA, string strB);

// 반환값이 있는 함수 (사칙)
// 더하기
int GetAddValue(int numA, int numB);
// 빼기
int GetSubValue(int numA, int numB);
// 곱하기
int GetMulValue(int numA, int numB);
// 나누기
int GetDivideValue(int numA, int numB);
#pragma endregion

// 표준 C++ 기준으로 main() 함수의 반환형은 int 줘야 한다.
//	ㄴ void로 줘도 동작은 하지만...
//	ㄴ 진입점이자 프로그램이 끝났을 때 결과를 OS에게 알려주는 함수
//	ㄴ 프로그램 종료시 → OS → 종료 상태 코드(Exit Code)를 돌려준다.

int main()
{
	// 함수 콜 / 호출
	
	ExampleFunction_A();
	ExampleFunction_B(5);
	ExampleFunction_C(1, 9);
	PrintString("과제가 너무 쉽다.");

	// 확장성 → 재활용을 하고 싶다라는 의지가...
	int nResultA = GetAddValue(18, 25);

	// 미스매치
	// 확장성이 죽고 좋지 않다.
	// cout << nResultA;

	ExampleFunction_B(nResultA);

	string sResultB = CombineString("쉽다", "쉬워");
	PrintString(sResultB);

	nResultA = CompareStrings("과제 더 내주세요", "과제 더 내주세요");

	ExampleFunction_B(nResultA);

	int numL = 0;
	int numR = 0;

	cout << "정수 (2개) 입력 : " << endl;

	cin >> numL >> numR;

	// C
	printf("%d + %d = %d\n", numL, numR, GetAddValue(numL, numR));
	printf("%d - %d = %d\n", numL, numR, GetSubValue(numL, numR));
	printf("%d * %d = %d\n", numL, numR, GetMulValue(numL, numR));
	printf("%d / %d = %d\n", numL, numR, GetDivideValue(numL, numR));

	cout << '\n';

	// C++
	cout << numL << " + " << numR << " = " << GetAddValue(numL, numR) << endl;
	cout << numL << " - " << numR << " = " << GetSubValue(numL, numR) << endl;
	cout << numL << " * " << numR << " = " << GetMulValue(numL, numR) << endl;
	cout << numL << " / " << numR << " = " << GetDivideValue(numL, numR) << endl;

	/*
	 함수는 다양한 유형을 가질 수 있다.

	 C/C++ 함수의 유형
	 - 입력 O, 출력 O
	 - 입력 O, 출력 X
	 - 입력 X, 출력 O
	 - 입력 X, 출력 X
	
	 
	 Ex)
		void ShowInfo(int nAge, char psName);				입력 O, 출력 X
		int GetRandomValue(void);							입력 X, 출력 O
		void SomeFunction(void);							입력 X, 출력 X
	
	*/



	// 정상 종료 (종료 상태 코드)
	return 0;

	// 에러가 있거나 비정상 종료 의미로 쓰는 경우가 많다. (0이 아닌 값을 돌리면)
	// return 1;
}

/*
 
 - 함수는 특정 작업을 수행하도록 만든 코드 묶음이다.
 - C/C++ 프로그램의 실행 시작점은 우리가 알고 있는 main
 - 실행되는 문장은 보통 함수 안에 작성한다.


*/

#pragma region 함수 정의
void ExampleFunction_A()
{
	cout << "내가 함수이다." << endl;
}

void ExampleFunction_B(int numA)
{
	cout << numA << endl;
}

void ExampleFunction_C(int numA, int numB)
{
	cout << numA << numB << endl;
}

void PrintString(string str)
{
	cout << str << endl;
}

string CombineString(string strA, string strB)
{
	// return은 함수를 즉시 종료하고 → 함수의 결과 값을 호출한 곳으로 돌려준다.
	// 함수의 결과값은 한번에 하나만 반환할 수 있다.
	// return : 함수를 즉시 종료하고 값을 돌려준다.
	// void : 값을 돌려주지 않는다.

	// 프로그래밍에서 함수는 흔히 음료수 자판기에 비유한다.

	// char* / const char* / char[]
	// string → char
	// C/C++ : 둘다 사용할 수 있게 선택의 폭을 열어주고
	// C# : string을 사용하게끔 유도
	// char

	// char

	return strA + strB;
	// 나비효과를 발생시킨다. → 안정성 검사 전혀 안되어 있는 날 코드
	//	ㄴ 조건문으로 예외처리를 해줘야 함

	// C++은 선택
	// C#이 많이 좋아하는 방식
	// append : 문자열 뒤에 다른 문자열을 이어 붙인다.
	//return strA.append(strB);
}

bool CompareStrings(string strA, string strB)
{
	// t / f
	return strA == strB;
}

int GetAddValue(int numA, int numB)
{
	return numA + numB;
}

int GetSubValue(int numA, int numB)
{
	return numA - numB;
}

int GetMulValue(int numA, int numB)
{
	return numA * numB;
}

int GetDivideValue(int numA, int numB)
{
	return numA / (float)numB;
}
#pragma endregion