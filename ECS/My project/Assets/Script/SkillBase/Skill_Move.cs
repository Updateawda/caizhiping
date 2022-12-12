using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Skill_Move : SkillBase
{
    Player m_player;
    public Vector3 m_position;
    public float m_time;
    public Skill_Move(Player player)
    {
        m_player = player;
       
    }

    public override async void Play()
    {
        base.Play();
        //await Task.Delay((int)(m_time / Time.timeScale * 1000));
        m_player.transform.Translate(m_position);
    }
}
