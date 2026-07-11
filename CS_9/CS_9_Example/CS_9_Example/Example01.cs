// using 지시자 : 지정한 네임스페이스의 모든 명칭을 이 선언이 있는 영역으로 가져와서 바로 사용한다.
// 특정 네임스페이스에 있는 클래스나 다른 타입들을 코드에서 사용하기 위한 해당 네임스페이스를 가져오는 지시문
// 네임스페이스 : 프로그래밍에서는 이름 충돌 이라는것이 생길 수가 있는데 같은 이름일 경우 컴파일 에러가 생길 수 있다.

// C# 코드 구조으 ㅣ핵심 요소

// System : C#에서 기본적으로 자주 사용하는 타입과 기능을 담고 있는 대표적인 네임스페이스
//  ㄴ 숫자 / 텍스트 같은 데이터를 다룰 수 있는 깁노적인 데이터 처리 클래스를 포함한다. (C# 코드가 필요로 하는 클래스)
using System;
// Collections : 간단하게 정의하면 데이터 모음 (자료구조)
//  ㄴ 컬렉션은 데이터를 여러 개 모아 관리하기 위한 자료구조를 의미한다.
//  ㄴ List / Stack / Queue / Hashtable 등이 C#에서는 컬렉션이라는 이름으로 제공이 된다.
using System.Collections;
// Generic : 제네릭은 컬렉션을 사용하기 위해 추가하는 네임스페이스
//  ㄴ 자료형을 미리 정해서 안전하게 데이터를 저장 / 관리 할 수 있다.
//  ㄴ 제네릭 컬렉션 같은 경우 저장할 자료형을 미리 정하기 때문에 형변환이 줄어들고 코드가 더 안전해 진다. (읽기 편함)
using System.Collections.Generic;


#region 프로젝트 생성시
/*

▶ 프로그램 생성

1. 최상위문 여부

- C# 9.0부터 도입문 기능 → 메인함수 생략할건지 안할건지..?

- 간단한 프로젝트의 경우 채용을 하는 경우가 있음


2. AOT

- 몰라도 된다. → 네이티브 코드를 컴파일 시키는 친구...

- 필요하다고 느낄 때... → C 스타일 라이브러리를 채용하고 싶을 때


3. C# 버전 확인

a. 프로젝트 속성 → 빌드에서 확인

b. #error version


4. .NET Framework VS .NET 6 ↑
    ㄴ .Net Framework 4.7.2 → C# 7.0(2.3) 기반 → 최신 문법 사용 불가
    ㄴ .NET → 언어 버전을 올리기 때문에 최신 문법 사용 가능

*/
#endregion


namespace CS_9_Example
{
    // 접근 제어 지시자 + 클래스 + Program
    //  ㄴ 지금은 크게 신경 쓰지 않아도 된다.
    internal class Example01
    {
        // 자동 완성 주석
        //  ㄴ 클래스 또는 함수 앞에서 /// 입력으로 자동 완성
        //  ㄴ 보통 사람을 위해서 준 기능이기 때문에 우리가 효율적으로 사용하면 좋다.
        //  ㄴ 미래의 나를 위해 + 내 동료를 위해 적재적소에 사용한다.

        /*
        ▶ 메인 함수

        - 메인 함수는 1개만 존재한다. → 최상위문을 제외하면 Main함수를 포함해야 한다.

        ★★★★★
        ▶ C# 코드가 실행되기까지의 큰 흐름

        - 작성한 C# 코드는 먼저 컴파일된다. (소스 코드 컴파일)

        - 컴파일 된 결과는 중간 언어로 형태가 만들어진다. (IL / MSIL)
            ㄴ 작성된 실행 파일 또는 동적 라이브러리 파일이 생성 → 이 파일이 어셈블리

        - 이후 CLR 환경에서 실행된다.

        - 실행 시점에 JIT 컴파일러가 IL 코드를 CPU가 이해할 수 있는 기계어로 변환하여 실행한다.
            ㄴ 런타임에 MSIL을 CPU가 이해할 수 있는 네이티브 기계어로 다시 컴파일하여 최종적으로 실행


        ※ 정리
        - C# 소스 코드
        - IL 컴파일
        - CLR위에서 실행
        - JIT가 최종 기계어 변환


        ▶ C# 코드를 컴퓨터가 이해하는 과정 (컴파일)
        
        - C#으로 작성한 코드는 사람이 읽기 쉬운 고급 언어
            ㄴ 당연히 컴퓨터가 바로 이해할 수 있는 형태는 아니다.

        - 그래서 C# 역시 번역 과정을 거쳐야 실행이 된다.
            ㄴ 코드의 번역을 담당하는 대표적인 컴파일러가 Rosiyn
            ㄴ Roslyn 컴파일러는 C# 소스 코드를 중간어 형태로 변환
            ㄴ 이후 .Net 런타임이 이 중간 언어를 실행하는 구조
        */



