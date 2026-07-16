#region 클래스
/*

▶ 클래스

- 속성에 해당하는 필드와 행위에 해당하는 함수의 집합을 클래스라고 한다. (사용자 정의 자료형)

- OOP에서 객체를 만들기 위한 중요한 역할을 한다. (설계도)

- 클래스를 이용하면 데이터 뿐만 아니라 함수를 특정 집합에 포함하는게 가능하다.

※ 클래스로 생성된 객체는 참조 형식이다.
 ㄴ 변수로 대입하거나 매개변수로 전달할 때 객체 자체 복사가 아니라 객체를 가르키는 참조 정보가 전달된다. (주소)


▷ C# 언어의 클래스 선언 방법

class CUint
{
    // 필드

    // 생성자

    // 정보 설정 함수

    // 정보 출력 관련 함수들

}

+ 종족 카테고리는 따로... / 전장... / 특징 객체..? / + 추가

※ 객체지향부터는 ★★★★★ 설계 ★★★★★가 매우 중요하게!!!
 ㄴ 여긴 늪 → 본인의 역량을 인정 및 파악하고 타협 → 여러분들이 생각하고 만든 설계는 대부분 효율적이지 않다. (시행착오 → 다듬어 진다.)


콘솔 미니 프로젝트 : 7일
 ㄴ 1일 → 반나절 → 그 이전에 보통 어느정도 마무리
 ㄴ 7일 → 3일차 4일차 쯤.. → 잘하고 싶은 욕심 → 더 만들고 싶은 욕심
 ㄴ 7일 → 3일차 4일차 쯤.. → 왜 작업이 이것밖에 안됐을까요?
  ㄴ 1. 리소스 작업 하느라..
  ㄴ 2. 갈아 엎었습니다..
  ㄴ 3. 열심히 안했습니다..


※ 웬만하면 롤백 → 프로젝트
 ㄴ 1일차 작업물 정도는..? 그나마..?


▶ 클래스 접근 제한자 종류

- 클래스는 접근 제한자를 통해 변수 또는 함수에 접근할 수 있는 영역을 제한하는 것이 가능하다.

- 이를 통해 객체의 안정성을 확보하고 잘못된 접근을 방지할 수 있다.


private :

- 같은 클래스 내부에서만 접근이 가능하도록 허용

- 이 속성을 가진 멤버는 클래스 외부에서 접근할 수 없다.

- 외부에서는 private 멤버를 읽거나 쓸 수 없으며 클래스 내부 로직을 통해서만 간접적으로 접근이 가능하다.


public :

- 어디서든 접근이 가능하도록 허용

- 이 속성을 가진 멤버는 외부에 공개되어 누구나 접근이 가능하다.

- 함수의 경우 외부에서 호출까지 가능


protected :

- 외부에서는 접근할 수 없지만 상속 받은 파생 클래스에서는 접근이 가능하다.

- private와 달리 파생 클래스에서는 접근 가능하다라느 차이가 존재한다.
 ㄴ 게임에선 보통 설계 단계에 들어간다.


internal :

- 같은 어셈블리(프로젝트) 내에서만 접근 가능

- 동일한 프로젝트 내부에서는 public처럼 동작한다.

- 다른 어셈블리에서는 접근할 수 없다.

- 여기는 어셈블리 때문에 개념이 좀 어려울 수 있으니 지금은 → 같은 프로젝트 내부에서만 접근 가능 정도만 기억


protected internal :

- 같은 어셈블리이거나 상속 관계에 있는 파생 클래스에서 접근 가능


private internal :

- 같은 클래스 내부이거나 같은 어셈블리 안에 있는 파생 클래스에서만 접근 가능


● 구조체와 클래스

- 구조체는 값 형식 / 클래스는 참조 형식
 ㄴ 클래스는 참조를 통해 다루고 구조체는 값 자체를 복사하는 특성을 가진다.

- 구조체는 비교적 가볍고 단순한 데이터 묶음에 자주 사용하면 좋다.

- 구조체는 다른 클래스나 구조체를 상속받아 확장하는 방식으로 사용할 수 없기 때문에 확장성면에서는 클래스 대비 불리하다.

- 클래스는 객체의 상태와 동작을 함께 관리하는데 적합
 ㄴ 관련 기능들을 통해서 기능을 확잘할 수 있다.


※ 클래스는 클래스 안에 클래스를 만들 수 있다 (중첩 클래스)
  ㄴ중첩 클래스는 클래스 이름을 통해서만 접근할 수 있다 (바깥)

*/
#endregion

