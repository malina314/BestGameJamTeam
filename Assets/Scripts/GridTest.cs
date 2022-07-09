using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridTest : MonoBehaviour
{
    [SerializeField] private TileBase tile;
    [SerializeField] private Tilemap tilemap;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach(var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
            TileBase tile = tilemap.GetTile(gridPosition);
            if (tile != null)
            {
                Debug.Log($"Obra¿enia tego turreta: " + dataFromTiles[tile].damage);
            }

            //tilemap.SetTile(gridPosition, tile);
        }
    }
}
