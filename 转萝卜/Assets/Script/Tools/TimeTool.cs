using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTool : MonoBehaviour
{
    private static TimeTool _instance;
    public static TimeTool instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = new TimeTool();                                                                                                                                                                                                                    
            }
            return _instance;
        }
    }

    public float timer;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            timer -= Time.deltaTime;
            if (timer==0)
            {
                Notification notification2 = new Notification();
                notification2.Refresh("TimeOver", true);
                MsgCenter.Instance.SendMsg("TimeOver", notification2);
                flag = false;

            }
        }
    }
}
