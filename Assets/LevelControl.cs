using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public List<List<int>> waves = new List<List<int>> { new List<int> {1,1,1}, new List<int> {1,1,1,1} }; // each index is an array were [num of enemy 1, num of enemy 2, num of enemy 3]
    public float spawnRate = 5;
    public Spawner spawnerMain;
    public Spawner spawnerRight;
    public Spawner spawnerLeft;

    public HealthSystem hs;

    public int currentWaveNumber = -1;
    public bool startWave = false;
    public bool currentWaveFinished = true;
    public int numAliveEnemys = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (numAliveEnemys==0 && startWave) // CURRENT WAVE IS FINISHED
        {
            startWave = false;
            if (currentWaveNumber==waves.Count-1) // GAME OVER
            {
                
            }
            else // START NEXT WAVE
            {
                currentWaveNumber += 1;
                StartWave(currentWaveNumber);
                hs.UpdateWaveText(currentWaveNumber);
            }
            
        }
    }


    void StartWave(int waveNumber)
    {
        List<int> spawnRequests = waves[waveNumber];
        Debug.Log(spawnRequests.Count);
        foreach (int enemyType in spawnRequests)
        {
            spawnerMain.AddToSpawnQueue(enemyType);
            //spawnerRight.SpawnEnemy(enemyType);
            //spawnerLeft.SpawnEnemy(enemyType);
        }
    }
}
