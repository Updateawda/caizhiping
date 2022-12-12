using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;


#region ����ί�е��¼�����
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
    //�洢��Ϣ�ļ���
    Dictionary<string, Action<Notification>> m_MsgDicts = new Dictionary<string, Action<Notification>>();
    /// <summary>
    /// ע������ķ���
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
    /// ���ע��ķ���
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
    /// �㲥�ķ���
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
/// ��Ϣ����ö��
/// </summary>
/// <summary>
/// ��Ϣ��
/// </summary>
public class Notification
{
    //��Ϣ����
    public string msg;
    //�洢��Ϣ�ļ���
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
