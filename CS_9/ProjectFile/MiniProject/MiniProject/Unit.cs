using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal abstract class Unit
    {
        public string _name { get; protected set; }
        public int _maxHp { get; protected set; }
        public int _currentHp { get; protected set; }
        public int _attackPower { get; protected set; }
        public int _attackSpeed { get; protected set; }
        public int _currentGauge { get; protected set; }
        public int _maxGauge { get; protected set; }
        public int _defense { get; protected set; }
        public bool _isAlive => _currentHp > 0;          // currentHP가 0보다 클때만 true

        protected Unit(string name, int maxHp, int attackPower, int attackSpeed, int maxGauge, int defense)
        {
            _name = name;
            _maxHp = maxHp;
            _currentHp = maxHp;             // 시작 체력은 maxHP이기 때문
            _attackPower = attackPower;
            _attackSpeed = attackSpeed;
            _maxGauge = maxGauge;
            _defense = defense;
            _currentGauge = 0;                // 처음에는 공속 게이지가 0칸
        }

        public void UpdateGauage()
        {
            _currentGauge++;
            if (_currentGauge > _maxGauge)
            {
                _currentGauge = 0;
            }
        }

        public bool CanAttack()              // 공속 게이지가 다 찼을 때 공격가능
        {
            return _currentGauge == _maxGauge;
        }
            


        public void Attack(Unit target)                // 공격 기능
        {

        }

        public void Hit(int damage)                   // 피격 기능, 공격당해서 데미지를 받음 (체력이 깎임)
        {

        }

    }
}
