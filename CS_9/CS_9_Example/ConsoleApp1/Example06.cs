#define EXAMPLE_TYPE_SHUFFLE
// #define EXAMPLE_TYPE_STRING

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

#region 셔플
/*
셔플
- 게임 프로그래밍에서 셔플이란 데이터를 섞는 행위를 말한다
- 배열이나 리스트 같은 문법에 들어 있는 데이터의 순서를 무작위로 섞는 것
- 아이템 드롭 순서/ 몬스터 스폰 순서/ 카드 덱 섞기 등 랜덤성이 필요한 대부분의 게임 시슽템에서 사용된다
- 셔플은 단순히 여러 번 뒤섞는 것이 아니라 각 위치에 들어갈 데이터를 하나씩 확정해 나간다

알고리즘
자료구조 / 알고리즘


언어별 셔플 방식
C
- C언어는 셔플 전용 기능이 없다 > 직접 알고리즘을 구현해서 셔플을 수행한다
ex) 피셔 -예이츠 셔플
- 모든 경우의 수가 동일한 확률로 섞이는 공정한 알고리즘
C++
- 알고리즘 헤더에 들어가 있다
- 내부적으로 피셔
- 예이츠 기반으로 동작
- 단 사용을 위해서는 난수 엔진이 필요하다
C#
- 기본 라이브러리에 셔플 전용 함수는 없다
- 다만 랜덤과 배열 혹은 리스트를 이용해 셔플 알고리즘을 직접 구현한다
*/
#endregion

#region 알고리즘
/*
▶ 알고리즘

- 자료구조 / 알고리즘

◈ 자료구조 : 데이터를 저장하고 관리하는 방법 또는 형태
 ㄴ 데이터를 더 효율적으로 접근 / 수정 / 검색하기 위해 사용

- 알고리즘이란 문제를 해결하기 위한 절차나 방법
 ㄴ 프로그램에서는 이러한 절차가 명령어의 형태로 작성

- 어떤 문제를 해결하기 위해 "무엇을 어떤 순서로 처리할것인가...?"를 정한 것이 알고리즘

EX :
- 두 값을 바꾸는 스왑
- 숫자를 오름차순 / 내림차순 정렬
- 카드 덱을 섞는 방법


▶ 셔플도 알고리즘이다.

- 데이터를 무작위로 섞는 작업

- 단순히 데이터를 뒤섞는 것처럼 보이지만 실제로는 어떤 순서로 / 어떤 기준으로 자리를 바꿀 것인지가 필요하다.
 ㄴ 데이터를 섞기 위한 절차가 필요하다 → 알고리즘에 해당


- 셔플에서 알고리즘은 공정한 결과가 나와야 한다.
 ㄴ 경우의 수 → 어떤 경우의 수는 자주 나오고 / 어떤 경우의 수는 거의 나오지 않고


● 피셔-에이츠 셔플의 장점

- 대표적인 배열 셔플 알고리즘
 ㄴ 배열의 뒤쪽부터 한칸씩 내려온다. → 현재 위치의 데이터를 서로 바꾸는 방식으로 동작

- O(n)
- 구현이 단순하며 배열에서 직접 동작하기 때문에 사용하기도 쉽다.
- 각 경우의 수가 고르게 나올 수 있도록 설계된 공정한 알고리즘 (셔플)
- 한번 순화하면서 처리할 수 있어 효율도 좋다.

O(1) O(log n) O(n) O(nlogn) O(n^2)

● 알고리즘 성능

평가 기준
 ㄴ 1. 시간 복잡도
 ㄴ 2. 공간 복잡도

- 알고리즘은 최선 / 평균 / 최악의 경우를 나눠서 평가하는데 좋은 알고리즘이란...
 ㄴ 평균과 최악의 경우를 중심으로 평가한다.


입력값         O(1)            O(n)            O(n^2)
1              1               1               1
10             1               10              100
100            1               100             10000
1000           1               1000            1000000
n              1               n               n^2



*/
#endregion

