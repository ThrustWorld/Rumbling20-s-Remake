using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] LevelGenerator _levelGenerator;
    [SerializeField] Transform _spawner;
    [SerializeField] Camera _camera;
    [SerializeField] List<ScriptableObstacles> _obstacles;
    [SerializeField] float[] X;
    [SerializeField] int maxCars;
    [SerializeField] int maxHoles;
    [SerializeField] int maxPowerUps;

    List<GameObject> obstacles;
    Vector3 spawnerPos;
    int maxObstacles;
    
    void Start()
    {
        maxObstacles = maxCars + maxHoles + maxPowerUps;
        spawnerPos = _levelGenerator.SpawnPosition;
        transform.position = spawnerPos;
        InvokeRepeating("Spawn",8,5);
    }

    public void Initialize()
    {
        obstacles = new List<GameObject>();
        for (int i = 0; i < maxObstacles; i++)
        {
            AddObstacle();
        }
    }

    void AddObstacle()
    {
        int randomObstacle = Random.Range(0,_obstacles.Count);
        if(_obstacles[randomObstacle].Type == ObstacleType.Car && maxCars > 0)
        {
            GameObject go = Instantiate(_obstacles[randomObstacle].Prefab, transform.position, Quaternion.Euler(0,180,0), _spawner); // spawning obstacle
            obstacles.Add(go);
            go.SetActive(false);
            maxCars--;
        }
        else if(_obstacles[randomObstacle].Type == ObstacleType.Hole && maxHoles > 0)
        {
            GameObject go = Instantiate(_obstacles[randomObstacle].Prefab, transform.position, Quaternion.Euler(0,180,0), _spawner); // spawning obstacle
            obstacles.Add(go);
            go.SetActive(false);
            maxHoles--;
        }
        else if(_obstacles[randomObstacle].Type == ObstacleType.PowerUp && maxPowerUps > 0)
        {
            GameObject go = Instantiate(_obstacles[randomObstacle].Prefab, transform.position, Quaternion.Euler(0,180,0), _spawner); // spawning obstacle
            obstacles.Add(go);
            go.SetActive(false);
            maxPowerUps--;
        }
        else if(maxCars != 0 || maxHoles != 0 || maxPowerUps != 0)
        {
            maxObstacles++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State != GameState.Flow)
            return;
        CheckObstaclePosition();
    }

    void Spawn()
    {
        int randomX = Random.Range(0,X.Length); // random position taken from X[]
        int randomObstacle = Random.Range(0,obstacles.Count); // random obstacle taken from _obstacles list
        Vector3 pos = new Vector3(X[randomX],transform.position.y,transform.position.z); // obstacle updated position

        for (int i = 0; i < obstacles.Count; i++)
        {
            if(!obstacles[i].activeInHierarchy && obstacles[i].tag == obstacles[randomObstacle].tag)
            {
                obstacles[i].transform.position = pos;
                obstacles[i].SetActive(true);
                break;
            }
            else
            {
                continue;
            }
        }
    }
    public void UpdateSpawnerPosition()
    {
        spawnerPos = _levelGenerator.SpawnPosition;
        transform.position = spawnerPos - new Vector3(0,0,1f);
    }


    public void CheckObstaclePosition()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if(obstacles[i].activeInHierarchy)
            {
                if(_camera.transform.position.z > obstacles[i].transform.position.z)
                {
                    obstacles[i].SetActive(false);
                }
            }
        }
    }
}
