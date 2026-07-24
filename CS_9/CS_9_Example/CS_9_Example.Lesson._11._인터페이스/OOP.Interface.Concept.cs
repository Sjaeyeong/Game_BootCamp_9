#region ISP
/*
▶ ISP

- 인터페이스 분리의 원칙

- 하나의 거대한 인터페이스보다 여러 개의 작은 인터페이스가 좋다.
 ㄴ 사용하지 않는 기능에 의존하지 않도록 설계

- 객체가 할 수 있는 행동 단위로 인터페이스를 쪼갠다.

- ISP를 지키다 보면 인터페이스가 많아질 수 있다.


EX :
X : 인터페이스는 많아질수록 좋다.
O : 인터페이스는 잘게 나눠질수록 좋다.

public interface IInteractable
{
    .....
}

- 문 / 아이템 / 던전이 전부 이걸 구현했다.

- 고려해야 할 점..
 ㄴ 그럼 하나로 처리하면 되나..? → 이건 구조가 커지면 바로 문제가 터진다.

public interface IGameObject
{
    void Interact();
    void Enter();
    void PickUp();
    void Talk();
}

public class Door : IGameObject
{
    public void Interact() {...}
    public void Enter() {...}     //의미 없음
    public void PickUp() {...}    //의미 없음
    public void Talk() {...}      //의미 없음
}

- 클라이언트는 자신이 사용하지 않는 함수에 의존하면 안된다.
  ㄴ 문에게 대화 기능을 강요하지 마시길
  ㄴ 기능 기준으로 쪼갠다.
*/
#endregion


namespace OOP.Interface.Concept
{
    internal static class Interface_ISP
    {
        // ISP → 역할 단위 인터페이스

        // 베이직 : 서로 다른 객체가 같은 행동 하나를 공유
        // ISP : 행동이 많아지면 하나의 인터페이스에 몰아넣지 말고 역할별로 나눈다.
        //  ㄴ 게임에서의 행위는 단순한 경우도 있지만 아닌 경우가 더 많기 때문에 ISP 기반 설계하는 경우가 더 많다.

        /// <summary>
        /// 상효작용 가능한 대상
        /// </summary>
        public interface IInteractable
        {
            // 이런 형태는 디자인 패턴에서 많이 사용된다.

            // 구현 없음
            // 이 함수는 반드시 제공해라 라는 것을 계약서 형태로 발행
            void Interact();
        }

        /// <summary>
        /// 입장 가능한 대상
        /// </summary>
        public interface IEnterable
        {
            void Enter();
        }

        /// <summary>
        /// 획득 가능한 대상
        /// </summary>
        public interface IPickable
        {
            void PickUp();
        }

        public class Door : IInteractable
        {
            public void Interact()
            {
                Console.WriteLine("문을 열다");
            }
        }

        public class Item : IPickable
        {
            public void PickUp()
            {
                Console.WriteLine("아이템을 획득한다.");
            }
        }

        /// <summary>
        /// 던전 오브젝트
        /// : 입장만 가능
        /// </summary>
        public class Dungeon : IEnterable
        {
            public void Enter()
            {
                Console.WriteLine("던전에 입장한다.");
            }
        }

        // 상속 자리 살릴 수 있고
        // 오직 이 행동을 할 수 있는가? 만 보기 때문에 굉장히 관리하기가 좋다.
        public class Player
        {
            public void InteractWith(IInteractable target)
            {
                target.Interact();
            }

            public void EnterPlace(IEnterable place)
            {
                place.Enter();
            }

            public void Pick(IPickable item)
            {
                item.PickUp();
            }
        }

        public static void ExampleFunction()
        {
            Console.WriteLine("---- 인터페이스 분리 원칙 ----");

            Player player = new Player();

            Door door = new Door();
            Item item = new Item();
            Dungeon dungeon = new Dungeon();

            player.InteractWith(door);
            player.Pick(item);
            player.EnterPlace(dungeon);


        }


    }
}
