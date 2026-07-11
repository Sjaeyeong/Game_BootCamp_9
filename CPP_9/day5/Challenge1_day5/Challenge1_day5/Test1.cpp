#include <iostream>
#include <cmath>

using namespace std;

void main()
{

	cout << "도전과제 1. 마름모 찍기" << endl;
	cout << '\n';

	int n;

	cout << "마름모 변의 길이를 입력해주세요 : ";
	cin >> n;

	cout << '\n';

	for (int i = 0; i < (2*n - 1) * (2*n - 1); i++)
	{
		cout << ((abs(i/(2*n - 1) - (n - 1)) + abs(i%(2*n - 1) - (n - 1))) <= (n - 1) ? "◆ " : "· ") << (i % (2 * n - 1) == (2 * n - 2) ? '\n' : ' ');
	}

}