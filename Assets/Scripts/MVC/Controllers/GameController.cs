using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : BaseController<UIGameRoot>
{
    [SerializeField] private GameModel gameModel;
    [SerializeField] private GridScript gridScript;
    public override void EngageController()
    {
        base.EngageController();
        ui.AddWarriors(gameModel.Warriors,OnTurretDragged,gameModel.GameCanvasScaler);
    }

    public override void DisengageController()
    {
        base.DisengageController();
    }

    public void OnTurretDragged(PointerEventData eventData,WarriorType warriorType)
    {
        Debug.Log($"Warrior type {warriorType}");
        WarriorEntity warriorToSpawn = new WarriorEntity();
        switch (warriorType)
        {
            case WarriorType.Archer:
                warriorToSpawn = gameModel.ArcherPrefab;
                break;

            case WarriorType.Shielder:
                warriorToSpawn = gameModel.ShielderPrefab;
                break;
            case WarriorType.Spearman:
                Debug.Log("UPS");
                break;
        }

        gridScript.spawnTower(Camera.main.ScreenToWorldPoint(eventData.position), warriorToSpawn);

        gameModel.NavMeshSurface.BuildNavMesh();
    }

    public void DealDamageToCastle(int value)
    {
        gameModel.castleHealth-= value;
        ui.UpdateHealth(gameModel.castleHealth);
        if(gameModel.castleHealth <= 0)
        {
            Time.timeScale = 0f;
            gameModel.gameOverState = "LOST";
            root.ChangeController(RootController.ControllerTypeEnum.GameOver);
        }
    }
}
