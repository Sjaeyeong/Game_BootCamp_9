// → 이거 나오기전 나오기전으로 수정
// 정적 멤버를 바로 쓰기 위한 문법이라 → 커스텀 클래스와는 결이 좀 다르다.
// 클래스 만지다가 컴퓨터가 임의로 아래 문구를 추가하면 그건 여러분의 클래스가 객체가 아닌 전역 함수처럼 설계됐다는 신호
// 조심 → 컴퓨터가 은근슬쩍 끼워넣음
// using static xxx


#region 유틸리티
/*
▶ 유틸리티

- C# → 같은 어셈블리 안에 있으면 네임스페이스가 달라도 using으로 참조가 가능하다.

- 이러한 특성을 이용해 공통적으로 필요한 기능을 하나로 묶어 관리하면 좋다.

- 유틸리티라는 특성상 당연히 보통의 경우 상태를 가지고 있지 않으며 정적(static) 함수 위주로 구성이 된다.

- 이러한 설계는
 ㄴ 코드의 가독성 ↑
 ㄴ 중복 코드를 줄여주고
 ㄴ 대규모 프로젝트에서 개발 효율을 올려준다.

※ 이러한 것들이 모인것이 뭐다..? → 유니티
*/
#endregion

namespace CS_9_Example.Lesson._09.프로퍼티
{

    // 출력 유틸리티 클래스
    //  ㄴ 콘솔 출력의 가독성 → 통일
    public static class ConsolePrint
    {
        // static class → 인스턴스 생성 불가
        //  ㄴ출력 책임까지만 → 로그 시스템으로 발전은 가능하다. → PrintDot

        // 빈줄 입력
        public static void Line()
        {
            Console.WriteLine();
        }

        // 큰 제목
        public static void Title(string title)
        {
            Console.WriteLine();
            Console.WriteLine($"== [{title}] ==");
        }

        // 섹션
        public static void Section(string section)
        {
            Console.WriteLine();
            Console.WriteLine($"---- [{section}] ----");
        }

    }

}