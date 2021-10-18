using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    /// <summary> 
    /// HuangRongGui 2020-10-15 
    /// 定义消息服务的接口 
    /// </summary>
    interface NotificationInterface
    {
        /// <summary>
        /// 向通知中心订阅通知
        /// </summary>
        /// <param name="observer">订阅者</param>
        /// <param name="name">消息名称</param>
        void addObserver(Observer observer, string name);

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="observer">订阅者</param>
        void removeObserver(Observer observer);

        /// <summary>
        /// 给订阅人发通知
        /// </summary>
        /// <param name="name">消息名称</param>
        /// <param name="anObject">消息参数</param>
        void postNotificationName(string name, Object anObject);
    }
}
