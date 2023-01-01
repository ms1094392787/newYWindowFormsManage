
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Service
//  类名：CursorWin32Helper
//	作者：ms
//	注释：
//  创建时间：2023/1/1 12:31:14
//*******************************************************
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace MsssWindowsManage.Service
{
    public struct IconInfo
    {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }

    public class CursorWin32Helper
    {
        /// <summary>
        /// 光标资源加载函数
        /// </summary>
        /// <param name="fileName">加载路径下的.cur文件</param>
        /// <returns></returns>
        [DllImport("User32.DLL")]
        public static extern IntPtr LoadCursorFromFile(string fileName);
        /// <summary>
        /// 设置系统指针函数（用hcur替换id定义的光标）
        /// </summary>
        /// <param name="hcur"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("User32.DLL")]
        public static extern bool SetSystemCursor(IntPtr hcur, uint id);
        
        /// <summary>
        /// 查询或设置的系统级参数函数
        /// </summary>
        /// <param name="uiAction"></param>
        /// <param name="uiParam"></param>
        /// <param name="pvParam"></param>
        /// <param name="fWinIni"></param>
        /// <returns></returns>
        [DllImport("User32.DLL")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

    }
}
