using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class Unit
    {
        public string _name { get; protected set; }
        public int _maxHp { get; protected set; }
        private int _currentHp;
        public int CurrentHP            // 현재 체력이 0보다 낮아지는 음수인 경우를 예외처리 시켜 적용
        {
            get { return _currentHp; }
            set
            {
                Math.Max(_currentHp, value);
            }
        }
        public int _attackPower { get; protected set; }
        public int _attackSpeed { get; protected set; }
        public int _currentGauge { get; protected set; }
        public int _maxGauge { get; protected set; }
        public int _defense { get; protected set; }

        public bool _canAttack { get; protected set; }
        public bool _isAlive { get; protected set; }       // currentHP가 0보다 클때만 true

        public Unit(string name, int maxHp, int attackPower, int attackSpeed, int maxGauge, int defense)
        {
            _name = name;
            _maxHp = maxHp;
            _currentHp = maxHp;             // 시작 체력은 maxHP이기 때문
            _attackPower = attackPower;
            _attackSpeed = attackSpeed;
            _maxGauge = maxGauge;
            _defense = defense;
            _currentGauge = 0;                // 처음에는 공속 게이지가 0칸
            _canAttack = false;
            _isAlive = true;

        }

        public void UpdateGauage()          // 프레임마다 게이지 한칸 올리고 최대 게이지가 되면 공격준비를 활성화 시키고 다시 게이지 0으로 초기화
        {
            if (!_isAlive)
            {
                return;
            }

            _currentGauge++;

            if (_currentGauge > _maxGauge)
            {
                _canAttack = true;
                _currentGauge = 0;
            }

            _canAttack = false;
        }

        public int Attack(Unit target)                // 공격 기능 / 방어력이 공격력보다 높을때는 무조건 데미지 1로 고정
        {
            if (!_canAttack || !_isAlive)
            {
                return 0;
            }

            _canAttack = false;
            int damage = Math.Max(1, _attackPower - target._defense);
            return damage;

        }

        public void Hit(int damage)                   // 피격 기능, 공격당해서 데미지를 받음 (체력이 깎임)
        {
            _currentHp -= damage;
            if (_currentHp <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            _isAlive = false;
        }
    }
}
