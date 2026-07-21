using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class Player : Unit
    {
        public int _level { get; set; }
        public int _killCount { get; set; }
        public int _totalKill {  get; set; }
        public int _requiredKill { get; set; }      // 렙업시 필요 킬카운트

        public Player(string name) : base(name, maxHp: 500, attackPower: 5, attackSpeed: 1, maxGauge: 4, defense: 5)
        {
            _level = 1;
            _killCount = 0;
            _totalKill = 0;
            _requiredKill = 3;
        }

        public void LevelUP()       // 레벨 업, 다음렙업시 필요한 킬요구수치 1씩 증가
        {
            _level++;
            _killCount = 0;
            _requiredKill++;
        }

        public void UpdateStats()   // 레벨업 선택지에서 증가한 스탯 적용
        {

        }

    }
}
