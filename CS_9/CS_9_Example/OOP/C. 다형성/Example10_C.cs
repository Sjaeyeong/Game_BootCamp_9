#region 다형성
/*
▶ 다형성

- 여러 형태로 표현될 수 있다는 뜻

- 부모 클래스의 함수를 자식 클래스에서 재정의하며 같은 호출 방식이지만 서로 다른 동작을 수행하도록 만드는 객체지향의 개념

- 자식 객체의 인스턴스를 부모 타입으로 참조할 수 있음
 ㄴ 이때 실제 동작은 객체의 실제 타입에 따라 결정됨
 ㄴ 그리고 어느 클래스에서 생서된 객체를 인스턴스라고 한다.

EX :
- 집이라는 클래스를 설계하고 → 내 방이라는 객체를 생성하면 → 집 클래스의 인스턴스가 생성됐다라고 얘기할 수 있다.


● 다형성하면 기억할 것

1. 하이딩

- 부모 클래스의 함수를 자식 클래스에서 재정의하여 부모의 함수를 숨기곘다.


2. 오버라이딩

- 부모 클래스의 가상 함수를 자식 클래스에서 재정의 하겠다.


★★★★★
● 가상 소멸자

- virtual → X → Dispose 패턴을 사용해서 정리할 것

- 어려운게 맞음


EX : 상속 관계에서..

- 클래스는 결국 생성자 + 소멸자


        O
    
    O       O

O               O

▶ 가상 함수

- 부모 클래스의 함수를 자식 클래스에서 재정의할 수 있도록 허용한다.

- virtual / override

- 런타임 시점에 실제 객체 타입을 기준으로 호출을 결정한다.

★★★★★★★★★★★★★★★★★★★★★★★★★★★★
V - Table


● 함수 오버라이딩

- 부모 클래스의 가상 함수를 자식 클래스에서 동일한 시그니처로 재정의하는 것
 ㄴ 함수이름 + 매개 변수 동일 + 반환형 같아야 함

- 런타임에 실제 객체 타입을 기준으로 호출 함수를 결정한다.
 ㄴ 이를 동적 바인딩이라고 한다.

- virtual / override 를 명시하지 않으면 하이딩 처리 됨


※ 다형성은 부모 타입 하나로 여러 자식 객체를 다루되 실제 동작은 객체 스스로 결정하게 만드는 구조


*/
#endregion

namespace OOP.Polymorphism
{
    internal static class Example10_C
    {


        public static void ExampleFunction()
        {


        }

        class Skill
        {
            public virtual void Use()
            {
                Console.WriteLine("기본 공격 실행");
            }


        }

        class GunSkill : Skill
        {
            public override void Use()
            {
                Console.WriteLine("총알 발사");
            }
        }

        class BowSkill : Skill
        {
            public override void Use()
            {
                Console.WriteLine("화살 발사");
            }
        }

        class BattleScene
        {
            private Skill _gunSkill;
            private Skill _bowSkill;
            private Skill _currentSkill;

            public BattleScene()
            {
                _gunSkill = new GunSkill();
                _bowSkill = new BowSkill();

                Console.WriteLine("전투 시작");

                _currentSkill = _gunSkill;
                _currentSkill.Use();

                _currentSkill = _bowSkill;
                _currentSkill.Use();

            }
        }

        // 추상 클래스 → 1개 이상의 추상 메서드를 포함하는 클래스
        //  ㄴ 클래스가 추상적인 표현을 정의하는 경우 → 자식 클래스에서 구체화하여 구현할 것을 염두에 두고 abstract를 붙여 명시한다.
        abstract class Unit
        {
            public void ShowInfo()
            {
                Console.WriteLine("기본 유닛");
            }

            // 추상 함수 → 구현이 없는 함수 → 재정의가 필요하다는 것 → 상속
            public abstract void Move();

            public virtual void Die()
            {
                Console.WriteLine("유닛 사망");
            }

            // 다형성 : 같은 명령 → 다른 동작

            // 추상화 : 부모는 규칙만 제시  → 구현은 자식에게 위임

            // 각각 별개로 사용할 수도 있으나 둘은 대부분 같이 사용할 때가 많다.

        }

        class GroundUnit : Unit
        {
            public new void ShowInfo() => Console.WriteLine("지상 유닛");

            public override void Move()
            {
                Console.WriteLine("지상 유닛이 이동한다.");
            }

            public override void Die()
            {
                Console.WriteLine("지상 유닛 파괴");
            }

        }

        class AirUnit : GroundUnit
        {
            public new void ShowInfo() => Console.WriteLine("공중 유닛");

            public override void Move()
            {
                Console.WriteLine("공중 유닛이 이동한다.");
            }

            public override void Die()
            {
                Console.WriteLine("공중 유닛 파괴");
            }
        }

        private static void Example_Polymorphism_A()
        {
            BattleScene scene = new BattleScene();

            Console.WriteLine("하이딩 (같은 인스턴스");

            AirUnit air = new AirUnit();
            GroundUnit groundRef = air;
            Unit unitRef = groundRef;

            unitRef.ShowInfo();
            groundRef.ShowInfo();
            air.ShowInfo();
        }











    }

}

