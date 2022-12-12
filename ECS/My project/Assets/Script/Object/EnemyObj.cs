using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObj : ObjectBase
{
    public Enemyinfo m_enemyinfo;
    public EnemyObj(Enemyinfo enemyinfo)
    {
        m_enemyinfo = enemyinfo;
        m_name = m_enemyinfo.name;
        m_modelPath = m_enemyinfo.Path;
    }

    //创建对象
    public override void CreatObj()
    {
        SetPos(m_enemyinfo.vector3);
        base.CreatObj();

    }
    //初始化创建逻辑
    public override void OnCreat()
    {
        base.OnCreat();
        HPManager hpManager = m_go.AddComponent<HPManager>();
        hpManager.SetDate(m_enemyinfo.name, m_enemyinfo.m_HP, m_enemyinfo.m_MP);
    }
    //设置位置
    public override void SetPos(Vector3 pos)
    {
        base.SetPos(pos);
    }
}
public class GatherObj:ObjectBase
{
    public Gatherinfo m_gatherinfo;
    public Scopecheck scopecheck;
    Checkmanager checkmanager;
    public GatherObj(Gatherinfo gatherinfo)
    {
        m_gatherinfo=gatherinfo;
        m_name = gatherinfo.name;
        m_modelPath = gatherinfo.Path;
    }
    public override void CreatObj()
    {
        SetPos(m_gatherinfo.vector3);
        base.CreatObj();

    }
    public override void OnCreat()
    {
        base.OnCreat();
        scopecheck= m_go.AddComponent<Scopecheck>();
        scopecheck.m_call = (ins) =>
        {
            Notification notify = new Notification();
            notify.Refresh("CheckGather", m_gatherinfo.ID);
            MsgCenter.Instance.SendMsg("OnCheck", notify);
        };
        checkmanager= m_go.AddComponent<Checkmanager>();
        
        MsgCenter.Instance.AddListener("StartCheck", OnStartchenk);
        //收集完成
        MsgCenter.Instance.AddListener("S2CCheckCompent", (notify) =>
        {
            if (notify.msg.Equals("S2CCheckCompent"))
            {
                Debug.Log("收集完成");
                checkmanager.preafb.SetActive(false);
            }
        });

    }
    public override void SetPos(Vector3 pos)
    {
        base.SetPos(pos);
    }
    private void OnStartchenk(Notification notification)
    {
        if (notification.msg.Equals("StartCheck"))
        {
            checkmanager.preafb.SetActive(true);
        }
    }
}
