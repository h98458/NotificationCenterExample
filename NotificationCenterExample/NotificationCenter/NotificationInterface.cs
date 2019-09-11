using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    /// <summary> 
    /// hrg 2018-10-15 
    /// 定义消息服务的接口 
    /// </summary>
    interface NotificationInterface
    {
        /// <summary> 
        /// 向通知中心订阅通知 
        /// </summary>
        void addObserver(Observer observer,string name);

        /// <summary> 
        /// 取消订阅 
        /// </summary>
        void removeObserver(Observer observer);

        /// <summary> 
        /// 给订阅人发通知 
        /// </summary>
        void postNotificationName(string name);
    }
}
