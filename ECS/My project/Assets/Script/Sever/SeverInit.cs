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
                Debug.Log("����ɼ���");
                notify.Refresh("StartCheck", (int)notify.data[0]);
                MsgCenter.Instance.SendMsg("StartCheck", notify);
            }
        });
        //��ʼ�ɼ�
        MsgCenter.Instance.AddListener("CheckClik", (notify) =>
        {
            if (notify.msg.Equals("CheckClik"))
            {
                notify.Refresh("S2CCheckClik", (int)notify.data[0]);
                MsgCenter.Instance.SendMsg("S2CCheckClik", notify);
            }
        });
        //�ɼ����
        MsgCenter.Instance.AddListener("C2SCheckCompent", (notify) =>
        {
            if (notify.msg.Equals("CheckCompent"))
            {
                notify.Refresh("S2CCheckCompent", (int)notify.data[0]);
                MsgCenter.Instance.SendMsg("S2CCheckCompent", notify);
            }
        });
        //���ﲥ�ż���
        MsgCenter.Instance.AddListener("C2SPlaySkill", (notify) =>
        {
            if (notify.msg.Equals("C2SPlaySkill"))
            {
                notify.Refresh("S2CPlaySkill", notify.data[0]);
                MsgCenter.Instance.SendMsg("S2CPlaySkill", notify);
            }
        });
        //��������C2SAcceptTask
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
