using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.MathF;

namespace MiniProject
{
    public class Monster : Unit
    {
        public Monster(string name, int maxHp, int attackPower, int attackSpeed, int maxGauge, int defense)
            : base(name, maxHp, attackPower, attackSpeed, maxGauge, defense)
        {
            _isAlive = true;
        }

        static public Monster[] MonsterGroup(int round, PngDecoder decoder)     // 07/21 강의때 배운 static 활용
        {
            Monster[] monsters = new Monster[3];
            int maxHp = 8 + (round * 2);
            int attackPower = 1 + ((round / 2) * 2);
            int defense = 1 + round;

            monsters[0] = new Monster("일반 슬라임", maxHp, attackPower, 4, 1, defense);  // 공격속도가 빠름
            monsters[1] = new Monster("행복한 슬라임", maxHp + 5, attackPower, 1, 4, defense); // 체력 +5, 공격속도가 느림
            monsters[2] = new Monster("화난 슬라임", maxHp - 2, (int)(attackPower * 1.2f), 2, 3, defense);    // 체력이 -2, 공격력이 1.2배, 공격속도는 2 (게이지3)

            return monsters;
        }

        static public Monster BossMonster(int round, PngDecoder decoder)
        {
            int maxHp = 25 + (round * 2);
            int attackPower = 10 + (round * 2);
            int defense = 5 + (round * 2);

            Monster boss = new Monster("킹 슬라임", maxHp, attackPower, 2, 3, defense);
            return boss;
        }

    }
}
