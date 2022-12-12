using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TrapSystem : Isystem
{
    int fixationindex = 5;//¹Ì¶¨ÏÝÚå
    public TrapSystem(Facade facade) : base(facade)
    {
        Initialize();
    }

    public override void Initialize()
    {
        MsgCenter.Instance.AddListener("TrapControl", (notify) => TrapControl(notify));
        Notification notification = new Notification();
        notification.Refresh("fixationTrap", fixationindex);
        MsgCenter.Instance.SendMsg("fixationTrap", notification);
    }
    private void TrapControl(Notification notification)
    {
        //Ëæ»úÏÝÚå
        Debug.Log("Ëæ»úÏÝÚå");
        int ran=Random.Range(0,Facade.Instance.GetMap().objects.Count);
        while (ran==fixationindex)
        {
            ran = Random.Range(0, Facade.Instance.GetMap().objects.Count);
        }
        Notification notification1 = new Notification();
        notification1.Refresh("RandomTrap", ran);
        MsgCenter.Instance.SendMsg("RandomTrap", notification1);

    }
    public override void Release()
    {

    }
    public override void Update()
    {

    }
}
