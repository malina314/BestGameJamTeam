using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightScript : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private TileBase newTile;

    private Vector3Int oldGridPosition;

    private void Update()
    {
        HighLightningGridTiles();
    }

    public void HighLightningGridTiles()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);

        if (!gridPosition.Equals(oldGridPosition))
        {
            tilemap.SetTile(oldGridPosition, null);
            oldGridPosition = gridPosition;
            tilemap.SetTile(gridPosition, newTile);
        }
    }
}
