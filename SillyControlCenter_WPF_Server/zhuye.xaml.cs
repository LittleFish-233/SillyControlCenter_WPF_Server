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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SillyControlCenter_WPF_Server
{
    /// <summary>
    /// zhuye.xaml 的交互逻辑
    /// </summary>
    public partial class zhuye : Page
    {
        System.Threading.Timer timer;

        public zhuye()
        {
            InitializeComponent();
            //启动定时器
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(Gengxin), null, 0, 1000);//1S定时器 
        }
        public void Gengxin(object a)
        {
            App.Current.Dispatcher.Invoke(new Action(() =>
            {
                lock (this)
                {
                    try
                    {
                        //刷新前台数据
                        textblock0.Text = App.Mianban_.peizhi.Shuju.Zhujiming;
                        textblock1.Text = "连接设备数：" +( App.Mianban_.shuju_Shebei_PCs.Count+App.Mianban_.shuju_Shebei_ADs.Count).ToString();
                    }
                    catch
                    {

                    }
                }
            }));
        }

    }
}
