using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    /// <summary>
    /// HuangRongGui 2020-10-15
    /// 抽象类Observer的派生类，定义了主界面接收通知的委托
    /// </summary>
    class DelegateObserver : Observer
    {
        //定义接收消息的委托
        public delegate void ReceiveNotification(string name, Object anObject);
        public ReceiveNotification notificationDelegate;

        /// <summary>
        /// 接收消息中心的通知
        /// </summary>
        /// <param name="name">消息名称</param>
        /// <param name="anObject">消息参数</param>
        public override void receiveNotification(string name, Object anObject)
        {
            notificationDelegate(name, anObject);
        }
    }
}
