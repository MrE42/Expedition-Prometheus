using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy1;
    private Queue<int> spawnQueue = new Queue<int> { };
    public LevelControl levelControler;
    public bool allEnemysDead = true;
    private float lastSpawnTime = 0;
    public GameObject enemysTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ((Time.time - lastSpawnTime > levelControler.spawnRate) && spawnQueue.Count>0)
        {
            SpawnEnemy(spawnQueue.Dequeue());
            lastSpawnTime = Time.time;
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
            levelControler.numAliveEnemys = levelControler.numAliveEnemys + 1;
            spawnedEnemy.transform.position = gameObject.transform.position;
            spawnedEnemy.GetComponent<crewmateAI>().target = enemysTarget;
            spawnedEnemy.GetComponent<crewmateAI>().levelControler = levelControler;
            //spawnedBullet.transform.rotation = spawnPointSmall.rotation;
            //Destroy(spawnedBullet, 5);
        }
    }
}
