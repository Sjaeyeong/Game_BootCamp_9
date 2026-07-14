// #define EXAMPLE_TYPE_STRING_METHOD
#define EXAMPLE_TYPE_USER_DEFINED_TYPE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#region 문자열 관련 기능
/*
▶ C# 언어의 문자열 조작 기능
 
- 무작열을 다룰 때 일반적으로 사용할 수 있는 기능들의 집합
 ㄴ 문자열은 System.string 클래스 타입

- 정통적으로 문자열을 다룰 때 사용하는 기능들은 C#에서 프로퍼티 / 연산자 / 함수 형태로 내장되어 제공이 되고 있다.


● 사용 빈도가 높은 함수 (필수)

1. 문자열 길이
 ㄴ Length
 ㄴ 문자열의 길이를 나타내는 프로퍼티

EX :
 ㄴ C# → str.Length
 ㄴ C → strlen(str);


2. 문자열 비교

==, Equals()
 ㄴ 두 문자열의 내용이 같은지 비교
 ㄴ 결과는 t / f

Compare()
 ㄴ 두 문자의 정렬 순서를 비교
 ㄴ 같으면 0
 ㄴ 왼쪽이 크면 양수
 ㄴ 왼쪽이 작으면 음수

EX : 
 ㄴ C# → string.Compare(str1, str2);
 ㄴ C → strcmp(str1, str2);


3. 문자열 복사 / 대입

- C# 문자열은 불변객체이므로 단순 대입으로도 안전하게 사용 가능

EX :
 ㄴ C# → str2 = str1 / string.Copy(str2); → 후자는 레거시라서 잘 사용 안함
 ㄴ C → strcpy(str1, str2);

- C# 참조형 + 불면이라 a, b에 대한 메모리 복사를 사용할 이유가 없다.
 ㄴ 이말은 즉슨 단순 대입으로 안전하게 사용가능하다는 얘기를 다시한번 강조


4. 문자열 연결

- '+' 또는 String.Concat() 사용
 ㄴ 문자열을 합치는 기능

EX :
 ㄴ C# → str1 + str2 / string.Concat(str1, str2);
 ㄴ C → strcat(str1, str2);


@
5. 문자열 분리

- Split()
 ㄴ 문자열을 특정 기준으로 나누어 배열로 전환

EX :
 ㄴ C# → str.Split(' ');
 ㄴ C → strtok(str, " ");

- 당연히 C#쪽이 사용이 더 편리하고 안전하다.

## 자주 쓰이는 추가 문자열

6. Contains()   →   있냐?
 ㄴ 문자열에 특정 문자열이 포함되어 있는지 확인
 ㄴ 포함되어 있으면 t / 아니면 f 반환
 ㄴ 기본적으로 대소문자를 구분한다.

- 포함 여부만 확인할 때 가장 직관적인 C# 문자열 함수

EX :
string str = "Unity Engine";
str.Contains("Engine");     t
str.Contains("engine");     f

7. IndexOf()    →   어디냐?

- 문자열에서 특정 문자열 또는 문자가 처음 나타나는 위치를 반환
 ㄴ 문자열의 시작 인덱스는 0부터 시작
 ㄴ 찾는 문자열이 없으면 -1 반환

- 위치가 필요하면 Contains보다 IndexOf가 더 유용하다.

EX :
string str = "Unity Engine";
str.IndexOf("Engine");     6
str.IndexOf("Game");       -1


8. Replace()

- 문자열 내의 특정 문자열을 다른 문자열로 치환

- 원본 문자열은 변경되지 않고 새로운 문자열을 반환
 ㄴ 문자열이 불변이기 때문에 반드시 반환값을 사용해야 한다.

※ 문자열은 직접 수정되지 않고 항상 새 문자열을 만든다.

EX :
string str = "Unity Engine";
string result = str.Replace("Engine", "Game");
→ 출력시 Unity Game

※ 필요하면 사용은 하되 웬만하면 반복문은 고민을 해보자.
 ㄴ 퍼포먼스 → GC


9. Trim()

- 문자열의 앞과 뒤에 있는 공백을 제거

- 문자열 중간의 공백은 제거되지 않는다.

- 보통 입력 처리시 자주 사용된다.

*/
#endregion

