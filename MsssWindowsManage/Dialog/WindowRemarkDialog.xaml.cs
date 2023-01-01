using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MsssWindowsManage.Dialog
{
    /// <summary>
    /// WindowRemarkDialog.xaml 的交互逻辑
    /// </summary>
    public partial class WindowRemarkDialog : Window
    {
        public WindowRemarkDialog()
        {
            InitializeComponent();
        }

        public void SetTitleBlock(string title)
        {
            titleBlock.Text = title;
        }
        public void SetTitle(string winTitle)
        {
            this.titleBox.Text = winTitle;
            this.remarkBox.Text = winTitle;
        }

        public string RemarkName { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RemarkName = this.remarkBox.Text;
            this.DialogResult = true;
            this.Close();
        }
    }
}
