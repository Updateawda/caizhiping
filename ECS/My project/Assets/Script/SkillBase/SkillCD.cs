using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCD : MonoBehaviour
{
    public string Name;
    bool flag;
    float timerdlag,timer;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (flag==false)
            {
                GetComponent<Image>().fillAmount = 0;
                flag = true;
                Notification notification = new Notification();
                notification.Refresh("C2SPlaySkill", Name);
                MsgCenter.Instance.SendMsg("C2SPlaySkill", notification);
                timerdlag = player.playUse.playdic[Name].CD;
                
                
            }
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (flag==true)
        {
            timer += Time.deltaTime;
            GetComponent<Image>().fillAmount =timer/timerdlag;
        }
        if (GetComponent<Image>().fillAmount==1)
        {
            timer = 0;
            flag = false;
        }
    }
}
