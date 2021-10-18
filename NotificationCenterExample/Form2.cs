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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotificationCenter.GetInstance().postNotificationName(NotificationDefine.LoginSucceedNotification,"登录成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NotificationCenter.GetInstance().postNotificationName(NotificationDefine.LoginFailNotification,"登录失败");
        }
    }
}
