
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Service
//  类名：Win32APIWindowStateEnum
//	作者：ms
//	注释：
//  创建时间：2023/1/1 16:21:09
//*******************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsssWindowsManage.Service
{
    public enum Win32APIWindowStateEnum
    {
        SW_HIDE = 0,
        SW_NORMAL,
        SW_SHOWMINIMIZED,
        SW_SHOWMAXIMIZED,
        SW_SHOWNOACTIVATE
    }
}
