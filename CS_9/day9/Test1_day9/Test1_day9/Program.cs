using System;
using System.Xml.Linq;
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
            public string _cardNum;

            public CardInfo(CardType type, string cardNum)
            {
                _type = type;
                _cardNum = cardNum;
            }

            public string CardNumToString()     // 특정 번호의 카드들을 알파벳으로 바꿔주는 메서드
            {
                switch (_cardNum)
                {
                    case "1":
                        return "A";
                    case "11":
                        return "J";
                    case "12":
                        return "Q";
                    case "13":
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
                Console.WriteLine($" {CardNumToString()}");
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            CardInfo[] deck = CardDeck();                               // 덱생성
            
            CardShuffle(deck);                                          // 덱 셔플

            GamePlay(deck);


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
                    cardDeck[cardNum] = new CardInfo(type, j.ToString());
                    cardNum++;
                }
                
            }

            return cardDeck;
        }

        static void CardShuffle(CardInfo[] deck)        // 피셔-에이츠 셔플활용
        {
            for (int i = deck.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                CardInfo temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        static void GamePlay(CardInfo[] deck)
        {
            int i = 0;
            for (i = 0; i < 5; i++)
            {
                deck[i].PrintInfo();
            }

            deck[i].PrintInfo();
            Console.WriteLine(i);
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
