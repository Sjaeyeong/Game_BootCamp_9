namespace MiniProject
{
    enum GameState
    {
        Playing,        // 전투 중
        LevelUp,        // 레벨 업 (선택 중)
        GameOver        // 게임 오버
    }

    enum LevelUP
    {
        AttackPower,    // 공격력 업
        AttackSpeed,    // 공격속도 업
        Defense,        // 방어력 업
        HPRegen         // 즉시 체력 회복
    }

    internal class MiniProject
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            gameManager.Play();
        }
    }
}
