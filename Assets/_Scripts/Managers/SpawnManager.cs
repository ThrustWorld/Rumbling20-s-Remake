using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    public int SpawnTime; // First spawn
    public int SpawnRate; // Amount of the time after the first spawn
    
    [SerializeField] LevelGenerator _levelGenerator;
    [SerializeField] Transform _spawner;
    [SerializeField] Camera _camera;
    [SerializeField] List<ScriptableObstacles> _obstacles; // Obstacle type
    [SerializeField] float[] X; // Random X pos
    [SerializeField] Vector3 _offSet;
    [SerializeField] int maxCars; // Limit number of cars
    [SerializeField] int maxHoles; // Limit number of holes
    [SerializeField] int maxPowerUps; // Limit number of powerups

    List<GameObject> obstacles;
    Vector3 spawnerPos;
    int maxObstacles; // Tot obstacles
    
    void Start()
    {
        maxObstacles = maxCars + maxHoles + maxPowerUps;
        spawnerPos = _levelGenerator.SpawnPosition; // Obstacle spawner equals to the last level chunk pos
        transform.position = spawnerPos; // Update pos
        InvokeRepeating("Spawn",SpawnTime,SpawnRate); // Spawning obstacles randomly during the game 
    }

    public void Initialize()
    {
        // Pooling setup
        obstacles = new List<GameObject>();
        for (int i = 0; i < maxObstacles; i++)
        {
            AddObstacle(); // Pooling system
        }
    }

    void AddObstacle()
    {
        // Initialize n obstacles foreach type
        int randomObstacle = Random.Range(0,_obstacles.Count);
        if(_obstacles[randomObstacle].Type == ObstacleType.Car && maxCars > 0)
        {
            GameObject go = Instantiate(_obstacles[randomObstacle].Prefab, transform.position, Quaternion.Euler(0,180,0), _spawner); // Add them in the list
            obstacles.Add(go);
            go.SetActive(false);
            maxCars--;
        }
        else if(_obstacles[randomObstacle].Type == ObstacleType.Hole && maxHoles > 0)
        {
            GameObject go = Instantiate(_obstacles[randomObstacle].Prefab, transform.position, Quaternion.Euler(0,180,0), _spawner); // Add them in the list
            obstacles.Add(go);
            go.SetActive(false);
            maxHoles--;
        }
        else if(_obstacles[randomObstacle].Type == ObstacleType.PowerUp && maxPowerUps > 0)
        {
            GameObject go = Instantiate(_obstacles[randomObstacle].Prefab, transform.position, Quaternion.Euler(0,180,0), _spawner); // Add them in the list
            obstacles.Add(go);
            go.SetActive(false);
            maxPowerUps--;
        }
        else if(maxCars != 0 || maxHoles != 0 || maxPowerUps != 0) // The inizialization continues if we didn't create the maximum obstacles foreach type
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
        int randomX = Random.Range(0,X.Length); // Random position taken from X[]
        int randomObstacle = Random.Range(0,obstacles.Count); // Random obstacle taken from _obstacles list
        Vector3 pos = new Vector3(X[randomX],transform.position.y,transform.position.z); // Obstacle updated position

        for (int i = 0; i < obstacles.Count; i++)
        {
            if(!obstacles[i].activeInHierarchy && obstacles[i].tag == obstacles[randomObstacle].tag) // We search one of the obstacles of the list equal to the randomObstacle type
            {
                // Obstacle activation
                obstacles[i].transform.position = pos; 
                obstacles[i].SetActive(true);
                break;
            }
            else
            {
                continue; // Research if we are not finding it
            }
        }
    }
    public void UpdateSpawnerPosition()
    {
        spawnerPos = _levelGenerator.SpawnPosition; // Obstacle spawner equals to the last level chunk pos
        transform.position = spawnerPos - _offSet;
    }


    public void CheckObstaclePosition()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if(obstacles[i].activeInHierarchy)
            {
                if(_camera.transform.position.z > obstacles[i].transform.position.z) // If the obstacle is out of the screen, it becomes inactive
                {
                    obstacles[i].SetActive(false);
                }
            }
        }
    }
}
