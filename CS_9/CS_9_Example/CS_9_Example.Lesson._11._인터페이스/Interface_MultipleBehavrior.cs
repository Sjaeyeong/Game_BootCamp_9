using System.Collections.Generic;

#region 인터페이스 다중 구현
/*
▶ 인터페이스 다중 구현

- 하나의 객체는 여러 인터페이스를 동시에 구현할 수 있다.
 ㄴ 즉, 같은 종류가 아니라 할 수 있는 역할을 여러개 가질 수 있다.

EX :
- 상자는 조사할 수 있다.
- 상자는 열 수도 있다.
- 통은 조사할 수 있다.
- 통은 부술 수 있다.

※ 추상 클래스는 "같은 분류"를 묶는데 강한 문법이고 인터페이스는 "같은 역할"을 조합하는데 강하다.
*/
#endregion

namespace OOP.Interface.Concept
{
    internal class Interface_MultipleBehavrior
    {
        public static void ExmpaleFenction()
        {
            ConsolePrint.Title("인터페이스 다중 구현");

            Player player = new Player();
            Chest chest = new Chest();
            Barrel barrel = new Barrel();

            player.InteractWith(chest);
            player.OpenTarget(chest);

            player.InteractWith(barrel);
            player.BreakTarget(barrel);

            IInteractable[] interactables =
            {
                chest,
                barrel
            };

            // 아래에서 필요한것들 순회
            // 반복 돌리면 됨

            // 배열과 마찬가지로 List<인터페이스 타입>으로도 묶을 수 있다라는 것을 확인하기 위해 사용

            // 조사 가능한 대상들
            List<IInteractable> interactableList = new List<IInteractable>()
            {
                chest,
                barrel
            };

            foreach (IInteractable target in interactableList)
            {
                target.Interact();
            }

            List<IOpenable> openableList = new List<IOpenable>
            {
                chest
            };

            foreach (IOpenable target in interactableList)
            {
                target.Open();
            }

            // 필요시 반복


            // 필요시 파괴 기능까지 만든다.

        }

        public interface IInteractable
        {
            void Interact();
        }

        public interface IOpenable
        {
            void Open();
        }

        public interface IBreakable
        {
            void Break();
        }

        public class Chest : IInteractable, IOpenable
        {
            public void Interact()
            {
                Console.WriteLine("상자를 조사한다.");
            }

            public void Open()
            {
                Console.WriteLine("상자를 연다.");
            }

        }

        public class Barrel : IInteractable, IBreakable
        {
            public void Interact()
            {
                Console.WriteLine("통을 조사한다.");
            }

            public void Break()
            {
                Console.WriteLine("통을 부순다.");
            }

        }

        public class Player
        {
            // 인터페이스를 매개변수로 받고 있음
            public void InteractWith(IInteractable target)
            {
                target.Interact();
            }

            public void OpenTarget(IOpenable target)
            {
                target.Open();
            }
            public void BreakTarget(IBreakable target)
            {
                target.Break();
            }

        }


    }
}
