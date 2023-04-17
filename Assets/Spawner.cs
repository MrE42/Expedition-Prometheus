using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy1;
    private Queue<int> spawnQueue;
    public SceneManager sm;
    public bool allEnemysDead = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time % sm.spawnRate == 0 && spawnQueue.Count>0)
        {
            SpawnEnemy(spawnQueue.Dequeue());
        }
    }

    public void AddToSpawnQueue(int type)
    {
        spawnQueue.Enqueue(type);
    }

    public void SpawnEnemy(int type)
    {
        if (type==1)
        {
            GameObject spawnedEnemy = Instantiate(enemy1);
            //spawnedBullet.transform.position = spawnPointSmall.position;
            //spawnedBullet.transform.rotation = spawnPointSmall.rotation;
            //Destroy(spawnedBullet, 5);
        }
    }
}
