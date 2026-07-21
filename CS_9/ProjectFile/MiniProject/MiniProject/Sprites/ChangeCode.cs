using System;
using System.Drawing; // 빨간 줄이 뜨면 'System.Drawing.Common' NuGet 패키지 설치 필요!

namespace MiniProject
{
    class ChangeCode
    {
        public static void DrawDotImage()
        {
            // 콘솔 창 기호 깨짐 방지
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                // 이미지 파일 불러오기 (Sprites 폴더 경로 포함)
                using (Bitmap bmp = new Bitmap("Sprites\\ironcladNoBack1.png"))
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color pixelColor = bmp.GetPixel(x, y);

                            // 투명한 픽셀은 공백으로 패스
                            if (pixelColor.A == 0)
                            {
                                Console.Write("  ");
                                continue;
                            }

                            // 픽셀 색상에 맞춰 콘솔 글자색 바꾸기
                            Console.ForegroundColor = GetClosestConsoleColor(pixelColor);

                            // 픽셀 하나를 네모 기호로 채우기
                            Console.Write("██");
                        }
                        Console.WriteLine(); // 줄바꿈
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"이미지 로드 실패: {ex.Message}");
            }

            Console.ResetColor();
        }

        // 간단한 콘솔 색상 매칭 메서드
        private static ConsoleColor GetClosestConsoleColor(Color pixelColor)
        {
            ConsoleColor closestColor = ConsoleColor.Black;
            double minDistance = double.MaxValue;

            // 콘솔이 지원하는 16가지 색상의 실제 RGB 값 정의
            var consoleColors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));

            foreach (var color in consoleColors)
            {
                Color c = GetRgbFromConsoleColor(color);

                // 3차원 공간에서의 두 색상 간의 거리 계산 (유클리드 거리)
                double distance = Math.Pow(pixelColor.R - c.R, 2) +
                                  Math.Pow(pixelColor.G - c.G, 2) +
                                  Math.Pow(pixelColor.B - c.B, 2);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestColor = color;
                }
            }

            return closestColor;
        }

        // 콘솔 색상 상수를 실제 RGB 객체로 변환해주는 맵핑 함수
        private static Color GetRgbFromConsoleColor(ConsoleColor consoleColor)
        {
            return consoleColor switch
            {
                ConsoleColor.Black => Color.FromArgb(0, 0, 0),
                ConsoleColor.DarkBlue => Color.FromArgb(0, 0, 128),
                ConsoleColor.DarkGreen => Color.FromArgb(0, 128, 0),
                ConsoleColor.DarkCyan => Color.FromArgb(0, 128, 128),
                ConsoleColor.DarkRed => Color.FromArgb(128, 0, 0),
                ConsoleColor.DarkMagenta => Color.FromArgb(128, 0, 128),
                ConsoleColor.DarkYellow => Color.FromArgb(128, 128, 0),
                ConsoleColor.Gray => Color.FromArgb(192, 192, 192),
                ConsoleColor.DarkGray => Color.FromArgb(128, 128, 128),
                ConsoleColor.Blue => Color.FromArgb(0, 0, 255),
                ConsoleColor.Green => Color.FromArgb(0, 255, 0),
                ConsoleColor.Cyan => Color.FromArgb(0, 255, 255),
                ConsoleColor.Red => Color.FromArgb(255, 0, 0),
                ConsoleColor.Magenta => Color.FromArgb(255, 0, 255),
                ConsoleColor.Yellow => Color.FromArgb(255, 255, 0),
                ConsoleColor.White => Color.FromArgb(255, 255, 255),
                _ => Color.Black
            };
        }
    }
}