#region 문자열 + 불변
/*
▶ 문자와 문자열

● 문자 (char)

- 문자는 하나의 문자를 저장하기 위한 자료형이다.
- C#의 char는 유니코드 기반으로 하나의 문자를 표현한다. (UTF-16)


● 문자열 (string)
 
- 문자열이란 문자들이 모여 만들어진 데이터로 단어 / 문장 / 텍스트 정보를 표현하기 위해 사용된다.

- 개념적으로 문자열은 여러개의 문자가 연속적으로 모인 형태 (char)
 ㄴ C#에서는 문자열을 string 클래스로 제공을 한다. (참조형)
 ㄴ 단순한 문자 배열이 아니라 문자를 다루기 쉽게 만들어준 클래스라고 보면 된다.

★★★★
- 불변 객체 : 한번 생성된 문자열은 수정되지 않고 새로운 문자열을 생성
 ㄴ 변경이 발생하면 기존 문자열을 수정하는 것이 아니라 새로운 문자열이 생성된다.

- string 클래스는 내부적으로 char 배열을 기반으로 동작하지만 사람이 더 편하게 다룰 수 있도록 여러 기능을 지원한다. (함수)
 ㄴ 문자열 관련 기능이 System.String 클래스에 들어가 있고
 ㄴ 복사 / 비교 / 연결 / 검색 등 모든 기능이 함수 호출로 가능! (유레카)

- 문자열 끝을 나타내는 널 문자를 직접 관리할 필요도 없다.
 ㄴ 사용 난이도가 낮고 편의성은 좋다.
 ㄴ 다만...문자열이 불변 객체이기 때문에 반복적인 문자열 변경이 많은 경우에는 성능면에서 매우 비효율적...


▷ C#에서의 문자와 문자열

문자(char)
 ㄴ ''로 감싼 한 글자

문자열(string)
 ㄴ ""로 감싼 여러 글자 집합


▷ 메모리 단위

- C# char → 2바이트 (16비트) → UTF-16 문자 하나를 표현하기 위해

- 바이트와 비트의 관계
 ㄴ 1바이트 == 8비트
 ㄴ 1비트 : 0과 1을 표현할 수 있는 가장 작은 단위

- C/C++ → char → 1 바이트 (아스키 문자용)

- C#은 전 세계 문자를 다루기 위해 char부터 2바이트를 사용하며 이는 범용성 + 사용을 위한 선택


C/C++ → '찰' → 1바이트

C# →'찰' → 2바이트


● 메모리 단위 흐름

- bit → byte → KB → MB → GB → TB → PB → EB → ZB


▷ 문자 집합과 인코딩 살짝만..

- 문자 집합은 어떤 문자를 표현할지 정해둔 약속

- 인코딩은 그 문자를 실제 컴퓨터 메모리에 어떻게 저장할지 정하는 방식이다.

1. ASCII (영어 중심)
 ㄴ 영어 알파벳, 숫자, 일부 기호 중심의 옛 문자 체계
 ㄴ 한글 같은 다양한 문자를 표현하기가 힘들다.

2. Unicode (전 세계 문자 지원)
 ㄴ 전 세계 문자를 하나의 기준으로 다루기 위한 문자 체계
 ㄴ C# 문자열은 유니코드 기반으로 동작

3. 멀티바이트
 ㄴ 지금은 이름 정도만.. 이런게 있구나...

=========================================== 여기까지 1차 =================================================

▶ 문자열 불변성

문자열 → 불변 객체 → 스트링 킨택스트 풀 (인턴 풀) → 둘의 상관관계

- C# 문자열 → 불변 객체
 ㄴ 한번 생성된 문자열은 내부 내용을 직접 수정할 수 없다.
 ㄴ 문자열이 변경되는 것처럼 보이는 모든 동작은 실제로는 새로운 문자열을 생성하고 있는 것

- 문자열을 수정하는 함수들은 원본 문자열을 변경하지 않고 항상 새로운 문자열을 반환한다.

불변 → 인턴 풀 → 안전한 메모리 공유

char[옥지불]
char[불지옥........코]
     0 1 2 .....5......100000 → 100000

0-1-2-3-4.......-100000

char[불지옥] → 출입문 → 0 주소값

일자..? → 자료구조 → 선형 자료구조

[10] → 사람 관점... → 결과가 OK


Q. 문자가 10개 있다고 가정했을 때 마지막 문자에 추가로 문자를 붙인다면 메모리적으로 어떤 일이 발생하는가?


EX :
string strA = "(!)불지옥";
string strB = strA;

strB = strB + " 환영";

strA : 불지옥
strB : 불지옥 환영


▶ 문자열 컨텍스트 풀 (+인턴 풀)

- 언젠가 보겠지...
*/
#endregion


