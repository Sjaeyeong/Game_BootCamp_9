#include <iostream>
#include <Windows.h>
#include <string>

using namespace std;

void GamePlay();

int main()
{

	cout << "과제 2번 가위바위보 게임" << endl;
	cout << '\n';

	cout << "=====================================================================" << endl << endl;

	GamePlay();

	return 0;
}

void GamePlay()
{
	srand(time(NULL));

	int icomRPS;
	string scomRPS;
	int imyRPS = 0;
	string smyRPS;
	int count = 1;


	while (count < 6)
	{
		icomRPS = rand() % 3;

		if (icomRPS == 0)
		{
			scomRPS = "가위";
		}

		else if (icomRPS == 1)
		{
			scomRPS = "바위";
		}

		else
		{
			scomRPS = "보";
		}

		cout << "치트 : " << scomRPS << endl;
		cout << '\n';

		// cout << count << ". 가위(0), 바위(1), 보(2) 중에서 하나를 골라 숫자를 입력해주세요 : ";
		cout << count << ". 가위, 바위, 보 중에서 하나를 골라 입력해주세요 : ";
		cin >> smyRPS;
		cout << '\n';

		if (!(smyRPS == "가위" || smyRPS == "바위" || smyRPS == "보"))
		{
			cout << "다시 입력해 주세요" << endl;
			cout << '\n';

			cout << "=====================================================================" << endl << endl;

			continue;
		}

		if (smyRPS == "가위")
		{
			imyRPS = 0;
		}
		else if (smyRPS == "바위")
		{
			imyRPS = 1;
		}
		else if (smyRPS == "보")
		{
			imyRPS = 2;
		}

		if (imyRPS == icomRPS)
		{
			cout << "결과는 비겼습니다." << endl << endl;
		}
		else if ((imyRPS + 1) % 3 == icomRPS)
		{
			cout << "결과는 졌습니다..." << endl << endl;
		}
		else
		{
			cout << "결과는 이겼습니다!!" << endl << endl;
		}

		cout << "=====================================================================" << endl << endl;

		count++;
	}
}
