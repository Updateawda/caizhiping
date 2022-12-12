using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : Uibase
{

    public override void DoCreate(string path)
    {
        base.DoCreate(path);
    }
    public override void DoShow(bool active)
    {
        base.DoShow(active);
        m_go.transform.localPosition = new Vector3(-322, 65, 0);
        m_go.transform.GetChild(0).GetComponent<Text>().text = "接受任务";
        m_go.GetComponent<Button>().onClick.AddListener(() =>
        {
            m_go.SetActive(false);
            Notification notification = new Notification();
            notification.Refresh("C2SAcceptTask", 0);
            MsgCenter.Instance.SendMsg("C2SAcceptTask", notification);
        });
        //接受任务完成
        MsgCenter.Instance.AddListener("S2CAcceptTask", (notify) =>
        {
            if (notify.msg.Equals("S2CAcceptTask"))
            {
                Debug.Log("接受任务");
                TaskScroll uibase = new TaskScroll();
                uibase.tasks = notify.data[0] as List<Task>;
                uibase.DoCreate("TaskScrollView");
            }
        });
    }

}

public class TaskScroll:Uibase
{
    public List<Task> tasks = new List<Task>();
    public Transform conect;
    public override void DoCreate(string path)
    {
        base.DoCreate(path);
        m_go.transform.localPosition = new Vector3(-322, 65, 0);
    }
    public override void DoShow(bool active)
    {
        base.DoShow(active);
        for (int i = 0; i < tasks.Count; i++)
        {
            GameObject item = GameObject.Instantiate(Resources.Load<GameObject>("TaskItem"), m_go.transform.Find("Viewport/Content"));
            item.transform.GetChild(0).GetComponent<Text>().text = tasks[i].name;
            item.transform.GetChild(1).GetComponent<Text>().text = tasks[i].des;
        }
       
    }
}
