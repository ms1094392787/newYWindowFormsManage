
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Integration
//  类名：IntegrationWindow
//	作者：ms
//	注释：
//  创建时间：2023/1/1 16:29:20
//*******************************************************
using MsssWindowsManage.Dialog;
using MsssWindowsManage.Integration.Model;
using MsssWindowsManage.Model.WindowManageModels;
using MsssWindowsManage.Provider;
using MsssWindowsManage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MsssWindowsManage.Integration
{
    public class IntegrationWindow : IntegrationBase
    {
        private void ExecuteMin(ContentModel param)
        {
            WindowWin32Helper.ShowWindow(param.Window.WindowHandle, (int)Win32APIWindowStateEnum.SW_SHOWMINIMIZED);
        }

        private void ExecuteNormal(ContentModel param)
        {
            WindowWin32Helper.ShowWindow(param.Window.WindowHandle, (int)param.Window.WindowState);
        }

        private BitmapImage GetWindowShotCut(IntPtr wind)
        {
            var image = WindowScreenshotWin32Helper.GetShotCutImage(wind);
            var bitmapImage = BitmapConverterHelper.ConvertToBitmapImage(image);
            return bitmapImage;
        }

        public override ContentModel Load(object param = null)
        {
            ContentModel model = new ContentModel();
            model.ContentType = Enum.ContentTypeEnum.Window;
            var winModel = new WindowModel();
            winModel.WindowHandle = WindowWin32Helper.WindowFromCursor();
            winModel.WindowState = WindowWin32Helper.GetWindowState(winModel.WindowHandle);
            model.Window = winModel;
            return model;
        }

        public override ListBoxItemModel Converter(ContentModel param)
        {
            ListBoxItemModel model = new ListBoxItemModel();
            model.WindowHandle = param.Window.WindowHandle;

            //获取窗口名称
            var lpString = new StringBuilder(512);
            WindowWin32Helper.GetWindowText(param.Window.WindowHandle, lpString, lpString.Capacity);
            model.WindowTitle = lpString.ToString();            
            model.ImgSource = GetWindowShotCut(model.WindowHandle);
            model.ItemType = Enum.ContentTypeEnum.Window;
            model.Tag = param;
            return model;
        }

        public override ListBoxItemModel Execute(ContentModel param)
        {            
            var curState = WindowWin32Helper.GetWindowState(param.Window.WindowHandle);
            switch (curState)
            {
                case Win32APIWindowStateEnum.SW_SHOWMINIMIZED:
                    ExecuteNormal(param);
                    break;
                case Win32APIWindowStateEnum.SW_NORMAL:                    
                case Win32APIWindowStateEnum.SW_SHOWMAXIMIZED:
                    param.Window.WindowState = curState;
                    ExecuteMin(param);
                    break;
            }
            return Converter(param);
        }
    }
}
