using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScheduler : MonoBehaviour
{
    [SerializeField]
    private bool isWaveInProgress = false;
    [SerializeField]
    private float timeToNextWave;
    [SerializeField]
    private int remainingEnemies = -1;
    [SerializeField]
    private int currentWaveNumber = 1;

    public bool IsWaveInProgress { get => isWaveInProgress; set => isWaveInProgress = value; }
    public float TimeToNextWave { get => TimeToNextWave; set => TimeToNextWave = value; }
    public int CurrentWaveNumber { get => currentWaveNumber; set => currentWaveNumber = value; }
    public float TimeToNextWave1 { get => timeToNextWave; set => timeToNextWave = value; }
    public float CalculatedTime { get => nextWaveStartTime - elapsed; }

    [SerializeField]
    protected float elapsed = 0;
    [SerializeField]
    private float nextWaveStartTime;
    private EnemyEntity[]? spawnedEntities;

    // Start is called before the first frame update
    void Start()
    {
        spawnedEntities = null;
        nextWaveStartTime += elapsed + TimeToNextWave1;
    }

    private bool isWaveOver()
    {
        int cnt = 0;
        foreach( EnemyEntity enemy in spawnedEntities)
        {
            if (enemy != null)
            {
                cnt++;
            }
        }
        remainingEnemies = cnt;
        if (cnt == 0) return true;
        else return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaveInProgress)
        {
            if( isWaveOver()) {
                isWaveInProgress = false;
                nextWaveStartTime = elapsed + TimeToNextWave1;
                CurrentWaveNumber++;
            }
        } 
        else
        {
            if(elapsed > nextWaveStartTime)
            {
                isWaveInProgress = true;
                EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
                spawner.spawnNewWave();
                spawnedEntities = GameObject.FindObjectsOfType<EnemyEntity>();
                Debug.Log($"SPAWNED ENTS: {spawnedEntities.Length}");
                remainingEnemies = spawnedEntities.Length;
            }
        }
        elapsed += Time.deltaTime;
    }
}
