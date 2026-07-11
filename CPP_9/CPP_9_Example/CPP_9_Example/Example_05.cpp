#include <iostream>
#include <time.h>
// Sleep() 함수를 사용하기 위한 헤더파일 추가
// Sleep(1000) : 1초동안 멈춘다.
// Sleep(500) : 0.5초동안 멈춘다.
#include <Windows.h>

using namespace std;

#pragma region 설계 방향성
/*
 ▶ 무언가를 구현할때는...

 1. 필요한 친구들(기능)을 미리 사용할 수 있게 해당 명령어를 통해 복사를 해둔다.
	ㄴ 프로그래머는 명령을 내리고 복사는 컴퓨터가 수행한다.

 2. 지역을 구분지어 준다. <<
	ㄴ 라이프 사이클

 3. 내가 만들고자 하는 기능에 대해 지역별로 구분을 지어준다. <<
	ㄴ 접근성 / 메모리 효율

 4. 필요한 변수들이 있으면 생성한다.

 5. 만들어 둔 변수를 필요하다면 초기화까지 진행한다.

 6. 만들고 싶은, 로직에 맞춰 반복문을 돌릴 준비를 한다. (돌린다)

 7. 반복문안에서는 현재 만드는 로직에 맞게 판정을 한다.
	ㄴ 반복이 돌아가는 로직안에서는 프로그램을 종료할 수 있는 방안을 강구해야 한다.

 8. 실행이 되면 입력 → 분리 → 검증까지의 흐름이 한눈에 들어와야 한다.

 9. 위 형태를 지키면 웬만한 로직을 만드는데 있어 거부감이 들지 않는다.

 10. 참 쉽다.


*/
#pragma endregion


// 업다운 게임
// ㄴ 숫자를 정하고 그 숫자를 맞추는 게임 (Ex : 50)
// ㄴ A : 20 → 업 / B : 60 → ㄷㅏ운 / C : 50



void main()
{
	// 랜덤시드 초기화
	srand(time(NULL));

	int comNumber;		// 랜덤한 숫자를 담아 놓을 컴퓨터 변수
	int myNumber;		// 사용자로부터 입력받기 위한 변수
	
	

	// 무한 반복
	while (true)
	{
		comNumber = rand() % 100 + 1;

		// 원할한 테스트를 위해 → 우리를 위해
		cout << "치트 : " << comNumber << endl;

		cout << "1 ~ 100 까지 숫자 중 1개를 선택하자. (업다운)" << endl;
		cin >> myNumber;
		Sleep(1000);

		if (myNumber == comNumber)
		{
			cout << "== 찾았다. == " << endl;
			Sleep(2000);
			system("cls"); // 콘솔 화면 초기화

			// break;
		}

		else if (myNumber > comNumber)
		{
			cout << "더 작은 수를 생각해 보자." << endl;
		}

		else
		{
			cout << "더 큰 수를 생각해 보자." << endl;
		}

		cout << '\n';

	}

}