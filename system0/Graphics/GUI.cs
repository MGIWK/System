using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system0.Graphics
{
    public static class GUI
    {
        public static int ScreenSizeX = 1920, ScreenSizeY = 1080;
        public static SVGAIICanvas MainCanvas;
        public static Bitmap Wallpaper, Cursor;

        public static void Update()
        {
            MainCanvas.DrawImage(Wallpaper, 0, 0);
            MainCanvas.DrawImage(Cursor, (int)MouseManager.X, (int)MouseManager.Y);
            MainCanvas.Display();
        }

        public static void StartGUI()
        {
            MainCanvas = new SVGAIICanvas(new Mode((uint)ScreenSizeX, (uint)ScreenSizeY, ColorDepth.ColorDepth32));
            MouseManager.ScreenWidth = (uint)ScreenSizeX;
            MouseManager.ScreenHeight = (uint)ScreenSizeY;
            MouseManager.X = (uint)ScreenSizeX/2;
            MouseManager.Y = (uint)ScreenSizeY / 2;
        }
    }
}
