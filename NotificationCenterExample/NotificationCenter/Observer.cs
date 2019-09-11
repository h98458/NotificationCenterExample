using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notification
{
    /// <summary> 
    /// hrg 2018-10-15  
    /// 订阅消息者的抽象基类 
    /// </summary>
    public abstract class Observer
    {
        /// <summary>
        /// 收到消息中心发来的消息。
        /// <param name="name">消息名称</param>
        /// </summary>
        abstract public void receiveNotification(string name);
    }
}
