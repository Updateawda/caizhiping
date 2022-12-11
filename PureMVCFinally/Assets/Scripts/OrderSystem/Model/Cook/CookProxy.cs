
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 18:17:11
* Description:$safeprojectname$
==========================================*/

using System.Collections.Generic;
using System.Diagnostics;
using PureMVC.Patterns;

namespace OrderSystem
{
    public class CookProxy : Proxy
    {
        public Queue<Order> Waitorder = new Queue<Order>();
        public new const string NAME = "CookProxy";
        public IList<CookItem> Cooks
        {
            get { return (IList<CookItem>) base.Data; }
        }

        public CookProxy( ) : base(NAME , new List<CookItem>())
        {
            
        }
        public void Chagestate(CookItem cook)
        {
            GetCookItem(cook.id).state = 0;
            if (Waitorder.Count!=0)
            {
                CookCooking(Waitorder.Dequeue());
            }
            else
            {
                SendNotification(OrderSystemEvent.ResfrshCook);
            }
            
        }
        public CookItem GetCookItem(int id)
        {
            for (int i = 0; i < Cooks.Count; i++)
            {
                if (Cooks[i].id==id)
                {
                    return Cooks[i];
                }
            }
            return null;
        }
        public override void OnRegister()
        {
            base.OnRegister();
            AddCook(new CookItem(1, "老高", 0));
            AddCook(new CookItem(2, "老樊", 0));
            AddCook(new CookItem(3, "大牛", 0));
        }
        public void AddCook( CookItem item )
        {
            Cooks.Add(item);
        }
        public void RemoveCook( CookItem item )
        {
            Cooks.Remove(item);
        }

        public void CookCooking(Order order)
        {
            for (int i = 0; i < Cooks.Count; i++)
            {
                if (Cooks[i].state == 0)//找到非忙碌厨师改变其状态
                {
                    Cooks[i].state=1;
                    Cooks[i].cooking = order.names;//厨师抄的什么菜
                    Cooks[i].cookOrder = order;// 厨师炒菜的菜单
                    SendNotification(OrderSystemEvent.ResfrshCook);//找到空闲厨师去刷新一下厨师显示的状态
                    return;
                }
            }
            Waitorder.Enqueue(order);
            
        }
    }
}