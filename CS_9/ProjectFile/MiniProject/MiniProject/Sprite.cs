using System;
using System.Drawing;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace MiniProject
{
    /// <summary>
    /// 콘솔 화면 출력을 전담하는 클래스
    /// 복잡한 버퍼 생성이나 위치 설정을 미리 해두고, 어디서든 간편하게 출력할 수 있게 도와줌.
    /// _buffer.Clear();는 필요한 부분에 직접 설정해줘야 함. (GameManager.Play()의 반복문에 꼭!!!)
    /// </summary>
    public static class RenderManager
    {
        // 콘솔 창 크기로 버퍼와 렌더러 생성
        private static FrameBuffer _buffer = new FrameBuffer(Console.WindowWidth, Console.WindowHeight);
        private static ConsoleRenderer _renderer = new ConsoleRenderer();

        // 스프라이트 하나만 넣으면 10, 0 위치에 그려줌
        public static void Draw(SpriteFrame sprite)
        {
            //_buffer.Clear();
            _buffer.DrawSprite(10, 0, sprite); // 위치 10, 0 고정 → 모든 그림들의 크기를 배경 크기에 맞춰 위치 시켰음
            _renderer.EndFrame(_buffer);
        }
    }

    public class RgbaPixel          // R, G, B, Alpha 값 저장 클래스
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public RgbaPixel(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }

    public class PngDecoder         // PNG파일의 비트맵을 불러와 각 좌표를 1차원배열로 바꾸어 각 색(R,G,B,A)을 저장 후 PixelImage로 보냄
    {
        public PixelImage ReadPNG(string filePath)
        {
            using var bitmap = new Bitmap(filePath);

            var pixels = new RgbaPixel[bitmap.Width * bitmap.Height];

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    pixels[(y * bitmap.Width) + x] = new RgbaPixel(color.R, color.G, color.B, color.A);
                }
            }
            return new PixelImage(bitmap.Width, bitmap.Height, pixels);
        }

    }

    public class PixelImage     // PngDecoder로 읽은 값들의 배열을 클래스로 저장
    {
        public int _width;
        public int _height;
        public RgbaPixel[] _pixels;

        public RgbaPixel this[int x, int y] => _pixels[(y * _width) + x];       // _pixels에 저장된 데이터를 밖에서 image[x, y]인 2차원 좌표로 뽑아내게 해줌

        public PixelImage(int width, int height, RgbaPixel[] pixels)
        {
            _width = width;
            _height = height;
            _pixels = pixels;
        }

        public SpriteFrame ToSpriteFrame(byte alphaThreshold = 32)  // alphaThreshold를 기준 알파값으로 두고 기준값 보다 알파값이 낮은 pixel 칸은 null로 지정, 나머지는 각 pixel의 색으로 지정
        {
            int frameWidth = _width;
            int frameHeight = (_height + 1) / 2;
            var cells = new SpriteCell[frameWidth * frameHeight];
            

            for (int cellY = 0; cellY < frameHeight; cellY++)
            {
                for (int x = 0; x < frameWidth; x++)
                {
                    int topY = cellY * 2;
                    int bottomY = topY + 1;

                    RgbaPixel top = this[x, topY];
                    RgbaPixel? bottom = null;
                    RgbaPixel clearPixel = new RgbaPixel(0, 0, 0, 0);
                    if (bottomY < _height)
                    {
                        bottom = this[x, bottomY];
                    }

                    bool topVisible = top.A >= alphaThreshold;
                    bool bottomVisible = bottom != null && bottom.A >= alphaThreshold;

                    if (topVisible && bottomVisible)
                    {
                        cells[(cellY * frameWidth) + x] = new SpriteCell('▀', top, bottom!);
                    }
                    else if (topVisible)
                        cells[(cellY * frameWidth) + x] = new SpriteCell('▀', top, clearPixel);
                    else if (bottomVisible)
                        cells[(cellY * frameWidth) + x] = new SpriteCell('▄', bottom!, clearPixel);
                }
            }

            return new SpriteFrame(frameWidth, frameHeight, cells);
        }
    }

    public class SpriteCell
    {
        public char _symbol;
        public RgbaPixel _foreground;
        public RgbaPixel _background;

        public SpriteCell(char symbol, RgbaPixel foreground, RgbaPixel background)
        {
            _symbol = symbol;
            _foreground = foreground;
            _background = background;
        }
    }

    public class SpriteFrame
    {
        public int _width;
        public int _height;
        public SpriteCell[] _cells;

        public SpriteCell? this[int x, int y] => _cells[(y * _width) + x];      // _cells에 저장된 데이터를 밖에서 spriteFrame[x, y] 2차원 좌표로 뽑아내게 해줌

        public SpriteFrame(int width, int height, SpriteCell[] cells)
        {
            _width = width;
            _height = height;
            _cells = cells;
        }
    }

    public class RenderCell
    {
        public char _symbol;
        public RgbaPixel _foreground;
        public RgbaPixel _background;

        public RenderCell(char symbol, RgbaPixel foreground, RgbaPixel background)
        {
            _symbol = symbol;
            _foreground = foreground;
            _background = background;
        }

        //public static RenderCell Empty(RgbaPixel clearColor)
        //{
        //    return new RenderCell(' ', clearColor, clearColor);
        //}
    }

    // ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    public class FrameBuffer            // 여기부터는 구현에 어려움을 느껴 동기와 ai에게 피드백을 받으면서 구현
    {
        public int _width;
        public int _height;

        private RenderCell?[] _cells;

        public FrameBuffer(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new RenderCell?[width * height];
        }

        private int GetIndex(int x, int y) => (y * _width) + x;

        public RenderCell? this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= _width || y < 0 || y >= _height) return null;
                return _cells[GetIndex(x, y)];
            }
            set
            {
                if (x >= 0 && x < _width && y >= 0 && y < _height)
                    _cells[GetIndex(x, y)] = value;
            }
        }
        public void Clear()
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i] = null;
            }
        }

        public void DrawSprite(int startX, int startY, SpriteFrame sprite)
        {
            for (int sy = 0; sy < sprite._height; sy++)
            {
                int targetY = startY + sy;
                if (targetY < 0 || targetY >= _height) continue;

                for (int sx = 0; sx < sprite._width; sx++)
                {
                    int targetX = startX + sx;
                    if (targetX < 0 || targetX >= _width) continue;

                    SpriteCell? cell = sprite[sx, sy];
                    if (cell == null) continue;

                    // 이미 프레임버퍼에 그려져 있던 밑배경 셀
                    RenderCell? existing = this[targetX, targetY];

                    RgbaPixel fg = cell._foreground;
                    RgbaPixel bg = cell._background;

                    // 전경/배경 픽셀의 알파값이 0(투명)이면 밑에 깔린 기존 배경색으로 대체
                    if (fg.A == 0 && existing != null)
                    {
                        fg = existing._foreground;
                    }

                    if (bg.A == 0 && existing != null)
                    {
                        // 캐릭터의 하단/상단 투명 영역에 기존 배경색을 입혀 검은 박스를 방지
                        bg = existing._background;
                    }

                    //this[targetX, targetY] = new RenderCell(cell._symbol, cell._foreground, cell._background);
                    this[targetX, targetY] = new RenderCell(cell._symbol, fg, bg);
                }
            }
        }
    }

    public class ConsoleRenderer
    {
        private readonly TextWriter _output = Console.Out;
        private RgbaPixel? _lastFg = null;
        private RgbaPixel? _lastBg = null;

        public void EndFrame(FrameBuffer buffer)
        {
            var builder = new StringBuilder();

            builder.Append("\u001b[H");

            _lastFg = null;
            _lastBg = null;

            for (int y = 0; y < buffer._height; y++)
            {
                for (int x = 0; x < buffer._width; x++)
                {
                    RenderCell? cell = buffer[x, y];

                    if (cell == null)
                    {
                        if (_lastBg != null)
                        {
                            builder.Append("\u001b[49m");
                            _lastBg = null;
                        }
                        _lastFg = null;

                        builder.Append(' ');
                        continue;
                    }

                    if (!IsSameColor(_lastFg, cell._foreground))
                    {
                        builder.Append($"\u001b[38;2;{cell._foreground.R};{cell._foreground.G};{cell._foreground.B}m");
                        _lastFg = cell._foreground;
                    }

                    if (cell._background == null || cell._background.A == 0)
                    {
                        if (_lastBg != null)
                        {
                            builder.Append("\u001b[49m");
                            _lastBg = null;
                        }
                    }
                    else if (!IsSameColor(_lastBg, cell._background))
                    {
                        builder.Append($"\u001b[48;2;{cell._background.R};{cell._background.G};{cell._background.B}m");
                        _lastBg = cell._background;
                    }

                    builder.Append(cell._symbol);
                }

                builder.AppendLine();
            }

            builder.Append("\u001b[0m");

            _output.Write(builder.ToString());
            _output.Flush();
        }

        private bool IsSameColor(RgbaPixel? a, RgbaPixel? b)
        {
            if (a == null || b == null) return false;
            return a.R == b.R && a.G == b.G && a.B == b.B;
        }
    }
}