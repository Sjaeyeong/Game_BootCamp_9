using System;
using System.Security;
using System.Text;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test1_day9
{
    internal class Program
    {
        static public Random random = new Random();     // 랜덤 변수인 random을 시작할때 전역으로 한번 선언

        enum CardType
        {
            Diamond,
            Spade,
            Heart,
            Clover
        }

        enum PlayerAction
        {
            High,
            Low,
            Seven,
            Fold
        }

        class CardInfo
        {
            public CardType _type;
            public int _cardNum;

            public CardInfo(CardType type, int cardNum)
            {
                _type = type;
                _cardNum = cardNum;
            }

            public string CardNumToString()     // 특정 번호의 카드들을 알파벳으로 바꿔주는 메서드
            {
                switch (_cardNum)
                {
                    case 1:
                        return "A";
                    case 11:
                        return "J";
                    case 12:
                        return "Q";
                    case 13:
                        return "K";
                    default:
                        return _cardNum.ToString();
                }
            }

            public string GetCardType()         // 카드 타입에 따라 특수기호로 바꿔주는 메서드
            {
                switch (_type)
                {
                    case CardType.Diamond:
                        return "◆";
                    case CardType.Spade:
                        return "♠";
                    case CardType.Heart:
                        return "♥";
                    case CardType.Clover:
                        return "♣";
                    default :
                        return "";
                }
            }

            public ConsoleColor GetCardColor()
            {
                switch (_type)
                {
                    case CardType.Diamond:
                    case CardType.Heart:
                        return ConsoleColor.Red;
                    case CardType.Spade:
                    case CardType.Clover:
                    default:
                        return ConsoleColor.Black;
                }
            }

            public void PrintInfo()
            {
                ConsoleColor cardColor = GetCardColor();
                TextColor($"{GetCardType()}", cardColor, ConsoleColor.White);
                string numStr = CardNumToString();
                string alignedStr = $" {numStr}".PadRight(3);   // 숫자가 10일때 배경색 밀림 방지
                TextColor(alignedStr, ConsoleColor.Black, ConsoleColor.DarkGreen);
            }
        }


        static void Main(string[] args)
        {
            CardInfo[] deck = CardDeck();                               // 덱생성
            int currentCardIndex = 0;
            int currentGold = 10000;
            int defaultBet = 1000;
            int round = 1;

            while (round <= 8 && currentCardIndex + 6 <= 52 && currentGold > 0) // 종료 조건 : 8라운드, 카드 부족, 소지금 0
            {
                Console.WriteLine($"\n=================== [ ROUND {round} ] ===================\n");
                Console.WriteLine($"현재 소지금: {currentGold}원");
                TextColor("                                                    \n", ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

                CardShuffle(deck, currentCardIndex);                        // 덱 셔플
                currentGold = PlayTurn(deck, currentCardIndex, currentGold, defaultBet);                           // 턴 진행

                currentCardIndex += 6;
                round++;

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

            Console.WriteLine("\n=====================================================\n");
            Console.WriteLine("게임이 종료되었습니다.");
            Console.WriteLine($"최종 결과 - 진행 라운드: {round - 1} | 최종 소지금: {currentGold}원");
            Console.WriteLine("\n=====================================================\n");

        }

        static CardInfo[] CardDeck()            // 카드덱 생성
        {
            CardInfo[] cardDeck = new CardInfo[52];
            int length = Enum.GetNames(typeof(CardType)).Length;    // CardType 열거형의 길이를 가져옴
            int cardNum = 0;

            for (int i = 0; i < length ; i++)
            {
                CardType type = CardType.Diamond;
                switch (i)
                {
                    case 0:
                        type = CardType.Diamond;
                        break;
                    case 1:
                        type = CardType.Spade;
                        break;
                    case 2:
                        type = CardType.Heart;
                        break;
                    case 3:
                        type = CardType.Clover;
                        break;
                    default:
                        break;
                }   

                for (int j = 1; j < 14; j++)
                {
                    cardDeck[cardNum] = new CardInfo(type, j);
                    cardNum++;
                } 
            }
            return cardDeck;
        }

        static void CardShuffle(CardInfo[] deck, int current)        // 피셔-에이츠 셔플활용
        {
            for (int i = deck.Length - 1; i > current; i--)
            {
                int j = random.Next(current, i + 1);

                CardInfo temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        static int PlayTurn(CardInfo[] deck, int startNum, int currentGold, int defaultBet)
        {
            int currentNum = 0;
            for (currentNum = startNum; currentNum < startNum + 5; currentNum++)    // 겜시작 첫 5개 공개까지 했음
            {
                TextColor(" ", ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);
                deck[currentNum].PrintInfo();
                TextColor(" ", ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);
            }
            
            TextColor("?", ConsoleColor.Black, ConsoleColor.White);
            TextColor(" ?   [치트 : ", ConsoleColor.Black, ConsoleColor.DarkGreen);
            deck[startNum + 5].PrintInfo();
            TextColor("]   \n", ConsoleColor.Black, ConsoleColor.DarkGreen);
            TextColor("                                                    \n", ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

            PlayerAction action = GetPlayerAction(deck, startNum);             //  플레이어에게 베팅 선택을 받음

            int finalBetGold = 0;
            
            if (action == PlayerAction.Fold)
            {
                // 기권
                finalBetGold = defaultBet;
                currentGold -= finalBetGold;

                Console.WriteLine($"\n기권하셨습니다. 기본금 {finalBetGold}원이 차감됩니다.");
            }
            else
            {
                // 베팅 진행
                finalBetGold = Betting(currentGold);
                PlayerAction result = GetResult(deck[startNum + 5]);     //  숨겨진 6번째 카드에 따른 결과 판독

                if (action == result)
                {
                    if (action == PlayerAction.Seven)
                    {
                        currentGold += finalBetGold * 13;
                        Console.WriteLine($"\n★★Seven 적중★★ {finalBetGold * 13}원 획득!");
                    }
                    else
                    {
                        currentGold += finalBetGold;
                        Console.WriteLine($"\n예측 성공! {finalBetGold}원 획득!");
                    }
                }
                else
                {
                    currentGold -= finalBetGold;
                    Console.WriteLine($"\n예측 실패... {finalBetGold}원 만큼 차감됩니다.");
                }
            }

            Console.Write("6번째 숨겨진 카드는 바로.. ");
            deck[startNum + 5].PrintInfo();
            Console.WriteLine("이었습니다\n");

            Console.WriteLine($"정산 후 현재 소지금 : {currentGold}\n");

            Console.WriteLine("===================================================");

            return currentGold;

        }

        static PlayerAction GetPlayerAction(CardInfo[] deck, int startNum)
        {
            while (true)
            {
                Console.WriteLine("6번째 숨겨진 카드의 숫자를 예측해 주세요!");
                Console.WriteLine("[High : H]  [Low : L]  [Seven : S]  [Fold : F]  [치트1 : C1] [치트2 : C2]\n");
                Console.WriteLine("※ 다른 키 입력 시 해당 턴은 기권(Fold) 처리됩니다.");
                Console.WriteLine("기권 시 기본금 1,000이 차감됩니다.");
                Console.Write("키 입력 : ");

                string playerAction = Console.ReadLine()!.ToUpper();    // 소문자인 영어를 대입해도 대문자로 처리

                switch (playerAction)
                {
                    case "H":
                        return PlayerAction.High;
                    case "L":
                        return PlayerAction.Low;
                    case "S":
                        return PlayerAction.Seven;
                    case "F":
                        return PlayerAction.Fold;
                    case "C1":      // 다시 확인하기
                        int nextHiddenIndex = startNum + 11;
                        if (nextHiddenIndex < deck.Length)
                        {
                            Console.Write("\n[치트 1 작동] 다음 라운드의 히든 카드: ");
                            deck[nextHiddenIndex].PrintInfo();
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            Console.WriteLine("\n[치트 1] 다음 라운드가 존재하지 않습니다!\n");
                        }
                        break;
                    case "C2":
                        Console.WriteLine("\n[치트 2] 남은 덱 카드 목록:");
                        int count = 0;
                        for (int i = startNum + 6; i < deck.Length; i++)
                        {
                            deck[i].PrintInfo();
                            count++;
                            if (count % 13 == 0) Console.WriteLine();       // 13장마다 줄바꿈
                        }
                        Console.WriteLine("\n");
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 기권으로 처리합니다.");
                        return PlayerAction.Fold;
                }
            }
        }
        
        static PlayerAction GetResult(CardInfo targetCard)
        {
            int cardNum = targetCard._cardNum;

            if (cardNum > 7)
            {
                return PlayerAction.High;
            }
            else if (cardNum < 7)
            {
                return PlayerAction.Low;
            }
            else
            {
                return PlayerAction.Seven;
            }
        }

        static int Betting(int currentGold)     // 베팅입력과 베팅한 금액 반환
        {
            int betGold = 0;
            int startY = Console.CursorTop;     // 현재 커서가 있는 위치

            while (true)
            {
                Console.SetCursorPosition(0, startY);           // 커서의 위치를 x축은 맨왼쪽, y축은 startY로 이동
                Console.Write(new string(' ', Console.WindowWidth));    // 해당줄을 공백으로 처리
                Console.SetCursorPosition(0, startY);

                Console.Write("베팅할 금액을 입력하세요 :");
                string? playerInput = Console.ReadLine();

                if (int.TryParse(playerInput, out betGold))
                {
                    if (betGold >= 1000 && betGold <= currentGold)
                    {
                        Console.SetCursorPosition(0, startY + 1);
                        Console.Write(new string(' ', Console.WindowWidth));

                        return betGold;
                    }
                    else
                    {
                        Console.WriteLine("※ 소지금을 초과했거나 최소 베팅 금액(1,000원) 미만입니다!");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해 주세요.                           ");
                }
            }
        }


        static void TextColor(string text, ConsoleColor textColor, ConsoleColor backColor)
        {
            ConsoleColor prevTextColor = Console.ForegroundColor;
            ConsoleColor prevBackColor = Console.BackgroundColor;

            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backColor;
            Console.Write(text);

            Console.ForegroundColor = prevTextColor;
            Console.BackgroundColor = prevBackColor;
        }
    }
}
