#include <iostream>

using namespace std;

void InputMonth(int year, int month);
bool LeapYearCalculation(int year);

int main()
{
	int month, year;
	int count = 1;

	cout << "과제 1번 일수 출력기" << endl;
	cout << '\n';

	cout << "올해가 몇년도인지 입력해주세요( Ex : 2026 )  : ";
	cin >> year;
	cout << '\n';

	while (count < 6)
	{
		cout << count << ". 원하는 달의 숫자를 입력해주세요 : ";
		cin >> month;

		InputMonth(year, month);

		if (month < 1 || month > 12)
			continue;

		count++;
	}
	
	return 0;
}

void InputMonth(int year, int month)
{
	switch (month)
	{
	case 1:
	case 3:
	case 5:
	case 7:
	case 8:
	case 10:
	case 12:
		cout << '\t' << month << "월은 31일까지 입니다." << endl << endl;
		break;
	case 2:
		if (LeapYearCalculation(year))
		{
			cout << "\t올해는 윤년이기 때문에 " << month << "월은 29일까지 입니다." << endl << endl;
			break;
		}
		cout << '\t' << month << "월은 28일까지 입니다." << endl << endl;
		break;
	case 4:
	case 6:
	case 9:
	case 11:
		cout << '\t' << month << "월은 30일까지 입니다." << endl << endl;
		break;
	default:
		cout << "\t범위 밖의 숫자 입니다 다시 입력해주세요." << endl << endl;
		break;
	}
}

bool LeapYearCalculation(int year)
{
	if ((year % 100 != 0 && year % 4 == 0) || year % 400 == 0)
	{
		return true;
	}
	else
		return false;
}