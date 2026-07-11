#include <iostream>

using namespace std;

void main()
{


	int countF = 0, totalNumF = 0; // for문
	int countW = 0, totalNumW = 0; // while문
	int countD = 0, totalNumD = 0; // do - while문

	cout << "과제 1 - 1" << endl;
	cout << '\n';

	for (int i = 10; i > 0; i--)
	{
		cout << i << " ";
		countF++;
		totalNumF += i;
	}

	cout << '\n';

	cout << "for문에서의 반복된 숫자의 갯수 : " << countF << endl;
	cout << "for문에서의 숫자의 총 합 : " << totalNumF << endl;

	cout << '\n';

	int j = 10;

	while (j > 0)
	{
		cout << j << " ";
		countW++;
		totalNumW += j;
		j--;
	}

	cout << '\n';

	cout << "while문에서의 반복된 숫자의 갯수 : " << countW << endl;
	cout << "while문에서의 숫자의 총 합 : " << totalNumW << endl;

	cout << '\n';

	int k = 10;

	do
	{
		cout << k << " ";
		countD++;
		totalNumD += k;
		k--;

	} while (k > 0);

	cout << '\n';

	cout << "do ~ while문에서의 반복된 숫자의 갯수 : " << countW << endl;
	cout << "do ~ while문에서의 숫자의 총 합 : " << totalNumW << endl;

	cout << '\n';

	cout << "=================================================" << endl;

	cout << "과제 1 - 2" << endl;

	cout << '\n';

	cout << "for문에서의 짝수 출력 : ";

	for (int i = 1; i < 6; i++)
	{
		cout << 2 * i << " ";
	}

	cout << '\n';
	cout << '\n';

	j = 1;

	cout << "while문에서의 짝수 출력 : ";

	while (j < 6)
	{
		cout << 2 * j << " ";
		j++;
	}

	cout << '\n';
	cout << '\n';

	cout << "do ~ while문에서의 짝수 출력 : ";

	k = 1;

	do
	{
		cout << 2 * k << " ";
		k++;
	} while (k < 6);

	cout << '\n';

}