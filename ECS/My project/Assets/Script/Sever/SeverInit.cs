using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SeverInit : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        MsgCenter.Instance.AddListener("OnCheck", (notify) =>
        {
            if (notify.msg.Equals("CheckGather"))
            {
                Debug.Log("到达采集点");
                notify.Refresh("StartCheck", (int)notify.data[0]);
                MsgCenter.Instance.SendMsg("StartCheck", notify);
            }
        });
        //开始采集
        MsgCenter.Instance.AddListener("CheckClik", (notify) =>
        {
            if (notify.msg.Equals("CheckClik"))
            {
                notify.Refresh("S2CCheckClik", (int)notify.data[0]);
                MsgCenter.Instance.SendMsg("S2CCheckClik", notify);
            }
        });
        //采集完成
        MsgCenter.Instance.AddListener("C2SCheckCompent", (notify) =>
        {
            if (notify.msg.Equals("CheckCompent"))
            {
                notify.Refresh("S2CCheckCompent", (int)notify.data[0]);
                MsgCenter.Instance.SendMsg("S2CCheckCompent", notify);
            }
        });
        //人物播放技能
        MsgCenter.Instance.AddListener("C2SPlaySkill", (notify) =>
        {
            if (notify.msg.Equals("C2SPlaySkill"))
            {
                notify.Refresh("S2CPlaySkill", notify.data[0]);
                MsgCenter.Instance.SendMsg("S2CPlaySkill", notify);
            }
        });
        //接受任务C2SAcceptTask
        MsgCenter.Instance.AddListener("C2SAcceptTask", (notify) =>
        {
            if (notify.msg.Equals("C2SAcceptTask"))
            {
                SeverDate.Instance.Init();
                notify.Refresh("S2CAcceptTask",SeverDate.Instance.tasks);
                MsgCenter.Instance.SendMsg("S2CAcceptTask", notify);
            }
        });
    }
}
