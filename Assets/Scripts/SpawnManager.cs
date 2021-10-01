using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] Obstacles;
    [SerializeField]
    private int Min;
    [SerializeField]
    private int Max;

    private int item;
    private void Start()
    {
        StartCoroutine(SpawnTimer());   
    }

    IEnumerator SpawnTimer()
    {
        // yield suspends the execution and return the value
        yield return new WaitForSeconds(Random.Range(Min,Max));
        
        UpdateSpawnTime();
        int spawnPoint = Random.Range(0, 3);
        Transform spawnPosition = transform.GetChild(spawnPoint);

        item = Random.Range(0, 3);
        Instantiate(Obstacles[item], spawnPosition);

        //Restart
        StartCoroutine(SpawnTimer());
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
