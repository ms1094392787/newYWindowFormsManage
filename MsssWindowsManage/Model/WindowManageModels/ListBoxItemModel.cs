
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Model
//  类名：WindowManageModel
//	作者：ms
//	注释：
//  创建时间：2023/1/1 11:44:22
//*******************************************************
using CommunityToolkit.Mvvm.ComponentModel;
using MsssWindowsManage.Integration.Enum;
using MsssWindowsManage.Integration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MsssWindowsManage.Model.WindowManageModels
{
    [INotifyPropertyChanged]
    public partial class ListBoxItemModel:ObservableObject
    {
        private string windowTitle;

        public string WindowTitle
        {
            get { return windowTitle; }
            set { windowTitle = value; OnPropertyChanged(nameof(WindowTitle)); }
        }

        private IntPtr windowHandle;
        public IntPtr WindowHandle
        {
            get { return windowHandle; }
            set { windowHandle = value; OnPropertyChanged(nameof(WindowHandle)); }
        }

        private string windowRemark;
        public string WindowRemark
        {
            get { return windowRemark; }
            set { windowRemark = value; OnPropertyChanged(nameof(WindowRemark)); }
        }

        private ImageSource imgSource;
        public ImageSource ImgSource
        {
            get { return imgSource; }
            set { imgSource = value; OnPropertyChanged(nameof(ImgSource)); }
        }



        public ContentTypeEnum ItemType { get; set; }

        public ContentModel Tag { get; set; }
    }
}
