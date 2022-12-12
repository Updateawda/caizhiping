using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkmanager : MonoBehaviour
{
    public GameObject preafb;
    bool flag;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
       
        //点击收集发送
        MsgCenter.Instance.AddListener("S2CCheckClik", (notify) =>
        {
            if (notify.msg.Equals("S2CCheckClik"))
            {
                flag = true;
            }
        });
        
        preafb = Instantiate(Resources.Load<GameObject>("CheckBut"), GameObject.Find("Canvas").transform);
        preafb.SetActive(false);
        preafb.GetComponent<Button>().onClick.AddListener(() =>
        {
            Notification notification = new Notification();
            notification.Refresh("CheckClik", 0);
            MsgCenter.Instance.SendMsg("CheckClik", notification);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (preafb!=null)
        {
            if (flag == true)
            {
                timer += Time.deltaTime;
                preafb.transform.GetChild(1).GetComponent<Scrollbar>().size = timer / 3;
                if (preafb.transform.GetChild(1).GetComponent<Scrollbar>().size == 1)
                {
                    timer = 0;
                    
                    Notification notification = new Notification();
                    notification.Refresh("CheckCompent", 0);
                    MsgCenter.Instance.SendMsg("C2SCheckCompent", notification);
                    flag = false;
                }
            }
            
        }
        
    }
}
