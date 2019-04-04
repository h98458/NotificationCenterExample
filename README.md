# NotificationCenterExample
C# NotificationCenter
VS C# 消息通知中心，实现在项目的任何地方向窗体发消息，零耦合，调用简单，具体看源码

form1接收消息：

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

            //接收通知
            NotificationCenter.GetInstance().addObserver(observer, NotificationDefine.LoginSucceedNotification);
            NotificationCenter.GetInstance().addObserver(observer, NotificationDefine.LoginFailNotification);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //移除通知
            NotificationCenter.GetInstance().removeObserver(observer);
        }
        
       发送消息：
       
       NotificationCenter.GetInstance().postNotificationName(NotificationDefine.LoginSucceedNotification);
       NotificationCenter.GetInstance().postNotificationName(NotificationDefine.LoginFailNotification);
       
       
