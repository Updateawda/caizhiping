using OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.OrderSystem.Model.Room
{
    public enum RoomState
    {
        free,
        busy,
        full

    }
    public class RoomItem
    {
        public int id;
        public int clientnum;
        public RoomState state;
        public int maxnum;

        public RoomItem(int id , int clientnum, RoomState state, int maxnum)
        {
            this.id = id;
            this.clientnum = clientnum;
            this.state = state;
            this.maxnum = maxnum;
        }

        public override string ToString()
        {
            return id + "号房间\n" + "人数:" + clientnum +"/"+maxnum+ "\n" + returnstate(state);
        }
        private string returnstate(RoomState state)
        {
            if (state.Equals(RoomState.free))
                return "空房间";
            if (state.Equals(RoomState.busy))
                return "有人";
            if (state.Equals(RoomState.full))
                return "满了";
            return null;
        }
    }
}
