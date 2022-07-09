using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController<UIMenuRoot>
{
    public override void EngageController()
    {
        base.EngageController();
        root.ChangeController(RootController.ControllerTypeEnum.Game);
    }

    public override void DisengageController()
    {
        base.DisengageController();
    }
}
