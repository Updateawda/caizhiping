using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{ 
    Animator m_animator;
    /*Player m_player;
    public Action actionW;
    public Action actionA;
    public Action actionS;
    public Action actionD;*/
    // Start is called before the first frame update
    void Start()
    {
        m_animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        if (x != 0 || y != 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10 * x);
            transform.Rotate(Vector3.up * Time.deltaTime * 80 * y);
            m_animator.SetBool("Move", true);
        }
        else
        {
            if (m_animator.GetBool("Move"))
            {
                m_animator.SetBool("Move", false);
            }

        }
    }
   /* public void SetPlay(Player player)
    {
        m_player = player;
    }*/
}
