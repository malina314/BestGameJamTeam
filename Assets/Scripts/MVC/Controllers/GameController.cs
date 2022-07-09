using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController<UIGameRoot>
{
    [SerializeField] private GameModel gameModel;
    public override void EngageController()
    {
        base.EngageController();
        ui.SetupTurretsDragging(gameModel.GameCanvasScaler);  
    }

    public override void DisengageController()
    {
        base.DisengageController();
    }
}
