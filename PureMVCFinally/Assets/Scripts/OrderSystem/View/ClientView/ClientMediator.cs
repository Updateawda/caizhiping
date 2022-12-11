
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 19:20:37
* Description:$safeprojectname$
==========================================*/

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace OrderSystem
{
    public class ClientMediator : Mediator
    {
        private ClientProxy clientProxy = null;
        public new const string NAME = "ClientMediator";
        private ClientView View
        {
            get { return (ClientView)ViewComponent; }
        }

        public ClientMediator( ClientView view ) : base(NAME , view)
        {
            view.CallWaiter += data => { SendNotification(OrderSystemEvent.CALL_WAITER , data); };
            view.Order += data => { SendNotification(OrderSystemEvent.ORDER , data); };
            view.Pay += ( ) => { SendNotification(OrderSystemEvent.PAY); };
        }

        public override void OnRegister()
        {
            base.OnRegister();
            clientProxy = Facade.RetrieveProxy(ClientProxy.NAME) as ClientProxy;
            if(null == clientProxy)
                throw new Exception("获取" + ClientProxy.NAME + "代理失败");
            IList<Action<object> > actionList = new List<Action<object>>()
            {
                item =>  SendNotification(OrderCommandEvent.GUEST_BE_AWAY, item, "Add"),
                item =>  SendNotification(OrderSystemEvent.GET_PAY, item),
            };
            View.UpdateClient(clientProxy.Clients,actionList);
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> notifications = new List<string>();
            notifications.Add(OrderSystemEvent.CALL_WAITER);
            notifications.Add(OrderSystemEvent.ORDER);
            notifications.Add(OrderSystemEvent.PAY);
            notifications.Add(OrderSystemEvent.REFRESH);
            return notifications;
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case OrderSystemEvent.CALL_WAITER:
                    ClientItem client = notification.Body as ClientItem;
                    break;
                case OrderSystemEvent.ORDER: 
                    Order order1 = notification.Body as Order;
                    if(null == order1)
                        throw new Exception("order1 is null ,please check it!");
                    SendNotification(OrderCommandEvent.ChangeClientState, order1,"WaitFood");
                    break;
                case OrderSystemEvent.PAY:
                    WaiterItem order2 = notification.Body as WaiterItem;
                    if (null == order2)
                        throw new Exception("order1 is null ,please check it!");
                    Debug.Log("支付"+order2.order.pay);
                   
                    break;
                case OrderSystemEvent.REFRESH:
                    //clientProxy = Facade.RetrieveProxy(ClientProxy.NAME) as ClientProxy;
                    ClientItem clientItem = notification.Body as ClientItem;
                    if (null == clientProxy)
                        throw new Exception("获取" + ClientProxy.NAME + "代理失败");
                    View.UpdateState(clientItem);
                    break;
            }
        }
    }
}