#region 언어 기반 테스트 찍먹
/*
→ 도전과제 → 기한은 그냥 편할 때 (이번주까지) → 시간날때마다 틈틈이
 ㄴ 1. 기한내에 풀어본다. (이번주)
 ㄴ 2. 시간내에 풀어본다. (20분)
 ㄴ 3. 효율적인지 확인한다.

▶ 언어 기반 테스트 준비

- 5문제 중 1개
 ㄴ 회사는 중견

- 코테 / 과제 전형
 ㄴ 1. 접해봐야 한다.

- 문자열은 코테에서 가장 자주 등장하는 문제 유형 중 하나

- 단골이자 논리를 확인하기에 아주 좋다.


● 코딩 테스트 : 문자열

※ 주의 사항

- C++/C# 언어 중 자신있는 언어로 문제를 풀어야 하고 내용에 알맞게 채워 넣으시면 됩니다.

C/C++
- C 런타임 라이브러리 / STL등 기타 라이브러리 기능을 사용하면 안됩니다.
- 특히 STL String을 사용시 바로 탈락처리 되오니 유의 바랍니다.

C#
- 2가지 케이스를 만들어 주시면 됩니다.
 ㄴ 01. string을 사용한 케이스
 ㄴ 02. string 대신 char를 사용한 케이스 (char[] 허용)

※ 일부 기능은 직접 구현해야 합니다.

- 그리고 본인이 작성한 방법에 대해 왜 그렇게 생각하는지 짧은 주석을 넣어 주세요.

- ! 추가 문구 ! / 지금은 할 필요 없음 (시간복잡도 계산 함수)

Q. 주어진 문자열을 단어 단위로 순서를 뒤집어 출력 하세요.

EX :
입력값 : Hello world this is Game Process
반환값 : Game Process is this world Hello

조건 :
 ㄴ 모든 문자열은 앞뒤에 공백이 없다고 가정합니다.
 ㄴ 모든 단어는 공백 한 칸으로 구분된다고 가정합니다.

함수 시그니처

// C++
void ReverseWords (char* output, int outputArraySize, const char* input)
{
    // TODO
}

// C#
Case 1.
static string ReverseWords (string input)
{
    // TODO
}

Case 2.
static void ReverseWords (char[] output, int outputArraySize, char[] input)
{
    // TODO
}
*/
#endregion

#region 사용자 정의 자료형
/*
▶ 사용자 정의 자료형

- 기본 자료형을 조합하여 새로운 의미를 가진 자료형을 직접 정의하는 것 (int / float / char 등등..)

- 사용자 정의 자료형을 활용하면 여러 데이터를 하나의 논리적 단위로 묶어 의미 있는 이름으로 관리할 수 있다.

◈ public

- public은 접근 제한자 중 1개 → public으로 선언된 대상은 다른 곳에서도 접근할 수 있다.
 ㄴ 접근 범위를 넓은 의미로 포함하는 느낌이 강함

- 지금은...
 ㄴ 구조체나 클래스 앞에 붙이면 외부에서 해당 자료형을 사용할 수 있다.
 ㄴ 구조체나 클래스 내부 멤버 앞에 붙이면 외부에서 해당 멤버에 접근할 수 있다.


● 사용자 정의 자료형의 종류

- 구조체 : 특정 데이터의 집합을 정의하는 자료형 → 디폴트 값 형식
- 열거형 : 고정된 상수들의 집합을 정의하는 자료형
- 튜플 : 간단한 여러 데이터 묶음을 정의하는 자료형
- 클래스 : OOP에서 특정 객체를 생성하고 관리하는 자료형 → 디폴트 참조 형식

※ 공용체 → C#에서는 공용체가 존재하지 않는다. → 비슷한 동작은 있지만 유니온 자체는 없음
 ㄴ 공용체 : 하나의 메모리 공간을 여러 자료형이 공유하는 구조


▶ 사용자 정의 자료형 선언 방법

- C#은 사용자 정의 자료형에 ;을 붙이지 않는다.

● 구조체

- 하나 이상의 변수를 묶어서 새로운 자료형을 정의 하는 도구 → 데이터와 관련 기능을 캡슐화 가능
- C# 구조체는 C언어와 달리 함수 / 생성자 / 프로퍼티도 포함할 수 있다.
- 값 형식이며 일방적으로 클래스와 다르게 값 복사 특성을 가진다.
 ㄴ 메모리 위치 / 상황에 따라 특성이 바뀔 수 있으니 이 점은 유의해야 한다.


● 열거형

- 명명된 상수들의 집합을 정의하는 값 형식
- 기본적으로 int를 기반으로 사용한다.
- 숫자 대신 의미 있는 이름을 사용하여 코드 가독성을 높인다. (기본)
- 효율적으로 사용하려면 비트 넣어야 한다.


● 튜플

- 여러개의 데이터를 간단히 묶어 표현할 때 사용
- 클래스를 만들 필요가 없을 정도로 단순한 데이터 집합에 적합


● 클래스

- 객체지향 프로그래밍의 핵심 자료형 (OOP)
- 구조체와 달리 디폴트 참조 형식이다.
- 변수에는 객체 자체가 아니라 / 객체를 가르키는 참조 정보가 저장도니다고 이해하면 된다.
- 4대 특징 + 5대 설계 원칙 + 객체 지향 문법들이 클래스쪽에 붙어서 효율적인 OOP가 완성된다.


*/
#endregion

