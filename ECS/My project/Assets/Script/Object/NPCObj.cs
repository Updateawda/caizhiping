using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObj : ObjectBase
{
    public NPCinfo m_npcinfo;
    public NPCObj(NPCinfo npcinfo)
    {
        m_npcinfo = npcinfo;
        m_name=m_npcinfo.name;
        m_modelPath = m_npcinfo.Path;
    }

    //��������
    public override void CreatObj()
    {
        SetPos(m_npcinfo.vector3);
        base.CreatObj();

    }
    public override void OnCreat()
    {
        base.OnCreat();
        Debug.Log("����NPC");
    }
    //����λ��
    public override void SetPos(Vector3 pos)
    {
        base.SetPos(pos);
    }
}
