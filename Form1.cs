using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notification;

namespace NotificationCenterExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //订阅和接收通知的派生类实例
        DelegateObserver observer;

        /// <summary>
        /// 实现委托，接收通知中心发来的消息
        /// </summary
        public void receveNotification(string name)
        {
            if (name.Equals(NotificationDefine.LoginSucceedNotification))
            {
                //登录成功
                MessageBox.Show("登录成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (name.Equals(NotificationDefine.LoginFailNotification))
            {
                //登录失败
                MessageBox.Show("登录失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化通知订阅者
            observer = new DelegateObserver();
            observer.notificationDelegate = receveNotification;

            //接收数据上传通知
            NotificationCenter.GetInstance().addObserver(observer, NotificationDefine.LoginSucceedNotification);
            NotificationCenter.GetInstance().addObserver(observer, NotificationDefine.LoginFailNotification);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //移除通知
            NotificationCenter.GetInstance().removeObserver(observer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
