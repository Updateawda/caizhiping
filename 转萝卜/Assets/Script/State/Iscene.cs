using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iscene
{
    protected SceneControll sceneControll;
    private string sceneName;
    public string SceneName
    {
        get { return sceneName; }
    }

    public Iscene(SceneControll sceneControll)
    {
        this.sceneControll = sceneControll;
    }
    public virtual void Start() { }
    public virtual void End() { }
    public virtual void Update() { }
}
