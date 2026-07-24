using System.Media;
using System.Runtime.InteropServices;
using static CS_9_Example.Lesson._12._사운드.CSoundPlayer.CSoundManager;

#region System.Runtime.InteropServices
/*
▶ System.Runtime.InteropServices

- C#이 운영체제와 다른 언어 라이브러리를 직접 호출할 수 있게 해주는 네임스페이스
 ㄴ C# 자체는 관리형 언어이지만 필요하면 운영체제의 네이티브 API도 직접 호출할 수 있다.

- 시스템.실행중인 닷넷 환경CLR.서로 다른 시스템간의 상호운용
 ㄴ C# ↔ C/C++ ↔ OS

window multi media
- winmm.dll → 네이티브 코드
 ㄴ C#과 네이티브 코드는 원래 직접 대화가 불가
 ㄴ 그걸 연결해주는 기능이나 도구들이 있다.


◈ d(다이나믹)l(링크)l(라이브러리)

- 동적 링크 라이브러리
 ㄴ 여러 프로그램이 공통으로 사용하는 실행 코드 / 데이터 / 리소스를 모아 놓은 파열
 ㄴ 필요할 때 로드를 한다. → 메모리를 절약 → 특성때문에 프로그램 간 기능 공유에 좋다. (윈도우 운영체제의 핵심 공유 라이브러리 파일)

*/
#endregion

#region 사운드 시스템
/*
▶ 콘솔 사운드

- C#도 다양한 방법을 통해서 사운드 재생 가능
 ㄴ !! 콘솔은 Wav 재생이 안정적!!
 ㄴ mp3 재생도 가능하나 환경 의존성이 있어서 고민 필요

- 그리고 이후 상용 엔젠이나 윈도우 어플리케이션으로 넘어가면 WAV / MP3 사용 자유
 ㄴ WAV : 음질이 좋다. → 무압축 → 리소스에 대한 용량
 ㄴ MP3 : 음질을 선택할 수 있다. → 좀 더 보편적 → 용량이 적으니까

- 유니티
 ㄴ 엔진 내장 오디오 / FMOD / Wwise 등으로 지원을 한다.


1. SoundPlayer

- 정석 C# → 표준 라이브러리 → 제어 한계가 명확함                     !!비추
 ㄴ 기능이 단순해서 다양한 포맷 지원 / 볼륨 / 다중 채널 등 사운드 할 때 사용할 수 있는 기능들이 없다.
 ㄴ 사용이 쉽고 → 별도 API 호출이 없다.
 ㄴ 내부적으로 winmm 같은 네이티브 API 사용

2. 네이티브 API                                                      !!강추
 ㄴ 엔진 없어도 OS 자원에 접근 가능
 ㄴ C# → OS 레벨 기능을 직접 호출 가능
 ㄴ 엔전에서 라이브러리화 되어 있는 경우 선호

3. mcisendString                                                     !!추천
 ㄴ MP3 / WAV 재생 가능
 ㄴ 근데 코텍 의존성이 강함

4. NAudio → MP3 / WAV 다 된다. → 제어도 강력 → Nuget 필요            !!추천
 ㄴ 실무 / 제어가 강력한 점 / 외부 라이브러리
 ㄴ C# 네이티브 환경
 ㄴ 외부 라이브러리 이고 제어가 강력하다는 점 → 타입이 늘어나고 NAudio 관련 클래스가 많이 추가 된다.
 ㄴ 좋긴한데 과함 → 사운드 개념 보다는 라이브러리 사용법을 따라가게 된다.

5. Windows Media Player                                             !!완전 비추
 ㄴ WAV / MP3 가능 → 윈도우 자체라서 호환성도 좋다. → 기능도 있을것 다 있음
 ㄴ 컴 객체가 필요한다 → 개념부터 사용까지 많이 무겁다. → 나는 사운드를 쓰고 싶은데... OS


▶ 리소스 관리

1. 기본적으로 사운드 파일은 실행 파일 기준 상대 경로로 탐색된다.
 ㄴ 사운드 파일을 실행 파일과 같은 폴더에 두는 것 (exe 파일)
  ㄴ bin 폴더 → debug → .net → .exe

2. 프로젝트에 포함 시킬 수 있다.
 ㄴ 누락이 안됟기 때문에 편안은 하지만..

※ 코드에서는 그냥 경로에 맞게 사용

● 리소스 관련된 모든 것들..

0. 오타!!!

1. 프로젝트 루트 처리

2. 절대 경로 쓰지 말기
 ㄴ 본인 컴퓨터에서만 동작함    

3. 엔진 습관
 ㄴ Unity : Resources
 ㄴ Unreal : Game/ActorRoot





*/
#endregion

namespace CS_9_Example.Lesson._12._사운드
{
    internal class Example12
    {
        //Soundplayer 
        public static void Main()
        {
            // CSoundPlayer.ExampleFunction_A();
            CSoundPlayer.ExampleFunction_B();
        }

    }

    internal class CSoundPlayer
    {
        //SoundPlayer player;
        //ConsoleKey
        // 이걸 어떻게 알고 쓰지..? → 이걸 여기서 왜 쓰고 있지?
        //if (GetAsynKeyState x 00000001)

