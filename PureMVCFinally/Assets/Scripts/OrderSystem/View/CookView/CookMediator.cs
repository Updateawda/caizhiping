
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 19:22:49
* Description:$safeprojectname$
==========================================*/

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace OrderSystem
{
    public class CookMediator : Mediator
    {
        private CookProxy cookProxy = null;
        public new const string NAME = "CookMediator";
        public CookView CookView
        {
            get { return (CookView) base.ViewComponent; }
        }

        public CookMediator( CookView view ) : base(NAME , view)
        {
            CookView.CallCook += ( ) => { SendNotification(OrderSystemEvent.CALL_COOK); };
            CookView.ServerFood += item => { SendNotification(OrderSystemEvent.SERVER_FOOD,item); };
        }

        public override void OnRegister( )
        {
            base.OnRegister();
            cookProxy = Facade.RetrieveProxy(CookProxy.NAME) as CookProxy;
            if(null == cookProxy)
                throw new Exception(CookProxy.NAME + "is null.");
            CookView.UpdateCook(cookProxy.Cooks);
        }

        public override IList<string> ListNotificationInterests( )
        {
            IList<string> notifications = new List<string>(); 
            notifications.Add(OrderSystemEvent.CALL_COOK);
            notifications.Add(OrderSystemEvent.SERVER_FOOD);
            notifications.Add(OrderSystemEvent.ResfrshCook);
            return notifications;
        }

        public override void HandleNotification( INotification notification )
        {
            switch (notification.Name)
            {
                case OrderSystemEvent.CALL_COOK:
                    Order order = notification.Body as Order;
                    if( null == order )
                        throw new Exception("order is null ,please check it.");
                    SendNotification(OrderCommandEvent.CookCooking,order,"Busy");
                    break;
                case OrderSystemEvent.SERVER_FOOD:
                    CookItem cook = notification.Body as CookItem;
                    SendNotification(OrderCommandEvent.selectWaiter, cook.cookOrder, "SERVING");
                    cook.cookOrder = null;
                    SendNotification(OrderCommandEvent.CookCooking, cook,"Rest");
                    
                    break;
                case OrderSystemEvent.ResfrshCook:
                    cookProxy = Facade.RetrieveProxy(CookProxy.NAME) as CookProxy;
                    if (null == cookProxy)
                        throw new Exception(CookProxy.NAME + "is null.");
                    CookView.ResfrshCook(cookProxy.Cooks);
                    break;;

            }
        }
    }
}