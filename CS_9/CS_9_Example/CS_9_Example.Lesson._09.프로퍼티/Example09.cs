
using System.Data;
#region 프로퍼티
/*
▶ 프로퍼티

- 접근자 + 설정자
 ㄴ 용어 잘 기억해둘것

- 객체의 필드에 접근할 때 사용하는 문법
 ㄴ 필드에 직접 접근하지 않고 → get / set을 통해 값을 읽거나 변경할 수 있다.
  ㄴ Getter / Setter의 조합

- 프로퍼티는 함수처럼 동작하지만 변수처럼 사용된다.
 ㄴ 하지만 실제로는 함수 호출 → 내부적으로 get / set 접근자를 통해 동작

- 프로퍼티를 사용하면 ..
 ㄴ 데이터 은닉
 ㄴ 값 검증 / 유지보수성 향상
 ㄴ OOP에서 사용 편의성이 좋다.

◈ 접근자

- 멤버 변수의 값을 반환

◈ 설정자

- 멤버 변수의 값을 변경하는 기능


● 특징

- 프로퍼티를 이용하여 변수에 대한 접근자 / 설정자를 간단하게 정의 가능
 ㄴ 일반적인 프로퍼티는 내부적으로 데이터를 저장할 멤버 변수가 필요하다.

- 내부 구현이 단순할 경우 자동으로 필드를 생성해 주는 오토 프로퍼티 기능도 제공한다.
 ㄴ 오토는 별도의 멤버 변수를 만들지 않아도 된다.

1. 클래스의 멤버 변수에 안전하게 접근 가능
 ㄴ 캡슐화 → 외부 접근은 허용 → 내부 제어는 클래스

2. 프로퍼티는 기본적으로 OOP에서 사용할 수 있는 다양한 매커니즘을 지원한다.

*/
#endregion


namespace CS_9_Example.Lesson._09.프로퍼티
{
    internal class Example09
    {
        class ShopNPC
        {
            //  여기서 플레이어에 접근해서 플레이어에 체력 좀 주물러 볼까..
            // Player P = new Player();
            // p.hp2 = 0; → 빨간줄 주목..
            // 흐음.. 아쉽군.. → 끝.. → 나는 클래스로 만들어 져씅니 내 할것만 하자. → 상점
        }

        // 상점 npc가 무엇을 할지 궁금하지 않음
        // 오호.. 아래쪽에 플레이어가 있네..?
        // 결국은 우리 서로 각자 필요한 멤버가 있겠지만 중요한건 뭐다? → 결국엔 어디선가 만난다.
        class Enemy
        {

        }


        // 단일 객체
        class Player
        {
            // Player → 게임 로직 객체 → 스탯 정도를 관리할 수 있다는 느낌이 온다.
            //  ㄴ 플레이어 기준 체력은 어떤 접근 제한자를 줘야 할까..
            //  ㄴ private / public / protected

            // 멤버 변수 (필드)
            private int _hp;
            // 데이터 은닉면에서는 고민이 필요하다.
            //  ㄴ 여지를 만들어 둔 곳
            // public int _hp2;

            private int _mp;
            private float _speed;

            // get : 현재 체력을 반환
            // set : 체력을 변경

            // 외부에서는 변수처럼 접근하지만 내부적으로 함수 호출 구조

            // HP 프로퍼티
            public int HP
            {
                get { return _hp; }
                // value : 전달 받은 인자 값
                set { _hp = value; }
            }

            // MP 프로퍼티
            public int MP
            {
                get { return _mp; }
                set { _mp = value; }
            }

            // Speed 프로퍼티
            public float Speed
            {
                get { return _speed; }
                set { _speed = value; }
            }
            // 최대한 주석 많이 작성

            // 오토 프로퍼티
            // - 필드가 단순하고 추가로직이 필요 없는 경우 사용할 수 있다.
            // - 값 변경이 안되도록 private 지정자를 추가하거나 초기값이 필요한 경우 초기값 할당도 가능

            // 1. 그냥 데이터일때 (가장 흔한)
            // 외부에서 읽고 / 쓰는게 자연스러운 상태값
            // EX : 플레이어 이름 / 레벨 / 옵션값 / 설정 값 등등...

