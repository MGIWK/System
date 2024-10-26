using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Graphics;
using system0.Graphics;

namespace system0.system
{
    public static class Boot
    {
        public static void onBoot()
        {
            Kernel.RunGui = true;
            GUI.Wallpaper = new Bitmap(Resources.Files.system0BackgroundRaw);
            GUI.Cursor = new Bitmap(Resources.Files.system0CursorRaw);
            GUI.StartGUI();
        }
    }
}
