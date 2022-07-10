using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIGameRoot : UIRoot
{
    [SerializeField] private UIWarrior warriorPrefab;
    [SerializeField] private GameObject warriorsContainer;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI moneyText;
    public override void InitView()
    {
        base.InitView();
    }

    public override void HideView()
    {
        base.HideView();
    }
    
    public void AddWarriors(List<WarriorData> warriors,UnityAction<PointerEventData,WarriorType> onTurretDragged,CanvasScaler gameCanvasScaler)
    {
        foreach(var warriorData in warriors)
        {
            var copy = Instantiate(warriorPrefab, warriorsContainer.transform);
            copy.Init(warriorData,gameCanvasScaler);
            copy.OnEndDragAction += onTurretDragged;
        }
    }
    public void UpdateHealth(int value)
    {
        healthText.text = value.ToString();
    }

    public void UpdateMoney(int value)
    {
        moneyText.text = $"{value} $";
    }

    public void UpdateWave(string message)
    {
        waveText.text = message;
    }
}
