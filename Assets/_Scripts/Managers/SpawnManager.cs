using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    public int SpawnTime; // first spawn
    public int SpawnRate; // amount of the time after the first spawn
    
    [SerializeField] LevelGenerator _levelGenerator;
    [SerializeField] Transform _spawner;
    [SerializeField] Camera _camera;
    [SerializeField] List<ScriptableObstacles> _obstacles; // obstacle type
    [SerializeField] float[] X; // random X pos
    [SerializeField] Vector3 _offSet;
    [SerializeField] int maxCars; // limit number of cars
    [SerializeField] int maxHoles; // limit number of holes
    [SerializeField] int maxPowerUps; // limit number of powerups

    List<GameObject> obstacles;
    Vector3 spawnerPos;
    int maxObstacles; // tot obstacles
    
    void Start()
    {
        maxObstacles = maxCars + maxHoles + maxPowerUps;
        spawnerPos = _levelGenerator.SpawnPosition; // obstacle spawner equals to the last level chunk pos
        transform.position = spawnerPos; // update pos
        InvokeRepeating("Spawn",SpawnTime,SpawnRate); // spawning obstacles randomly during the game 
    }

    public void Initialize()
    {
        // pooling setup
        obstacles = new List<GameObject>();
        for (int i = 0; i < maxObstacles; i++)
        {
            AddObstacle(); // pooling system
        }
    }

    void AddObstacle()
    {
        // initialize n obstacles foreach type
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
        else if(maxCars != 0 || maxHoles != 0 || maxPowerUps != 0) // the inizialization continues if we didn't create the maximum obstacles foreach type
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
            if(!obstacles[i].activeInHierarchy && obstacles[i].tag == obstacles[randomObstacle].tag) // we search one of the obstacles of the list equal to the randomObstacle type
            {
                // obstacle activation
                obstacles[i].transform.position = pos; 
                obstacles[i].SetActive(true);
                break;
            }
            else
            {
                continue; // research if we are not finding it
            }
        }
    }
    public void UpdateSpawnerPosition()
    {
        spawnerPos = _levelGenerator.SpawnPosition; // obstacle spawner equals to the last level chunk pos
        transform.position = spawnerPos - _offSet;
    }


    public void CheckObstaclePosition()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if(obstacles[i].activeInHierarchy)
            {
                if(_camera.transform.position.z > obstacles[i].transform.position.z) // if the obstacle is out of the screen, it becomes inactive
                {
                    obstacles[i].SetActive(false);
                }
            }
        }
    }
}
