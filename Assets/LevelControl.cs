using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelControl : MonoBehaviour
{
    public List<List<int>> waves = new List<List<int>> { new List<int> {1}, new List<int> {2}, new List<int> {1,2}, new List<int> {2,2}, new List<int> {3}, new List<int> {1,3}, new List<int> {1,3}, new List<int> {1,1,3}, new List<int> {1,1,1}, new List<int> {3}}; // each index is an array were [num of enemy 1, num of enemy 2, num of enemy 3]
    public float spawnRate = 15;
    public Spawner spawnerMain;
    public Spawner spawnerRight;
    public Spawner spawnerLeft;

    public HealthSystem hs;

    public int currentWaveNumber = -1;
    public bool startWave = false;
    public bool gameOver = false;
    public int numAliveEnemys = 0;
    private float waveTime = 20;
    public float waveTimer = 0;

    public int finalWave = 10;
    // Start is called before the first frame update
    void Start()
    {
        waveTimer = waveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (numAliveEnemys==0 && startWave) // CURRENT WAVE IS FINISHED && Intermidiate Timer Is Over
        {
            if (gameOver) // GAME OVER
            {
                startWave = false;
            }
            else // START NEXT WAVE
            {
                currentWaveNumber += 1;
                StartWave(currentWaveNumber);
                hs.UpdateWaveText(currentWaveNumber);
                startWave = false;
            }
            
        } else if (numAliveEnemys == 0 && !startWave && currentWaveNumber != -1)
        {
            //Start Wave Timer
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0)
            {
                waveTimer = waveTime;
                startWave = true;
            }
            else
            {
                hs.UpdateWaveTimer(waveTimer);
            }
        }
    }


    void StartWave(int waveNumber)
    {
        waveTime += 2;
        List<int> spawnRequests = waves[waveNumber];
        Debug.Log(spawnRequests.Count);
        foreach (int enemyType in spawnRequests)
        {
            spawnerMain.AddToSpawnQueue(enemyType);
            spawnerRight.AddToSpawnQueue(enemyType);
            spawnerLeft.AddToSpawnQueue(enemyType);
        }
    }
}
