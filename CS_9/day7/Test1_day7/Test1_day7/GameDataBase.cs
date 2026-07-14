using System.Net.Security;

namespace Test1_day7
{
    internal class GameDataBase
    {
        public enum GameLevel : byte // 자료형크기가 제일 작은? byte로 사용
        {
            All,
            Teen,
            Adult
        }

        struct GameData
        {
            public string titleName;                                // 타이틀명
            public GameLevel gameLevel;                                 // 이용등급
            public int price;                                       // 가격
            public float userScore;                                 // 평점
            public (bool HasIssue, string Comment) specials;        // 특이사항
            public string developerComment;                         // 개발자코멘트

        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;          // 커서가 깜빡거리는걸 방지한다고 함

            GameData[] gameArr = StoreData();       // StoreData() 함수로 게임데이터 배열을 바로 저장
            while (true)
            {
                MainMenu(gameArr);
            }
            
        }

        static void PrintLine()
        {
            Console.WriteLine("---------------------------------------------------------------");
        }

        static void ConsoleAbove()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n\n\n");
        }

        static void ConsoleBelow()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
        static void MainMenu(GameData[] game)
        {
            string[] menus = { "모든게임정보출력", "특정조건출력", "종료" };

            int cursor = 0;         // 메뉴 선택 위치 표시용

            while (true)
            {
                Console.Clear();
                ConsoleAbove();
                Console.WriteLine();
                Console.WriteLine("          게임 정보 데이터 베이스");
                Console.WriteLine("     아래 메뉴 중 하나를 선택해주세요\n\n");
                Console.WriteLine();

                for (int i = 0; i < menus.Length; i++)              
                {
                    
                    if (i == cursor)
                    {
                        Console.WriteLine($"\t[{menus[i]}]");   // 현재 선택된 메뉴에 [ ]를 붙여서 강조
                    }
                    else
                    {
                        Console.WriteLine($"\t{menus[i]}");
                    }
                }

                ConsoleBelow();

                Console.WriteLine();
                Console.WriteLine("▶ 방향키를 눌러 메뉴를 선택합니다.");
                Console.WriteLine("▶ 엔터(Enter) 키를 누르면 선택됩니다");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);     // 방향키로 메뉴 선택

                if (keyInfo.Key == ConsoleKey.UpArrow)              // 위 방향키로 메뉴 올리기
                {
                    cursor--;
                    if (cursor < 0) cursor = menus.Length - 1;      // 맨 위일때 반대편으로 이동
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)       // 아래 방향키로 메뉴 내리기
                {
                    cursor++;
                    if (cursor >= menus.Length) cursor = 0;         // 맨 아래일때 반대편으로 이동
                }

                if (keyInfo.Key == ConsoleKey.Enter)                // 엔터로 메뉴 선택
                {
                    Console.Clear();
                    switch (cursor)
                    {
                        case 0:
                            PrintAllData(game);
                            WaitForEnter();
                            break;
                        case 1:
                            SpecificExtraction(game);
                            WaitForEnter();
                            break;
                        default:
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                    }

                }
            }
        }
        static void WaitForEnter()          // 메뉴를 선택후 다시 메인메뉴로 돌아갈 때 엔터키를 받는 함수
        {
            Console.WriteLine();
            Console.WriteLine("▶ 엔터(Enter) 키를 누르면 메인 메뉴로 돌아갑니다.");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            Console.Clear();
        }

        static GameData[] StoreData()               // 구조체 배열을 반환하는 데이터저장 함수
        {
            GameData[] gameArr = new GameData[6];

            gameArr[0].titleName = "보틀그라운드";
            gameArr[0].gameLevel = GameLevel.Adult;
            gameArr[0].price = 0;
            gameArr[0].userScore = 10f;
            gameArr[0].specials = (false, "none");
            gameArr[0].developerComment = "무료인데 갓겜이에요!";

            gameArr[1].titleName = "팔팔월드";
            gameArr[1].gameLevel = GameLevel.All;
            gameArr[1].price = 320000;
            gameArr[1].userScore = 8f;
            gameArr[1].specials = (true, "어딘가와 유사한게임같은데..");
            gameArr[1].developerComment = "이번에 정식출시해서 재밌어졌어요!";

            gameArr[2].titleName = "엄청난카멜레온";
            gameArr[2].gameLevel = GameLevel.All;
            gameArr[2].price = 6500;
            gameArr[2].userScore = 9f;
            gameArr[2].specials = (true, "출시되자마자 엄청난 인기를??");
            gameArr[2].developerComment = "새로운 형식의 게임이라 놀라웠어요!";

            gameArr[3].titleName = "버스컴퍼니";
            gameArr[3].gameLevel = GameLevel.Teen;
            gameArr[3].price = 20000;
            gameArr[3].userScore = 4f;
            gameArr[3].specials = (false, "none");
            gameArr[3].developerComment = "안해봐서 모르겠어요..";

            gameArr[4].titleName = "저터널리턴";
            gameArr[4].gameLevel = GameLevel.All;
            gameArr[4].price = 500;
            gameArr[4].userScore = 6f;
            gameArr[4].specials = (true, "good!");
            gameArr[4].developerComment = "생각보다 재밌는데요?";

            gameArr[5].titleName = "트와이스휴먼";
            gameArr[5].gameLevel = GameLevel.Adult;
            gameArr[5].price = 1000;
            gameArr[5].userScore = 7f;
            gameArr[5].specials = (false, "none");
            gameArr[5].developerComment = "첨나왔을 때 재밌게했어요.";

            return gameArr;
        }

        static void PrintAllData(GameData[] gameArr) // 게임 정보 전체 출력
        {
            Console.Clear();
            PrintLine();
            foreach (var game in gameArr)           // foreach로 배열전체를 출력
            {
                
                Console.WriteLine("게임 제목\t: {0}", game.titleName);
                Console.WriteLine("이용 등급\t: {0}", game.gameLevel);
                Console.WriteLine("가 격\t\t: {0}", game.price);
                Console.WriteLine("평 점\t\t: {0}", game.userScore);
                Console.WriteLine("특이 사항\t: 이슈가 있었는가? {0}, 유저코멘트 : {1}", game.specials.Item1, game.specials.Item2);
                Console.WriteLine("개발자코멘트\t: {0}", game.developerComment);
                PrintLine();
            }
        }
        

        static void SpecificExtraction(GameData[] gameArr)
        {
            Console.Clear();
            PrintLine();
            RateOver(gameArr);
            PrintLine();
            AdultLevel(gameArr);
            PrintLine();
            HasIssue(gameArr);
            PrintLine();
            MyCondition(gameArr);
            PrintLine();
        }

        static void RateOver(GameData[] gameArr)
        {
            Console.WriteLine("▶ 평점 8.0 이상인 게임 추출 ◀");
            Console.WriteLine();

            foreach (var game in gameArr)
            {
                if (game.userScore >= 8.0f)
                {
                    Console.WriteLine($"[평점 8.0이상] {game.titleName} (평점: {game.userScore})");
                }
            }
        }

        static void AdultLevel(GameData[] gameArr)
        {
            Console.WriteLine("▶ 성인 등급인 게임 추출 ◀");
            Console.WriteLine();

            foreach (var game in gameArr)
            {
                if (game.gameLevel == GameLevel.Adult)
                {
                    Console.WriteLine($"[성인 전용] {game.titleName}");
                }
            }
        }

        static void HasIssue(GameData[] gameArr)
        {
            Console.WriteLine("▶ 특이사항이 있는 게임 추출 ◀");
            Console.WriteLine();

            foreach (var game in gameArr)
            {
                if (game.specials.HasIssue)
                {
                    Console.WriteLine($"[특이사항] {game.titleName} : {game.specials.Comment}");
                }
            }
        }

        static void MyCondition(GameData[] gameArr)
        {
            Console.WriteLine("▶ 가격이 만원이하인 게임 추출 ◀");
            Console.WriteLine();

            foreach (var game in gameArr)
            {
                if (game.price <= 10000)
                {
                    Console.WriteLine($"[가성비 좋음(만원이하)] {game.titleName} (가격: {game.price}원)");
                }
            }
        }

    }
}