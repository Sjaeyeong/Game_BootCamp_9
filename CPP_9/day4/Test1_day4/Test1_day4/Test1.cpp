#include <iostream>
#include <time.h>

using namespace std;

void main()
{
	srand(time(NULL));

	// 과제 1 변수 선언
	int numA, numB, numC;

	// 과제 2 변수 선언
	int myGold, rewardGold, totalGold;

	// 과제 3 변수 선언
	int myStr, myDex, myInt, totalStats;


	cout << "============================================================" << endl << endl;

	numA = rand() % 5 + 1;
	numB = rand() % 15 + 6;
	numC = rand() % 51 + 150;

	cout << "과제 1. 랜덤 숫자 담기" << endl;
	
	cout << endl;

	cout << numA << endl << numB << endl << numC << endl;

	cout << endl;

	cout << "============================================================" << endl << endl;

	cout << "과제 2. 현상금 받기" << endl;

	cout << endl;

	/*cout << "현재 내 소지금을 입력하시오 (100에서 200까지) : ";

	cin >> myGold;*/

	while (1) {

		cout << "현재 내 소지금을 입력하시오 (100에서 200까지) : ";

		cin >> myGold;

		if (myGold > 200 || myGold < 100) {
			cout << "소지금 입력이 잘못되었습니다" << endl;

			continue;
		}

		break;
	}

	rewardGold = rand() % 51 + 50;

	cout << "현상금 : " << rewardGold << endl;

	myGold += rewardGold;
	totalGold = myGold * 8 / 10;
	
	cout << endl << "세금이 20% 적용된 총 소지금 : " << totalGold;

	cout << endl;

	cout << "============================================================" << endl << endl;

	cout << "과제 3. 랜덤 능력치 생성 및 출력" << endl;

	cout << endl;

	myStr = rand() % 10 + 1;
	myDex = rand() % 10 + 1;
	myInt = rand() % 10 + 1;

	cout << "나의 Str : " << myStr << endl;
	cout << "나의 Dex : " << myDex << endl;
	cout << "나의 Int : " << myInt << endl;

	cout << endl;

	totalStats = myStr + myDex + myInt;

	cout << "나의 총 전투력 (Str + Dex + Int) : " << totalStats << endl;

	cout << "============================================================" << endl;

}