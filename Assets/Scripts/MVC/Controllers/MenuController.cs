using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController<UIMenuRoot>
{
    public Sprite panel1;
    public Sprite panel2;
    public Sprite panel3;
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
    public IEnumerator showDialog()
    {
        Debug.Log("Hej");
        ui.ChangePanel(panel1);
        yield return new WaitForSeconds(10f);
        ui.ChangePanel(panel2);
        yield return new WaitForSeconds(10f);
        ui.ChangePanel(panel3);
        yield return new WaitForSeconds(10f);

        root.ChangeController(RootController.ControllerTypeEnum.Game);
        Debug.Log("Started");
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
        StartCoroutine(showDialog());
    }
}