        /// <summary>
        ///  함수의 설명
        /// </summary>
        /// <param name="param1">매개변수1의 설명</param>
        /// <param name="param2">매개변수2의 설명</param>
        /// <returns>반환 값의 설명</returns>
        static void Main(string[] args)
        {
            // . : :: -> =>
            // C#은 대부분의 문법 접근을 .로 통일하고 있다.

            /*
            ▶ Console 클래스

            - 콘솔 프로그램에서 입력 / 출력 기능을 다루기 위해 사용하는 클래스
                ㄴ 우리가 보는 콘솔에 뭔가를 찍고 / 입력 받고 / 줄도 바꾸고... 전부 여기로 처리한다.
                ㄴ 콘솔 애플리케이션에 대한 표준 입력 / 출력, 그리고 스트림을 나타낸다.
                ㄴ 상속 불가

            EX :
            Console.Write()
            Console.WriteLine()

            Console.Read → 문자 1개 → 반환 int → 아스키 코드
            Console.ReadLine() → 한줄 전체를 읽음 → 반환 → string
            Console.ReadKey() → 키 입력을 바로 읽음 →콘솔에서 키 하나를 즉각 읽어오는 함수
             ㄴ 특수상황에서 좋긴한데 위에보단 범용성이 떨어진다.
            */

            Console.Write("지옥에 온걸 환영합니다.");
            Console.Write("지옥에 온걸 환영합니다.");

            Console.WriteLine();

            Console.WriteLine("지옥에 온걸 환영합니다.");
            Console.WriteLine("지옥에 온걸 \n환영합니다.");

            Console.Write("한글자 입력 : ");
            int inputValue = Console.Read();
            Console.WriteLine("입력 완료");

            Console.WriteLine("입력 완료\r\n");

            // 문자열 서식 출력
            Console.Write("숫자 : {0}, {1}, {2} \n", 1, 2, 3);

            Console.Write("한줄 입력 : ");
            Console.ReadLine();
            // Environment.NewLine : 현재 OS에 맞는 개행 문자를 반환
            Console.WriteLine(Environment.NewLine + "입력완료\n\n");

            /*
            
            ● Console.Read / Console.ReadLine

            - 동작 방식 차이가 있다

            EX :
            입력하시오. → A + Enter
            ㄴ Read() : 문자 1개만 읽음 → A만 읽고 → 엔터는 남아 있음
            ㄴ ReadLin() : 남아있는 Enter 버퍼를 읽고 문자열을("") 반환

            Console.Read();         // 한글자를 읽고 
            Console.ReadLine();      // 남은 Enter를 제거

            Console.Write("한 글자 : ");
            string c = Console.ReadLine();

            Console.Write("한줄 입력 : );
            string line = Console.ReadLine();


            업다운 게임
             ㄴ 숫자를 입력하시오. 범위는 1 ~ 100

            입력 : 50 + Enter까지
             ㄴ 50 / return

            출력 버퍼
            cout << '\n';
            cout < "\n";
            cout << endl;

            */

            Console.WriteLine("◆ ★");
            Console.Write("키 입력 : ");
            Console.ReadKey();
            Console.WriteLine("\n 입력 완료");

            #region 서식 문자열 + 특수 문자 + n진법
            /*
            ▶ 서식 문자열

            - 출력할 때 값을 원하는 형태로 표시하기 위한 문자열 형식

            - 문자열 안에 값을 끼워 넣거나 숫자를 특정 형식으로 바꿔 출력할때 사용한다.

            - C언어에서 사용한 printf()처럼 서식문자를 사용할 수 있으나 C언어 스타일 대론느 사용하지 않는다.
             ㄴ C# 만의 방식이 있다는 뜻


            ● 종류

            01. 문자열 보간

            - 보간이란?

            - 문자열 앞에 $를 붙이면 문자열 보간을 사용할 수 있다.

            Ex)
            int playerHP = 100;
            Console.Write("playerHP : {0}", playerHP);
            Console.WriteLine($"playerHP : {playerHP}");


            02. string.Format()

            03. ToSTring()



            ▶ 특수 문자


            ▶ n진법
            
            
            */
            #endregion

            Console.WriteLine();
            PrintTextColor("====", ConsoleColor.Blue, ConsoleColor.Green);

            Console.WriteLine();
            PrintTextColor("====", ConsoleColor.Red, ConsoleColor.Yellow);
        }

        // 함수 → 글자 색과 관련된
        // 콘솔에서는 16색상
        static void PrintTextColor(string text, ConsoleColor fontColor, ConsoleColor backgroundColor)
        {
            // 기존 색상 저장
            ConsoleColor oldFont = Console.ForegroundColor;
            ConsoleColor oldBackGround = Console.BackgroundColor;

            // 새 색상 적용
            Console.ForegroundColor = fontColor;
            Console.BackgroundColor = backgroundColor;

            // 출력
            Console.WriteLine(text);

            // 색상 복원
            Console.ForegroundColor = oldFont;
            Console.BackgroundColor = oldBackGround;

        }
    }
}
