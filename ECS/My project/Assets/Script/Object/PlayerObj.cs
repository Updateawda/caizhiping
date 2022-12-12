using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Xml.Linq;
using UnityEditor;

public class PlayerObj : ObjectBase
{
    public Playerinfo m_playerinfo;
    public PlayerObj(Playerinfo playerinfo)
    {
        m_playerinfo = playerinfo;
       
    }
    //创建对象
    public override void CreatObj()
    {
        SetPos(m_playerinfo.vector3);
        base.CreatObj();
    }
    public override void OnCreat()
    {
        base.OnCreat();
        HPManager hpManager = m_go.AddComponent<HPManager>();
        hpManager.SetDate(m_playerinfo.name, m_playerinfo.m_HP, m_playerinfo.m_MP);

    }
    //设置位置
    public override void SetPos(Vector3 pos)
    {
        base.SetPos(pos);
    }
}


public class MyPlayer:PlayerObj
{
    
    public MyPlayer(Playerinfo playerinfo):base(playerinfo)
    {
        m_modelPath = playerinfo.Path;
        m_name = playerinfo.name;
    }
    public override void CreatObj()
    {
        //SetPos(m_playerinfo.vector3);
        base.CreatObj();
    }
    public override void OnCreat()
    {
        base.OnCreat();
        GameObject.Find("Playercam").GetComponent<CinemachineVirtualCamera>().Follow = m_go.transform;
        GameObject.Find("Playercam").GetComponent<CinemachineVirtualCamera>().LookAt = m_go.transform;
        InputManager input = m_go.AddComponent<InputManager>();

        Player player= Player.Init(m_go, m_name);
        GameObject gather = GameObject.Find("Gather");
        gather.GetComponent<Scopecheck>().m_taget = m_go;
        //收集完成
        MsgCenter.Instance.AddListener("S2CPlaySkill", (notify) =>
        {
            if (notify.msg.Equals("S2CPlaySkill"))
            {
                Debug.Log("播放技能");
                player.Play(notify.data[0].ToString());
            }
        });
        //接受任务按钮
        Uibase uibase = new TaskManager();
        uibase.DoCreate("TaskBut");
    }
}

public class OtherPlayer : PlayerObj
{
    public OtherPlayer(Playerinfo playerinfo) : base(playerinfo)
    {
        m_modelPath = playerinfo.Path;
        m_name = playerinfo.name;
    }
    public override void OnCreat()
    {
        base.OnCreat();
    }
}
