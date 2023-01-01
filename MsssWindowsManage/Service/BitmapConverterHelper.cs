
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Service
//  类名：BitmapConverterHelper
//	作者：ms
//	注释：
//  创建时间：2023/1/1 16:49:01
//*******************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MsssWindowsManage.Service
{
    public class BitmapConverterHelper
    {
        [DllImport("gdi32")]
         static extern int DeleteObject(IntPtr o);
          public static BitmapSource ConvertToBitMapSource(Bitmap bitmap)
         {
              IntPtr intPtrl = bitmap.GetHbitmap();
              BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(intPtrl,
                  IntPtr.Zero,
                 Int32Rect.Empty,
                 BitmapSizeOptions.FromEmptyOptions());
             DeleteObject(intPtrl);
             return bitmapSource;
         }
         public static BitmapImage ConvertToBitmapImage(Bitmap bitmap)
         {
             using (MemoryStream stream = new MemoryStream())
             {
                 bitmap.Save(stream, ImageFormat.Bmp);
                 stream.Position = 0;
                 BitmapImage result = new BitmapImage();
                 result.BeginInit();
                 result.CacheOption = BitmapCacheOption.OnLoad;
                 result.StreamSource = stream;
                 result.EndInit();
                 result.Freeze();
                 return result;
             }
         }
    }
}
