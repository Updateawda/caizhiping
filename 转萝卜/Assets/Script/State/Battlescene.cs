using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlescene : Iscene
{

    public Battlescene(SceneControll sceneControll) : base(sceneControll)
    {
    }
    public override void Start()
    {
        Facade.Instance.Initialize();
    }
    public override void Update()
    {
        Facade.Instance.Update();
    }
    public override void End()
    {
        Facade.Instance.Release();
    }
}
