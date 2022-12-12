using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkillWindow : EditorWindow
{
    Player m_Player;
    List<SkillBase> m_skilllist;
    string m_skillName;
    string[] m_skilltype = new string[] { "动画", "音效", "特效" ,"位移"};
    int m_skillid = 0;
    float time,speed=1;
    AnimationClip m_clip;
    AudioClip m_audioClip;
    GameObject m_gameObject;
    float att, dis, ang,CD;
    Vector3 m_v3;
    public void SetDate(List<SkillBase> skillBases,Player player,string name)
    {
        m_skilllist = skillBases;
        m_Player = player;
        m_skillName = name;
    }
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("速度");
        float SP = EditorGUILayout.Slider(speed, 0, 3);
        if (SP != speed)
        {
            speed = SP;
            Time.timeScale = speed;
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        m_skillid = EditorGUILayout.Popup(m_skillid, m_skilltype);
        GUILayout.Space(20);
        if (GUILayout.Button("添加"))
        {
            switch (m_skillid)
            {
                case 0:
                    m_skilllist.Add(new Skill_Anim(m_Player));
                    break;
                case 1:
                    m_skilllist.Add(new Skill_Audio(m_Player));
                    break;
                case 2:
                    m_skilllist.Add(new Skill_Effect(m_Player));
                    break;
                case 3:
                    m_skilllist.Add(new Skill_Move(m_Player));
                    break;
                default:
                    break;
            }
        }
        GUILayout.EndHorizontal();

        for (int i = 0; i < m_skilllist.Count; i++)
        {
            GUILayout.BeginHorizontal();
            var item = m_skilllist[i];
            if (item is Skill_Anim)
            {
                m_clip = EditorGUILayout.ObjectField((item as Skill_Anim).m_clip, typeof(AnimationClip), false) as AnimationClip;
                if (m_clip != null)
                {
                    GUILayout.Label(m_clip.length.ToString());
                }
                GUILayout.Label("延迟时间：");
                time = EditorGUILayout.FloatField((item as Skill_Anim).m_time);
                if ((item as Skill_Anim).m_clip != m_clip || (item as Skill_Anim).m_time != time)
                {
                    (item as Skill_Anim).m_clip = m_clip;
                    (item as Skill_Anim).m_time = time;
                }
            }
            else if (item is Skill_Audio)
            {
                m_audioClip = EditorGUILayout.ObjectField((item as Skill_Audio).m_audioClip, typeof(AudioClip), false) as AudioClip;
                GUILayout.Label("延迟时间：");
                time = EditorGUILayout.FloatField((item as Skill_Audio).m_time);
                if ((item as Skill_Audio).m_audioClip != m_audioClip || (item as Skill_Audio).m_time != time)
                {
                    (item as Skill_Audio).m_audioClip = m_audioClip;
                    (item as Skill_Audio).m_time = time;
                }
            }
            else if (item is Skill_Effect)
            {
                m_gameObject = EditorGUILayout.ObjectField((item as Skill_Effect).m_effect, typeof(GameObject), false) as GameObject;
                GUILayout.Label("延迟时间：");
                time = EditorGUILayout.FloatField((item as Skill_Effect).m_time);
                if ((item as Skill_Effect).m_effect != m_gameObject || (item as Skill_Effect).m_time != time)
                {
                    (item as Skill_Effect).m_effect = m_gameObject;
                    (item as Skill_Effect).m_time = time;
                }
            }
            else if (item is Skill_Move)
            {
                m_v3 = EditorGUILayout.Vector3Field("", (item as Skill_Move).m_position);
                GUILayout.Label("延迟时间：");
                time = EditorGUILayout.FloatField((item as Skill_Move).m_time);
                if ((item as Skill_Move).m_position != m_v3 || (item as Skill_Move).m_time != time)
                {
                    (item as Skill_Move).m_position = m_v3;
                    (item as Skill_Move).m_time = time;
                }
            }
            GUILayout.Space(10);


            if (GUILayout.Button("删除"))
            {
                m_skilllist.Remove(item);
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(20);
        }

        GUILayout.BeginVertical();
        GUILayout.Label("攻击力");
        if (m_Player.playUse.playdic.ContainsKey(m_skillName))
        {
            m_Player.playUse.playdic[m_skillName].attack = EditorGUILayout.FloatField(m_Player.playUse.playdic[m_skillName].attack);
            att = m_Player.playUse.playdic[m_skillName].attack;
        }
        else
        {
            att = EditorGUILayout.FloatField(att);
        }

        GUILayout.Space(10);
        GUILayout.Label("攻击距离");
        if (m_Player.playUse.playdic.ContainsKey(m_skillName))
        {
            m_Player.playUse.playdic[m_skillName].attdistance = EditorGUILayout.FloatField(m_Player.playUse.playdic[m_skillName].attdistance);
            dis = m_Player.playUse.playdic[m_skillName].attdistance;
        }
        else
        {
            dis = EditorGUILayout.FloatField(dis);
        }
        GUILayout.Space(10);
        GUILayout.Label("攻击角度");
        if (m_Player.playUse.playdic.ContainsKey(m_skillName))
        {
            m_Player.playUse.playdic[m_skillName].attaugle = EditorGUILayout.FloatField(m_Player.playUse.playdic[m_skillName].attaugle);
            ang = m_Player.playUse.playdic[m_skillName].attaugle;
        }
        else
        {
            ang = EditorGUILayout.FloatField(ang);
        }
        GUILayout.Space(10);
        GUILayout.Label("技能CD:");
        if (m_Player.playUse.playdic.ContainsKey(m_skillName))
        {
            m_Player.playUse.playdic[m_skillName].CD = EditorGUILayout.FloatField(m_Player.playUse.playdic[m_skillName].CD);
            CD = m_Player.playUse.playdic[m_skillName].CD;
        }
        else
        {
            CD = EditorGUILayout.FloatField(CD);
        }
        GUILayout.EndVertical();
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("播放"))
        {
            m_Player.Play(m_skillName);
        }
        if (GUILayout.Button("保存配置"))
        {
            
            List<SkillBase> skill = new List<SkillBase>();
            skill = m_skilllist;
            m_Player.Skilldic[m_skillName] = skill;
            m_Player.playUse.playdic[m_skillName] = new SkillDate();
            m_Player.playUse.playdic[m_skillName].attack = att;
            m_Player.playUse.playdic[m_skillName].attaugle = ang;
            m_Player.playUse.playdic[m_skillName].attdistance = dis;
            m_Player.playUse.playdic[m_skillName].CD = CD;
           
        }
        GUILayout.EndHorizontal();
    }
}
