
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isystem 
{
    protected ICommand command;
    protected Facade facade1 = null;
    public Isystem(Facade facade)
    {
        facade1 = facade;
    }

    public virtual void Initialize() { }
    public virtual void Release() { }
    public virtual void Update() { }
}
