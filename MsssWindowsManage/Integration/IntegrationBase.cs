
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Integration
//  类名：IntegrationBase
//	作者：ms
//	注释：
//  创建时间：2023/1/1 16:28:11
//*******************************************************
using MsssWindowsManage.Integration.Enum;
using MsssWindowsManage.Integration.Model;
using MsssWindowsManage.Model.WindowManageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsssWindowsManage.Integration
{
    public class IntegrationBase : IIntegration
    {
        static IntegrationFile file = new IntegrationFile();
        static IntegrationDir dir = new IntegrationDir();
        static IntegrationWindow window = new IntegrationWindow();
        public static IIntegration GetProviderInstance(ContentTypeEnum type)
        {
            switch (type)
            {
                case ContentTypeEnum.Window:
                    return window;
                case ContentTypeEnum.File:
                    return file;
                case ContentTypeEnum.Dir:
                    return dir;                    
            }
            return null;
        }

        public virtual ListBoxItemModel Converter(ContentModel param)
        {
            throw new NotImplementedException();
        }

        public virtual ListBoxItemModel Execute(ContentModel param)
        {
            throw new NotImplementedException();
        }

        public virtual ContentModel Load(object param = null)
        {
            throw new NotImplementedException();
        }
    }
}
