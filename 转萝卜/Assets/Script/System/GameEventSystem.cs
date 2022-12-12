using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_GameEvent
{
    Null = 0,
    PlayMove = 1,
    Triggertrap = 2,
}
public class GameEventSystem : Isystem
{
    private Dictionary<ENUM_GameEvent,IGameEventSubject> m_eventdic=new Dictionary<ENUM_GameEvent, IGameEventSubject> ();
    public GameEventSystem(Facade facade) : base(facade)
    {
        Initialize();
    }
    public override void Initialize()
    {
       
    }
    public override void Release()
    {

    }
    public override void Update()
    {

    }
    /// <summary>
    /// 注册观察者
    /// </summary>
    public void RegisterObserver(ENUM_GameEvent gameEvent,IGameEventObserver observer)
    {
        if (!m_eventdic.ContainsKey(gameEvent))
        {
            IGameEventSubject gameEventSubject = null;
            switch (gameEvent)
            {
                case ENUM_GameEvent.PlayMove:
                    gameEventSubject = new PlayMoveSubject();
                    break;
                case ENUM_GameEvent.Triggertrap:
                    gameEventSubject = new TriggertrapSubject();
                    break;
                default:
                    break;
            }
            m_eventdic.Add(gameEvent, gameEventSubject);
        }
        m_eventdic[gameEvent].Add(observer);
        observer.SetDate();
    }
    /// <summary>
    /// 通知事件
    /// </summary>
    public void NotifySubject(ENUM_GameEvent gameEvent, object[] objects)
    {
        if (m_eventdic.ContainsKey(gameEvent))
        {
            m_eventdic[gameEvent].SetDate(objects);
        }
    }
}
