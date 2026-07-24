using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

#region 인터페이스가 없다면
/*

- 인터페이스가 없다면 플레이어라는 객체는 본인이 상호작용 할 수 있는 모든 경우에 대해 코드를 작성해야 한다.
 ㄴ if / is / 다수의 캐스팅이 발생 → 지옥도

- 위와 같은 구조가 생기면 인터페이스를 만들고 적절하게 적용하면 깔끔해지는 구조로 변경이 될 수 있다.
 ㄴ 플레이어는 대상의 정체를 몰라도 된다. → 대상의 정체는 궁금하지 않다.
 ㄴ 상호작용을 할 수 있냐? 없냐?

- 인터페이스가 채용이 되는데 인터페이스는 단일로 크게 잡기보다 쪼갠다.
 ㄴ ISP → 하나의 인터페이스 다 넣으면 → 또 다른 지옥도


EX :
- 플레이어가 맵을 돌아 다닌다.
 ㄴ 앞에 문이 있다.
 ㄴ 바닥에 아이템이 있다.
 ㄴ 입구에 던전이 있다.

- 플레이는 생각한다..
 ㄴ 이게 문인가? 아이템인가? 던전인가..? → 이런 행위 자체가 객체지향에서는 필요없다.

- 플레이어의 관점은 딱 하나
 ㄴ 상호작용 가능한가?

*/
#endregion


namespace OOP.Interface.Concept
{
    internal class Interface_Basic
    {
        // 인터페이스정의 → 규칙 선언
        // 공통 행동에 대한 인터페이스
        public interface IInteractable
        {
            // 구현이 없음
            // 이 함수는 반드시 제공해라 라는것을 계약서 형태로 발행
            void Interact();
        }

        // 상속을 살릴 수 있다.

        public class Door : IInteractable
        {
            public void Interact()
            {
                Console.WriteLine("문을 연다.");
            }


        }

        public class Item : IInteractable
        {
            public void Interact()
            {
                Console.WriteLine("아이템을 획득한다.");
            }


        }

        public class Dungeon : IInteractable
        {
            public void Interact()
            {
                Console.WriteLine("던전에 입장한다.");
            }


        }

        // 공통 부모 클래스 없음
        // 같은 행동은 가능
        // 플레이어도 좋다. → 정체 몰라도 된다.

        public class Player
        {
            // 오직 상호작용 가능한가?만 알고 있다
            public void InteractWith(IInteractable target)
            {
                target.Interact();
            }
        }

        public static void ExampleFunction_A()
        {
            // ConsolePrint.Section("인터페이스 X");

            // object : C# →모든 타입의 최상위(루트) 타입

            // 공통 타입을 예측할 수 없음 → object를 통해 뭉개서 담아야 한다.
            object[] objects =
            {
                new Door(),
                new Item(),
                new Dungeon()
            };

            // 이미 여기까지 온 순간.. 좋지가 않음
            for (int i = 0; i < objects.Length; i++)
            {
                // 1. 새로운 객체 추가시?
                //  ㄴ 객체 추가할 때마다 if 증가
                // 2. Interact 없는 객체가 들어와도 컴파일 OK → OCP 위반
                // 3. 코드들 계속 수정해야 할 여지가 생긴다.
                // 위에 것들이 다 모이면 → 지옥도
                if (objects[i] is Door door)
                {
                    door.Interact();
                }
                else if (objects[i] is Item item)
                {
                    item.Interact();
                }
                else if (objects[i] is Dungeon dugeon)
                {
                    dugeon.Interact();
                }

            }

        }

        public static void ExampleFunction_B()
        {
            Console.WriteLine("==  인터페이스 O ==");

            Player player = new Player();

            IInteractable[] interactabls =
            {
                new Door(),
                new Item(),
                new Dungeon()
            };

            foreach (IInteractable obj in interactabls)
            {
                // 객체가 3개 / 10개 / 100개여도..
                // 이게 확장에는 열려 있고 → 수정에도 닫혀 있는 구조 (OCP)
                // player 객체는 변경이 필요없다
                player.InteractWith(obj);

                // 자연스럽게 이어질 고민..
                //  ㄴ 그럼 Interact 하나로 처리하면 되는건가..?
                //   ㄴ 절대..

                // 인터페이스는 작게 + 역할별로 나눈다.


            }
        }
    }
}
