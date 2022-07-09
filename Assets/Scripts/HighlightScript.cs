using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightScript : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase newTile;

    private TileBase oldTile;
    private TileBase mapTile;
    private Vector3Int oldGridPosition;
    private void Update()
    {
        HighLightningGridTiles();
    }

    public void HighLightningGridTiles()
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

        if ((oldTile == null) || (!gridPosition.Equals(oldGridPosition) && !mapTile.Equals(newTile)))
        {

            if (oldTile != null)
                tilemap.SetTile(oldGridPosition, oldTile);

            oldTile = mapTile;
            oldGridPosition = gridPosition;
            tilemap.SetTile(gridPosition, newTile);

        }
    }
}
