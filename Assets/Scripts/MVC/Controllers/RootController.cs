using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
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
