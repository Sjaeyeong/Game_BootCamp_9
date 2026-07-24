#region 상속
/*
▶ 상속

- 기존 클래스가 가지고 있는 필드 또는 함수를 그대로 물려 받아 새로운 기능을 확장하는 것을 의미한다.
 ㄴ 부모 클래스의 모든 기능을 가지는 자식 클래스를 설계하는 방법

- 상속을 이용하면 공통 기능을 부모 클래스에 모아두고 여러 자식 클래스에서 재사용할 수 있다.
 ㄴ ★ 책임 / 역할 O → 올바른 상속 구조
 ㄴ ★ 책임 / 역할 X → 구조가 망가진다. → 공통이라는 이유로 막 올리기 시작하면...
    ㄴ 눈에 잘 안보인다. → 캐치 (캐치 X) → 마지막 엔트리에 올라갈때 까지 인지를 못하는 경우도 많다.
    ㄴ 덜덜 거리며 돌아간다..

- OOP에서 상속은 강력하지만 피곤한 개념
 ㄴ 그래서 많이 쓰는게 아니라 신중하게 사용하는걸 권장


▷ 올바른 상속 관계를 만들어 내는 규칙

is a의 관계

- 특정 클래스가 또 다른 클래스의 모습으로 허용 될 경우 (부모 클래스가 자식 클래스를 포함하는 상위개념)
 ㄴ A는 B이다 라는 문장이 자연스러울 때 상속 관계로 표현하는 것이 적합

EX : is a
학생은 인간이다.   O
인간은 학생이다.   X

- 위의 경우처럼 학생은 인간이기도 하기 떄문에 is a의 관계가 성립된다.
 ㄴ 학생 클래스가 인간 클래스를 상속한다면 이는 올바른 구조라는 것을 의미한다.


has a의 관계

- 특정 클래스가 또 다른 클래스로 포함이 허용 될 경우
 ㄴ A는 B를 가지고 있다의 문장이 자연스러울때는 상속이 아니라 포함으로 구현을 해야한다.
 ㄴ 상속이 아니라 멤버로 들고 있는 구조가 더 안전하기 때문에

EX : has a

- 자동차는 엔진을 가지고 있다. 자동차 클래스는 엔진 클래스를 포함해야 함

※ is a 관계일때만 상속 → has a 관계는 포함으로 표현을 한다.


● C# 상속에서 접근 제한자 핵심

- 자식 클래스에서 접근 가능
 ㄴ public / protected

- 자식 클래스에서 직접 접근 불가
 ㄴ private







*/
#endregion

namespace OOP.Inheritance
{
    public static class Exmaple10_B
    {
        public static void ExampleFunction()
        {
            ConsolePrint.Title("상속");

            // 관리자 클래스 걸어둠
            // static 함수를 호출해서 인스턴스를 만들 수 없다 (new를 안만들어도 됨)
            MainGame.ExampleFunction();

            ConsolePrint.Section("상속 예제 2번");
            Inheritance.ExampleFunction();

            ConsolePrint.Line();
        }
    }

    // 07/22 시작
    // 기본 클래스는 아닌거 같고...
    // 부모로 
    class Character
    {
        this.name = name;
    

        public virtual void ShowInfo()
        {
            Console.WriteLine($"캐릭터 이름 : {name}");
        }
        
    }
    class Player
    {
        
        int level;

        public Player(string name, int level) : base(name)
        {
            this.level = level;
        }

        public void Attack()
        {
            Console.Writeline($"{name}이 공격을 한다.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"플레이어 이름 : {name}, 레벨 : {level}");
        }


    }

    class NPCWorker : Character
    {
        public NPCWorker(string name) : base(name)
        {

        }

        public void Work()
        {
            Console.Writeline($"{name} NPC가 작업을 수행한다.");
        }

    }

