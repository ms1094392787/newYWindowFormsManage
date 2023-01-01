
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Integration
//  类名：IIntegration
//	作者：ms
//	注释：
//  创建时间：2023/1/1 16:06:50
//*******************************************************
using MsssWindowsManage.Integration.Model;
using MsssWindowsManage.Model.WindowManageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsssWindowsManage.Integration
{
    public interface IIntegration
    {
        ContentModel Load (object param = null);

        ListBoxItemModel Execute(ContentModel param);

        ListBoxItemModel Converter(ContentModel param);
    }
}
