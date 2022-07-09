using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameModel : MonoBehaviour
{
    [SerializeField] private CanvasScaler gameCanvasScaler;
    public CanvasScaler GameCanvasScaler { get => gameCanvasScaler; }
    
    [SerializeField] private List<WarriorData> warriors;
    public List<WarriorData> Warriors { get => warriors;}
   
    [SerializeField] private Archer archerPrefab;
    public Archer ArcherPrefab { get => archerPrefab;}

    [SerializeField] private Shielder shielderPrefab;
    public Shielder ShielderPrefab { get => shielderPrefab; }

    [SerializeField] private Transform warriorsContainer;
    public Transform WarriorsContainer { get => warriorsContainer; }
 
    [SerializeField] private NavMeshSurface2d navMeshSurface;
    public NavMeshSurface2d NavMeshSurface { get => navMeshSurface; }
    
    [SerializeField] private Transform enemiesContainer;
    public Transform EnemiesContainer { get => enemiesContainer; }

}
