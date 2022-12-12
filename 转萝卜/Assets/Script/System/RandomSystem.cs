using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class RandomSystem : Isystem
{
    public RandomSystem(Facade facade) : base(facade)
    {
        Initialize();
    }

    public override void Initialize()
    {
        MsgCenter.Instance.AddListener("ZhuanLuobo", (notify)=> Zhuanluo(notify));
    }
    public override void Release()
    {

    }
    public override void Update()
    {

    }
    /// <summary>
    /// ×ªÂÜ²·
    /// </summary>
    public void Zhuanluo(Notification notification)
    {
        int ran = Random.Range(0, 4);
        if (notification.msg.Equals("ZhuanLuobo"))
        {
            if (ran!=0)
            {
                Debug.Log("ÒÆ¶¯£º" + ran);
            }
            Notification notification1 = new Notification();
            notification1.Refresh("CharactControl", ran);
            MsgCenter.Instance.SendMsg("CharactControl", notification1);
            
            
        }
    }
}
