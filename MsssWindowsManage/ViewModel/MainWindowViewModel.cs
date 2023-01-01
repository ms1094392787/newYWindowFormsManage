
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.ViewModel
//  类名：MainWindowViewModel
//	作者：ms
//	注释：
//  创建时间：2023/1/1 11:40:05
//*******************************************************
using CommunityToolkit.Mvvm.ComponentModel;
using MsssWindowsManage.Provider;
using MsssWindowsManage.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MsssWindowsManage.ViewModel
{
    [ObservableObject]
    public partial class MainWindowViewModel:ObservableObject
    {
        
        private WindowManageViewModel contentDataModel = new WindowManageViewModel();

        public WindowManageViewModel ContentDataModel
        {
            get { return contentDataModel; }
            set { contentDataModel = value; OnPropertyChanged(nameof(ContentDataModel)); }
        }


        private MainWindowPro pro = new MainWindowPro();
        private MainDirFilePro dirPro = new MainDirFilePro();
        #region 界面事件
        public void GatherMouseDown(object sender, MouseButtonEventArgs e)
        {
            pro.UpdateCursor();
        }

        public void GatherMouseUp(object sender, MouseButtonEventArgs e)
        {
            pro.ResetCursor();
           
            var model = pro.GetMousePointWindow();
            if (model== null)
            {
                return;
            }
            ContentDataModel.DataModel.DataSource.Add(model);
        }

        public void FileDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetDataPresent(DataFormats.FileDrop);
            var l = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var item in l)
            {
               var model = dirPro.GetFile(item);
                if (model == null)
                {
                    return;
                }
                ContentDataModel.DataModel.DataSource.Add(model);
            }
        }
        #endregion
    }
}