#region 메모리 구성
/*



*/
#endregion


namespace CS_9_Example.Lesson._08._클래스
{
    internal class Example08
    {
        struct STPlyaerStat
        {
            public int hp;
            public int mp;
        }

        enum ColorType
        {

        }

        // 플레이어마다 이름, 위치, 능력치가 다를 수 있다.
        class Player
        {
            // 일반적으로 외부 접근을 제한하는 방식으로 설계하는게 일반적
            // 객체의 상태 변경을 public 통해 제어하며 이를 통해 객체의 안정성 + 일관성을 유지할 수 있다.

            // 명시 키워드임을 보여주기 위함
            //  ㄴ → 일단 변수 선언부분에서는.. → 익숙해 지기전까지 private으로 선언한다고 생각

            // 표기법 → 규칙에 따라간다.
            // 멤버 변수구나. (클래스안에 속해 있는)
            private string _name;               // 기본이 private라 private를 안적어도 됨 → 캡슐화
            private int _x;
            private int _y;
            private STPlyaerStat _stat;

            //// 변수 선언과 동시에 초기화
            //private int _id = 0;
            //private string _str = "";

            // 단발성 클래스면 사용해도 무방
            // 확장성 클래스라고 하면 사용했을 때 이후 굉장히 피곤해 진다.


            // 필요시 생략 가능
            // 지금은 필요하고
            // 생성자 → 객체가 생성될 때 자동으로 호출된다.
            //  ㄴ 주로 멤버 변수의 초기값을 넣는 역할을 수행한다.
            // 반환형이 없는 클래스 이름의 함수를 생성자라고 생각하면 된다.
            // 생성자를 포함하지 않아도 기본 생성자는 자동으로 생성이 된다.

            // 생성자 오버로딩
            //public Player()
            //{

            //}

            // 생성자
            public Player(string name, int hp, int mp)
            {
                _name = name;
                _x = 0;
                _y = 0;

                _stat.hp = hp;
                _stat.mp = mp;
            }

            // C# 주의
            // 소멸자 :
            // 객체가 바꿔 놓은 환경을 원래대로 돌려 놓거나 할당한 자원을 회수하는 역할을 한다. (EX : 동적할당 등의 메모리 해제)
            //                                                                                        ㄴ new
            // C# 소멸자는 GC에 의해서 관리되기 때문에 리소스 해제를 직접 하지 않는다.
            // GC가 객체를 수거할 때 호출되며 호출 시점을 개발자가 제어할 수 없다.
            ~Player()
            {
                // GC가 부르는 보험 (언제 부를지 알 수 없음)
                //  ㄴ 일반적으로 클래스의 동작 방식을 고려하면 마지막에 호출되는 경우가 많겠지만 그 또한 정확하게 예측할 수 없음

                // GC는
                //  ㄴ 메모리 압박
                //  ㄴ 내부 타이밍
                //  ㄴ 런타임 판단에 따라 언제 돌지 모른다.
            }

            // 플레이어 상태 출력
            public void PrintStatus()
            {
                Console.WriteLine($"이름 : {_name}");
                Console.WriteLine($"HP : {_stat.hp} / MP : {_stat.mp}");

            }

            // 플레이어 위치 출력
            public void ShowPosition()
            {
                Console.WriteLine($"위치 → x : {_x}, y : {_y}");
            }

            // 위치 이동
            public void MovePosition()
            {
                _x += 100;
                _y += 100;
            }