#region 비트마스킹
/*
▶ 비트마스킹

※ 많이 쓰나..? 안 쓰나..?
 ㄴ 현업은 이거다.

- 정수의 각 비트 (0 / 1)를 이용해서 여러 상태를 한번에 저장하고 검사하는 방법
 ㄴ 하나의 숫자 안에 여러개의 ON/OFF 스위치를 넣는 방식

EX :

기준점 : 0000 0000

- 0000 0001         →       대기
- 0000 0010         →       이동
- 0000 0100         →       공격
- 0000 1000         →       스킬

- 이렇게 각 상태가 서로 다른 비트를 가지만 하나의 변수로 여러 상태를 동시에 표현할 수 있다.

EX :
0000 0010
0000 0100

= 0000 0110


▷ 왜 비트마스킹을 쓰는가?

- 여러 상태를 하나의 값으로 관리할 수 있다.
- bool 변수를 여러개 두는것보다 상태를 묶어서 관리하기가 좋다.
- 상태 추가 / 제거 / 확인이 빠르며 규칙적으로 동작 시킬 수 있다.

※ 뭔가를 구현하려고 할때 상태를 바꾼다 라는 개념이 중점이 된다면 비트마스킹은 좀 고민이 필요하다.
 ㄴ 상태를 어떻게 관리하느냐에 중점



EX :
bool isMove;
bool isAttack;
bool isSkill;

bool isMove;
bool isAttack;
bool isSkill;

bool isMove;
bool isAttack;
bool isSkill;

bool isMove;
bool isAttack;
bool isSkill;

>> ECharacterState state; 여러묶음이 나와도 비트마스킹 하나로 가능(?)


▶ 비트마스킹에서 자주 쓰는 연산

1. 상태 추가

- OR 연산자 (|)
- 비트를 켜는 역할


2. 상태 제거

- AND + NOT 연산자 (& ~)
- 특정 비트만 끄는 역할


3. 상태 확인

- AND 연산자 (&)
- 해당 비트가 들어 있는지 검사


- 위의 연산자들을 통해서 상태를 하나의 값으로 묶어 관리가 가능하다.
 ㄴ 조헙면에서도 유리하다.




 
*/
#endregion

namespace CS_9_Example.Lesson_07
{
    internal class Example07
    {
        static void LinePrint() => Console.WriteLine("=====================================");

        // 문법 → 문법은 이게 끝
        //  구조체 1번
        struct Family
        {
            public string name;
            public int age;
            public int height;
            public float weight;
            public bool wedding;

        }

        // 구조체 2번
        struct CharacterStat
        {
            public int strength;            // 힘
            public int agility;             // 민첩
            public int intelligence;        // 지능
            public string name;

            public float GetAverageStat()
            {
                return (strength + agility + intelligence) / 3f;
            }

        }

        static void ExampleFunciton_A()
        {
            Console.WriteLine("== 구조체 ==");
            Console.WriteLine();

            // 구조체 생성 및 초기화 → 가장 기본적인 사용 방식
            // 구조체 초기화 및 기본값
            //  ㄴ 정수형 : 0 / 실수형 : 0.0 / 논리형 : false / 참조형 : null

            Family human = new Family();
            human.name = "컴파일러";
            human.age = 20;
            human.height = 110;
            human.weight = 100f;
            human.wedding = false;

            Console.WriteLine($"이름     : {human.name}");
            Console.WriteLine($"나이     : {human.age}");
            Console.WriteLine($"키       : {human.height}");
            Console.WriteLine($"몸무게   : {human.weight}");
            Console.WriteLine($"결혼여부 : {human.wedding}");

            Console.WriteLine();
            LinePrint();
            Console.WriteLine();

            // 구조체 선언
            CharacterStat warrior;

            warrior.name = "전사";
            warrior.strength = 100;
            warrior.agility = 70;
            warrior.intelligence = 40;

            Console.Write($"{warrior.name}의 평균 능력치는 ");
            Console.WriteLine(warrior.GetAverageStat());

            Console.WriteLine();

            LinePrint();
            Console.WriteLine();

        }

