
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 12:39:43
* Description:$safeprojectname$
==========================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

namespace OrderSystem
{
    public class WaiterView : MonoBehaviour
    {
       /* public UnityAction CallWaiter = null;
        public UnityAction<Order> Order = null;
        public UnityAction Pay = null;
        public UnityAction CallCook = null;*/
        public UnityAction<WaiterItem> ServerFood = null;

        private ObjectPool<WaiterItemView> objectPool = null;
        private List<WaiterItemView> waiters = new List<WaiterItemView>();
        private Transform parent = null;

        private void Awake()
        {
            parent = this.transform.Find("Content");
            var prefab = Resources.Load<GameObject>("Prefabs/UI/WaiterItem");
            objectPool = new ObjectPool<WaiterItemView>(prefab , "WaiterPool");
        }
        public void UpdateWaiter( IList<WaiterItem> waiters, IList<Action<object>> actionList)
        {
            for ( int i = 0 ; i < this.waiters.Count ; i++ )
                objectPool.Push(this.waiters[i]);

            this.waiters.AddRange(objectPool.Pop(waiters.Count));
            for (int i = 0; i < this.waiters.Count; i++)
            {
                this.waiters[i].transform.SetParent(parent);
                var item = this.waiters[i];
                item.actionList = actionList;
                item.InitDate(waiters[i]);

            }
        }

        public void Resfrsh(WaiterItem aiterItem)
        {
            for (int i = 0; i < waiters.Count; i++)
            {
                if (aiterItem.id == waiters[i].waiterItem.id)
                {
                    waiters[i].InitDate(aiterItem);
                    break;
                }
            }
        }
        
    }
}