            public void SetPosition(int x, int y)
            {
                // 객체 자신을 가르키는 키워드
                // 매개 변수와 + 멤버 변수의 이름이 같을때 혹은 이후 다른 클래스에서 이름이 중복될 것 같을때 명확한 명시 키워드
                this._x = x;
                this._y = y;
            }

            // 피해 받기

            public void TakeDamage(int damage)
            {
                _stat.hp -= damage;

                if (_stat.hp < 0)
                {
                    _stat.hp = 0;
                }
            }

        }


        static void ExampleFunction_ClassicBasic()
        {
            ConsolePrint.Title("클래스 기본");
            ConsolePrint.Line();

            Console.WriteLine("== 클래스 기본 ==");

            // 클래스를 익숙하지 않을때는 먼저 → 객체 생성
            Player playerA = new Player("전사", 100, 30);
            Player playerB = new Player("마법사", 70, 100);

            // new는 내일 진행
            #region new
            /*
            ▶ new

            - new는 객체 또는 데이터를 새로 생성할 때 사용하는 키워드

            - 이 키워드를 통해 필요한 메모리 공간을 확보하고 생성자를 호출하여 객체를 초기화한다.

            - new는 ...
             ㄴ 메모리 공간 준비
             ㄴ 객체 생성
             ㄴ 초기화 담당한다고 생각할 수 있다.


            ● 동적 할당 ★★★★

            - 프로그램 실행 중 (런타임)에 필요한 만큼 메모리를 생성해서 사용하는 방식
            - 미리 크기가 고정되는 것이 아니라 실행 도중 필요할 때 만들어서 사용한다.

            EX :
            런게임... 속도감

            블록 역시 메모리 (블록 하나당 메모리 1) → 충돌체 → 이미지

            // 블록 15개로 1분 ~ 1시간 ~ 100시간 버틸 수 있는 게임을 만들 수 있음

            EX :
            Monster monster = new Monster();
             ㄴ new Monster()는 Monster 객체를 생성
             ㄴ 실제 객체는 힙에 던진다.
             ㄴ 변수 monster는 극 객체를 가리키는 참조를 가진다.

            ● 참조 형식에서의 new

            - 위와 동일


            ● 값 형식에서의 new

            - 구조체 / int / float 같은 값 형식도 new를 사용할 수 있다.

            - 힙에 만든다 라기 보다 값을 초기화해서 사용 가능한 상태로 만든다는 의미가 강하다.

            EX :
            DamageInfo damage = new DamageInfo();

            - 구조체 값 자체를 초기화
            - 클래스처럼 참조를 돌려받는 개념과는 다르다.




            */
            #endregion

            //Random rand = new Random();

            // 각 객체는 서로 다른 데이터를 가진다.
            Console.WriteLine("플레이어 A");
            playerA.PrintStatus();
            playerA.ShowPosition();

            /*
            플레이어 A
            이름 : 전사
            HP: 100, MP : 30
            위치 → x : 0, y : 0
            */

            Console.WriteLine("플레이어 B");
            playerB.PrintStatus();
            playerB.ShowPosition();

            /*
            플레이어 B
            이름 : 마법사
            HP: 70, MP : 100
            위치 → x : 0, y : 0
            */

            Console.WriteLine("== 위치 이동 ==");

            playerA.PrintStatus();
            playerA.ShowPosition();

            playerB.SetPosition(300, 200);
            playerB.ShowPosition();

            Console.WriteLine("== 피해 받기 ==");

            playerA.TakeDamage(35);
            playerA.PrintStatus();

            playerB.TakeDamage(20);
            playerB.PrintStatus();

            // 같은 Player 클래스로 만들었지만 내부 데이터는 서로 다르다.
            // 클래스는 데이터를 보관하는 변수와 그 데이터를 다루는 함수를 하나로 묶어 관리하기 위해 사용하면 베스트!

        }



        static void Main(string[] args)
        {
            ExampleFunction_ClassicBasic();

        }
    }
}
