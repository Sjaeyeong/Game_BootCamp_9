using System;
using System.Drawing;

namespace MiniProject
{
    public enum GameState
    {
        Playing,        // 전투 중
        LevelUp,        // 레벨 업 (선택 중)
        GameOver,        // 게임 오버
        //MainMenu ?
    }

    public enum StatType
    {
        AttackPower,    // 공격력 업
        AttackSpeed,    // 공격속도 업
        Defense,        // 방어력 업
        HPRegen         // 즉시 체력 회복
    }

    public class MiniProject
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();                                    // 화면 초기화
            Console.CursorVisible = false;                      // 커서 숨기기

            #region 배경 미리 출력
            PngDecoder decoder = new PngDecoder();
            PixelImage backGround = decoder.ReadPNG(@"Sprites\Background.png");
            PixelImage aa = decoder.ReadPNG(@"Sprites\HappySlime1.png");
            SpriteFrame back = backGround.ToSpriteFrame();
            SpriteFrame a = aa.ToSpriteFrame();
            FrameBuffer buf = new FrameBuffer(Console.WindowWidth, Console.WindowHeight);
            buf.Clear();
            RenderManager.Draw(back);
            RenderManager.Draw(a);
            #endregion

            //GameManager gameManager = new GameManager();

            //gameManager.Play();



        }
    }
}
