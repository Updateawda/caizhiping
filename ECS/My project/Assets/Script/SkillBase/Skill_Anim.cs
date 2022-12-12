using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Skill_Anim : SkillBase
{
    Player m_player;
    public AnimationClip m_clip;
    AnimatorOverrideController m_overrideController;
    Animator m_anim;
    public float m_time;
    public Skill_Anim(Player player)
    {
        m_player = player;
        m_anim = player.GetComponent<Animator>();
        m_overrideController = player.m_overrideController;
    }
    
    public override async void Play()
    {
        base.Play();
       // await Task.Delay((int)(m_time / Time.timeScale * 1000));
        m_overrideController["Skill"] = m_clip;
        m_anim.StopPlayback();
        AnimatorStateInfo stateInfo = m_anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Idle"))
        {
            m_anim.SetTrigger("Skill");
        }

    }

}
