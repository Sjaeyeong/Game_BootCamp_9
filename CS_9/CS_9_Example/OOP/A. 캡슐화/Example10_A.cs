using System;
#region 캡슐화
/*
▶캡슐화

- 객체를 상태와 기능으로 묶는것
 ㄴ 객체가 가지는 상태와 기능을 통틀어 멤버라고 한다.

- 이를 통해 객체 간의 상호작용을 표현할 수 있다.

- 캡슐화는 무조건 숨기는 거싱 목적이 아니라 지켜야 할 것만 열어두는 것

- C# 객체의 멤버에는 여러 요스들이 포함된다.
 ㄴ 필드 (멤버 변수)
 ㄴ 함수 (멤버 함수)
 ㄴ 상수
 ㄴ 프로퍼티
    ㄴ 그 외 포함할 수 있는 것들도 있다. → C# 고급 문법들..


◈ 정보 은닉

- 객체의 내부 상태와 구현 세부 사항을 외부로부터 숨기는 개념

- 외부에서는 객체가 제공하는 제한된 인터페이스만을 통해서만 접근 가능

- 내부 구현 변경 시 외부 코드에 미치는 영향을 최소화할 수 있다.

→ 개입
- 개발자가 정보 은닉을 다음과 같은 문법 요소로 구현할 수 있다.
 ㄴ 1. 접근 제한자
 ㄴ 2. 프로퍼티를 통한 간접 접근
 ㄴ 3. 인터페이스 및 추상화를 통한 접근 제한





*/
#endregion

// 연결과 + 명시
namespace OOP.Encapsulation
{
    // 클래스  디폴트 접근 제한자..?
    public static class Example10_A
    {
	    public static void ExampleFunction()
        {
            ConsolePrint.Title("캡슐화");

            PlayerCharacter player = new PlayerCharacter(100, 20);

            Console.WriteLine("초기 상태");
            player.PrintStatus();

            Console.WriteLine("공격 받음");
            player.TakeDamage(30);
            player.PrintStatus();

            Console.WriteLine("회복 시도");
            player.Heal(50);
            player.PrintStatus();

            Console.WriteLine("스킬 사용");
            player.UseSkill(15);
            player.PrintStatus();

            Console.WriteLine("마나 과소비");
            player.UseSkill(100);
            player.PrintStatus();

            Console.WriteLine("죽격");
            player.TakeDamage(999);
            player.PrintStatus();

            // SRP
            //  ㄴ 객체가 자기 상태를 책임지고 있다. (외부 X / 내부 O)
        }
    }

    public class PlayerCharacter
    {
        // HP 프로퍼티
        // 조회만 가능하게 만들겠다는 의도
        // 변경 자체는 → 내부에서 수행을 해줘야 할 것 같고..
        public int HP { get; private set; }

        // 완전히 내부 관리
        int _mp;

        const int MAX_HP = 100;
        const int MAX_MP = 50;

        public PlayerCharacter(int hp, int mp)
        {
            HP = Clamp(hp, 0, MAX_HP);
            _mp = Clamp(mp, 0, MAX_MP);
        }
        
        // 내부 유틸 (외부 노출 x)
        // Clamp : value 값이 범위 안에 있는지 검사하고 범위 내에 있으면 그 값을 반환
        int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                return min;
            }

            if (value > max)
            {
                return max;
            }

            return value;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0)
            {
                HP = 0;
            }
        }

        public void Heal(int amount)
        {
            HP += amount;
            if (HP > MAX_HP)
            {
                HP = MAX_HP;
            }
        }

        public void UseSkill(int cost)
        {
            if (_mp < cost)
            {
                Console.WriteLine("MP 부족");
            }

            _mp -= cost;
        }
        
        public void PrintStatus()
        {
            Console.WriteLine($"[플레이어 상태] → HP : {HP} / MP : {_mp}");
        }

    }


}