namespace ConsoleApp1
{
    internal class Example06
    {
        // O(1) → 상수 시간
        //int Case1(int n)
        //{
        //    return n * n;
        //}

        //// O(n) → 선형 시간
        //int Case2 (int n)
        //{
        //    int count = 0;

        //    for (int i = 0; i < n; i++)
        //    {
        //        count++;
        //    }

        //    return count;
        //}

        // O(n)
        // 잘못된 셔플
        static void WrongShuffle(int[] array, Random random)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int randomIndex = random.Next(0, array.Length); // 0부터 배열길이까지 올라감

                int temp = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }

        // 피셔-에이츠 (균등 셔플)
        static void Shuffle(int[] array, Random rand)
        {
            for (int i = array.Length - 1; i > 0; i--) // 배열길이부터 역으로 1까지 내려감
            {

                int j = rand.Next(0, i + 1);

                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            /*
            - 배열이 3개라고 하면... 3! 6가지
             ㄴ ABC
             ㄴ ACB

             ㄴ BAC
             ㄴ BCA

             ㄴ CAB
             ㄴ CBA

            */
        }


        static void Main(string[] args)
        {

#if EXAMPLE_TYPE_SHUFFLE

            Random rand = new Random();

            // 배열 초기화
            int[] num = new int[10];
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = i;
            }

            // 출력
            Console.WriteLine("초기 배열 : ");
            for (int i = 0; i < num.Length; i++)
            {
                // 0 ~ 9
                Console.Write(num[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < num.Length; i++)
            {
                int dest = rand.Next(0, 10);
                int sour = rand.Next(0, 10);
                // 튜플 스왑
                (num[dest], num[sour]) = (num[sour], num[dest]);
            }

            Console.WriteLine("셔플 결과 : ");

            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine($"[{i}] = {num[i]}");
            }

            Console.WriteLine("========================================");

            Console.WriteLine("\n 1 ~ 5까지 섞기");
            Console.WriteLine();

            int[] small = new int[5];
            for (int i = 0; i < small.Length; i++)
            {
                small[i] = i + 1;
            }

            for (int i = 0; i < small.Length; i++)
            {
                Console.WriteLine(small[i] + " ");
            }

            // 함수의 순기능
            Shuffle(small, rand);

            Console.WriteLine();

#elif EXAMPLE_TYPE_STRING

            char ch = 'A';
            int numA = 20;
            float numB = 3.2f;
            bool numC = true;

            Console.WriteLine(ch);

            // 혹여나..... unSafe 사용 할 예정이면 지금 당장은 접으시길...
            Console.WriteLine(sizeof(char) + " : 바이트");
            Console.WriteLine(sizeof(int) + " : 바이트");
            Console.WriteLine(sizeof(float) + " : 바이트");
            Console.WriteLine(sizeof(bool) + " : 바이트");

            // C# 문자열 → 동작 방식 + 미래의 면접을 위해서 방어

            string strA = "Unity Engine!";
            

            Console.WriteLine("strA = " + strA);
            Console.WriteLine("문자열 길이 : " + strA.Length);
            // 대문자 반환
            Console.WriteLine("대문자 : " + strA.ToUpper());
            // 소문자 반환
            Console.WriteLine("소문자 : " + strA.ToLower());
            Console.WriteLine("일부만 : " + strA.Substring(0, 5));
            Console.WriteLine("첫번째 : " + strA[0]);

            LottoSample();



#else

#endif
        }

        static void LottoSample()
        {
            Random rand = new Random();

            char deco = '*';
            string title = "한방에 가자~!";

            // 지금 만드는 로직에선 효율적이지 않음
            Console.WriteLine($"{deco}{deco} {title} {deco} {deco}\n");
            //Console.WriteLine("** 한방에 가자~! * *");

            int[] number = new int[45];

            // 초기화
            for (int i = 0; i < 45; i++)
            {
                number[i] = i + 1;
            }

            Shuffle(number, rand);

            string header = "로또 번호 결과";

            Console.WriteLine(header);

            // 보너스 번호 고려 X
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"[{i}] = {number[i]}");
            }

            Console.WriteLine();

        }

    }
}
