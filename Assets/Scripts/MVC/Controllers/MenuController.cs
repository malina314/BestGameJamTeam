using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController<UIMenuRoot>
{
    public override void EngageController()
    {
        ui.InitView();
        base.EngageController();
        ui.OnGameStart += StartGame;
        
        Time.timeScale = 0f;
    }

    public override void DisengageController()
    {
        base.DisengageController();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        root.ChangeController(RootController.ControllerTypeEnum.Game);
        Debug.Log("Started");
    }
}
