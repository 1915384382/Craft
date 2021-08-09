using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel :MonoBehaviour
{
    private void Awake()
    {
        UIController.Instance.panels.Add(this);
    }
    public virtual void OnOpenPanel() { }
    public virtual void OnClosePanel() { }
    public virtual void InitPanel() { }
    public virtual void RegistEvent() { }
    public virtual void UnRegistEvent() { }
}
public class MainPanel : Panel
{
    public Text playerHpText;
    public Button reset;
    public override void RegistEvent()
    {
        GameManager.Instance.actionHpChange += Instance_actionHpChange; 
    }
    public override void UnRegistEvent()
    {
        GameManager.Instance.actionHpChange -= Instance_actionHpChange; 
    }
    private void Instance_actionHpChange(CraftCtrl arg1, int arg2)
    {
        if (arg1 is AirrCraftController)
        {
            playerHpText.text = GameManager.Instance.AddString("玩家血量：", arg2.ToString());
        }
    }
    public void ResetGame() 
    {

    }
}
