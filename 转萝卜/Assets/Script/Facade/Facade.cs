using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facade
{
    private static Facade _instance;
    public static Facade Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Facade();
            return _instance;
        }
    }
    private characterSystem _characterSystem;//角色系统
    private RandomSystem _randomSystem;//随机系统
    private MapSystem _mapSystem;
    private TrapSystem _trapSystem;

    private UIGame _gameui;//UI界面

    public void Initialize()
    {
        _mapSystem = new MapSystem(this);
        _characterSystem =new characterSystem(this);
        _gameui = new UIGame(this);
        _randomSystem=new RandomSystem(this);
        _trapSystem=new TrapSystem(this);
    }

    public void Release()
    {
        _characterSystem.Release();
        _gameui.Release();
        _randomSystem.Release();
        _mapSystem.Release();
        _trapSystem.Release();
    }
    public void Update()
    {
        _characterSystem.Update();
        _gameui.Update();
        _randomSystem.Update();
        _mapSystem.Update();
        _trapSystem.Update();
    }
    /// <summary>
    /// 注册事件
    /// </summary>
    public void RegisterGameEvent()
    {

    }
    /// <summary>
    /// 通知事件
    /// </summary>
    public void NotifyGameEvent()
    {

    }
    public MapSystem GetMap()
    {
        return _mapSystem;
    }
}
