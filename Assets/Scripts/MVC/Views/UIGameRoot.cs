using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameRoot : UIRoot
{
    [SerializeField] private GameObject warriorsContainer;
    public override void InitView()
    {
        base.InitView();
    }

    public override void HideView()
    {
        base.HideView();
    }
    
    public void SetupTurretsDragging(CanvasScaler gameCanvasScaler)
    {
        UIWarrior[] warriors = warriorsContainer.GetComponentsInChildren<UIWarrior>();
        foreach(var warrior in warriors)
        {
            warrior.draggableImage.Init(gameCanvasScaler);
        }
    }
}
