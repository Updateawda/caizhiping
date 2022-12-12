using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IPlayer 
{
    public GameObject play;
    public List<GameObject> maplist;
    int currindex;
    public IPlayer(List<GameObject> maplist)
    {
        this.maplist = maplist;
    }
    /// <summary>
    /// �ƶ�
    /// </summary>
    public virtual void Move(int count)
    {
        play.transform.localPosition = maplist[count].transform.localPosition;
    }
    
    /// <summary>
    /// ��������
    /// </summary>
    public virtual void Triggertrap()
    {
        Debug.Log("��������");
        //play.transform.localPosition = maplist[0].transform.localPosition;
        Notification notification= new Notification();
        notification.Refresh("Triggertrap");
        MsgCenter.Instance.SendMsg("Triggertrap",notification);
        Move(0);
    }

}
