using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class GameManager
    {
        public int _round;

        private Player _player;
        private CardSelector _selector;
        private Monster[] _monster;
        private Monster _boss;
        private Monster? _currentActiveMonster;  // 현재 싸우고 있는 몬스터가 누구인가
        private GameState _gameState;
        private StatType _statType;
        private int _frameCount;
        private PngDecoder _decoder;

        private Random rand = new Random();

        public GameManager()                // 게임 초기상태 설정
        {
            _round = 1;
            _decoder = new PngDecoder();
            _player = new Player("슬라임 슬레이어");
            _selector = new CardSelector();
            _monster = Monster.MonsterGroup(_round, _decoder);
            _boss = Monster.BossMonster(_round, _decoder);
            _gameState = GameState.Playing;     // 추후에 메인메뉴 만들면 메인메뉴로?
            _frameCount = 0;

            SpawnMonster();
        }

        public void Play()                              // GameOver가 될때까지 반복, Playing상태이면 UpdateFrame(), LeveUP시에는 게임 중단되고 레벨업 선택창이 나옴 
        {
            while (_gameState != GameState.GameOver)        // 0.5초마다 화면 변경
            {
                if (_gameState == GameState.Playing)
                {
                    SpawnMonster();
                    UpdateFrame();
                }

                if (_gameState == GameState.LevelUp)
                {
                    LevelUpSelect();
                }

                Thread.Sleep(500);
                _frameCount++;
            }

        }
        public void UpdateFrame()           // 프레임마다 : 공속게이지 1칸씩 채워짐, 다 채워지면 공격, 프레임마다 이미지 변경됨, 죽었는지 확인하기?
        {
            _player.UpdateGauage();
            _currentActiveMonster.UpdateGauage();

            if (_player._canAttack)
            {
                int playerDmg = _player.Attack(_currentActiveMonster);
                _currentActiveMonster.Hit(playerDmg);
            }
            if (_currentActiveMonster._canAttack)
            {
                int monsterDmg = _currentActiveMonster.Attack(_player);
                _player.Hit(monsterDmg);
            }
            CheckState();
        }

        public void SpawnMonster()
        {
            int monsterRandom = rand.Next(0, _monster.Length);

            if (_currentActiveMonster != null && _currentActiveMonster._isAlive)      // 살아있다면 스킵
            {
                return;
            }

            // 몬스터 스폰 시키는 메서드
            if (_round % 5 == 0)            // 5라운드마다 보스가 소환
            {
                _currentActiveMonster = _boss;
            }
            else
            {
                _currentActiveMonster = _monster[monsterRandom];
            }
        }

        public void CheckState()    // Unit들이 죽었는지 확인 / Player가 죽으면 게임종료, 몬스터가 죽으면 다음 몬스터 소환
        {
            if (!_player._isAlive)
            {
                _gameState = GameState.GameOver;
                return;
            }

            if (!_currentActiveMonster._isAlive)
            {
                _round++;
                _player.AddKill();
                _gameState = GameState.LevelUp;
                return;
            }

            
        }

        public void LevelUpSelect()                   // 레벨업시 선택지 출력
        {
            int statValue;
            _selector.SelectEffect(_player, out _statType, out statValue);
            _player.UpdateStats(_statType, statValue);
            _gameState = GameState.Playing;
        }

    }

}

