using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTurretTest : MonoBehaviour
{
    [SerializeField]
    private Archer ArcherPrefab;
    [SerializeField]
    private Shiedman SieldmanPrefab;
    [SerializeField]
    private GridScript gridScript;

    private TowerEntity nextTower;

    void updateNext()
    {
        if (nextTower == null || nextTower.Equals(ArcherPrefab))
            nextTower = SieldmanPrefab;
        else
            nextTower = ArcherPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            updateNext();
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gridScript.spawnTower(mousePosition, nextTower);
        }
    }
}
