
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 18:16:40
* Description:$safeprojectname$
==========================================*/

using Assets.Scripts.OrderSystem.View.RoomView;
using UnityEngine;

namespace OrderSystem
{
    public class MainUI : MonoBehaviour
    {
        public MenuView MenuView = null;
        public ClientView ClientView = null;
        public WaiterView WaitView = null;
        public CookView CookView = null;
        public RoomView RoomView = null;

        private void Start()
        {
            ApplicationFacade facade = new ApplicationFacade();
            facade.StartUp(this);
        } 
    }
}
