
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Provider
//  类名：MainDirFilePro
//	作者：ms
//	注释：
//  创建时间：2023/1/1 22:14:14
//*******************************************************
using MsssWindowsManage.Dialog;
using MsssWindowsManage.Integration;
using MsssWindowsManage.Integration.Enum;
using MsssWindowsManage.Model.WindowManageModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsssWindowsManage.Provider
{
    public class MainDirFilePro
    {
        private bool IsDir(string path)
        {
            FileInfo fi = new FileInfo(path);
            if ((fi.Attributes & FileAttributes.Directory) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ListBoxItemModel GetFile(string param)
        {
            IIntegration integ = null;
            if (IsDir(param))
            {
                integ = IntegrationBase.GetProviderInstance(ContentTypeEnum.Dir);
            }
            else
            {
                integ = IntegrationBase.GetProviderInstance(ContentTypeEnum.File);
            }
            var model = integ.Converter(integ.Load(param));

            //输入说明
            WindowRemarkDialog dia = new WindowRemarkDialog();
            dia.SetTitleBlock("路径：");
            dia.SetTitle(model.WindowTitle);
            if (dia.ShowDialog() == true)
            {
                model.WindowRemark = dia.RemarkName;
            }
            else
            {
                return null;
            }
            return model;
        }
    }
}
