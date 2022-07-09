using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridScript : MonoBehaviour //based on TileData.cs
{
    [SerializeField] private TileBase newTile;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Grid grid;

    [SerializeField]
    private List<TileData> tileDatas;

    private TileBase oldTile;
    private TileBase mapTile;
    private Vector3Int oldGridPosition;

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

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
        mapTile = tilemap.GetTile(gridPosition);

        if (mapTile == null)
        {

            if (oldTile != null)
                tilemap.SetTile(oldGridPosition, oldTile);
            return;

        }

        if ((oldTile == null) || (!gridPosition.Equals(oldGridPosition) && !mapTile.Equals(newTile)) )
        {   

            if (oldTile != null)
                tilemap.SetTile(oldGridPosition, oldTile);

            oldTile = mapTile;
            oldGridPosition = gridPosition;
            tilemap.SetTile(gridPosition, newTile);

        }
    }

    public void spawnTower(Vector2 mousePosition, TowerEntity object_prefab)
    {
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
        if (!occupiedCells.Contains(gridPosition))
        {
            Vector3 position = tilemap.GetCellCenterWorld(gridPosition);
            Instantiate(object_prefab, position, Quaternion.identity);
            occupiedCells.Add(gridPosition);
        }
    }
}
