using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController<UIMenuRoot>
{
    public override void EngageController()
    {
        
        base.EngageController();
        NormalGameInit();
    }

    public void NormalGameInit()
    {
        ui.OnGameStart += StartGame;

        Time.timeScale = 0f;
    }

    public void ForDebuggingGameInit()
    {
        root.ChangeController(RootController.ControllerTypeEnum.Game);
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
