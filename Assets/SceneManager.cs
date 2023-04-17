using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<List<int>> waves = new List<List<int>> {  }; // each index is an array were [num of enemy 1, num of enemy 2, num of enemy 3]
    public float spawnRate = 5;
    public Spawner spawnerMain;
    public Spawner spawnerRight;
    public Spawner spawnerLeft;
    private List<int> numberOfEnemysSpawned = new List<int> { };
    public int currentWaveNumber = 0;
    public bool startWave = true;
    public bool currentWaveFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<waves[0].Count; i++)
        {
            numberOfEnemysSpawned.Insert(0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startWave)
        {
            StartWave(currentWaveNumber);
            startWave = false;
        }
        currentWaveFinished = IsCurrentWaveFinished();
        if (currentWaveFinished)
        {
            if (currentWaveNumber==waves.Count-1)
            {
                // GAME OVER
            }else
            {
                // START NEXT WAVE
                currentWaveNumber += 1;
                startWave = true;
            }
            
        }
    }

    bool IsCurrentWaveFinished()
    {
        //if ()
        //{

        //}
        return false;
    }

    void StartWave(int waveNumber)
    {
        List<int> spawnRequests = waves[waveNumber];

        foreach (int enemyType in spawnRequests)
        {
            while (numberOfEnemysSpawned[enemyType]>0)
            {
                spawnerMain.SpawnEnemy(enemyType);
                spawnerRight.SpawnEnemy(enemyType);
                spawnerLeft.SpawnEnemy(enemyType);
                numberOfEnemysSpawned[enemyType] -= 1;
            }
        }
    }
}
