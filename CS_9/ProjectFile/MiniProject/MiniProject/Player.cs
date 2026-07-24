using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class Player : Unit
    {
        public int _level;
        public int _killCount;
        public int _totalKill;
        public int _requiredKill;      // 렙업시 필요 킬카운트

        public Player(string name) : base(name, maxHp: 500, attackPower: 5, attackSpeed: 1, maxGauge: 4, defense: 5)
        {
            _level = 1;
            _killCount = 0;
            _totalKill = 0;
            _requiredKill = 3;
            _isAlive = true;
        }

        public void AddKill()       // 플레이어가 몬스터를 처치하면 킬카운트가 올라가고 요구킬카운트에 도달하면 레벨업 메서드를 호출
        {
            _killCount++;
            _totalKill++;
            if (_killCount >= _requiredKill)
            {
                LevelUP();
            }
        }

        public void LevelUP()       // 레벨 업, 다음렙업시 필요한 킬요구수치 1씩 증가
        {
            _level++;
            _killCount = 0;
            _requiredKill++;
        }

        public void UpdateStats(StatType stat, int value)   // 레벨업 선택지에서 증가한 스탯 적용
        {
            _maxHp += 10;               // 레벨업 시 최대체력과 현재 체력이 각각 10씩 증가
            CurrentHP += 10;

            switch (stat)
            {
                case StatType.AttackPower:
                    _attackPower += value;
                    break;
                case StatType.AttackSpeed:
                    _maxGauge--;
                    _attackSpeed++;
                    break;
                case StatType.Defense:
                    _defense += value;
                    break;
                case StatType.HPRegen:      // 최대체력의 10퍼 회복
                    CurrentHP += (int)(_maxHp * 0.1);

                    if (CurrentHP >= _maxHp)     // 10퍼 회복했을 때 최대 체력을 넘어가는 경우 최대체력까지 회복시키게 함
                    {
                        CurrentHP = _maxHp;
                    }
                    break;
            }
        }
    }
}
