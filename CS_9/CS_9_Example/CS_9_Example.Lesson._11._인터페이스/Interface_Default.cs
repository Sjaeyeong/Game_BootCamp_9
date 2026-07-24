using OOP.Interface.Concept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region 디폴트 인터페이스 함수
/*
▶ 디폴트 인터페이스 함수

- 규칙만 두던 인터페이스도 최신 C#에서 일부 공통 동작을 기본으로 정의할 수 있다.
L 인터페이스 안에 기본 구현을 넣을 수 있다. (implementation)

- 원래 인터페이스는 규칙만 선언한다고 지금까지 배웠다.
L 공통 안내 / 공통 기본 동작 → 인터페이스쪽에서 한번에 제공
L 인터페이스 확장한다고 했을때 수정이 불가피 경우가 많다.

· 주의

- 이것은 당연히 인터페이스의 본질이 아니다.

- 기본 개념은 당연히 행동 계약
L 필요할때 추가로 사용할 수 있는 확장 문법정도로만 기억을 하면 좋다.

- 어 ..? 이거 ...? 추상 클래스와 비슷한 .?
*/
#endregion

namespace OOP.Interface.Concept
{
    internal static class Interface_Default
    {
        public static void ExampleFunction()
        {
            Door door = new Door();
            Chest chest = new Chest();

            IInteractable[] interactables =
            {
                door,
                chest
            };

            foreach (IInteractable target in interactables)
            {
                // 1. 상호작용 가능한 대상입니다.
                // 2. 문을 연다.
                // 3. 상자를 조사한다.

                target.ShowGuide();
                target.Interact();
                ConsolePrint.Line();
            }
        }

        // 추상 클래스 처럼
        public interface IInteractable
        {
            // 규칙
            void Interact();

            // 이미 만들어진 인터페이스에 기본 기능을 추가할 때 정도만 사용할 수 있고
            //  ㄴ 구현 클래스 전부를 다 고치지 않아도 된다는 장점이 있다.
            
            // 기본 구현 : 인터페이스쪽에서 기본으로 제공을 하겠다.
            // 사용할 준비만 시켜 놓겠다.
            void ShowGuide()
            {
                Console.WriteLine("상호작용 가능한 대상입니다.");
            }
        }
        public class Door : IInteractable
        {
            public void Interact()
            {
                Console.WriteLine("문을 연다");
            }
        }

        public class Chest : IInteractable
        {
            public void Interact()
            {
                Console.WriteLine("상자를 연다");
            }
        }

    }
}
