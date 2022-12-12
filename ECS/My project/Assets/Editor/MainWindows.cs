using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static UnityEditor.Progress;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;

public class MainWindows : EditorWindow
{
    List<string> m_rolename = new List<string>();
    int m_roletypeIndex = 0;
    int m_rolenameIndex = 0;
    SkillWindow m_skillWindow;
    UseDate m_useDate = new UseDate();
    Player m_player;
    string m_skillname,rolename,path;
    //bool flag=false;
    [MenuItem("Tools/Windows")]
    public static void Init()
    {
        if (Application.isPlaying)
        {
            MainWindows window = EditorWindow.GetWindow<MainWindows>();
            if (window != null)
            {
                window.Show();
            }
        }
            
        
       
    }
    private void OnEnable()
    {
        string[] Roletype = Directory.GetDirectories("Assets/ImportAssets/Act/Warrior");
        for (int i = 0; i < Roletype.Length; i++)
        {
            m_rolename.Add(Path.GetFileName(Roletype[i]));
        }
    }
    private void OnGUI()
    {
        

        GUILayout.BeginHorizontal();
        GUILayout.Label("选择角色");
        m_rolenameIndex = EditorGUILayout.Popup(m_useDate.m_roleindex, m_rolename.ToArray());
        if (m_useDate.m_roleindex != m_rolenameIndex)
        {
            m_useDate.m_roleindex = m_rolenameIndex;
            rolename= m_rolename[m_rolenameIndex];
            GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Role/" + rolename + ".prefab");
            path = "Assets/Resources/Role/" + rolename + ".prefab";
            m_player = Player.Init(go, rolename);
            
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(20);

       
        GUILayout.BeginHorizontal();
        GUILayout.Label("技能名称：");
        m_skillname = GUILayout.TextField(m_skillname);
        if (GUILayout.Button("添加技能"))
        {
            if ( m_skillname !=null&&m_player!=null)
            {
                m_skillWindow = EditorWindow.GetWindow<SkillWindow>("");
                m_player.Skilldic[m_skillname] = new List<SkillBase>();
                if (m_player.Skilldic.ContainsKey(m_skillname))
                {
                    if (m_skillWindow != null)
                    {
                        m_skillWindow.titleContent = new GUIContent(m_skillname);
                        m_skillWindow.Show();
                        m_skillWindow.SetDate(m_player.Skilldic[m_skillname], m_player, m_skillname);
                    }
                }
                else
                {
                    if (m_skillWindow != null)
                    {
                        m_skillWindow.titleContent = new GUIContent(m_skillname);
                        m_skillWindow.Show();
                        m_skillWindow.SetDate(new List<SkillBase>(), m_player, m_skillname);
                    }
                }
               
               
            }
            m_skillname = null;
            
        }
        GUILayout.EndHorizontal();

        if (m_player != null)
        {
            if (m_player.Skilldic != null)
            {
                foreach (var item in m_player.Skilldic)
                {
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button(item.Key, new GUILayoutOption[] { GUILayout.Width(200) }))
                    {

                        m_skillWindow = EditorWindow.GetWindow<SkillWindow>("");
                        if (m_skillWindow != null)
                        {
                            m_skillWindow.titleContent = new GUIContent(item.Key);
                            m_skillWindow.Show();
                            m_skillWindow.SetDate(item.Value,m_player, item.Key);
                        }
                    }
                    GUILayout.Space(20);
                    if (GUILayout.Button("预览"))
                    {
                        m_player.Play(item.Key);
                    }
                    GUILayout.EndHorizontal();
                }
            }
            
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("保存配置"))
        {
               foreach (var sk in m_player.Skilldic)
                {
                    m_player.playUse.playdic[sk.Key].m_compath.Clear();
                    m_player.playUse.playdic[sk.Key].m_time.Clear();
                    foreach (var value in sk.Value)
                    {
                        if (value is Skill_Anim)
                        {
                            m_player.playUse.playdic[sk.Key].m_compath.Add(AssetDatabase.GetAssetPath((value as Skill_Anim).m_clip));
                            m_player.playUse.playdic[sk.Key].m_time.Add((value as Skill_Anim).m_time);
                        }
                        else if (value is Skill_Audio)
                        {
                            m_player.playUse.playdic[sk.Key].m_compath.Add(AssetDatabase.GetAssetPath((value as Skill_Audio).m_audioClip));
                            m_player.playUse.playdic[sk.Key].m_time.Add((value as Skill_Audio).m_time);
                        }
                        else if (value is Skill_Effect)
                        {
                            m_player.playUse.playdic[sk.Key].m_compath.Add(AssetDatabase.GetAssetPath((value as Skill_Effect).m_effect));
                            m_player.playUse.playdic[sk.Key].m_time.Add((value as Skill_Effect).m_time);
                        }
                        else if (value is Skill_Move)
                        {
                            m_player.playUse.playdic[sk.Key].m_pos_x = (value as Skill_Move).m_position.x;
                            m_player.playUse.playdic[sk.Key].m_pos_y = (value as Skill_Move).m_position.y;
                            m_player.playUse.playdic[sk.Key].m_pos_z = (value as Skill_Move).m_position.z;
                            m_player.playUse.playdic[sk.Key].m_movetime= (value as Skill_Move).m_time;
                    }
                    }
                  
                    
                }

            m_player.playUse.m_name = rolename;
            m_player.playUse.m_path = path;
            File.WriteAllText("Assets/Script/Date/" + rolename + ".json", JsonConvert.SerializeObject(m_player.playUse));
            File.WriteAllText("Assets/Script/Date/play.json", JsonConvert.SerializeObject(m_player.playUse));
            AssetDatabase.Refresh();
            GameInit.SetDate();
            Debug.Log("保存成功");
        }
        GUILayout.EndHorizontal();
    }
    private void OnDestroy()
    {
        if (m_skillWindow!=null)
        {
            m_skillWindow.Close();
        }
        
    }

}
