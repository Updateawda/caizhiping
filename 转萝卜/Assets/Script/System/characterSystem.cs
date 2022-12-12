using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using UnityEngine.Playables;
using System.Threading.Tasks;

public class characterSystem : Isystem
{
    
    GameObject play1,play2;
    List<GameObject> maplist=new List<GameObject>();
    IPlayer player;
    int currindex = -1;//�ж����ĸ���ɫ
    int lasttrap=-1;//��һ�������λ��
    List<int> traplist = new List<int>();//�����λ��
    int play1index = -1;
    int play2index = -1;
    int index = -1;//��ɫ��λ��
    public characterSystem(Facade facade) : base(facade)
    {
        Initialize();
    }
    public override void Initialize()
    {
        Init();
        maplist = Facade.Instance.GetMap().objects;
        command = new PlayCommand();
        command.Execute(play1,play2);
    }
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public void Init()
    {
        MsgCenter.Instance.AddListener("CharactControl", (notify) => PlayMove(notify));
        MsgCenter.Instance.AddListener("TimeOver", (notify) => TimeOver(notify));
        MsgCenter.Instance.AddListener("SetPlat", (notify) => SetPlay(notify));
        //��������������Ϣ
        MsgCenter.Instance.AddListener("fixationTrap", (notify) =>
        {
            traplist.Add((int)notify.data[0]);
        });
        MsgCenter.Instance.AddListener("RandomTrap", (notify) => 
        {
            traplist.Remove(lasttrap);
            traplist.Add((int)notify.data[0]);
            if (traplist.Contains(index))
            {
                player.Triggertrap();
            }
            lasttrap = (int)notify.data[0];
        });
        //�������岽������
        MsgCenter.Instance.AddListener("Triggertrap", (notify) =>
        {
            if (currindex==0)
            {
                play1index = 0;
            }
            else if (currindex==1)
            {
                play2index = 0;
            }
            index = 0;
        });
        //MsgCenter.Instance.AddListener("MapList", (notify) => SetMap(notify));
    }
    public override void Release()
    {
        
    }
    public override void Update()
    {
        
    }
    public void SetPlay(Notification notification)
    {
        play1 = (GameObject)notification.data[0];
        play2 = (GameObject)notification.data[1];
    }
    /// <summary>
    /// ����ƶ�
    /// </summary>
    /// <param name="notification"></param>
    public void PlayMove(Notification notification)
    {
        currindex++;
        if (currindex == 2)
        {
            currindex = 0;
        }
        //�ж��Ƿ��ƶ������Ƿ�Ϊ��
        if ((int)notification.data[0]==0)
        {
            Notification notification2 = new Notification();
            notification2.Refresh("TrapControl", null);
            MsgCenter.Instance.SendMsg("TrapControl", notification2);
            return;
        }
        TimeMove((int)notification.data[0]);
        
        
    }
    private async void TimeMove(int num)
    {
        
        while (num!=0)
        {
            
            if (currindex == 0)
            {
                player = new Player1(maplist);
                player.play = play1;
                play1index ++;
                index = play1index;
            }
            else
            {
                player = new Player2(maplist);
                player.play = play2;
                play2index ++; 
                index = play2index;
            }
            player.Move(index);
            await Task.Delay(500);
            num--;
        }
       
        if (play2index == play1index)
        {
            if (currindex == 0)
            {
                play1index++;
            }
            else if (currindex == 1)
            {
                play2index++;
            }
            Debug.Log("��ǰλ�ô�����ң�������ǰ��һ��");
            index++;
        }
        if (index >= maplist.Count - 1)
        {
            index = maplist.Count - 1;
            //֪ͨview����Ϸʤ��
            Notification notification2 = new Notification();
            notification2.Refresh("GameVirtory", currindex);
            MsgCenter.Instance.SendMsg("GameVirtory", notification2);
            return ;
        }
        if (traplist.Contains(index))
        {
            player.Triggertrap();
            return;
        }
        player.Move(index);

    }
    private void TimeOver(Notification notification)
    {

    }


}
