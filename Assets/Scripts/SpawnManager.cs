using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public Transform[] Obstacles;
    public int Min;
    public int Max;


    int item;
    private void Start()
    {
        StartCoroutine(spawnTimer());   
    }

    IEnumerator spawnTimer()
    {
        // yield suspends the execution and return the value
        yield return new WaitForSeconds(Random.Range(Min,Max));
        
        UpdateSpawnTime();
        int spawnPoint = Random.Range(0, 3);
        Transform spawnPosition = transform.GetChild(spawnPoint);

        item = Random.Range(0, 3);
        Instantiate(Obstacles[item], spawnPosition);

        //Restart
        StartCoroutine(spawnTimer());
    }


    private void  UpdateSpawnTime()
    {
        if(Time.realtimeSinceStartup > 60f) // After 60sec, obstacles spawn in less time
        {
            Min = 1;
            Max = 3;
        }
    }
}
