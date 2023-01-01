
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Integration.Model
//  类名：ContentModel
//	作者：ms
//	注释：
//  创建时间：2023/1/1 16:18:13
//*******************************************************
using MsssWindowsManage.Integration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsssWindowsManage.Integration.Model
{
    public class ContentModel
    {
        public ContentTypeEnum ContentType { get; set; } = ContentTypeEnum.Window;

        public string FilePath { get; set; }

        public WindowModel Window { get; set; }
    }
}