        // 구조체 3번
        struct Player
        {
            public string name;
            public int hp;
            public int mp;
            public int attack;

            // 생성자 : 멤버 변수의 값을 원하는 값으로 대입하는 작업 + 그 외 객체가 동작하는데 필요한 대부분의 초기화 처리를 담당
            public Player(string name, int hp, int mp, int attack) // C++과 유사하지만 메모리적 개념이 삭제됐다?
            {
                this.name = name;
                this.hp = hp;
                this.mp = mp;
                this.attack = attack;
            }

            // 체이닝 : 중복 초기화를 줄일 수 있다. (이전 초기화를 이용하여 초기화 간소화)
            // 위임 → 초기화
            public Player(string name, int hp, int attack) // mp가 없는 Player 생성자 느낌
                : this(name, hp, 0, attack)
            {
            }

            // 데미지를 받는다.
            public void TakeDamage(int damage)
            {
                hp -= damage;

                if (hp <= 0)
                {
                    hp = 0;
                }
            }

            public void PrintStatus()
            {
                Console.WriteLine($"이름 : {name} → HP : {hp}, MP : {mp}, ATK : {attack}");
                Console.WriteLine();
            }


        }

        static void ExampleFunciton_B()
        {
            Console.WriteLine("== 전투 캐릭터 구조체 ==");
            Console.WriteLine();

            Player warrior = new Player("전사", 100, 15);
            warrior.PrintStatus();

            Player mage = new Player("마법사", 70, 50, 10);
            mage.PrintStatus();

            Console.WriteLine("전투 발생");

            mage.TakeDamage(warrior.attack);
            mage.PrintStatus();

            warrior.TakeDamage(mage.attack);
            warrior.PrintStatus();

            Console.WriteLine();

            Console.WriteLine("== 구조체 배열 --");
            Console.WriteLine();
            Console.WriteLine("플레이어 파티 구성");
            Console.WriteLine();

            // 반복문을 이용한 초기화 → 오늘은 아직
            // 구조체 배열로 선언 후 바로 초기화도 가능하다. → 객체 이니셜라이저를 통해 필요한 값만 대입한다.
            Player[] party = new Player[4]
            {
                // new Player()로 기본 초기화가 먼저 수행되기 때문에
                // 일부 필드만 이니셜라이저로 대입해도 에러가 발생하지 않는다.
                new Player {name = "전사", hp = 100, mp = 50, attack = 50},
                new Player {name = "마법사", hp = 90, mp = 40, attack = 30 },
                new Player {name = "도적", hp = 80, mp = 30, attack = 40 },
                new Player {name = "힐러", hp = 200, mp = 100, attack = 10 }
            };

            for (int i = 0; i < party.Length; i++)
            {
                Console.WriteLine($"{i + 1}번 캐릭터");
                party[i].PrintStatus();
                Console.WriteLine();
            }

            LinePrint();
            int index = 1;
            foreach (Player p in party)
            {
                Console.WriteLine($"{index}번째 플레이어");
                Console.WriteLine();
                Console.WriteLine($"hp : {p.hp}");
                LinePrint();

                index++;
            }

            Console.WriteLine();

        }

        // 0714 수업 시작
        // 사용자 정의 자료형 → 구조체 / 열거형 / 튜플 /                →               클래스

        // 열거형하면..
        //  ㄴ 상수 / 단어 + 숫자 / 요일 / 아이템 등급 / 상태 / 상수 모음집 / 상수 /메뉴판 / 가독성 /
        //     상수 집합 / 비트 플래그 / 간단한 데이터 묶음 / 비트 마스킹
        // 열거형 정의 : 열거형 이름과 멤버 이름 작성
        // 표기법 → E → 팀 규칙에 따라 생략되는 경우도 있음


        enum EColorType
        {
            RED,                    // 열거형 멤버에 정수값을 지정하지 않을 경우 0부터
            GREEN,                  // 1
            BLUE = 1000,            // 1000 직접 할당 가능 (정수값)
            BLACK,                  // 1001 정수값을 할당하지 않을 경우 이전 멤버 + 1값을 가진다
            WHITE                   // 1002
        }

        // C# enum 기본적으로 대입에 안전하다.
        //  ㄴ 타입에 안전하기 때문에 1. 자료형 범위를 지정할 수 있고 2. 접근 범위를 제한할 수 있다.
        enum EMotionType : ushort // 메모리낭비를 방지하기 위해 자료형 범위를 지정
        {
            R_WALK,
            L_WALK,
            R_RUN,
            L_RUN
        }

