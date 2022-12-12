using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : Iscene
{
    public MainScene(SceneControll sceneControll) : base(sceneControll)
    {
    }
    public override void Start()
    {
        GameObject but = GameObject.Find("StartBut");
        but.GetComponent<Button>().onClick.AddListener(() =>
        {
            sceneControll.SetsceneStart(new Battlescene(sceneControll), "Battlescene");
        });
    }
}
