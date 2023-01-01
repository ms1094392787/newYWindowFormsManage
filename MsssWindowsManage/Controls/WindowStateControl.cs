using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MsssWindowsManage.Controls
{
    public class WindowStateControl: System.Windows.Controls.Control
    {
        #region DependencyProperty
        public static readonly DependencyProperty MaxButtonVisibilityProperty =
            DependencyProperty.Register("MaxButtonVisibility", typeof(Visibility), typeof(WindowStateControl), new PropertyMetadata(Visibility.Visible));     
        public static readonly DependencyProperty NormalButtonVisibilityProperty =
            DependencyProperty.Register("NormalButtonVisibility", typeof(Visibility), typeof(WindowStateControl), new PropertyMetadata(Visibility.Collapsed));   
        public static readonly DependencyProperty WindowformProperty =
            DependencyProperty.Register("Windowform", typeof(Window), typeof(WindowStateControl), new PropertyMetadata(null));
        public static readonly DependencyProperty WindowStateProperty =
            DependencyProperty.Register("WindowState", typeof(WindowState), typeof(WindowStateControl), new PropertyMetadata(WindowState.Normal, WindowStateCallBack));
        public static readonly DependencyProperty WindowMinCommandProperty =
            DependencyProperty.Register("WindowMinCommand", typeof(IRelayCommand), typeof(WindowStateControl), new PropertyMetadata(null));
        public static readonly DependencyProperty WindowMaxCommandProperty =
            DependencyProperty.Register("WindowMaxCommand", typeof(IRelayCommand), typeof(WindowStateControl), new PropertyMetadata(null));
        public static readonly DependencyProperty WindowNormalCommandProperty =
            DependencyProperty.Register("WindowNormalCommand", typeof(IRelayCommand), typeof(WindowStateControl), new PropertyMetadata(null));
        public static readonly DependencyProperty WindowCloseCommandProperty =
            DependencyProperty.Register("WindowCloseCommand", typeof(IRelayCommand), typeof(WindowStateControl), new PropertyMetadata(null));
        private static void WindowStateCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var state = (WindowState)(e.NewValue);
            if (state == WindowState.Normal)
            {
                d.SetValue(NormalButtonVisibilityProperty, Visibility.Collapsed);
                d.SetValue(MaxButtonVisibilityProperty, Visibility.Visible);
            }
            else if (state == WindowState.Maximized)
            {
                d.SetValue(NormalButtonVisibilityProperty, Visibility.Visible);
                d.SetValue(MaxButtonVisibilityProperty, Visibility.Collapsed);
            }
        }        
        #endregion


        public Visibility MaxButtonVisibility
        {
            get { return (Visibility)GetValue(MaxButtonVisibilityProperty); }
            set { SetValue(MaxButtonVisibilityProperty, value); }
        }
        public Visibility NormalButtonVisibility
        {
            get { return (Visibility)GetValue(NormalButtonVisibilityProperty); }
            set { SetValue(NormalButtonVisibilityProperty, value); }
        }
        public Window Windowform
        {
            get { return (Window)GetValue(WindowformProperty); }
            set { SetValue(WindowformProperty, value); }
        }
        public WindowState WindowState
        {
            get { return (WindowState)GetValue(WindowStateProperty); }
            set { SetValue(WindowStateProperty, value); }
        }

        public IRelayCommand WindowMinCommand
        {
            get { return (IRelayCommand)GetValue(WindowMinCommandProperty); }
            set { SetValue(WindowMinCommandProperty, value); }
        }        

        public IRelayCommand WindowMaxCommand
        {
            get { return (IRelayCommand)GetValue(WindowMaxCommandProperty); }
            set { SetValue(WindowMaxCommandProperty, value); }
        }

        public IRelayCommand WindowNormalCommand
        {
            get { return (IRelayCommand)GetValue(WindowNormalCommandProperty); }
            set { SetValue(WindowNormalCommandProperty, value); }
        }

        public IRelayCommand WindowCloseCommand
        {
            get { return (IRelayCommand)GetValue(WindowCloseCommandProperty); }
            set { SetValue(WindowCloseCommandProperty, value); }
        }
        

        public WindowStateControl()
        {
            InitCommand();
            InitialTray();
        }
        
        public void InitCommand()
        {
            WindowMinCommand = new RelayCommand(WindowMin);
            WindowMaxCommand = new RelayCommand(WindowMax);
            WindowNormalCommand = new RelayCommand(WindowNormal);
            WindowCloseCommand = new RelayCommand(WindowClose);
        }

        private void WindowMin()
        {
            Windowform.Visibility = Visibility.Hidden;
            _notifyIcon.BalloonTipText = "托盘运行中……";//托盘气泡显示内容
            _notifyIcon.ShowBalloonTip(1000);
            //Windowform.WindowState = WindowState.Minimized;
        }

        private void WindowMax()
        {
            Windowform.WindowState = WindowState.Maximized;
        }

        private void WindowNormal()
        {
            Windowform.WindowState = WindowState.Normal;
        }

        private void WindowClose()
        {
            Windowform.Close();
        }


        #region 最小化托盘
        private NotifyIcon _notifyIcon = null;

        private void InitialTray()
        {
            //设置托盘的各个属性
            _notifyIcon = new NotifyIcon();            
            _notifyIcon.Text = "newY 窗口管理工具";
            _notifyIcon.Visible = true;//托盘按钮是否可见
            _notifyIcon.Icon = new Icon(@"./FileResource/icon.ico");//托盘中显示的图标            
            _notifyIcon.MouseClick += notifyIcon_MouseClick;
            //窗体状态改变时触发            
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Windowform.Visibility == Visibility.Visible)
                {
                    Windowform.Visibility = Visibility.Hidden;
                }
                else
                {
                    Windowform.Visibility = Visibility.Visible;
                    Windowform.Activate();
                }
            }
        }
        #endregion
    }
}
