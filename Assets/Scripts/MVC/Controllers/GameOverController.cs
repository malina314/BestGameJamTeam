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
        ui.UpdateMessage("Khotyn has been taken over. Your army retreats north, leaving behind many perished soldiers. Dark days await the Commonwealth as the now seemingly undefeatable Ottoman army march onward, wrecking havoc on the lands of Ukraine.");
    }

    public void CreateWinView()
    {
        ui.UpdateTitle("You WON!");
        ui.UpdateMessage("Victory! Thanks to the help of the Cossacks the Commonwealth will love to see another day. The largest military battle of the Polish-Lithuanian Commonwealth to date, it will go down in history for securing its place in Europe and stopping the westward march of the Ottoman Empire.");
    }
}
