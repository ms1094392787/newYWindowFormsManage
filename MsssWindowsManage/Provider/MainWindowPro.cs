
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Provider
//  类名：MainWindowPro
//	作者：ms
//	注释：
//  创建时间：2023/1/1 12:35:04
//*******************************************************
using MsssWindowsManage.Dialog;
using MsssWindowsManage.Integration;
using MsssWindowsManage.Integration.Enum;
using MsssWindowsManage.Model.WindowManageModels;
using MsssWindowsManage.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsssWindowsManage.Provider
{
    public class MainWindowPro
    {
        #region 光标操作
        public const uint OCR_NORMAL = 32512;
        public const uint OCR_IBEAM = 32513;
        public const uint SPI_SETCURSORS = 87;
        public const uint SPIF_SENDWININICHANGE = 2;
        public void UpdateCursor()
        {
            IntPtr hcur_click = CursorWin32Helper.LoadCursorFromFile("FileResource\\cursorFile.cur");
            CursorWin32Helper.SetSystemCursor(hcur_click, OCR_NORMAL);
            CursorWin32Helper.SetSystemCursor(hcur_click, OCR_IBEAM);
            //设置移动
            //cur = LoadCursorFromFile("my.cur");
            //SetSystemCursor(cur, OCR_SIZEALL);
            //设置不可用
            //cur = LoadCursorFromFile("my.cur");
            //SetSystemCursor(cur, OCR_NO);
            //设置超链接
            //cur = LoadCursorFromFile("my.cur");
            //SetSystemCursor(cur, OCR_HAND);
        }

        public void ResetCursor()
        {
            CursorWin32Helper.SystemParametersInfo(SPI_SETCURSORS, SPIF_SENDWININICHANGE, IntPtr.Zero, SPIF_SENDWININICHANGE);
        }
        #endregion

        #region 窗口操作
        public ListBoxItemModel GetMousePointWindow()
        {
            IIntegration integ = IntegrationBase.GetProviderInstance(ContentTypeEnum.Window);
            var model = integ.Converter(integ.Load());

            //输入说明
            WindowRemarkDialog dia = new WindowRemarkDialog();
            dia.SetTitle(model.WindowTitle);
            if (dia.ShowDialog() == true)
            {
                model.WindowRemark = dia.RemarkName;
            }
            else
            {
                return null;
            }

            integ.Execute(model.Tag);
            return model;
        }

        #endregion

        #region 文件操作

        #endregion
    }
}
