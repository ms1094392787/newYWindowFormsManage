
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Integration.Model
//  类名：WindowModel
//	作者：ms
//	注释：
//  创建时间：2023/1/1 16:19:36
//*******************************************************
using MsssWindowsManage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsssWindowsManage.Integration.Model
{
    public class WindowModel
    {
        public IntPtr WindowHandle { get; set; }

        public Win32APIWindowStateEnum WindowState { get; set; }
    }
}
