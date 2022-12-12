using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MapSystem : Isystem
{
    public List<GameObject> objects=new List<GameObject> ();
    Transform Path;
    int lastindex;
    public MapSystem(Facade facade) : base(facade)
    {
        Initialize(); 
    }
    public override void Initialize()
    {
        Path = UITool.FindUIGameObject("Path").transform;
        Creat();
        Notification notification = new Notification();
        notification.Refresh("MapList", objects);
        MsgCenter.Instance.SendMsg("MapList", notification);
        //监听创建陷阱消息
        MsgCenter.Instance.AddListener("fixationTrap", (notify) => CreatTarp(notify));
        MsgCenter.Instance.AddListener("RandomTrap", (notify) => RandomCreatTarp(notify));
    }
    /// <summary>
    /// 创建随机陷阱
    /// </summary>
    /// <param name="notification"></param>
    private void RandomCreatTarp(Notification notification)
    {
        if (lastindex!=-1)
        {
            CancelTarp(lastindex);
        }
        objects[(int)notification.data[0]].GetComponent<Image>().color = Color.black;
        lastindex = (int)notification.data[0];
    }
    /// <summary>
    /// 删除上一个陷阱
    /// </summary>
    /// <param name="notification"></param>
    private void CancelTarp(int index)
    {
        objects[index].GetComponent<Image>().color = Color.white;
    }
    /// <summary>
    /// 创建固定陷阱
    /// </summary>
    /// <param name="notification"></param>
    private void CreatTarp(Notification notification)
    {
        objects[(int)notification.data[0]].GetComponent<Image>().color = Color.black;
    }
    /// <summary>
    /// 创建地图
    /// </summary>
    public void Creat()
    {
        int[,] map = MapInfo.Instance.map;
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == 1)
                {
                    GameObject item = GameObject.Instantiate(Resources.Load<GameObject>("Item"), Path);
                    item.transform.localPosition = new Vector3(-585 + (j * 105), 326 - (i * 105), 0);
                    objects.Add(item);
                }
            }
        }
    }
    public override void Release()
    {

    }
    public override void Update()
    {

    }

}
