using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class CardSelector           // 4일차 과제 활용하여 선택창 이미지로 출력
    {
        static public Random rand = new Random();

        /// <summary>
        /// 스탯 중 랜덤으로 3개를 골라 랜덤한 수치로 각 박스에 넣음
        /// out 매개변수를 활용하여 변수의 값을 채워서 바로 출력 사용할때는 사용하는 메서드에서 각각 type과 stat 변수를 만들어 줘야함!!!
        /// </summary>
        /// <param name="powerUpOpstions"></param>
        /// <param name="selectedType"></param>
        /// <param name="selectedstat"></param>
        public void SelectEffect(Player player, out StatType selectedType, out int selectedstat)
        {
            StatType[] powerUpOptions;

            if (player._attackSpeed >= 4)           // 공속 최대치인 4 도달시 배열에서 공속 제거
            {
                powerUpOptions = new StatType[]{
                    StatType.AttackPower,
                    StatType.Defense,
                    StatType.HPRegen
                };
            }
            else
            {
                powerUpOptions = new StatType[]{
                    StatType.AttackPower,
                    StatType.AttackSpeed,
                    StatType.Defense,
                    StatType.HPRegen
                };
            }

            Shuffle(powerUpOptions);       // shuffle함수로 StatType 배열을 섞어 AttackPower, AttackSpeed, Defense, HPRegen 중 3개를 1 2 3번 박스에 넣음

            StatType type1 = powerUpOptions[0];
            StatType type2 = powerUpOptions[1];
            StatType type3 = powerUpOptions[2];

            int stat1 = StatRandom(type1);       // 각 박스의 스탯을 StatRandom함수로 랜덤하게 설정
            int stat2 = StatRandom(type2);
            int stat3 = StatRandom(type3);

            SpriteFrame box1 = GetBoxSprite(1, type1, stat1);
            SpriteFrame box2 = GetBoxSprite(2, type2, stat2);
            SpriteFrame box3 = GetBoxSprite(3, type3, stat3);

            RenderCardSelection(box1, box2, box3);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.NumPad1:
                        selectedType = type1;
                        selectedstat = stat1;
                        return;
                    case ConsoleKey.NumPad2:
                        selectedType = type2;
                        selectedstat = stat2;
                        return;
                    case ConsoleKey.NumPad3:
                        selectedType = type3;
                        selectedstat = stat3;
                        return;
                    default:
                        break;
                }
            }
        }

        // png파일 이름 "Box_박스번호_ATK(열거형에맞게)_수치"로 해야함!!!
        public SpriteFrame GetBoxSprite(int posNum, StatType statName, int statValue)       // png 이미지 불러오기
        {
            PngDecoder decoder = new PngDecoder();
            if (statName == StatType.AttackSpeed || statName == StatType.HPRegen)   // 공속과 체젠은 value가 따로 없기 때문
            {
                PixelImage image0 = decoder.ReadPNG($@"Sprites\Box{posNum}_{statName}.png");
                return image0.ToSpriteFrame();
            }
            PixelImage image = decoder.ReadPNG($@"Sprites\Box{posNum}_{statName}_{statValue}.png");
            return image.ToSpriteFrame();
        }

        public void RenderCardSelection(SpriteFrame box1, SpriteFrame box2, SpriteFrame box3)       // 불러온 이미지 출력
        {
            RenderManager.Draw(box1);
            RenderManager.Draw(box2);
            RenderManager.Draw(box3);
        }

        private int StatRandom(StatType type)              // 스탯 랜덤
        {
            switch (type)
            {
                case StatType.AttackPower:
                    return rand.Next(8, 16);  // 공격력 상승 수치 8 ~ 15 랜덤 (후반 체감 폭 커짐)

                case StatType.Defense:
                    return rand.Next(3, 7);   // 방어력 상승 수치 3 ~ 6 랜덤

                default:
                    return 0; // 공속과 체력회복은 Player 클래스에서 정한 고정수치 이기때문에 0
            }
        }

        private void Shuffle(StatType[] array)     // 피셔-에이츠 셔플 활용
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                StatType temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
