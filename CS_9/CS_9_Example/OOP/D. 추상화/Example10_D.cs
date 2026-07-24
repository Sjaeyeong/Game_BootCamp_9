#region 추상화
/*
▶ 추상화


복잡한 구현 세부 사항을 숨기고 핵심적인 특징만 남기는 것을 의미한다.
 ㄴ 

1. 추상 함수

- abstract

- 함수의 구현부가 없는 함수를 의미

- 보통 순수 가상 함수라고 부른다. → C#은 그냥 추상 함수라고 부르면 된다.


2. 추상 클래스

- 하나의 추상 함수를 포함하는 클래스

- 게임의 공통 속성 + 동작을 묶는 설계도 역할을 할 수 있다.
 ㄴ 직접 객체 생성 불가

- 추상 클래스는 내용을 구체화 할 수 없는 추상 함수는 구현부를 정의하지 않는다.
 ㄴ 자식 구현을 염두에 두고 설계

- 추상 클래스를 상속한 자식 클래스가 추상 함수를 재정의하여 실체화 한 경우 인스턴스 생성 가능

- 관점 → 모든(대부분의) 유닛은 행동을 한다. → 행동 방식이 유닛마다 다르다.

- 공통 구현 + 강제 구현이 섞여 있음
 ㄴ 공통은 당연히부모에 둔다.

- abstract → override

- 부모를 수정하면 자식에게 전부 영향을 줄 수 있다.

※ 추상적 개념은 큰거 한방보다 → 작게 여러개로...


3. 인터페이스

- 인터페이스는 기본적으로 구현보다 "규약"을 정의하는 구조

- C# → interface 키워드로 정의
 ㄴ 표기법은 I

- C#에서 인터페이스는 "기본 구현"도 가능하게 최신 문법으로 추가된 상태

EX :
- 추상 클래스 : 게임 기획서 / 설계도
- 인터페이스 : 행동 계약서


4. 가상 함수와 오버라이드

- 재정의를 할 수 있는 기능

*/
#endregion
namespace OOP.Polymorphism
{
    internal static class Example10_D
    {
        public static void ExampleFunction()
        {
            ConsolePrint.Title("추상화");

            Unit scv = new SCV();
            Unit probe = new Probe();

            scv.PrintStatus();
            probe.PrintStatus();

            scv.Work();
            probe.Work();

            // 객체가 다수 일때는 배열 처리로 진행하면 편리하다

        }

        public abstract class Unit
        {
            protected string name;
            protected int hp;
            protected int workPower;


            protected Unit(string name, int hp, int workPower)
            {
                this.name = name;
                this.hp = hp;
                this.workPower = workPower;
            }

            public void PrintStatus()
            {
                Console.WriteLine($"{name} HP : {hp}, 작업 효율 : {workPower}");
            }

            public abstract void Work();

        }

        public class SCV : Unit
        {
            public SCV() : base("SCV", 60, 5)
            {
                Console.WriteLine("SCV 생산 완료");
            }

            public override void Work()
            {
                Console.WriteLine("SCV가 광물을 채취한다.");
                hp -= 1;

            }
        }

        public class Probe : Unit
        {
            public Probe() : base("Probe", 40, 7)
            {
                Console.WriteLine("Probe 생산 완료");
            }

            public override void Work()
            {
                Console.WriteLine("Probe가 광물을 채취한다.");
                hp -= 1;

            }
        }



    }
}
