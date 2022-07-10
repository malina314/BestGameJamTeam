using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class GridScript : MonoBehaviour //based on TileData.cs
{
    [SerializeField] private NavMeshSurface2d navMeshSurface;
    [SerializeField] private GameModel gameModel;
    [SerializeField] private TileBase newTile;
    [SerializeField] private Tilemap tilemap;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private HashSet<Vector3Int> occupiedCells;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }
    private void Start()
    {
        occupiedCells = new HashSet<Vector3Int>();
    }

    public bool spawnTower(Vector2 mousePosition, WarriorEntity object_prefab)
    {
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
        //Debug.Log(tilemap.HasTile(gridPosition));
        if (!occupiedCells.Contains(gridPosition) && !tilemap.HasTile(gridPosition))
        {
            Vector3 position = tilemap.GetCellCenterWorld(gridPosition);
            WarriorEntity spawned = Instantiate(object_prefab, position, Quaternion.identity,gameModel.WarriorsContainer);
            spawned.OnDeath += despawn;
            occupiedCells.Add(gridPosition);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void despawn(Entity sender)
    {
        if (sender is WarriorEntity)
        {
            Vector3Int gridPosition = tilemap.WorldToCell(sender.transform.position);
            occupiedCells.Remove(gridPosition);
            Debug.Log("removed from HashSet");
            navMeshSurface.BuildNavMesh();
        }
    }
}
