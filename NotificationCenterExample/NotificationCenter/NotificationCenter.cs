using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Notification
{
    /// <summary> 
    /// HuangRongGui 2020-10-15
    /// 消息服务中心 实现了订阅和发送信息的业务接口 
    /// </summary> 
    class NotificationCenter : NotificationInterface
    {

        #region 单例
        // 定义一个静态变量来保存类的实例
        private static NotificationCenter uniqueInstance;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        // 定义私有构造函数，使外界不能创建该类实例
        private NotificationCenter()
        {
            systemIsBusy = false;
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static NotificationCenter GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new NotificationCenter();
                    }
                }
            }
            return uniqueInstance;
        }
        #endregion

        //系统是否正忙（弹出等待框）
        public bool systemIsBusy;

        //保存订阅者的数组 
        private ArrayList observerList = new ArrayList();

        /// <summary>
        /// 向通知中心订阅通知
        /// </summary>
        /// <param name="observer">订阅者</param>
        /// <param name="name">消息名称</param>
        public void addObserver(Observer observer, string name)
        {
            //判断相同对象实例是否已经订阅的通知
            foreach (Dictionary<string, Observer> dict in observerList)
            {
                if (dict.ContainsKey(name))
                {
                    Observer item = dict[name];
                    if (item.Equals(observer))
                    {
                        return;
                    }

                }

            }
            Dictionary<string, Observer> dis = new Dictionary<string, Observer>();
            dis.Add(name, observer);
            observerList.Add(dis);
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="observer">订阅者</param>
        public void removeObserver(Observer observer)
        {
            for (int i = observerList.Count - 1; i >= 0; i--)
            {
                Dictionary<string, Observer> dict = (Dictionary<string, Observer>)observerList[i];
                foreach (Observer item in dict.Values)
                {
                    if (item.Equals(observer))
                    {
                        observerList.Remove(dict);
                    }
                }
            }

        }

        /// <summary>
        /// 给订阅人发通知
        /// </summary>
        /// <param name="name">消息名称</param>
        /// <param name="anObject">消息参数</param>
        public void postNotificationName(string name, Object anObject)
        {
            if (name.Equals(NotificationDefine.ShowWaitingNotification))
            {
                systemIsBusy = true;
            }
            else if (name.Equals(NotificationDefine.CloseWaitingNotification))
            {
                systemIsBusy = false;
            }

            for (int i = 0; i < observerList.Count; i++)
            {
                Dictionary<string, Observer> dict = (Dictionary<string, Observer>)observerList[i];
                if (dict.ContainsKey(name))
                {
                    Observer observer = dict[name];
                    observer.receiveNotification(name, anObject);
                }
            }
        }
    }
}