            public string Name { get; set; } = "";

            // 2. 외부 수정은 막고 읽기만 허용하고 싶을 때
            //  ㄴ HP는 보이게 하되 → 건드리면 안될 때

            public int Health
            {
                get; private set;
            } = 100;

            // 3. 불변으로 만들고 싶을 때
            //  ㄴ 생성 이후 → 바꾸면 안되는 값에 적합
            public int CharacterID { get; init; }

        }

        // 위젯 클래스 → 게임 HUD / UI 요소를 지칭
        //  ㄴ Player의 데이터를 화면에 보여주기 위한 UI 객체
        class GameWidget
        {
            // 데이터를 보여준다.
            // 둘다 내부 필드는 private → 외부 접근은 프로퍼티로 통제

            // 멤버 변수
            private int _value = 0;
            private string _text = "";

            public int Value
            {
                get { return _value; }
                set { _value = value; }
            }

            public string Text
            {
                get; set;
            } = "";
            
            // ------

            // 접근자 / 설정자

            public int Getvalue()
            {
                return _value;
            }

            public void SetValue(int value)
            {
                _value = value;
            }

            public string GetText()
            {
                return _text;
            }

        }

        class PotionTarget
        {
            private int _hp;

            public int HP
            {
                get { return _hp; }

                set
                {
                    if (value > 100)
                    {
                        _hp = 100;
                    }

                    else if (value < 0)
                    {
                        _hp = 0;
                    }

                    else
                    {
                        _hp = value;
                    }
                }
            }
        }

        class PotionSystem
        {
            public void UsePotionSet(PotionTarget target, int healAmount, int potionCount)
            {
                Console.WriteLine("== 포션 사용 시작 ==");

                while (potionCount > 0 && target.HP < 100)
                {
                    if (target.HP >= 100)
                    {
                        Console.WriteLine("체력이 이미 최대");
                    }

                    Console.WriteLine($"포션 사용 / (남은 포션 : {potionCount})");

                    target.HP += healAmount;
                    potionCount--;

                    Console.WriteLine($"포션 사용 / (남은 포션 : {potionCount}");
                    Console.WriteLine($"현재 체력 : {target.HP}");
                }

                Console.WriteLine("== 포션 사용 종료 ==");
            }
        }

        static void ExampleFunction_A()
        {
            ConsolePrint.Title("프로퍼티");
            ConsolePrint.Section("Player 프로퍼티");

            Player player = new Player();

            player.HP = 100;
            player.MP = 50;
            player.Speed = 3.5f;

            Console.WriteLine($"플레이어 HP : {player.HP}");
            Console.WriteLine($"플레이어 MP : {player.MP}");
            Console.WriteLine($"플레이어 Speed : {player.Speed}");
            ConsolePrint.Line();

            ConsolePrint.Section("UI 위젯 프로퍼티");

            GameWidget hpWidget = new GameWidget();

            hpWidget.Value = player.HP;
            hpWidget.Text = "플레이어 체력";

            Console.WriteLine($"{hpWidget.Text} : {hpWidget.Value}");

            // 필요하다면 → 만들어 뒀다면
            hpWidget.SetValue(80);
            // 출력문 → hpWidget.GetValue();

            PotionTarget target = new PotionTarget();
            target.HP = 30;

            PotionSystem potionSystem = new PotionSystem();

            bool isRunning = true;

            while (isRunning)
            {
                ConsolePrint.Section("포션 세트 사용");

                // 문법 : 이름 붙인 인자
                // : 가 라벨 역할
                //  ㄴ 매개 변수 지정 → 그 이름에 값을 대입하는 호출 방식
                // potionSystem.UsePotionSet(target, 30, 3);
                potionSystem.UsePotionSet(target, healAmount : 30, potionCount : 3);

                Console.WriteLine($"현재 최종 체력 : {target.HP}");
                Console.Write("포션 다시 사용 ? (Y/N) : ");

                char input = Console.ReadKey().KeyChar;

                if (input != 'Y' && input != 'y')
                {
                    isRunning = false;

                }
            }

            Console.WriteLine("게임 종료");
        }



        static void Main(string[] args)
        {
            ExampleFunction_A();

        }
    }
}
