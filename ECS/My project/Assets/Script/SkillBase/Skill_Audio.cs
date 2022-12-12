using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Skill_Audio : SkillBase
{
    Player m_player;
    public AudioClip m_audioClip;
    AudioSource m_audioSource;
    public float m_time;
    public Skill_Audio(Player player)
    {
        m_player = player;
        m_audioSource = player.GetComponent<AudioSource>();
    }
   
    public override async void Play()
    {
        base.Play();
        //await Task.Delay((int)(m_time / Time.timeScale * 1000));
        m_audioSource.clip = m_audioClip;
        m_audioSource.Play();
    }
}