    public static class Inheritance
    {
        public static void ExampleFunction()
        {
            ConsolePrint.Section("상속 : 게임 캐릭터");

            // 부모 타입 + 부모 객체
            Character baseCharacter = new Character("중립 캐릭터");
            // 자식 타입 + 자식 객체
            Player player = new Player("주인공", 5);
            NPCWorker worker = new NPCWorker("SCV");

            ConsolePrint.Line();

            Console.WriteLine("ShowInfo() 호출");

            baseCharacter.ShowInfo();
            player.ShowInfo();
            worker.ShowInfo();

            ConsolePrint.Line();

            player.Attack();
            worker.Work();

            // 부모 타입으로 자식 객체를 참조
            // ㄴ 타입은 Character / 실제 인스턴스는 Player & NPCWorker
            Character playerInCharacter = new Player("두번째 주인공", 10);
            Character workerInCharacter = new NPCWorker("프로브");

            Console.Writeline("ShowInfo() 재호출");

            // 플레이어 이름 : 두번째 주인공 / 레벨 : 10 → 이게 나올것인가 말것인가
            // vir / override 덕분에 부모 타입이여도 실제 객체 기준으로 함수가 호출된다.
            playerInCharacter.ShowInfo();
            // 캐릭터 이름 : 프로브
            workerInCharacter.ShowInfo();

            // V / Override의 진짜 의미
            // 변수의 타입이 아니라 실제 객체 (P / NPC) 기준으로 어떤 함수가 실행될지가 결정됨

            // 규칙
            // - 부모 타입에 담긴 자식 인스턴스는 부모가 알고 있는 기능만 사용할 수 있다.
            //  ㄴ 자식 고유 기능은 접근을 할 수가 없다.

            // 오류가 남
            //playerInCharacter.Attack();
            //workerInCharacter.Work();

            /*
            캐스팅이 필요하다..
             ㄴ 부모 타입으로 담긴 자식 객체의 고유 기능을 사용하고 싶을 때

            is / as 키워드의 차이점
            
            - is 키워드는 값 형식, 참조 형식에 모두 사용할 수 있따.
             ㄴ 결과는 논리형으로 나옴 → t / f

            - 반면 as 키워드는 참조형식에만 사용하는 것이 가능하다.
             ㄴ 결과는 null 또는 해당 타입의 참조 값으로 변환
             ㄴ 대부분 안 터진다.
            */

            // 형변환이 가능한지 여부만 확인 (실제로는 하지 않는다.)
            //  ㄴ if문으로 걸러낼 수가 있기 때문에 변환이 안전해 진다.
            if (playerInCharacter is Player)
            {
                Console.WriteLine("playerInCharacter는 Player로...");

                Player castPlayer = (Player)playerInCharacter;
                castPlayer.Attack();
            }
            // 이건 어떨까..?
            if (playerInCharacter is NPCWorker)
            {
                // 실행 x
                Console.WriteLine("playerInChacter는 NPCWorker로...");
            }

            else
            {
                Console.WriteLine("playerInCharacter는 NPCWorker로... X");
            }

            
            if (playerInCharacter is Player castPlayer2)
            {
                // is 패턴 매칭
                // 검사 + 형변환 + 변수 선언까지 올인원 세트
                castPlayer2.Attack();
            }

            // 더 보기 편하게
            if (playerInCharacter is not NPCWorker)
            {
                Console.WriteLine("playerInCharacter는 NPCWorker가 아니다.");
            }

            // as 연산자
            //  ㄴ 형변환 가능하면 변환 → 불가하다면 null
            //  ㄴ 예외가 발생하지 않는 안전한 캐스팅

            Player? asPlayer = playerInCharacter as Player;
            NPCWorker? asWorker = playerInCharacter as NPCWorker;

            if (asPlayer != null)
            {
                asPlayer.Attack();
            }

            if (asWorker == null)
            {
                Console.WriteLine("asWorker는 변환 실패 (null)");
            }

            ConsolePrint.Line();
            Console.WriteLine("명시적 형변환");

            try
            {
                // 성공
                Player forcedPlayer = (Player)playerInCharacter;
                forcedPlayer.Attack();

                // 실패
                NPCWorker forcedWorker = (NPCWorker)playerInCharacter;
                forcedWorker.Work();
            }

            catch (InvalidCastException)
            {
                // 실패하면  여기에 잡힌다.
                // 실패시 컴파일이 아닌 런타임 예외로 처리된다.

                Console.WriteLine("잘못된 캐스팅으로 캐치에 걸렸고 예외가 발생했다.");
            }

            // GetType()

            ConsolePrint.Line();
            Console.WriteLine("GetType() 확인");

            // T F T F
            Console.Writeline(playerInCharacter.GetType() == typeof(Player));
            Console.Writeline(playerInCharacter.GetType() == typeof(Character);
            Console.Writeline(workerInCharacter.GetType() == typeof(NPCWorker));
            Console.Writeline(workerInCharacter.GetType() == typeof(Character));

            // if (playerInCharacter is Charcter) → T
            //  ㄴ is 는 상속 관계까지 포함해서 검사
            // playerInCharacter.GetType() == typeof(Character) → F
            // 
        }



    }




}

	
