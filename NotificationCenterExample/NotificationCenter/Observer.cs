using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notification
{
    /// <summary> 
    /// HuangRongGui 2020-10-15  
    /// 订阅消息者的抽象基类 
    /// </summary>
    public abstract class Observer
    {
        /// <summary>
        /// 收到消息中心发来的消息。
        /// </summary>
        /// <param name="name">消息名称</param>
        /// <param name="anObject">消息参数</param>
        abstract public void receiveNotification(string name, Object anObject);
    }
}
