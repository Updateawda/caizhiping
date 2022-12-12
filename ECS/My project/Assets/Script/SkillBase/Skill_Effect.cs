using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Skill_Effect : SkillBase
{
    Player m_play;
    public GameObject m_effect;
    ParticleSystem m_particleSystem;
    public float m_time=0f;
    GameObject eff;
    public Skill_Effect(Player player)
    {
        m_play = player;
    }
   
    public override async void Play()
    {
        
        base.Play();
        //await Task.Delay((int)(m_time / Time.timeScale * 1000));
        if (eff == null)
        {
            eff = GameObject.Instantiate(m_effect);
           
        }
        ParticleSystem[] particles = eff.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].loop = false;
        }
        eff.transform.position = m_play.transform.position;
        eff.transform.eulerAngles = m_play.transform.eulerAngles;
        eff.transform.parent = m_play.transform;
        if (eff.GetComponent<ParticleSystem>() != null)
        {
            m_particleSystem = eff.GetComponent<ParticleSystem>();
            m_particleSystem.Play();
        }


    }
}
