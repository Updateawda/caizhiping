using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : IUserInterface
{
    private Button Luobo;
    private GameObject GameVirtoryUI;
    public UIGame(Facade facade) : base(facade)
    {
        Initialize();
    }
    public override void Show()
    {
        
    }
    public override void Hide()
    {
        
    }
    public override void Initialize()
    {
        MsgCenter.Instance.AddListener("GameVirtory", (notify) => GameVirtory(notify));
        Luobo = UITool.GetUIComponent<Button>("luobo");
        Luobo.onClick.AddListener(()=>ZhuanLuobo());
    }
    /// <summary>
    /// 弹出游戏胜利面板
    /// </summary>
    /// <param name="notification"></param>
    public void GameVirtory(Notification notification)
    {
        if (GameVirtoryUI==null)
        {
            GameVirtoryUI = GameObject.Instantiate(Resources.Load<GameObject>("jifen"), UITool.FindUIGameObject("Canvas").transform);
        }
        Text GameVirtoryUItext = GameVirtoryUI.transform.Find("Text").GetComponent<Text>();
        if ((int)notification.data[0]==0)
        {
            GameVirtoryUItext.text = "蓝方胜利";
        }
        else
        {
            GameVirtoryUItext.text = "红方胜利";
        }
    }
    public override void Release()
    {

    }
    public override void Update()
    {
        
    }
    /// <summary>
    /// 转萝卜按钮
    /// </summary>
    public void ZhuanLuobo()
    {
        Notification notification=new Notification();
        notification.Refresh("ZhuanLuobo", null);
        MsgCenter.Instance.SendMsg("ZhuanLuobo", notification);
    }
}
