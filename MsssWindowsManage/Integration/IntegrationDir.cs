
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Integration
//  类名：IntegrationDir
//	作者：ms
//	注释：
//  创建时间：2023/1/1 22:04:18
//*******************************************************
using MsssWindowsManage.Integration.Model;
using MsssWindowsManage.Model.WindowManageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MsssWindowsManage.Integration
{
    public class IntegrationDir: IntegrationFile
    {
        private ImageSource GetImage()
        {
            return new BitmapImage(new Uri("pack://application:,,,/FileResource/dir.png"));
        }
        public override ContentModel Load(object param = null)
        {
            var model = base.Load(param);
            model.ContentType = Enum.ContentTypeEnum.Dir;
            return model;
        }

        public override ListBoxItemModel Converter(ContentModel param)
        {
            var model = base.Converter(param);
            model.ItemType = Enum.ContentTypeEnum.Dir;
            model.ImgSource = GetImage();
            return model;
        }
    }
}
