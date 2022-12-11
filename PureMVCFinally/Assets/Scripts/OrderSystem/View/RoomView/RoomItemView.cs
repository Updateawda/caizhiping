using Assets.Scripts.OrderSystem.Model.Room;
using OrderSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.OrderSystem.View.RoomView
{
    public class RoomItemView:MonoBehaviour
    {
        private Text text = null;
        private Image image = null;
        public RoomItem room = null;
        public IList<Action<object>> actionList = new List<Action<object>>();
        private void Awake()
        {
            text = transform.Find("Id").GetComponent<Text>();
            image = transform.Find("Image").GetComponent<Image>();
        }
        public void InitDate(RoomItem roomItem)
        {
            room=roomItem;
            UpdateState();
        }
        private void UpdateState()
        {
            if (room == null)
            {
                return;
            }
            Color color = Color.white;

            switch (this.room.state)
            {
                case RoomState.free:
                    color = Color.green;
                    break;
                case RoomState.busy:
                    color = Color.yellow;
                    break;
                case RoomState.full:
                    color = Color.red;
                    StartCoroutine(Clean());
                    break;

            }

            image.color = color;
            text.text = room.ToString();

        }
        IEnumerator Clean()
        {
            yield return new WaitForSeconds(6);
            actionList[0].Invoke(room);
        }
    }
}
