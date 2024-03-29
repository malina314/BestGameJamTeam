using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameModel gameModel;
    [SerializeField]
    private GameObject[] spawnPoints;
    [SerializeField]
    private Transform[] targetPoints;
    [SerializeField]
    private int[] waves;

    [SerializeField]
    private float startingRadius;
    [SerializeField]
    private float spread;
    [SerializeField]
    private EnemyEntity[] enemyPrefabs;

    private int waveNumber = 0;

    public int WaveNumber { get => waveNumber; set => waveNumber = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spawnNewWave();
        }
    }

    public void spawnNewWave()
    {
        if (WaveNumber >= waves.Length)
        {
            WaveNumber = waves.Length - 1;
        }
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            spawnEnemyGroup(i, new int[] { waves[WaveNumber] / spawnPoints.Length });
        }
        WaveNumber++;
    }

    private void spawnEnemyGroup(int spawnpoint, int[] NumberOfEnemies) // number of enemies of each type
    {
        int enemyCount = 0;
        foreach(int value in NumberOfEnemies)
        {
            enemyCount += value;
        }

        float radius = startingRadius;

        int numberToSpawnOnLayer = 3;
        float angle = Random.Range(0, 2 * Mathf.PI);
        while(enemyCount > 0)
        {
            float xcoord = spawnPoints[spawnpoint].transform.position.x + Mathf.Cos(angle) * radius;
            float ycoord = spawnPoints[spawnpoint].transform.position.y + Mathf.Sin(angle) * radius;
            for (int i = 0; i < numberToSpawnOnLayer; i++)
            {
                spawnRandomEnemy(ref NumberOfEnemies,xcoord,ycoord);
                enemyCount--;
                if( numberToSpawnOnLayer <= enemyCount)
                {
                    angle += (2 * Mathf.PI) / (float)numberToSpawnOnLayer;
                }
                else
                {
                    angle += (2 * Mathf.PI) / ((float)enemyCount);
                }
                xcoord = spawnPoints[spawnpoint].transform.position.x + Mathf.Cos(angle) * radius;
                ycoord = spawnPoints[spawnpoint].transform.position.y + Mathf.Sin(angle) * radius;

            }
            angle += Random.Range(0, 2 * Mathf.PI);
            radius += spread;
            numberToSpawnOnLayer+=5;
        }
    }

    private void spawnRandomEnemy(ref int[] NumberOfEnemies,float xcoord, float ycoord)
    {
        int randomEnemyIndex = Random.Range(0, NumberOfEnemies.Length-1);
        for(int i = 0; i < 15; i++)
        {
            if( NumberOfEnemies[randomEnemyIndex] > 0)
            {
                Vector3 pos = new Vector3(xcoord, ycoord, 0);
                Quaternion rot = new Quaternion(0, 0, 0, 0);
                var copy = Instantiate(enemyPrefabs[randomEnemyIndex],pos,rot,gameModel.EnemiesContainer);
                copy.targetPoint = targetPoints[Random.Range(0, targetPoints.Length)];
                NumberOfEnemies[randomEnemyIndex]--;
                return;
            }
            else
            {
                randomEnemyIndex = Random.Range(0, NumberOfEnemies.Length-1);
            }
        }
    }
}
