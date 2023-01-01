
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Service
//  类名：WindowWin32Helper
//	作者：ms
//	注释：
//  创建时间：2023/1/1 14:17:22
//*******************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace MsssWindowsManage.Service
{
    public class WindowWin32Helper
    {
        /// <summary>
        /// 操作窗口状态
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        
        /// <summary>
        /// 获取鼠标坐标
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetCursorPos")]
        public static extern bool GetCursorPos(out Point pt);

        /// <summary>
        /// 获取指定位置所在的窗口句柄
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        public static extern IntPtr WindowFromPoint(Point pt);

        /// <summary>
        /// 获取鼠标位置的窗体
        /// </summary>
        /// <returns></returns>
        public static IntPtr WindowFromCursor()
        {
            if (GetCursorPos(out Point pt))
            {
                return WindowFromPoint(pt);
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// 移动窗体、调整窗体大小
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="X">新位置</param>
        /// <param name="Y">新位置</param>
        /// <param name="nWidth">新大小</param>
        /// <param name="nHeight">新大小</param>
        /// <param name="bRepaint">是否重新渲染客户区，推荐始终为true</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint = true);

        /// <summary>
        /// 获取窗口标题
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lptrString"></param>
        /// <param name="nMaxCount"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lptrString, int nMaxCount);

        /// <summary>
        /// 当前窗口是否最小化
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);
        /// <summary>
        /// 当前窗口是否最大化
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsZoomed(IntPtr hWnd);
        /// <summary>
        /// 判断窗口是否可见
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// 获取当前窗口句柄状态
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static Win32APIWindowStateEnum GetWindowState(IntPtr hWnd)
        {
            var isMin = IsIconic(hWnd);
            var isMax = IsZoomed(hWnd);
            if (isMin)
            {
                return Win32APIWindowStateEnum.SW_SHOWMINIMIZED;
            }
            else if (isMax)
            {
                return Win32APIWindowStateEnum.SW_SHOWMAXIMIZED;
            }
            else if (!isMin&&!isMax)
            {
                return Win32APIWindowStateEnum.SW_NORMAL;
            }

            return Win32APIWindowStateEnum.SW_NORMAL;
        }
    }
}
