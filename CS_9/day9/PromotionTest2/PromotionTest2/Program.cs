using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;

namespace PromotionTest2
{
    internal class Program
    {
        static Random random = new Random();

        enum Hand
        {
            Scissors = 1,
            Rock,
            Paper
        }

        enum GameResult
        {
            Win = 1,
            Lose,
            Draw
        }

        class Player
        {
            public int _money;
            public int _currentBet;
            public Hand _hand;
            public Computer _computer;


            public Player(int startMoney)       // 시작돈 설정
            {
                _money = startMoney;
            }

            public void Betting()               // 베팅하기 + 함수결과 : _money에 베팅금만큼 차감
            {

                int startY = Console.CursorTop;             //  오류처리 문구 초기화 시키기용

                while (true)
                {
                    Console.SetCursorPosition(0, startY);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, startY);

                    Console.Write("베팅할 금액을 입력해 주세요. (최소 : 1,000원) : ");
                    string input = Console.ReadLine()!;

                    if (!int.TryParse(input, out _currentBet))
                    {
                        Console.SetCursorPosition(0, startY + 2);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, startY + 2);

                        Console.Write("※ 숫자만 입력할 수 있습니다. 다시 입력해 주세요.");
                        continue;
                    }

                    if (_currentBet < 1000)
                    {
                        Console.SetCursorPosition(0, startY + 2);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, startY + 2);

                        Console.Write("※ 최소 베팅 금액은 1000원입니다. 다시 입력해 주세요.");
                        continue;
                    }

                    if (_money < _currentBet)
                    {
                        Console.SetCursorPosition(0, startY + 2);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, startY + 2);

                        Console.Write("※ 소지금보다 많은 금액을 베팅할 수 없습니다. 다시 입력해 주세요.");
                        continue;
                    }

