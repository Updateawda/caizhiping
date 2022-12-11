using Assets.Scripts.OrderSystem.Model.Room;
using Assets.Scripts.OrderSystem.View.RoomView;
using OrderSystem;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMediator : Mediator
{
    private RoomProxy roomProxy = null;
    public new const string NAME = "RoomMediator";
    public RoomView roomView
    {
        get { return (RoomView)ViewComponent; }
    }
    public RoomMediator(RoomView roomView):base(NAME,roomView)
    {

    }
    public override void OnRegister()
    {
        base.OnRegister();
        roomProxy = Facade.RetrieveProxy(RoomProxy.NAME) as RoomProxy;
        if (null == roomProxy)
            throw new Exception(RoomProxy.NAME + "is null,please check it!");
        IList<Action<object>> actionList = new List<Action<object>>()
        {
            item =>  SendNotification(OrderCommandEvent.RoomControl, item, "Remove"),
        };
        roomView.UpdateClient(roomProxy.Roooms,actionList);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifications = new List<string>();
        notifications.Add(OrderSystemEvent.JOINROOM);
        notifications.Add(OrderSystemEvent.CLEANROOM);
        notifications.Add(OrderSystemEvent.ResfrshRoom);
        return notifications;
    }
    public override void HandleNotification(INotification notification)
    {
        switch(notification.Name)
        {
            case OrderSystemEvent.JOINROOM:
                ClientItem clientItem = notification.Body as ClientItem;
                SendNotification(OrderCommandEvent.RoomControl, clientItem, "Join");
                break;
            case OrderSystemEvent.CLEANROOM:
                break;
            case OrderSystemEvent.ResfrshRoom:
                RoomItem roomItem = notification.Body as RoomItem;
                roomView.Updatestate(roomItem);

                break;
        }
    }
}