        enum MoveKey
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        enum GamePhase
        {
            TITLE,
            LOBBY = 10,
            INGAME,
            BOSSBATTLE,
            GAMEOVER
        }

        static void ExampleFunction_C()
        {
            Console.WriteLine("== Enum 예제 ==");
            Console.WriteLine($"블랙 : {(int)EColorType.BLACK}");

            // 열거형 변수
            //  ㄴ 열거형의 기본 기반 타입은 int
            //  ㄴ 기반 타입을 명시하면 크기는 달라질 수 있다.
            EMotionType motion = EMotionType.L_WALK;

            // 배열 → 반복문 (for문)
            // 열거형 → 스위치

            switch (motion)
            {
                case EMotionType.R_WALK:
                    Console.WriteLine("오른쪽 걷기");
                    break;
                case EMotionType.L_WALK:
                    Console.WriteLine("왼쪽 걷기");
                    break;
                case EMotionType.R_RUN:
                    Console.WriteLine("오른쪽 걷기");
                    break;
                case EMotionType.L_RUN:
                    Console.WriteLine("왼쪽 걷기");
                    break;
            }

            if (motion == EMotionType.L_WALK)
            {
                motion = EMotionType.R_RUN;

                if (motion == EMotionType.R_RUN)
                {
                    Console.WriteLine("오른쪽 뛰기");
                }
            }

            Console.WriteLine();

            // C# → 스위치 패턴 매칭 (스위치 기반 식문) → 열거형에서 사용할 수 있으나 굳이..?
            //  ㄴ 꼭...회사 코드보면 누군가 쓰더라...

            string motionText = motion switch
            {
                EMotionType.R_WALK => "오른쪽 걷기",
                EMotionType.L_WALK => "왼쪽 걷기",
                EMotionType.R_RUN => "오른쪽 뛰기",
                EMotionType.L_RUN => "왼쪽 뛰기",
                _=> "알수없는 동작"
            };

            Console.WriteLine(motionText);

            motion = motion switch
            {
                EMotionType.R_WALK => EMotionType.R_RUN,
                _ => motion
            };

            MoveKey key = MoveKey.UP;

            //string motionText = motion switch
            //{
            //    EMotionType.R_WALK => "오른쪽 걷기",
            //    EMotionType.L_WALK => "왼쪽 걷기",
            //    EMotionType.R_RUN => "오른쪽 뛰기",
            //    EMotionType.L_RUN => "왼쪽 뛰기",
            //    _ => "알수없는 동작"
            //};

            switch (key)
            {
                case MoveKey.UP:
                    Console.WriteLine("위쪽으로 이동");
                    break;
                case MoveKey.DOWN:
                    //Console.WriteLine("위쪽으로 이동");
                    break;
                case MoveKey.LEFT:
                    //Console.WriteLine("위쪽으로 이동");
                    break;
                case MoveKey.RIGHT:
                    //Console.WriteLine("위쪽으로 이동");
                    break;
            }

            // 코딩 규약 + 규칙을 어떻게 가져갈 것인가..? → 이후에 진행할 팀플에서는 팀원과 상의하여 정하고
            //  ㄴ 취업 / 창업 / 출시 → 팀 규칙
            // aa bb cc dd...
            // int TestHP = 0;

            GamePhase phase1 = GamePhase.INGAME;

            // 1. 열거형 변수를 int로 형변환
            // 현재 게임 상태를 숫자로 저장
            Console.WriteLine("{0}의 정수값은 {1}", phase1, (int)phase1);

            // 2. 정수에서 열거형 변수로 변환
            GamePhase phase2 = (GamePhase)0;
            Console.WriteLine(phase2);

            // 3.
            GamePhase phase3 = (GamePhase)5;
            Console.WriteLine(phase3);          // 5가 출력됨
                                                // ㄴ enum에 없는 값인데 통과.. → 상태 분기 로직 꼬임
            Console.WriteLine();

            // enum 범위 체크 패턴
            //  ㄴ 받은 숫자가 실제 유효한 게임 상태인지 안전하게 확인 (서버)

            // 숫자형태로 받은 게임 상태 값 → 서버 / 파일 / 패킷 / 세이브 데이터 등등
            int valueFrontSever = 15;

            // 이 숫자가 GamePhase에 실제 정의된 값이냐..?
            // typeof : 타입 정보 요청 → enum
            if (Enum.IsDefined(typeof(GamePhase), valueFrontSever))
            {
                // 검증 통과시 → 안전하게 변환
                GamePhase phase = (GamePhase)valueFrontSever;
                Console.WriteLine($"현재 상태 : {phase}");
            }
            else
            {
                // 버전 불일치 / 해킹 / 치트 / 파일 깨짐(세이브) / 개발자의 실수 등등..
                Console.WriteLine("알수 없는 게임 상태 → 이후 추가 검증 필요");
            }


            if (Enum.IsDefined(typeof(GamePhase), valueFrontSever))
            {
                Console.WriteLine("잘못된 게임 상태 수신 → 타이틀 화면으로");
                phase3 = GamePhase.TITLE;
            }

        }

