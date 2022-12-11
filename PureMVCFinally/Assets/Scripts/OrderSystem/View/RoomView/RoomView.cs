using Assets.Scripts.OrderSystem.Model.Room;
using OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.OrderSystem.View.RoomView
{
    public class RoomView:MonoBehaviour
    {
        private ObjectPool<RoomItemView> objectPool = null;
        private List<RoomItemView> rooms = new List<RoomItemView>();
        private Transform parent = null;
        private void Awake()
        {
            parent = this.transform.Find("Content");
            var prefab = Resources.Load<GameObject>("Prefabs/UI/RoomItem");
            objectPool = new ObjectPool<RoomItemView>(prefab, "RoomPool");
        }
        public void UpdateClient(IList<RoomItem> room, IList<Action<object>> actionList)
        {
            for (int i = 0; i < this.rooms.Count; i++)
                objectPool.Push(this.rooms[i]);

            this.rooms.AddRange(objectPool.Pop(room.Count));

            for (int i = 0; i < this.rooms.Count; i++)
            {
                this.rooms[i].transform.SetParent(parent);
                var item = this.rooms[i];
                item.actionList = actionList;
                item.InitDate(room[i]);
            }
        }
        public void Updatestate(RoomItem room)
        {
            for (int i = 0; i < this.rooms.Count; i++)
            {
                if (room.id == rooms[i].room.id)
                {
                    rooms[i].InitDate(room);
                    break;
                }
            }
        }
    }
   
}
