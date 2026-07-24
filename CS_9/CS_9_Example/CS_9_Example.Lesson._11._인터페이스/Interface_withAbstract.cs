#region ISP → 추상 클래스
/*
▶ ISP → 추상 클래스

ISP 
- 무엇을 할 수 있는가?
- 행동 단위 분리

추상 클래스
- 어떤 존재 인가?
- 공통 상태 + 공통 로직

- 인터페이스와 추상 클래스는 둘 다 규약 / 설계 역할을 할 수 있지만 목적과 사용 방식이 다르다.
 ㄴ 공통점 : 함수에 대한 선언만 정의하고 이를 포함하는 클래스에서 구체화 한다.

- 그래서 우리는 언제나 상황에 맞게 적절한 문버을 꺼내 들어야 한다.
 ㄴ 계약서 : 인터페이스 → (같은 행동 가능 여부) → 무엇을 할 수 있는가?
 ㄴ 설계도 : 추상 클래스 (같은 종류) → 어떤 존재인가?

EX :
추상 클래스
 ㄴ 당신은 건물이다 / 유닛이다.

인터페이스
 ㄴ 너는 상호작용 할 수 있다.
 ㄴ 너는 들어 갈 수 있다.

*/
#endregion

using System.Xml.Linq;

namespace CS_9_Example.Lesson._11._인터페이스
{
    internal class Interface_withAbstract
    {
        public static void ExampleFunction()
        {

        }
    }

    // 1. 캡슐화 2. 상속 3. 다형성 4. 추상화
    // 5. 실제 인스턴스 만들 녀석까지 만들어 둠
    // 한계단씩

    // 행동 정의 → ISP
    public interface IAttackable
    {
        void Attack();
    }

    public interface IMoveable
    {
        void Move();
    }

    // 추상 클래스 : 존재 정의
    public abstract class Character
    {
        protected string name;

        protected Character(string name)
        {
            this.name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{name} : 준비 완료");
        }

    }

    public class Player : Character, IAttackable, IMoveable
    {
        public Player(string name) : base(name)
        {

        }

        public void Attack()
        {
            Console.WriteLine($"{name}이(가) 공격");
        }


        public void Move()
        {
            Console.WriteLine($"{name}이(가) 이동");
        }

        // 아래에서는 어떠한 행위를 할 것인가..?

    }

    public class NPC : Character, IMoveable
    {

        public NPC(string name) : base(name)
        {
            
        }

        public void Move()
        {
            Console.WriteLine($"{name}이(가) 이동");
        }

    }
}