        static void PrintState(bool isIdle, bool isMove, bool isAttack, bool isSkill)
        {
            Console.WriteLine($"대기 : {isIdle}");
            Console.WriteLine($"이동 : {isMove}");
            Console.WriteLine($"공격 : {isAttack}");
            Console.WriteLine($"스킬 : {isSkill}");
            Console.WriteLine("=======");
        }

        static void ExampleFunction_BoolState()
        {
            Console.WriteLine("bool 상태 관리");

            bool isIdle = true;
            bool isMove = false;
            bool isAttack = false;
            bool isSkill = false;

            // 처음 상태 : 대기
            PrintState(isIdle, isMove, isAttack, isSkill);

            // 이동 시작
            isIdle = false;
            isMove = true;
            PrintState(isIdle, isMove, isAttack, isSkill);

            // 이동하면서 공격
            isAttack = true;
            PrintState(isIdle, isMove, isAttack, isSkill);

            // 이동 종료
            isMove = false;
            PrintState(isIdle, isMove, isAttack, isSkill);

            // 공격 종료 → 스킬 시작
            isAttack = false;
            isSkill = true;
            PrintState(isIdle, isMove, isAttack, isSkill);

            // ※ 미래적으로 보면 당연히 매우 불리한 코드
            //  ㄴ 미니 프로젝트전까지는 허용

            /*
            ● 위 코드에서 불편한 점

            - 상태 종류가 많아질수록 관리할 변수가 늘어남 → 관리 문제 + 메모리 + 쓸데없이 줄이 길어진다.
            - 매번 직접 수정도 해야 함
            - 복합 상태가 되면 고통이다.
             ㄴ 이동 + 공격 + 스킬 + 무적 + 기절 + 사망

            ● 장점

            - 직관적 → 그리고 편리함 (사람이)

            */

        }

        // 열거형 비트 플래그
        //  ㄴ enum 값을 비트 단위 상태값으로 사용 → 여러 상태를 동시에 저장 가능
        //  ㄴ 비트 연산으로 처리하겠다.
        [Flags]
        enum ECharacterState
        {
            // Flags
            // ㄴ enum값을 비트 플래그처럼 사용할 때 붙이는 속성
            // ㄴ 여러값이 조합될 때 출력 결과를 더 보기 좋게 하기위해 일반적으로 비트 플래그를 사용하면 붙이다.
            // Idle | Move
            //  ㄴ 출력 : 0000_0001 | 0000_0010
            //  ㄴ 출력 : Idle | Move

            // 0b : 이진수
            // 0x : 16진수

            None = 0b_0000_0000,            // 0 : 상태 없음

            Idle = 0b_0000_0001,            // 1 : 대기
            Move = 0b_0000_0010,            // 2 : 이동
            Attack = 0b_0000_0100,          // 4 : 이동
            Skill = 0b_0000_1000,           // 8 : 스킬

            CombatState = Attack | Skill    // 전투 상태 (상태를 묶은 조합값)
        }

        // n진법 
        //enum WeaponOption
        //{
        //    None = 0,
        //    Fire = 1 << 0,
        //    Ice = 1 << 1,
        //    Bleed = 1 << 2
        //}

        static void ExampleFunction_D()
        {
            // 비트마스킹 : 상태값 설계
            // 비트마스킹 : 상태 조작 / 검사

            // 여러 상태 조합 : OR → |

            // 0000 0001 | 0000 0010 → 0000 0011
            ECharacterState state = ECharacterState.Idle | ECharacterState.Move;
            Console.WriteLine(state);

            // 비트마스킹을 이용한 상태 추가
            // 값 추가 OR + 대입 → |=
            state |= ECharacterState.Attack;
            Console.WriteLine(state);

            // 비트마스킹을 이용한 상태 제거
            //  ㄴ 값 제거 (AND + NOT : &= ~)
            //  ㄴ 여기서는 이동 상태 제거
            //  ㄴ AND 연산 → 해당 비트만 끄기

            // Move 비트는 0000 0010 → ~Move → 1111 1101

            state &= ~ECharacterState.Move;
            Console.WriteLine(state);

            // 비트 마스킹을 이용한 상태 확인
            //  ㄴ 공격중..?
            //  ㄴ 포함 여부 → AND → &
            bool isAttacking = (state & ECharacterState.Attack) != ECharacterState.None;
            Console.WriteLine(isAttacking);

        }
        
