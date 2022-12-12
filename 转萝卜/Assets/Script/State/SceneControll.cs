using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll
{
    private Iscene scene;
    private AsyncOperation async;
    private bool IsRun=false;
    public void SetsceneStart(Iscene iscene,string Name)
    {
        IsRun = false;
        if(scene!=null)
        {
            scene.End();
        }
        async = SceneManager.LoadSceneAsync(Name);
        scene = iscene;
        
    }
    public void SetsceneUpdate()
    {
        if (!async.isDone)
        {
            return;
        }
        if (scene!=null&&IsRun==false)
        {
            scene.Start();
            IsRun = true;
        }
        if (scene!=null)
        {
            scene.Update();
        }
    }
}
