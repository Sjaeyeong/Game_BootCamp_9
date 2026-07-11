#include <iostream>

using namespace std;

void main()
{
	int square = 15;

	cout << "과제 2 - A" << endl;

	cout << '\n';

	cout << "변의 길이가 15인 정사각형" << endl;

	cout << '\n';

	for (int i = 0; i < square; i++)
	{
		for (int j = 0; j < square; j++)
		{
			cout << "■ ";
		}
		cout << '\n';
	}

	cout << '\n';

	cout << "============================================" << endl;

	cout << '\n';

	cout << "과제 2 - B" << endl;

	cout << '\n';

	int squareInput;

	cout << "정사각형의 변의 길이를 입력해주세요 (10이하의 수) : ";
	cin >> squareInput;
	cout << '\n';

	for (int i = 0; i < squareInput; i++)
	{
		for (int j = 0; j < squareInput; j++)
		{
			cout << "□ ";
		}
		cout << '\n';
	}



}