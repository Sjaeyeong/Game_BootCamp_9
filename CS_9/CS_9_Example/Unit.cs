namespace OOP.Inheritance
{
    /*
    ● Unit (모든 유닛의 공통 기반 클래스)

    - 모든 유닛이 공통으로 가지는 속성과 동작만 정의
    - 이동 방식 / 공격 방식 등은 자식 클래스에서 구체화를 할 수 있게 틀을 만든다.




    */

    // 공통 개념만 남기고 자식에서 확장 가능하게
    internal class Unit
    {
        // 자식 클래스에서 접근 가능 (공통 상태)
        protected string name;
        protected int hp;
        protected int mp;
        protected int atk;
        protected bool isDead;
        
        public Unit(string name, int hp, int mp, int atk)
        {
            this.name = name;
            this.hp = hp;
            this.mp = mp;
            this.atk = atk;
            this.isDead = false;
        }

        // 공통 동작

        /// <summary>
        /// 이동 (기본 동작)
        /// : 이동 방식은 자식 클래스에서 재정의 가능
        /// </summary>
        public virtual void Move()
        {
            // 가상 함수
            //  ㄴ 부모 클래스의 함수를 자식 클래스에서 재정의할 수 있도록 허용하는 매커니즘
            // 부모 함수가 virtual 이면 자식에서 재정의 가능
            //  ㄴ 재정의가 발생하면 → 자식 함수가 실행이 된다.

            Console.WriteLine($"{name}이(가) 이동한다.");

            // 수정이 필요할 것 같다...
        }

        /// <summary>
        /// 공격
        /// : 실제 공격 방식은 자식에서 재정의
        /// </summary>
        public virtual void Attakc()
        {
            Console.Writelin($"{name}이(가) 공격한다. (공격력 : {atk}");

            // Console.WriteLine($"칼로 공격한다. (공격력 : {atk})");

        }

        // 공개 인터페이스
        public void Kill()
        {
            Die();

        }

        protected virtual void Die()
        {
            isDead = true;
            Console.WriteLine($"{name}이(가) 파괴됨");
        }

        // 상태 출력
        public void PrintStatus()
        {
            Console.WriteLine($"[상태] 이름 : {name}, HP : {hp}, MP : {mp}, Atk : {atk}, 생존 : {!isDead}");
        }



    }
}