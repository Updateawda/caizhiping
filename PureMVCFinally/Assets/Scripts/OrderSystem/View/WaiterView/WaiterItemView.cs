
/*=========================================
* Author: Administrator
* DateTime:2017/6/22 17:00:07
* Description:$safeprojectname$
==========================================*/

using Assets.Scripts.OrderSystem.Model.Room;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace OrderSystem
{
    public class WaiterItemView : MonoBehaviour
    {
        private Text text = null;
        private Image image = null;
        public WaiterItem waiterItem = null;
        public IList<Action<object>> actionList = new List<Action<object>>();
        private void Awake()
        {
            text = transform.Find("Id").GetComponent<Text>();
            image = transform.Find("Image").GetComponent<Image>();
        }
        public void InitDate(WaiterItem waitItem)
        {
            waiterItem = waitItem;
            UpdateState();
        }
        private void UpdateState()
        {
            if (waiterItem == null)
            {
                return;
            }
            Color color = Color.white;

            switch (this.waiterItem.state)
            {
                case 0:
                    color = Color.green;
                    break;
                case 1:
                    color = Color.yellow;
                    StartCoroutine(WaiterServing(waiterItem));
                break;

            }

            image.color = color;
            text.text = waiterItem.ToString();

        }
        IEnumerator WaiterServing(WaiterItem item, float time = 5)
        {
            yield return new WaitForSeconds(time);
            actionList[0].Invoke(item);
        }
    }
}