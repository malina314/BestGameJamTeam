using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : BaseController<UIGameRoot>
{
    [SerializeField] private GameModel gameModel;
    public override void EngageController()
    {
        base.EngageController();
        ui.AddWarriors(gameModel.Warriors,OnTurretDragged,gameModel.GameCanvasScaler);  
    }

    public override void DisengageController()
    {
        base.DisengageController();
    }

    public void OnTurretDragged(PointerEventData eventData,WarriorType warriorType)
    {
        Debug.Log($"Warrior type {warriorType}");
    }
}
