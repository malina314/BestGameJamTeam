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
        ui.UpdateMessage("Khotyn has been taken over. Your army retreats north, defeated. Dark days await the Commonwealth as the now seemingly undefeatable Ottoman army march onward, wrecking havoc on the lands of Ukraine.");
    }

    public void CreateWinView()
    {
        ui.UpdateTitle("You WON!");
    }
}
