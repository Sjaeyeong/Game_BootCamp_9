#include <iostream>

using namespace std;

#pragma region 조건문
/*
 
 ▶ 조건문이란?

 - 프로그램이 실행되는 동안 정해져 있는 경우에 수에 맞춰서 서로 다른 결과를 도출하기 위한 문법을 의미한다.
	ㄴ 조건에 따라 실행이 달라지게 할 때 사용하는 문장

 - 조건문을 이용하면 다양한 결과를 출력하는 프로그램을 작성하는 것이 가능하다.


 ● C/C++ 언어 조건문의 종류

 1. if ~ else 조건문

 2. switch ~ case 조건문


 ▶ if ~ else 문

 - 조건적 실행 (조건에 따라 실행 유무)

 - 조건식의 true / false에 따라 실행할 블록을 결정하는 조건문

 - 조건을 만족하는 if문을 발견하면 나머지 if문을 건너뛴다. (하나의 문장으로 작성했을 시)

 - if ~ else가 만나서 이루는 문장의 수는 둘이 아니라 한개라고 보면 된다.

 - if ~ else문에서 조건의 만족여부 검사는 위에서 아래로 → 절차지향

 - 조건이 만족되어 해당 블록을 실행할 시 마지막 else 문까지도 건너뛴다.
	ㄴ 조건을 만족하지 않으면 else문 실행


 Ex)
	if (조건식)
	{
		조건식이 참이면 실행될 코드
	}

	else if (조건식)
	{
		조건식이 참이면 실행될 코드
	}

	else (조건식)
	{
		위 조건들이 만족되지 않으면 실행될 코드
	}

 
 ▶ switch문

 - 스위치문을 사용하는 경우는 일일이 조건별로 세팅을 해주기가 용이하기 떄문에 상태 변화, 조건이 많은 경우에 사용하면 좋은 효율을 낼 수 있는 문법이다.

 - 조건값에 따라 실행할 시작 지점을 결정하는 조건문
	ㄴ 여러 경우 중 하나를 선택해야 할 때 유용하다.

 - if ~ else문과 비슷한 기능을 하지만 조건 자체가 "값의 일치 여부" 일 때 더 효율적이고 가독성이 좋다.
	ㄴ 흡사하다는 특성은 덤


 → 데이터 타입의 위치에는 int형 + char 형이 올 수 있다.
 Ex)
	switch (Data Type)
	{
		case 1:
			break;
		case 2:
			break;
		~
		~
		~
		default:
			break;
	}

 
 ▶ C/C++ 언어 제어문의 종류

 1. return
 ㄴ 조건문일 때는 다시 돌려보낸다. (함수에서 즉시 탈출 → 함수에서는 값을 반환하고 초기화 한다.)
 ㄴ 조건이 참이면 함수 실행을 중단하고 바로 밖으로 나간다.

 2. continue
 ㄴ 조건문일 때는 연산을 하지 않고 뛰어 넘는다. / while문에서는 바로 이전 문항으로

 3. break
 ㄴ 만나면 멈춘다. / while문의 경우 while문을 빠져 나온다.
 ㄴ break문은 반복문을 탈출하는 용도로 사용하면 편하다. → break의 유무에 따라 

 4. goto
 ㄴ 점프문이라고 불리며 goto에 라벨을 지정하며 지정된 라벨로 이동한다. (즉시)


*/

#pragma endregion


void main()
{
	int nInput;

	cout << "내가 입력한 숫자 : ";
	cin >> nInput;

	if (nInput == 0)
	{
		cout << "첫번째 " << endl;
	}

	else if (nInput == 1)
	{
		cout << "두번째 " << endl;
	}

	else
	{
		cout << "그외 (나머지) " << endl;
	}

	cout << '\n';

	int inputNumber;

	cout << "0번, 1번, 2번 중 하나를 선택" << endl;
	cout << "InputNumber : ";
	cin >> inputNumber;

	switch (inputNumber)
	{
		case 0:
			cout << "0번 입력시 출력" << endl;
			break;
		case 1:
			cout << "1번 입력시 출력" << endl;
			break;
		case 2:
			cout << "2번 입력시 출력" << endl;
			break;
		default:
			cout << "그외 입력시 출력" << endl;
			break;
	}


	int nValueA, nValueB, nValueC, nValueD;
	nValueA = nValueB = nValueC = nValueD = 10;

	if ((nValueA == nValueB++) && (nValueC++ < ++nValueD))
	{
		cout << nValueA << endl;
		cout << nValueB << endl;
		cout << nValueC << endl;
		cout << nValueD << endl;
	}

	// 6일차 강의 시작

	for (int i = 2; i < 100 + 2; i++)
	{
		// 프로그래밍적 사고
		if (i % 2 != 0)
		{
			continue;
		}

		cout << "출력값 : " << i << endl;

	}

	/*

		 - goto 문

		 - 아픈 손가락 같은 문법

		 - 일반적으로 가독성을 떨어뜨리고 스파게티 코드를 만드는데 일조한다.
			ㄴ 사용하기 전에 정말 필요한가...?

		 Ex)
			goto 레이블:
			레이블:

	*/

	for (int i = 2; i < 10; i++)
	{
		for (int j = 1; j < 10; j += 1)
		{
			if (i % 2 == 0)
			{
				goto EXIT_1;
			}

			if (i % 5 == 0)
			{
				goto EXIT_2;
			}

			// EX : 2 X 1 = 2
			cout << i << " X " << j << " = " << i * j << endl << endl;
		}

	EXIT_1:
		cout << "i 단을 출력 후 실행 : " << i << endl << endl;
	}

EXIT_2:
	cout << "반복문 탈출" << endl;

}