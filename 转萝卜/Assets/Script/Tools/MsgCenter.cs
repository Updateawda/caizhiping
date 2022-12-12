using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;


#region 基于委托的事件中心
public class MsgCenter 
{
    private static MsgCenter _instance;
    public static MsgCenter Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MsgCenter();
            return _instance;
        }
    }
    //public static MsgCenter Instance { get; private set; }
    //存储消息的集合
    Dictionary<string, Action<Notification>> m_MsgDicts = new Dictionary<string, Action<Notification>>();
    /// <summary>
    /// 注册监听的方法
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="action"></param>
    public void AddListener(string msg, Action<Notification> action)
    {
        if (!m_MsgDicts.ContainsKey(msg))
        {
            m_MsgDicts.Add(msg, null);
        }
        m_MsgDicts[msg] += action;
    }

    /// <summary>
    /// 解除注册的方法
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="action"></param>
    public void RemoveListener(string msg, Action<Notification> action)
    {
        if (m_MsgDicts.ContainsKey(msg))
        {
            m_MsgDicts[msg] -= action;
            if (m_MsgDicts[msg] == null)
            {
                m_MsgDicts.Remove(msg);
            }
        }
    }

    /// <summary>
    /// 广播的方法
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="notify"></param>
    public void SendMsg(string msg, Notification notify)
    {
        if (m_MsgDicts.ContainsKey(msg))
        {
            m_MsgDicts[msg].Invoke(notify);
        }
    }

    internal void AddListener(string v1, object v2)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// 消息类型枚举
/// </summary>
/// <summary>
/// 消息类
/// </summary>
public class Notification
{
    //消息类型
    public string msg;
    //存储消息的集合
    public object[] data;

    public void Refresh(string msg, params object[] data)
    {
        this.msg = msg;
        this.data = data;
    }
    public void Clear()
    {
        msg = string.Empty;
        data = null;
    }
}
#endregion
