using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
namespace ZCP.cc
{
    /// <summary>
    /// 截屏
    /// </summary>
    public class ScreenCut
    {
        public static Mat PrtSrc()
        {
            Bitmap memory = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(memory);
            g.CopyFromScreen(0, 0, 0, 0, memory.Size);
            //Clipboard.SetImage(memory);
            Mat mat= Bitmap2Mat(memory);
            //GC.Collect();
            return mat;
        }
        public static Mat Bitmap2Mat(Bitmap bitmap)
        {
            bitmap.Save(Config.GetCacheImgPath());
            return new Mat(Config.GetCacheImgPath(), ImreadModes.Color);
        }
    }
}