                    Console.SetCursorPosition(0, startY + 1);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, startY + 1);

                    _money -= _currentBet;
                    Console.WriteLine($"\n{_currentBet}만큼 베팅하였습니다! 베팅 후 소지금은 {_money}입니다.");

                    return;
                }

            }

            public void ChooseHand(Computer _computer)            // 손 입력 받기 + 함수결과 : _hand에 입력받은 손 저장
            {
                int startY = Console.CursorTop;
                bool isCheat = false;

                while (true)
                {
                    Console.SetCursorPosition(0, startY);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, startY);

                    Console.WriteLine("무엇을 내시겠습니까?");
                    Console.Write("[가위], [바위], [보]");
                    Console.WriteLine(isCheat ? $"\t[치트] 컴퓨터가 낸 손 : {_computer._hand}" : "");
                    Console.Write("선택 : ");

                    string playerAction = Console.ReadLine()!;

                    switch (playerAction)
                    {
                        case "가위":
                            _hand = Hand.Scissors;
                            return;
                        case "바위":
                            _hand = Hand.Rock;
                            return;
                        case "보":
                            _hand = Hand.Paper;
                            return;
                        case "치트":      // 치트 구현
                            isCheat = true;
                            Console.SetCursorPosition(0, startY + 2);
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, startY + 2);
                            continue;
                        default:
                            Console.SetCursorPosition(0, startY + 2);
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, startY + 3);

                            Console.WriteLine("잘못된 입력입니다. 다시 입력해 주세요.");
                            continue;
                    }
                }
            }

        }

        class Computer
        {
            public Hand _hand;

            public void ChooseHand()            // 컴퓨터 랜덤 가위바위보
            {
                _hand = (Hand)random.Next(1, 4);
            }

        }

        class GameManager
        {
            public Player _player;
            public Computer _computer;
            public GameDisplay _gameDisplay;
            private int _round = 1;
            private int _stackGold = 0;

            public int _winCount = 0;
            public int _loseCount = 0;
            public int _drawCount = 0;

            public GameManager()
            {
                _player = new Player(10000);    // 시작 돈 10000원 설정
                _computer = new Computer();
                _gameDisplay = new GameDisplay(this);
            }

            public void GamePlay()
            {
                while (true)
                {
                    int menuSelect = _gameDisplay.ShowMenu();

                    switch (menuSelect)
                    {
                        case 0:
                            while (_round <= 5 && _player._money > 0)
                            {
                                Console.Clear();                                                        // 콘솔 화면 초기화
                                _gameDisplay.PrintLine();                                               
                                _gameDisplay.ShowRoundStatus(_round, _player._money, _stackGold);       // 라운드 정보 출력

                                _player.Betting();                                                      // 베팅금액 설정
                                _computer.ChooseHand();                                                 // 컴퓨터가 낼 가위바위보 결정
                                _player.ChooseHand(_computer);                                                   // 플레이어가 무엇을 낼지 결정

                                GameResult result = Judge(_player._hand, _computer._hand);              // 게임의 결과 반환

                                _gameDisplay.ShowBattle(_player._hand, _computer._hand);                // 결과 콘솔에 출력
                                _gameDisplay.ShowRoundResult(result);                                   // 라운드 결과 출력

                                CalculateResult(result);                                                // 결과에 따른 소지금 계산

                                _gameDisplay.WaitForEnter();                                            // 다음화면 넘기기 위한 엔터키 입력 대기

                                _round++;
                            }
                            _gameDisplay.ShowFinalResult(_winCount, _loseCount, _drawCount, _player._money);    // 최종 게임 결과 출력
                            Console.WriteLine("\n게임을 이용해 주셔서 감사합니다. 프로그램을 종료합니다.\n");
                            _gameDisplay.PrintLine();
                            Environment.Exit(0);
                            break;
                        case 1:
                            _gameDisplay.PrintLine();
                            _gameDisplay.ShowGameRule();                                                // 게임 룰 설명
                            _gameDisplay.PrintLine();

                            break;
                        case 2:                                                                         // 게임 종료
                        default:
                            Console.Clear();
                            _gameDisplay.PrintLine();
                            Console.WriteLine("\n게임을 종료합니다.\n");
                            _gameDisplay.PrintLine();
                            Environment.Exit(0);
                            break;
                    }
                }
            }

            private GameResult Judge(Hand p, Hand c)        // 게임 결과 반환 ( GameResult 결과 )
            {
                if (p == c) return GameResult.Draw;             // return으로 함수를 그냥 끝내기 때문에 굳이 else를 사용하지 않아도 된다고 함

                if ((p == Hand.Scissors && c == Hand.Paper) ||
                    (p == Hand.Rock && c == Hand.Scissors) ||
                    (p == Hand.Paper && c == Hand.Rock))
                {
                    return GameResult.Win;
                }

                return GameResult.Lose;
            }

            private void CalculateResult(GameResult result)
            {
                switch (result)
                {
                    case GameResult.Win:
                        _winCount += 1;
                        _player._money += (_player._currentBet * 3) + _stackGold;
                        _stackGold = 0;
                        break;
                    case GameResult.Lose:
                        _loseCount += 1;
                        _stackGold = 0;
                        break;
                    case GameResult.Draw:
                        _drawCount += 1;
                        _stackGold += _player._currentBet;
                        break;
                }
            }
        }

        class GameDisplay
        {
            public GameManager gameManager;

            public GameDisplay(GameManager manager)
            {
                gameManager = manager;
            }

            public void PrintLine()
            {
                Console.WriteLine("============================================================");
            }

            public int ShowMenu()
            {
                string[] menus = { "게임 시작", "설명 보기", "종 료" };
                int cursor = 0;

                while (true)
                {
                    Console.Clear();
                    PrintLine();
                    Console.WriteLine("\n\n");
                    string titleText = $"가위 바위 보 게임";
                    string title = titleText.PadLeft(31).PadRight(60);
                    Console.WriteLine(title);
                    Console.WriteLine("\n\n");

                    for (int i = 0; i < menus.Length; i++)
                    {

                        if (i == cursor)
                        {
                            string menuText = $"[{menus[i]}]";
                            string rendered = menuText.PadLeft(31).PadRight(60);
                            Console.WriteLine(rendered);
                        }
                        else
                        {
                            string menuText = $"{menus[i]}";
                            string rendered = menuText.PadLeft(30).PadRight(60);
                            Console.WriteLine(rendered);
                        }
                    }
                    Console.WriteLine("\n\n");
                    PrintLine();

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

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
                        return cursor;
                    }
                }
            }

            public void ShowGameRule()
            {
                Console.Clear();
                PrintLine();
                Console.WriteLine("\n초기 소지금은 10,000입니다.\n");
                Console.WriteLine("최소 베팅은 1,000부터 입니다.\n");
                Console.WriteLine("현재 소지금 보다 많은 금액은 베팅 할 수 없습니다.\n");
                Console.WriteLine("무승부 시 베팅금액은 누적되며, 승리시 현재 베팅금액의 3배를 획득합니다.\n");
                Console.WriteLine("소지금을 전부 잃거나 5판 진행이 끝난 후 게임이 종료됩니다.\n");
                PrintLine();
                WaitForEnter();
            }

            public void WaitForEnter()
            {
                Console.WriteLine("▶ 엔터(Enter) 키를 누르면 넘어갑니다.");

                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        break;
                    }
                }
            }

            public void ShowRoundStatus(int round, int money, int stackGold)
            {
                Console.WriteLine($"[ {round} 번째 판 ]\n");
                Console.WriteLine($"현재 플레이어의 소지금: {money}원");
                Console.WriteLine($"현재 누적 이월 판돈: {stackGold}원\n");
            }

            public void ShowBattle(Hand playerHand, Hand computerHand)
            {
                PrintLine();
                Console.WriteLine("▶ 대결 결과 ◀\n");

                Console.WriteLine($"플레이어: {StringChange(playerHand)}  VS  컴퓨터: {StringChange(computerHand)}\n");
            }

            public string StringChange(Hand hand)
            {
                switch (hand)
                {
                    case Hand.Scissors:
                        return "가위";
                    case Hand.Rock:
                        return "바위";
                    case Hand.Paper:
                        return "보";
                    default:
                        return "잘못된 입력";
                }
            }

            public void ShowRoundResult(GameResult result)
            {
                if (result == GameResult.Win)
                    Console.WriteLine("결과: 축하합니다! 이겼습니다!! (배팅금 3배 + 누적 판돈 획득)");
                else if (result == GameResult.Lose)
                    Console.WriteLine("결과: 아쉽게도 졌습니다... (배팅금 소멸)");
                else
                    Console.WriteLine("결과: 비겼습니다. 판돈이 누적됩니다.");

                Console.WriteLine();
                PrintLine();
            }

            public void ShowFinalResult(int win, int lose, int draw, int finalMoney)
            {
                Console.Clear();

                PrintLine();

                Console.WriteLine("★ 최종 결과 ★\n");
                Console.WriteLine($"승 : {win}\n");
                Console.WriteLine($"패 : {lose}\n");
                Console.WriteLine($"무승부 : {draw}\n");
                Console.WriteLine($"최종 소지금 : {finalMoney}원");

                PrintLine();
            }
        }

        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            gameManager.GamePlay();
        }
    }
}
