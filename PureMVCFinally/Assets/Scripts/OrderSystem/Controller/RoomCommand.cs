using Assets.Scripts.OrderSystem.Model.Room;
using OrderSystem;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.OrderSystem.Controller
{
    public class RoomCommand:SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            RoomProxy roomProxy = Facade.RetrieveProxy(RoomProxy.NAME) as RoomProxy;
            if (notification.Type=="Join")
            {
                roomProxy.Changestate(notification.Body as ClientItem);
            }
            else if (notification.Type == "Remove")
            {
                roomProxy.CleanRoom(notification.Body as RoomItem);
            }
            
        }
    }
}
