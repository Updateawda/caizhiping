using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonDate
{
    public string m_name;
    public string m_path;
    public int HP;
    public int energy;
    public int mokang;
    public int wukang;
}
public class UseDate
{
    public string m_name;
    public Player m_player;
    public int m_roleindex = -1;
    public int m_roletypeindex = -1;
    public AnimationClip m_clip;
    public AudioClip m_audioClip;
    public GameObject m_gameObject;
    public JsonDate m_role = new JsonDate();
}
public class PlayUse
{
    public string m_name;
    public string m_path;
    public int HP;
    public int energy;
    public int mokang;
    public int wukang;
    public Dictionary<string, SkillDate> playdic = new Dictionary<string, SkillDate>();
}
public class SkillDate
{
    public List<string> m_compath = new List<string>();
    public List<float> m_time = new List<float>();
    public float m_pos_x;
    public float m_pos_y;
    public float m_pos_z;
    public float m_movetime;
    public float attack;
    public float attdistance;
    public float attaugle;
    public float CD;

}