        // 구조체 O / 열거형 O / 튜플 O
        //  ㄴ 구조체는 많이 사용이 된다.
        //  ㄴ 열거형은 적재적소에 사용된다. → 영항을 미치는 범위가 구조체보다 작다.
        //  ㄴ 튜플 : 임시 데이터 + 잠깐 묶을 필요가 있을 때 → 구조체나 클래스를 만들기엔 너무 작은 경우
        // 튜플 : 임시 데이터 묶음 / 함수 결과 여러개 반환 / 잠깐 묶어서 쓰는 데이터에 적합하다.
        
        static Random rand = new Random();

        // 기본 공격력 + 치명타 확률을 받아 실제로 적용될 데미지와 치명타 여부 계산
        //  ㄴ 함수 반환용 튜플 → 데미지 계산 결과 반환
        //  ㄴ 데미지 계산 결과 여러 값으로 반환하기 위함

        static (int damage, bool isCritical) CalculateDamage(int baseDamage, float critRate)
        {
            // NextDouble() : 0.0 이상 ~ 1.0 미만의 실수 반환
            bool isCrit = rand.NextDouble() < critRate;

            /*
            랜덤값 : 0.25
            치명타 확률 : 0.30

            - 0.25 < 0.30 → 치명타 터졌다!
            */

            // 최종 데미지 계산 → 2배 아니면 기본
            int finalDamage = isCrit ? baseDamage * 2 : baseDamage;

            return (finalDamage, isCrit);
        }

        static void ExampleFunction_E()
        {
            Console.WriteLine("== 튜플 ==");

            // 이름이 없는 튜플
            (int, float) attackInfo = (50, 1.5f);

            // Item1, Item2 ... 등으로 접근 가능
            Console.WriteLine("공격력 : {0}, 배율 : {1}", attackInfo.Item1, attackInfo.Item2);

            // 이름 없는 튜플은 빠르게 쓰기에는 좋다.
            //  ㄴ 의미 자체가 잘 안보이기 때문에 실제로는 (협업시) 이름있는 튜플쪽으로 던져줘야 팀원이 편하다.

            // 이름이 있는 튜플
            //  ㄴ 이름 접근이 가능하기 때문에 보기에 편하다.
            (int Damage, float CriticalRate) skillInfo = (120, 0.24f);
            Console.WriteLine("스킬 데미지 : {0}, 치명타 확률 {1}", skillInfo.Damage, skillInfo.CriticalRate);

            // 튜플 비교 (중요)
            //  ㄴ 이름이 달라도 타입과 순서가 같으면 비교 가능
            //  ㄴ 결국 튜플 이름은 가독성을 위한 별칭에 가깝고 → 실제 비교는 각 위치의 값 기준으로 이뤄진다.
            (int hp, int mp) playerStatA = (100, 50);
            (int health, int mana) playerStatB = (100, 50);

            // T / F
            Console.WriteLine(playerStatA == playerStatB);

            // (int hp, int mp) playerStatA = (100, 50);
            (int hp, int mp) playerStatC = (120, 50);

            // F
            Console.WriteLine(playerStatA == playerStatC);


            // 함수 반환 튜플 받기
            // 기본형태
            (int damage, bool isCritical) result = CalculateDamage(50, 0.3f);
            // var result = CalculateDamage(50, 0.3f);

            Console.WriteLine($"데미지 : {result.damage}");
            Console.WriteLine($"치명타 여부 : {result.isCritical}");

            // 튜플 분해
            //(int damage, bool isCritical) temp = CalculateDamage(50, 0.3f);
            //
            //int damage = temp.damage;
            //bool isCritical = temp.isCritical;

            // 자료형 자동변환
            var (damage, isCritical) = CalculateDamage(50, 0.3f);

            Console.WriteLine($"데미지 : {damage}");
            Console.WriteLine($"치명타 여부 : {isCritical}");
        }


