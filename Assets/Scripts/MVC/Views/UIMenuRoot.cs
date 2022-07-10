using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIMenuRoot : UIRoot
{
    [SerializeField] private Button startButton;
    [SerializeField] private Image dialogPanel;

    public override void InitView()
    {
        base.InitView();
        startButton.onClick.AddListener(GameStart);
    }

    public override void HideView()
    {
        base.HideView();
    }

    public UnityAction OnGameStart;

    public void GameStart()
    {
        Debug.Log("hej?");
        OnGameStart?.Invoke();
    }

    public void ChangePanel(Sprite sprite)
    {
        dialogPanel.gameObject.SetActive(true);
        dialogPanel.sprite = sprite;
    }
}
