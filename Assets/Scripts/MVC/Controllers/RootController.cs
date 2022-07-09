using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    /// <summary>
    /// Every new type must be added as case in ChangeController() and in DisengageController()
    /// </summary>
    public enum ControllerTypeEnum 
    {
        Menu,
        Game,
        GameOver
    }

    [Header("Controllers")]
    [SerializeField] private MenuController menuController;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameOverController gameOverController;

    private void Start()
    {
        QualitySettings.antiAliasing = 0;

        menuController.root = this;
        gameController.root = this;
        gameOverController.root = this;

        ChangeController(ControllerTypeEnum.Menu);
    }

    public void ChangeController(ControllerTypeEnum controllerType)
    {
        DisengageControllers();

        switch (controllerType)
        {
            case ControllerTypeEnum.Menu:
                menuController.EngageController();
                break;
            case ControllerTypeEnum.Game:
                gameController.EngageController();
                break;
            case ControllerTypeEnum.GameOver:
                gameController.EngageController();
                break;

            default:
                Debug.LogError("WHAT HAVE YOU DONE!");
                break;
        }
    }

    private void DisengageControllers()
    {
        menuController.DisengageController();
        gameController.DisengageController();
        gameOverController.DisengageController();
    }
}
