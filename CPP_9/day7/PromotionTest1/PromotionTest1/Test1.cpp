#include <iostream>
#include <Windows.h>
#include <string>

using std::cout;
using std::cin;
using std::string;
using std::endl;

void ConsoleAbove();
void ConsoleBelow();
void ConsoleContent(int menuSelect);
void TextLine();

void MenuSelect();
void GameRule();

string RockPaperScissors(int rps);
int ConvertRPS(string myRPS);
void GamePlay();
int GameResult(int comRPS, int myRPS);
bool IsCheating();


int main()
{
	srand(time(NULL));

	while (1)
	{
		MenuSelect();
		GamePlay();
	}

	return 0;
}



void ConsoleAbove()
{
	cout << "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓" << endl << endl << endl;
}

void ConsoleBelow()
{
	cout << endl << endl << endl;
	cout << "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛" << endl << endl;
}

void ConsoleContent(int menuSelect)
{
	ConsoleAbove();

	cout << "\t\t\t     가위 바위 보" << endl << endl << endl;
	if (menuSelect == 0)
	{
		cout << "\t\t\t     [게임 시작]" << endl << endl;
	}
	else
	{
		cout << "\t\t\t      게임 시작" << endl << endl;
	}
	
	if (menuSelect == 1)
	{
		cout << "\t\t\t     [설명 보기]" << endl << endl;
	}
	else
	{
		cout << "\t\t\t      설명 보기" << endl << endl;
	}

	if (menuSelect == 2)
	{
		cout << "\t\t\t      [종   료]";
	}
	else
	{
		cout << "\t\t\t       종   료";
	}
	

	ConsoleBelow();
}

void TextLine()
{
	cout << "=======================================================================" << endl << endl;
}

void MenuSelect()
{
	int menuSelect;
	bool isSelecting = true;

	

	while (isSelecting)
	{

		ConsoleContent(-1);

		TextLine();

		cout << "메뉴를 선택해 주세요 (게임시작 : 0, 설명 보기 : 1, 종료 : 2) : "; // 지금 배운 내용으로는 예외처리가 힘든 부분
		cin >> menuSelect;
		cout << '\n';

		if (!(menuSelect == 0 || menuSelect == 1 || menuSelect == 2))
		{
			cout << "잘못된 입력입니다. 다시 입력해주세요." << endl << endl;
			continue;
		}

		TextLine();

		switch (menuSelect)
		{
			case 0:
				ConsoleContent(menuSelect);
				// GamePlay(); // << exit(1) 사용시 main으로 옮기기
				isSelecting = false;
				break;
			case 1:
				ConsoleContent(menuSelect);
				GameRule();
				isSelecting = true;
				break;
			case 2:
				ConsoleContent(menuSelect);
				// isSelecting = false; // << exit(1) 사용으로 주석처리
				exit(1);
				break;

			default:
				ConsoleContent(menuSelect);
				cout << "잘못된 입력입니다. 다시 선택해 주세요" << endl << endl;
				break;
		}
	}
}

void GameRule()
{
	ConsoleAbove();

	cout << "초기 소지금은 10,000입니다." << endl << endl;
	cout << "최소 베팅은 1,000부터 입니다." << endl << endl;
	cout << "현재 소지금 보다 많은 금액은 베팅 할 수 없습니다." << endl << endl;
	cout << "무승부 시 베팅금액은 누적되며, 승리시 현재 베팅금액의 3배를 획득합니다" << endl << endl;
	cout << "소지금을 전부 잃거나 5판 진행이 끝난 후 게임이 종료됩니다.";

	ConsoleBelow();
	Sleep(2000);

}

string RockPaperScissors(int rps)
{
	if (rps % 3 == 0)
	{
		return string("가위");
	}

	else if (rps % 3 == 1)
	{
		return string("바위");
	}

	else
	{
		return string("보");
	}
}

int ConvertRPS(string myRPS)
{
	if (myRPS == "가위")
	{
		return 0;
	}
	else if (myRPS == "바위")
	{
		return 1;
	}
	else
	{
		return 2;
	}
}

