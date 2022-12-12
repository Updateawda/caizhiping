using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class ObjectBase
{
    public string m_name;
    public GameObject m_go;
    public Vector3 m_pos;
    public MonsterType m_monsterType;
    public int m_insID;
    public string m_modelPath;
    public ObjectBase()
    {

    }
    public virtual void CreatObj()
    {
        //m_monsterType = monsterType;
        if (!string.IsNullOrEmpty(m_modelPath))
        {
            m_go = GameObject.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(m_modelPath));
            m_go.transform.position = m_pos;
            m_go.transform.name = m_name;
            if (m_go!=null)
            {
                OnCreat();
            }
        }
    }
    public virtual void OnCreat()
    {
        
    }

    //…Ë÷√Œª÷√
    public virtual void SetPos(Vector3 pos)
    {
        m_pos = pos;
    }
}
