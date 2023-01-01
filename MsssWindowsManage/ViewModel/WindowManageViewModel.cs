
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.ViewModel
//  类名：WindowManageViewModel
//	作者：ms
//	注释：
//  创建时间：2023/1/1 11:40:18
//*******************************************************
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MsssWindowsManage.Integration;
using MsssWindowsManage.Model;
using MsssWindowsManage.Model.WindowManageModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MsssWindowsManage.ViewModel
{

    public partial class WindowManageViewModel : ObservableObject
    {

        public WindowManageModel dataModel = new WindowManageModel();

        public WindowManageModel DataModel
        {
            get { return dataModel; }
            set { dataModel = value; OnPropertyChanged(nameof(DataModel)); }
        }

        #region 事件
        public void Execute(object sender, MouseButtonEventArgs e)
        {
            if ((e.Source as FrameworkElement).DataContext is ListBoxItemModel model)
            {
                IIntegration integ = IntegrationBase.GetProviderInstance(model.Tag.ContentType);
                model = integ.Execute(model.Tag);
            }
        }

        public void DeleteContent(object sender, MouseButtonEventArgs e)
        {
            if ((e.Source as FrameworkElement).DataContext is ListBoxItemModel model)
            {
                this.DataModel.DataSource.Remove(model);
                e.Handled = true;
            }
        }
        #endregion

    }
}
