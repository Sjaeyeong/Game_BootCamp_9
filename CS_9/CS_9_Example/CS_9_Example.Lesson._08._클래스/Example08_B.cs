using System;

#region 메모리 구성
/*
▶ 메모리 구성

※ 메모리 순환(5일차)

- 컴퓨터는 다양한 메모리의 구성 영역을 가진다.

- OS나 아니면 사용하는 언어에 따라 조금씩 변동은 있지만 개념적으로는 비슷
 ㄴ 런타임 / JIT 등에 따라 조금씩 변동이 생길 수 있다.


1. 코드 영역

- 실행할 코드가 저장되는 메모리 공간 → CPU는 코드 영역에 저장된 명령문들을 하나씩 가져와서 실행

- 코드 영역은 운영체제에 의해서 관리되기 때문에 직접적 제어 불가능

- 실행할 프로그램 코드가 저장되는 영역 → CPU가 주로 활동할 수 있는 영역

- C# → 소스코드가 IL로 컴파일 되고 → 실행시 JIT → 기계어


2. 데이터 영역

- static 멤버처럼 프로그램 전체에서 오래 유지되는 데이터가 논리적으로 관리되는 영역

- 근데 C#에서는 전역 변수 개념이 없으며 static 멤버가 그 역할을 일부 대신한다.

- 프로그램 시작과 동시에 메모리 공간에 할당되어 프로그램 종료시 해제가 된다.

※ const는 컴파일 타임 상수


3. 스택 영역

- 지역 변수 / 매개변수 / 함수 호출 정보등이 관리되는 영역

- 함수 호출 시 생성되고 함수 종료시 정리되는 흐름을 가진다.
 ㄴ 시스템에 의해서 자동 관리

- 값 형식의 데이터가 주로 저장된다.
 ㄴ 스택 : 나중에 들어온 것이 먼저 나간다. (선입후출)
 ㄴ 큐 : 먼저들어온 것이 먼저 나간다. (선입선출)
  ㄴ 스택은 되감기 / 큐는 예약 재생

★★★
- 스택의 용량은 윈도우 기준 기본 1MB로 생각할 수 있다.
 ㄴ 당연히 설정 값 바꿔 줄 수도 있고 분할도 가능

- 스택은 스레드마다 따로 1개씩 별도로...

※ C#에서는 지역 변수와 함수 호출 흐름을 관리하는 공간이다.


4. 힙 영역

- 참조 형식 객체가 주로 생성되고 관리되는 영역

- new 키워드를 통해 생성한 객체는 보통 힙 영역에 생성된다고 이해하면 된다.

- C# → GC가 객체의 생명 주기를 관리한다.

- 개발자가 메모리 해제 시점을 직접 제어하지 않음


● C# 메모리 구성 특징

- C#은 관리형 언어 → 용어 기억할 것 ★★
- 메모리 할당과 회수는 GC가 담당 (런타임)
- 개발자는 객체 생성에만 집중하고 메모리 해제는 직접 하지 않는다.


● 힙 객체 생성과 관리

- new 키워드를 통해 힙에 객체가 생성된다.
- 객체를 참조하는 변수가 더 이상 없으면 GC가 해당 객체를 수거한다?
- 언제 해제되는지는 보장되지 않으며 이는 런타임이 성능을 고려해 결정을 한다.


설계 → 고려를 해야하는 부분


● 동적 할당

C#
- new로 객체 생성
- delete가 없음
- GC
- 전통적인 댕글링 포인터 개념이 없다 → GC 때문에


● 메모리 관련 주의 사항

1. 메모리 릭 (메모리 누수)

- 참조가 남아 있어 더 이상 필요 없는 객체가 수거되지 않는 현상
- static 참조 / 이벤트 미해제 / 컬렉션 미정리 등이 대표적인 메모리 릭 현상을 유발한다.
 ㄴ 관리되지 않는 리소스 → 해제하지 않으면 메모리 릭 발생

작업 기준 → 30일 → 초 중 후


2. 댕글링 포인터

- 일반적인 C# 코드에서는 전통적인 의미의 댕글링 포인터는 거의 발생하지 않는다.
- 대신 참조가 남아 있어서 GC가 수거하지 못하는 형태의 메모리 릭에 더 신경을 써야 한다.

※ C#은 메모리를 자동 관리하지만 → 불필요한 참조를 정리하는 설계까지 자동으로 해주지 않는다. → 개입

*/
#endregion

