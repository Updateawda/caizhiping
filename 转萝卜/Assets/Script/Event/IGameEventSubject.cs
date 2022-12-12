using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameEventSubject
{
    private List<IGameEventObserver> _observers = new List<IGameEventObserver>();
    public object[] date;
    public void Add(IGameEventObserver observer)
    {
        _observers.Add(observer);
    }
    public void Remove(IGameEventObserver observer)
    {
        _observers.Remove(observer);
    }
    public void Notify()
    {
        for (int i = 0; i < _observers.Count; i++)
        {
            _observers[i].Update();
        }
    }
    public void SetDate(object[] objects)
    {
        date = objects;
    }
}
