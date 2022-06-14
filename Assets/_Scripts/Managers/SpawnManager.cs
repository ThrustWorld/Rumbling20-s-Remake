using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] LevelGenerator _levelGenerator;
    [SerializeField] Transform _spawner;
    [SerializeField] List<ScriptableObstacles> _obstacles;
    [SerializeField] float[] X;
    Vector3 spawnerPos;

    void Start()
    {
        spawnerPos = _levelGenerator.SpawnPosition;
        transform.position = spawnerPos;
        InvokeRepeating("Spawn",8,5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawn()
    {
        int randomX = Random.Range(0,X.Length); // random position taken from X[]
        int randomObstacle = Random.Range(0,_obstacles.Count); // random obstacle taken from _obstacles list
        Vector3 pos = new Vector3(X[randomX],transform.position.y,transform.position.z); // obstacle updated position
        GameObject go = Instantiate(_obstacles[randomObstacle].Prefab, pos, Quaternion.Euler(0,180,0), _spawner); // spawning obstacle
    }
    public void UpdateSpawnerPosition()
    {
        spawnerPos = _levelGenerator.SpawnPosition;
        transform.position = spawnerPos - new Vector3(0,0,1f);
    }

}
