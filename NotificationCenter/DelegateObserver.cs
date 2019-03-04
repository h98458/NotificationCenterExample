using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    /// <summary>
    /// 抽象类Observer的派生类，定义了主界面接收通知的委托
    /// </summary>
    class DelegateObserver : Observer
    {
        //定义接收消息的委托
        public delegate void ReceiveNotification(string name);
        public ReceiveNotification notificationDelegate;

        /// <summary>
        /// 接收消息中心的通知
        /// </summary>
        /// <param name="name"></param>
        public override void receiveNotification(string name)
        {
            notificationDelegate(name);
        }
    }
}
