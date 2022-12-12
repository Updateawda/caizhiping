using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeInvoke
{
    public float startTime;
    public float delayTime;
    public Action callBack;

    public TimeInvoke(float startTime, float delayTime, Action callBack)
    {
        this.startTime = startTime;
        this.delayTime = delayTime;
        this.callBack = callBack;
    }
}

public class TimeTool : MonoBehaviour
{

    List<TimeInvoke> timeInvokes = new List<TimeInvoke>();

    /// <summary>
    /// �����ʱ����
    /// </summary>
    /// <param name="delayTime">��ʱʱ��</param>
    /// <param name="callBack">�ص�����</param>
    public void AddTimeInvoke(float startTime, float delayTime, Action callBack)
    {
        timeInvokes.Add(new TimeInvoke(startTime, delayTime, callBack));
    }

    /// <summary>
    /// �Ƴ���ʱ����
    /// </summary>
    /// <param name="startTime"></param>
    public void RemoveTimeInvoke(float startTime)
    {
        for (int i = timeInvokes.Count - 1; i >= 0; i--)
        {
            if (timeInvokes[i].startTime == startTime)
            {
                timeInvokes.RemoveAt(i);
            }
        }
    }

    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        //��ʱ��ʱ����
        for (int i = timeInvokes.Count - 1; i >= 0; i--)
        {
            float currTimes = (DateTime.Now.Ticks - timeInvokes[i].startTime) / 10000000;
            if (currTimes >= timeInvokes[i].delayTime)
            {
                timeInvokes[i].callBack();
                timeInvokes.RemoveAt(i);
            }
        }
    }
}