        static void Main(string[] args)
        {

#if EXAMPLE_TYPE_STRING_METHOD
            Console.WriteLine("C# 문자열 함수 다루기");

            Console.WriteLine();

            // 1. 문자열 길이
            string strA = "abcde";

            Console.WriteLine("문자열 : " + strA);
            Console.WriteLine("문자열 길이 : " + strA.Length);

            Console.WriteLine();

            // 2. 문자열 비교

            /*
            stringA < stringB = 0보다 작다 (-1)
            stringA == stringB = 0
            stringA > stringB = 0보다 크다 (1)

            - 알파벳, 가나다 순서 기준

            1. a vs a   같음
            2. b vs b   같음
            3. c vs b   다름 → 여기서 결정

            */

            string strB = "abc";
            string strC = "abc";
            string strD = "abb";

            Console.WriteLine(strB == strC);
            Console.WriteLine(strB == strD);

            int result1 = string.Compare(strB, strC);
            int result2 = string.Compare(strB, strD);

            Console.WriteLine($"문자열 비교 : {result1}");
            Console.WriteLine($"문자열 비교 : {result2}");

            Console.WriteLine();

            // 3. 문자열 복사

            string strE = "ABCD";
            string strF = "CDAB";

            Console.WriteLine("문자열 복사 전 : " + strF);

            strF = strE;

            // 1. 메모리적으로 무슨 일이 발생하는가..? / 2. 어떻게 동작하는가..?
            //  ㄴ [a][ ][ ] ← [a][b][c][d][ ][ ]...
            Console.WriteLine("문자열 복사 전 : " + strF);


            // 4. 문자열 연결 (Concat)

            string strG = "오늘 과제는 ";
            string strH = "무엇이 나올까?";

            Console.WriteLine("문자열 연결 전 : " + strG);
            strG = string.Concat(strG, strH);
            // strG += strH;

            Console.WriteLine("문자열 연결 후 : " + strG);

            Console.WriteLine();

            // 5. 문자열분리
            //  ㄴ 특정 기준을 사용하여 문자열을 나눈다.

            string str1 = "ABCD EFGH";
            string[] parts = str1.Split(' ');

            Console.WriteLine("문자열 분리");

            // a.
            Console.WriteLine(parts[0]);
            Console.WriteLine(parts[1]);

            // b.
            foreach (string word in parts)
            {
                Console.WriteLine(word);
            }
            
            Console.WriteLine();

            Console.WriteLine("자주 쓰이는 문자열 함수");

            // 6. Conains
            //  ㄴ 특정 문자열이 포함되어 있는지 확인 → t / f + 대소문자 구분

            string strAA = "Unity Engine Programming";

            Console.WriteLine("문자열 : " + strAA);

            // 포함 여부 확인
            Console.WriteLine("Engine 포함 여부 : " + strAA.Contains("Engine"));
            Console.WriteLine("engine 포함 여부 : " + strAA.Contains("engine"));


            // 7. IndexOf()
            // ㄴ 위치 반환 → 문자열의 인덱스는 0부터 시작
            // ㄴ 위치가 필요하면 IndexOf()가 유리함
            // ㄴ -1 → 찾지 못했다.

            string strBB = "CSharp Programming";

            Console.WriteLine("문자열 : " + strBB);

            int index1 = strBB.IndexOf("Programming");
            int index2 = strBB.IndexOf("C++");

            Console.WriteLine("Programming 위치 : " + index1);
            Console.WriteLine("C++ 위치 : " + index2);


            // 8. Replace()

            string strCC = "I like Unity";

            Console.WriteLine();
            Console.WriteLine("변경 전 문자열 : " + strCC);

            string result = strCC.Replace("Unity", "C#");

            Console.WriteLine("변경 후 : " + result);
            Console.WriteLine("원본 : " + strCC);


            // 9. Trim()
            //  ㄴ 문자열의 앞과 뒤 공백 제거 (중간 공백은 제거되지 않는다.)

            string strDD = "                C#World             ";

            Console.Write("Trim 전 문자열 : ");
            Console.Write($"{strDD}");
            Console.WriteLine("끝!");

            string trimResult = strDD.Trim();

            Console.Write("Trim 후 문자열 : ");
            Console.Write($"{trimResult}");
            Console.WriteLine("끝!");


#elif EXAMPLE_TYPE_USER_DEFINED_TYPE

            ExampleFunciton_A();
            ExampleFunciton_B();
            ExampleFunction_C();
            ExampleFunction_BoolState();
            ExampleFunction_D();
            ExampleFunction_E();

#else

#endif

        }
    }
}
