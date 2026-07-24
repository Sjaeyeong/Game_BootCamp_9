using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.InteropServices;

namespace MiniProject
{
    public enum SFX
    {

    }

    public class AudioManager
    {
        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string? pszSound, IntPtr hmod, uint fdwSound);

        private const uint SND_ASYNC = 0x0001;  // 비동기 재생
        private const uint SND_NODEFAULT = 0x0002;  // 비프음 제거
        private const uint SND_LOOP = 0x0008;   // 루프
        private const uint SND_FILENAME = 0x00020000;   // 파일 이름으로 재생

        public void PlayBGM(GameState state)
        {
            StopBGM();

            bool result = PlaySound
                (
                    $@"Sound\{state}",
                    IntPtr.Zero,
                    SND_FILENAME | SND_ASYNC | SND_LOOP | SND_NODEFAULT
                );

        }

        public void PlaySFX(string sfxFile)
        {
            bool result = PlaySound
                (
                    @$"Sound\{sfxFile}",
                    IntPtr.Zero,
                    SND_FILENAME | SND_ASYNC | SND_NODEFAULT
                );
        }

        public void StopBGM()
        {
            PlaySound(null, IntPtr.Zero, 0);
            Console.WriteLine("[BGM] 정지");
        }


    }
}
