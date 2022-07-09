using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModel : MonoBehaviour
{
    [SerializeField] private CanvasScaler gameCanvasScaler;
    public CanvasScaler GameCanvasScaler { get => gameCanvasScaler; }
    
    [SerializeField] private List<WarriorData> warriors;
    public List<WarriorData> Warriors { get => warriors;}
}