namespace CS_9_Example.Lesson._08._클래스
{


    internal class Example08_B
    {
        /*
        ▶ 값 형식과 참조 형식

        ● 값 형식

        - 스택 영역에 저장되는 경우가 많음
        - 복사 시 실제 데이터 자체가 복사된다.
        - 서로 다른 변수는 완전히 독립적
        - 블록이 끝나면 자동 소멸

        EX : int / float / bool / struct

        ※ 값 형식은 데이터 자체가 중요하다. ← ★★★


        ● 참조 형식

        - 주로 힙 영역에 저장
        - 변수에는 데이터가 아닌 주소가 들어가 있음
        - 복사시 주소만 복제됨
        - 여러 변수가 같은 객체를 가리킬 수 있음
        - 참조되지 않으면 → GC에 의해 소멸


        EX : class / string / array

        ※ 참조 형식은 원본 객체가 중요

        */

        // 복사와 참조

        // ref 매개변수
        static void AddHp(ref int hp, int value)
        {
            hp += value;
        }

        static void ExampleFunction()
        {
            int hp = 100;

            AddHp(ref hp, 20);

            // 100
            Console.WriteLine(hp);

            // hp → 값 → 복사
            //  ㄴ 함수 내부에서 바뀐 hp는 원본과 무관

            // 원본을 직접 바꾸는 게 아니라 변경된 값을 다시 받아와서 덮어쓴다.
            //  ㄴ 값 형식에서 가장 흔한 패턴

            // ref를 사용하면 값 형식이라도 참조로 전달이 된다.
            // 함수 내부에서 바꾼 값이 원본에 그대로 반영
            // 값 형식임에도 불구하고 참조처럼 동작할 수 있다.
        }

        struct PlayerValue
        {
            public int hp;
        }

        class Playerref
        {
            public int hp;
        }

        static void ExampleFunction_A()
        {
            // 값 복사
            PlayerValue a;
            a.hp = 100;

            // a를 b에 대입 → 참조를 넘긴게 아닌 → a안에 들어 있는 값 전체를 복사
            PlayerValue b = a;
            b.hp = 200;

            // 구조체 → 값 → 대입 시 값 자체가 복사
            //  ㄴ 서로 독립 a : hp = 100, b : hp = 200
            // 100
            Console.WriteLine(a.hp);
            // 200
            Console.WriteLine(b.hp);

            // 힙... → 객체... → c라고 하는 놈은... 객체의 주소를 가지고 있겠군..
            //  ㄴ 클래스는 참조 타입
            Playerref c = new Playerref();
            c.hp = 100;

            // 주소 복사
            //  ㄴ 대입시 값이 아니라 주소(참조)가 복사됨
            //  ㄴ c가 들고 있는 주소를 그대로 d에게 복사
            //  ㄴ c와 d는 같은 객체를 가르키고 있다? 없다?
            Playerref d = c;
            // d를 통해 접근 → 객체는 결국 하나 → 같은 객체의 hp가 변경이 됨
            d.hp = 200;

            // 2..
            Console.WriteLine(c.hp);
            // 2..
            Console.WriteLine(d.hp);

            // 값 형식 : 데이터가 중요 → 값이 복사된다.
            // 참조 형식 : 원본이 중요 → 원본 주소가 복사됨
            // ※ 값 형식은 사본으르 만들어 쓰는 개념 / 참조 형식은 같은 물건을 여러 명이 같이 쓰는 개념 (! → OOP)

        }

