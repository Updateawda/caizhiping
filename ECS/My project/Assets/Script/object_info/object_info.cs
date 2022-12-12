using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_info 
{
    public string name;
    public string Path;
    public Vector3 vector3;
    public MonsterType m_type;
    public int ID;
}
public class Playerinfo:object_info
{
    public float m_HP;
    public float m_hpMax;
    public float m_MP;
    public float m_mpMax;
}
public class NPCinfo:object_info
{
    public int m_plotId = 0;
}
public class Enemyinfo : object_info
{
    public float m_HP;
    public float m_MP;
}
public class Gatherinfo:object_info
{

}
