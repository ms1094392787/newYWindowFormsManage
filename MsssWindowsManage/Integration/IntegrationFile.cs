
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Integration
//  类名：IntegrationFile
//	作者：ms
//	注释：
//  创建时间：2023/1/1 16:29:36
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
    public class IntegrationFile: IntegrationBase
    {
        private ImageSource GetImage()
        {
            return new BitmapImage(new Uri("pack://application:,,,/FileResource/file.png"));
        }
        public override ContentModel Load(object param = null)
        {
            ContentModel model = new ContentModel();
            model.ContentType = Enum.ContentTypeEnum.File;
            model.FilePath = param.ToString();
            return model;
        }

        public override ListBoxItemModel Converter(ContentModel param)
        {
            ListBoxItemModel model = new ListBoxItemModel();
            model.WindowTitle = param.FilePath;
            model.ItemType = Enum.ContentTypeEnum.File;
            model.ImgSource = GetImage();
            model.Tag = param;
            return model;
        }

        public override ListBoxItemModel Execute(ContentModel param)
        {
            System.Diagnostics.Process.Start(param.FilePath);
            return Converter(param);
        }
    }
}
