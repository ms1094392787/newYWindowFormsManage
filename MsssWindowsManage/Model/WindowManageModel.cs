
//*******************************************************
//  CLR版本：4.0.30319.42000
//	命名空间：MsssWindowsManage.Model
//  类名：WindowManageModel
//	作者：ms
//	注释：
//  创建时间：2023/1/1 11:54:00
//*******************************************************
using CommunityToolkit.Mvvm.ComponentModel;
using MsssWindowsManage.Model.WindowManageModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsssWindowsManage.Model
{
    public partial class WindowManageModel:ObservableObject
    {
        
        private ObservableCollection<ListBoxItemModel> dataSource = new ObservableCollection<ListBoxItemModel>();

        public ObservableCollection<ListBoxItemModel> DataSource
        {
            get { return dataSource; }
            set { dataSource = value; OnPropertyChanged(nameof(DataSource)); }
        }


    }
}