void GamePlay()
{

	int comRPS;
	string myRPS;

	int winCount = 0;
	int loseCount = 0;
	int drawCount = 0;

	int count = 1;
	bool isCheat = 0;

	int myGold = 10000;
	int betGold = 0;
	int stackGold = 0;

	TextLine();

	cout << "게임이 시작되었습니다." << endl << endl;
	
	isCheat = IsCheating(); // 피드백 내용 : isCheat를 IsCheating함수의 return인 bool값으로 초기화 시켜줌 (GamePlay함수안에 while문이 여러개 있는 것이 보기 안좋아서 함수로 뺌 → 초기화 하는 부분에 문제가 생겨 고민하다 막혀서 조교님에게 피드백을 구함)

	TextLine();

	while (count < 6)
	{
		comRPS = rand() % 3;

		cout << "[ " << count << " 번째 판]" << endl << endl;

		if (isCheat == 1)
		{
			cout << "치트 : " << RockPaperScissors(comRPS) << endl << endl;
		}

		cout << "현재 플레이어의 소지금은 " << myGold << " 입니다." << endl << endl;

		cout << "베팅금액을 금액을 입력해주세요 (최소 1,000) : ";
		cin >> betGold;

		cout << '\n';

		if (myGold < betGold) // TODO 입력값이 int가 아니거나 큰 수일 때 무한루프
		{
			cout << "소지금보다 많은 금액을 베팅할 수 없습니다." << endl << endl;
			TextLine();
			continue;
		}
		else if (betGold < 1000)
		{
			cout << "베팅금액 최소 금액은 1000입니다. 다시입력해주세요." << endl << endl;
			TextLine();
			continue;
		}
		/*else if (???)
		{
			cout << "잘못된 입력입니다. 다시 입력해주세요." << endl << endl;
		}*/

		cout << "베팅 후 소지금은 " << myGold - betGold << " 입니다." << endl << endl;

		cout << "가위, 바위, 보 중에서 하나를 골라 입력해주세요 : ";
		cin >> myRPS;
		cout << '\n';

		if (!(myRPS == "가위" || myRPS == "바위" || myRPS == "보"))
		{
			cout << "잘못된 입력입니다. 다시 입력해 주세요" << endl;
			cout << '\n';

			TextLine();

			continue;
		}

		myGold -= betGold;

		int result = 0;

		result = GameResult(comRPS, ConvertRPS(myRPS));

		switch (result)
		{
		case 0:
			stackGold += betGold;
			drawCount += 1;
			break;
		case 1:
			stackGold = 0;
			loseCount += 1;
			break;
		default:
			myGold += 3 * betGold + stackGold;
			stackGold = 0;
			winCount += 1;
			break;
		}

		if (myGold <= 0)
		{
			cout << "소지금을 전부 잃었습니다.. 게임이 종료됩니다." << endl << endl;
			TextLine();
			break;
		}

		cout << "현재 누적 판돈은 " << stackGold << "입니다." << endl << endl;

		TextLine();

		count++;
	}
	ConsoleAbove();

	cout << "\t\t\t\t최종 결과" << endl << endl;
	cout << "\t\t\t\t승 : " << winCount << endl << endl;
	cout << "\t\t\t\t패 : " << loseCount << endl << endl;
	cout << "\t\t\t\t무승부 : " << drawCount << endl << endl;
	cout << "\t\t\t\t최종 소지금 : " << myGold;

	ConsoleBelow();

	TextLine();

	for (int i = 5; i > 0; i--)
	{
		cout << i << "초 뒤에 종료됩니다..." << endl;
		Sleep(1000);
	}

	TextLine();
	
	system("cls");
}

int GameResult(int comRPS, int myRPS)
{
	if (myRPS == comRPS)
	{
		cout << "결과는 비겼습니다." << endl << endl;
		return 0;
	}
	else if ((myRPS + 1) % 3 == comRPS)
	{
		cout << "결과는 졌습니다..." << endl << endl;
		return 1;
	}
	else
	{
		cout << "결과는 이겼습니다!!" << endl << endl;
		return 2;
	}

}

bool IsCheating()
{
	int isCheat = 0; 

	while (true)
	{
		isCheat = 0; // << 피드백 내용 : 입력을 0이나 1이 아닌 큰 숫자 or 다른 문자를 받았을 때 무한루프가 발생 → while문 안에서 시작시에 한번더 초기화

		cout << "치트 기능을 사용할지 선택해주세요. (OFF = 0, ON = 1) : ";
		cin >> isCheat;


		if (!(isCheat == 0 || isCheat == 1))
		{
			cout << '\n';
			cout << "잘못된 입력입니다 다시 입력해 주세요." << endl << endl;
			continue;
		}

		break;
	}

	cout << '\n';

	switch (isCheat)
	{
	case 0:
		cout << "치트 기능을 OFF 하였습니다." << endl << endl;
		break;
	case 1:
		cout << "치트 기능을 ON 하였습니다." << endl << endl;
		break;
	}

	return isCheat;
	
}

