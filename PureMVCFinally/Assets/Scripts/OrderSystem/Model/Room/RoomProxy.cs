using OrderSystem;
using PureMVC.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.OrderSystem.Model.Room
{
    public class RoomProxy:Proxy
    {
        public new const string NAME = "RoomProxy";
        public IList<RoomItem> Roooms
        {
            get { return (IList<RoomItem>)base.Data; }
        }

        public RoomProxy() : base(NAME, new List<RoomItem>())
        {

        }
        public override void OnRegister()
        {
            base.OnRegister();
            Roooms.Add(new RoomItem(1,0,0,4));
            Roooms.Add(new RoomItem(2,0,0,5));
            Roooms.Add(new RoomItem(3,0,0,6));
        }
        public void Changestate(ClientItem client)
        {
            for (int i = 0; i < Roooms.Count; i++)
            {
                if (Roooms[i].state!=RoomState.full)
                {
                    Roooms[i].clientnum += client.population;
                    if (Roooms[i].clientnum >= Roooms[i].maxnum)
                    {
                        Roooms[i].state = RoomState.full;
                    }
                    else
                    {
                        Roooms[i].state = RoomState.busy;
                    }
                    SendNotification(OrderSystemEvent.ResfrshRoom, Roooms[i]);
                    break;
                }
                
            }
        }
        public void CleanRoom(RoomItem room)
        {
            for (int i = 0; i < Roooms.Count; i++)
            {
                if (room.id == Roooms[i].id)
                {
                    Roooms[i].state = 0;
                    Roooms[i].clientnum = 0;
                    SendNotification(OrderSystemEvent.ResfrshRoom, Roooms[i]);
                }
            }
        }
    }
}
