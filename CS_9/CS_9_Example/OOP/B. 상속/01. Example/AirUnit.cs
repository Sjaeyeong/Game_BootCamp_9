using System;
/*
1. 못한다 X
2. 권장하지 않음
3. 지금은 사용하지 말것
4. 뺏긴것


A               O



B       O               O



C   O       O       O       O
 

*/


namespace OOP.Inheritance
{
    // 상속 중간 단계
    // AirUnit은 공중이라는 특성만 추가하면 된다.
    //  ㄴ 유닛으로서의 기본 책임은 Unit
    internal class AirUnit : Unit
    {
        // 이동 방식만 공중 특성에 맞개 재정의가 필요하다.
        // 공격 방식 / 특수 능력 등등은 하위 클래스에서 구현이 필요하다.
        // 고도
        protected int altitude;

        // 생성자
        public AirUnit(string name, int hp, int mp, int atk, int altitude)
            : base(name, hp, mp, atk)
        {
            /*
            ● base 키워드

            - 자식 클래스에서 부모 클래스 쪽 생성자 또는 멤버를 가르킬때 사용하는 키워드

            → C# 기준
            - 자식 객체를 만들때는 부모가 가진 공통 부분이 먼저 초기화 되어야 한다.


            base → 부모쪽 처리
            this → 현재 자식 객체인 자기 자신
            */
            this.altitude = altitude;
        }

        // 공중 이동
        // 
        public override void Move()
        {
            // 책임 분리를 하고 있다.
            Console.WriteLine($"{name}이(가) 공중을 비행한다. (고도 : {attitude}");

            /*
            
            ● 오버라이딩

            - 오버로딩 / 오버라이딩

            - 재정의
            - 부모 클래스의 virtual 함수를 하위 클래스에서 재정의해 사용하는 것을 의미
             ㄴ 주로 상속 관계에서 자식의 클래스가 부모의 클래스에 대해서 행해진다.

            - 기존에 정의된 함수를 무시해 버린다.
            - 함수를 상속받아 재정의 한다.

            ★★★
            C# → virtual / override를 명시하지 않으면 오버라이딩이 아닌 하이딩 처리를 한다.

            */

        }

        // public void Information() => Console.WriteLine("정보");

        protected override void Die()
        {
            base.Die();
            Console.WriteLine($"{name}이(가) 공중에서 추락한다.");
        }
        
    }
}


