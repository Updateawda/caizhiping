using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Xml.Linq;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public Dictionary<string,List<SkillBase>> Skilldic=new Dictionary<string, List<SkillBase>>();
    public PlayUse playUse = new PlayUse();
    public Playerinfo playerinfo;
    Animator m_animator;
    RuntimeAnimatorController controller;
    RuntimeAnimatorController controllerflag;

    public Transform m_effect;
    public AnimatorOverrideController m_overrideController;
    // Start is called before the first frame update

    public static Player Init(GameObject go,string name)
    {
        Player player = null;
        player =go.AddComponent<Player>();
        player.m_overrideController = new AnimatorOverrideController();
        player.controllerflag = player.GetComponent<Animator>().runtimeAnimatorController;
        player.controller = Resources.Load<RuntimeAnimatorController>("Player");
        player.m_overrideController.runtimeAnimatorController = player.controller;
        player.m_animator = player.GetComponent<Animator>();
        player.m_animator.runtimeAnimatorController = player.m_overrideController;
        player.m_overrideController["Idle"] = AssetDatabase.LoadAssetAtPath<AnimationClip>("Assets/ImportAssets/Act/Warrior/"+name+"/Action/N_ds_stand_01.FBX");
        player.m_overrideController["Run"] = AssetDatabase.LoadAssetAtPath<AnimationClip>("Assets/ImportAssets/Act/Warrior/" + name + "/Action/N_ds_run_01.FBX");
        player.LoadJson(name);
        return player;
    }
    //人物加载读取JSON
    public void LoadJson(string name)
    {
        if (File.Exists("Assets/Script/Date/"+name+".json"))
        {
            playUse= JsonConvert.DeserializeObject<PlayUse>(File.ReadAllText("Assets/Script/Date/" + name + ".json"));
            foreach (var item in playUse.playdic)
            {
                List<SkillBase> skillBases = new List<SkillBase>();
                for (int i = 0; i < item.Value.m_compath.Count; i++)
                {
                    var go = AssetDatabase.LoadAssetAtPath<Object>(item.Value.m_compath[i]);
                    if (go is AnimationClip)
                    {
                        Skill_Anim _Anim = new Skill_Anim(this);
                        _Anim.m_clip = go as AnimationClip;
                        _Anim.m_time = item.Value.m_time[i];
                        skillBases.Add(_Anim);
                    }
                    else if (go is AudioClip)
                    {
                        Skill_Audio _Anim = new Skill_Audio(this);
                        _Anim.m_audioClip = go as AudioClip;
                        _Anim.m_time = item.Value.m_time[i];
                        skillBases.Add(_Anim);
                    }
                    else if (go is GameObject)
                    {
                        Skill_Effect _Anim = new Skill_Effect(this);
                        _Anim.m_effect = go as GameObject;
                        _Anim.m_time = item.Value.m_time[i];
                        skillBases.Add(_Anim);
                    }
                }
                if (item.Value.m_pos_x != 0 || item.Value.m_pos_y != 0 || item.Value.m_pos_z != 0)
                {
                    Skill_Move _Anim = new Skill_Move(this);
                    _Anim.m_position = new Vector3(item.Value.m_pos_x, item.Value.m_pos_y, item.Value.m_pos_z);
                    _Anim.m_time = item.Value.m_movetime;
                    skillBases.Add(_Anim);
                }

                Skilldic.Add(item.Key, skillBases);
            }
        }
    }
    private void Start()
    {
        GameObject but = GameObject.Find("Skill");
        for (int i = 0; i < but.transform.childCount; i++)
        {
            but.transform.GetChild(i).GetComponent<SkillCD>().player = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string name)
    {
        if(Skilldic.ContainsKey(name))
        {
            foreach (var item in Skilldic[name])
            {
                item.Play();
            }
        }
        
    }
}