        static void ExampleFunction_B()
        {
            int playerHP = 10;

            // 참조가 유리
            // 값 형식의 참조를 전달하기 위한 ref
            ref int currentHp = ref playerHP;

            // 원본 변경
            playerHP = 20;

            // 참조 중인 값도 같이 변경됨
            Console.WriteLine($"현재 체력 : {currentHp}");

        }

        // 값에 의한 호출
        static void SwapItem(int slotA, int slotB)
        {
            // 매개 변수 slotA / slotB 원본 값의 복사본
            // 함수 안에서만 존재하는 지역 변수

            int temp = slotA;
            slotA = slotB;
            slotB = temp;
        }

        // 참조에 의한 호출 (Call By Reference)
        static void SwapItem(ref int slotA, ref int slotB)
        {
            // 값이 아닌 원본 변수 자체를 전달
            // 함수의 매개변수가 원본 변수의 별명(별칭)이 된다.
            // 함수 내부 변경 = 원본 변경

            int temp = slotA;
            slotA = slotB;
            slotB = temp;
        }

        // 출력 전용 매개변수
        //  ㄴ 함수가 반드시 값을 넣어야 함
        static void CalculateReward(out int gold)
        {
            // out은 함수 안에서 계산된 결과를 호출한 쪽으로 되돌려 주기 위한 매개변수이다.
            gold = 100;

        }

        struct DamageInfo
        {

        }

        class Monster
        {

        }


        // 매개 변수의 전달 방식
        //  ㄴ ref 매개 변수 : 참조 형식으로 매개변수를 넣어 원본을 수정 가능
        //  ㄴ out 매개 변수 : 출력 전용 참조형식으로 매개변수를 넣은 경우.. 원본이 함수에서 변경한 데이터도 수정이 된다.
        //                     여러 값을 한번에 반환하고 싶을 때

        static void ExampleFunction_C()
        {
            int itemSlotA = 1;
            int itemSlotB = 2;

            SwapItem(itemSlotA, itemSlotB);

            // 그대로 나옴 1 / 2
            // 값 타입 → 값만 복사 → 함수안에서 바뀐 값은 원본에 영향 없음
            Console.WriteLine($"슬롯 A : {itemSlotA} / 슬롯 B : {itemSlotB}");

            int itemSlotC = 1;
            int itemSlotD = 2;

            SwapItem(ref itemSlotC, ref itemSlotD);

            // 2 / 1
            // ref는 원본 주소를 전달 → 실제 슬롯이 바뀐다.
            //  ㄴ 함수 내부에서의 변경이 호출한 쪽에도 그대로 반영이 된다.
            Console.WriteLine($"슬롯 C : {itemSlotC} / 슬롯 D : {itemSlotD}");

            int rewardGold;

            CalculateReward(out rewardGold);

            Console.WriteLine($"획득 골드 : {rewardGold}");

            /*
            
            ref :
            - 들어올 때 값 필요
            - 나갈때도 값 유지
            - 기존 값을 수정하는 용도


            out :
            - 들어올 때는 값 필요 없음
            - 나갈 때 반드시 값이 채워져야 함
            - 결과 전달 전용

            ● 정리

            - 값 전달 : 임시 계산용

            - ref : 직접 수정이 필요할 때

            - out : 결과를 함수가 계산해서 돌려받고 싶을 때

            */

            // 값 (스택)
            DamageInfo damage;                  // 스택 영역에 공간 확보
            damage = new DamageInfo();          // 구조체 값이 스택에 직접 저장이 된다.

            // 참조 (힙)
            Monster monster;                    // 스택에는 참조만
            monster = new Monster();            // 실제 몬스터 객체는 힙에

            // 함수안에 있어서 함수가 스택에서 빠질 때 위의 4개는 다 빠지지만 monster는 힙영역에 남게된다
            // 하지만 monster의 주소가 없어져서 GC의 대상이 되어 GC에 의해 사라진다?
        }

        
        static void Main(string[] args)
        {

            ExampleFunction();
            ExampleFunction_A();
            ExampleFunction_B();
            ExampleFunction_C();

        }

    }
}
