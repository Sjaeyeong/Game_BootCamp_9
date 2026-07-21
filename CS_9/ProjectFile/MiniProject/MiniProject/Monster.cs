using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniProject
{
    internal class Monster : Unit
    {
        public bool _isBoss { get; set; }


        public Monster(string name, int maxHp, int attackPower, int attackSpeed, int maxGauge, int defense, bool isBoss)
            : base(name, maxHp, attackPower, attackSpeed, maxGauge, defense)
        {
            _isBoss = isBoss;
        }

        public Monster NormalMonster(int round)     // 일반몹 수치 조정 필요
        {
            Random random = new Random();
            int monsterType = random.Next(0, 3);    // 3가지의 랜덤 몬스터 소환

            string name = "";
            int maxHp = 8 + (round * 2);
            int attackPower = 1 + (round%2 * 2);
            int defense = 1 + round;
            int maxGauge = 4;

            switch (monsterType)
            {
                case 0:
                    name = "슬라임";
                    maxHp += 4;
                    maxGauge = 2;
                    break;
                case 1:
                    name = "골렘";
                    maxHp = (int)(maxHp * 1.5);
                    maxGauge = 3;
                    attackPower += 4;
                    defense += 4;
                    break;
                case 2:
                    name = "고블린";
                    maxGauge = 1;
                    defense += 1;
                    break;
            }

            return new Monster(name, maxHp, attackPower, 1, maxGauge, defense, false);
        }

        public Monster BossMonster(int round)   // 보스 수치 조정필요
        {
            string name = "";
            int maxHp = 8 + (round * 2);
            int attackPower = 1 + (round % 2 * 2);
            int defense = 1 + round;
            int maxGauge = 4;

            return new Monster(name, maxHp, attackPower, 1, maxGauge, defense, true);
        }



    }
}
