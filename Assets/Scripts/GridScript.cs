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
}
