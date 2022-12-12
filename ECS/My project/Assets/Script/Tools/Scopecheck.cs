using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scopecheck : MonoBehaviour
{
    public float m_distance = 3f;
    public GameObject m_taget;
    public Action<bool> m_call;
    public bool m_flag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_flag==true)
        {
            if (m_taget!=null)
            {
                if (Vector3.Distance(transform.position, m_taget.transform.position) <= m_distance)
                {
                    m_call(true);
                    m_flag = false;
                }
            }
           
        }
    }
}