        public static void ExampleFunction_A()
        {
            ConsolePrint.Title("사운드 플레이어");

            // 사운드 플레이어는 편의 클래스가 시스템이 아님 → 이런 구조때문에 직접 쓰기가 더욱 망설여 진다.
            //  ㄴ 간단한 재생에는 편하다. / 단순하다.
            SoundPlayer player = new SoundPlayer("Sound/Town.wav");

            // 리소스 → 확인하는 습관이 중요
            Console.Write(Environment.CurrentDirectory);

            Console.WriteLine("배경음 재생");

            // 재생 전에 파일을 먼저 로드
            //  ㄴ 만약 파일을 못 찾으면 여기서 걸린다.
            player.Load();
            player.PlayLooping();

            // 윈도우 전용이기 때문에
            Console.WriteLine("엔터 입력시 정지");
            Console.ReadLine();

            player.Stop();
            Console.WriteLine("사운드 정지");
        }

        // 
        internal class CSoundManager
        {
            // 현재 게임의 어떤 상황인지 표현하기 위한 상태 값
            public enum GameState
            {
                NONE,
                TOWN,
                BATTLE
            }

            // OS API

            // CSoundPlayer → 편의성 ( C# 스타일대로 편의 클래스)
            // CSoundManager → 로우하지만 구조를 알기에 좋음

            /*
            C#에서 구현된 함수 혹은 C#에는 없는 함수다.

            함수 선언 → 실제 구현이 외부 DLL에 존재한다는 의미이다.
             ㄴ 호출 → 실행 흐름은 → C# → 운영체제 → 네이티브 DLL

            PlaySound : 멀티미디어 API 함수중 하나


            - 윈도우 네이밍 규칙

            string pszSound : 파일 경로
            IntPtr hmod     : 사운드 리소스가 들어있는 핸들 안쓸거기때문에 NULL
            uint fdwSound   : 사운드 재생 방식 옵션

            ● 비유

            C# : 전화기 

            winmm.dll : 외부 회사

            DllImport : 전화번호 등록

            extern : 설명서만 있고 실제 일은 다른쪽에서 함

            */

            [DllImport("winmm.dll")]
            private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

            private const uint SND_ASYNC = 0x0001;              // 비동기 재생
            private const uint SND_NODEFAULT = 0x0002;          // 기본 사운드 X → 비프음 제거(경고음)
            private const uint SND_LOOP = 0x0008;               // 반복 재생
            private const uint SND_FILENAME = 0x00020000;       // 파일 이름으로 재생

            //private uint SND_SYNC = 0x0000;                     // 동기
            //private uint SND_MEMORY = 0x0004;                   // 메모리에서 재생

            private GameState _currentState = GameState.NONE;

            // 상태 변경
            public void ChangeState(GameState newState)
            {
                if (_currentState == newState)
                {
                    return;
                }

                // 기존 BGM 정지
                StopBGM();

                _currentState = newState;

                switch (_currentState)
                {
                    case GameState.TOWN:
                        PlayTownBGM();
                        break;
                    case GameState.BATTLE:
                        PlayBasttleBGM();
                        break;
                }
            }

            // 인터페이스 → 추상 클래스

            private void PlayTownBGM()
            {
                bool result = PlaySound
                    (
                    "Sound/Town.wav",
                    IntPtr.Zero,
                    SND_FILENAME | SND_ASYNC | SND_LOOP | SND_NODEFAULT
                    );

                Console.WriteLine($"[BGM] 마을 배경음 재생 ({result})");

            }

            private void PlayBasttleBGM()
            {
                bool result = PlaySound
                    (
                    "Sound/Battle.wav",
                    IntPtr.Zero,
                    SND_FILENAME | SND_ASYNC | SND_LOOP | SND_NODEFAULT
                    );

                Console.WriteLine($"[BGM] 전투 배경음 재생 ({result})");

            }
            public void StopBGM()
            {
                PlaySound(null, IntPtr.Zero, 0);
                Console.WriteLine("[BGM] 정지");
            }

            // SFX

            public void PlayEffect(string effectFile)
            {
                bool result = PlaySound
                    (
                        $"Sound/{effectFile}",
                        IntPtr.Zero,
                        SND_FILENAME | SND_ASYNC | SND_NODEFAULT
                    );

                Console.WriteLine($"[SFX] {effectFile} 재생 ({result})");
            }
        }

        public static void ExampleFunction_B()
        {
            CSoundManager sound = new CSoundManager();

            Console.WriteLine(Environment.CurrentDirectory);

            ConsolePrint.Title("콘솔 사운드");

            while (true)
            {
                ConsolePrint.Line();
                Console.WriteLine("[1] 마을 입장");
                Console.WriteLine("[2] 전투 시작");
                Console.WriteLine("[3] 공격 이펙트");
                Console.WriteLine("[0] 종료");

                string? input = Console.ReadLine();

                if (input == "1")
                {
                    sound.ChangeState(GameState.TOWN);
                }

                if (input == "2")
                {
                    sound.ChangeState(GameState.BATTLE);
                }

                if (input == "3")
                {
                    sound.PlayEffect("Attack.wav");
                }

                if (input == "0")
                {
                    break;
                }

            }

        }

    }
}
