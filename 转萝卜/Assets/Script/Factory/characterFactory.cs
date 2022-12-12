using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class characterFactory : IcharacterFactory
{
    public override void CreatPlay(params object[] date)
    {
        date[0] = GameObject.Instantiate(Resources.Load<GameObject>("Play1"), UITool.FindUIGameObject("Play").transform);
        date[1] = GameObject.Instantiate(Resources.Load<GameObject>("Play2"), UITool.FindUIGameObject("Play").transform);
        Notification notification = new Notification();
        notification.Refresh("SetPlat", date);
        MsgCenter.Instance.SendMsg("SetPlat", notification);
    }

    
}
