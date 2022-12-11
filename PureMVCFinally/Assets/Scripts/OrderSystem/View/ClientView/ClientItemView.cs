﻿
/*=========================================
* Author: Administrator
* DateTime:2017/6/22 16:47:56
* Description:$safeprojectname$
==========================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum ClientState
{
    WaitMenu,
    WaitFood,
    Eating,
    Pay
}

namespace OrderSystem
{
    public class ClientItemView : MonoBehaviour
    {
        private Text text = null;
        private Image image = null;
        public ClientItem client = null;
        public IList<Action<object>> actionList = new List<Action<object>>();
        private void Awake()
        {
            text = transform.Find("Id").GetComponent<Text>();
            image = transform.GetComponent<Image>();
        }

        public void InitClient( ClientItem client )
        {
            this.client = client;
            UpdateState(); 
        }

        private void UpdateState(  )
        {
            if (client==null)
            {
                return;
            }
            Color color = Color.white;

            switch (this.client.state)
            {
                case ClientState.WaitMenu:
                    color = Color.green;
                    break;
                case ClientState.WaitFood:
                    color = Color.yellow;
                    break;
                case ClientState.Eating:
                    color = Color.red;
                    StartCoroutine(eatting());
                    break;
                case ClientState.Pay:
                    StartCoroutine(AddGuest());
                    break;
            }

            image.color = color;
            text.text = client.ToString();
            
        }

      
        /// <summary>
        /// 来客人了
        /// </summary>
        /// <returns></returns>
        IEnumerator AddGuest(float time = 4)
        {
            yield return new WaitForSeconds(time);
            actionList[0].Invoke(client);

        }
        IEnumerator eatting( float time = 5 )
        {
            yield return new WaitForSeconds(time);
            client.state++;
            actionList[1].Invoke(client);
        }
    }
}