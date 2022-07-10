using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : BaseController<UIGameOverRoot>
{
    public GameModel gameModel;
    public override void EngageController()
    {
        base.EngageController();
        if(gameModel.gameOverState == "LOST")
        {
            CreateLostView();
        } else
        {
            CreateWinView();
        }
    }

    public override void DisengageController()
    {
        base.DisengageController();
    }

    public void CreateLostView()
    {
        ui.UpdateTitle("You LOST!");
    }

    public void CreateWinView()
    {
        ui.UpdateTitle("You WON!");
    }
}
