using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    SceneControll SceneControll;
    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(this);
        SceneControll=new SceneControll();
        SceneControll.SetsceneStart(new MainScene(SceneControll), "MainScene");
    }

    // Update is called once per frame
    void Update()
    {
        SceneControll.SetsceneUpdate();
    }
}
