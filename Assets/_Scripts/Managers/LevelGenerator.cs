using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : Singleton<LevelGenerator>
{
    public Vector3 SpawnPosition {get; private set; }
    
    [SerializeField] private GameObject _groundTile; // prefab
    [SerializeField] Transform _spawner;
    [SerializeField] Vector3 _origin;
    [SerializeField] int _spawnedTiles; // max chunks
    [SerializeField] Camera _camera;
    [SerializeField] Vector3 _offSet;

    private float distance;
    private List<GameObject> tiles;

    void Start()
    {
        distance = 1f;
    }
    
    public void Initialize()
    {
        tiles = new List<GameObject>();
        
        for (int i = 0; i < _spawnedTiles; i++)
        {
            SpawnGroundTile();
        }
    }

    void Update()
    {
        if(GameManager.Instance.State != GameState.Flow)
            return;
        
        CheckChunksPosition();
    }

    void SpawnGroundTile()
    {
        // Spawn a chunk and add it to the list
        GameObject tmp = Instantiate(_groundTile, SpawnPosition + _origin, Quaternion.identity,_spawner);
        SpawnPosition = SpawnPosition + _offSet;
        tiles.Add(tmp);
    }

    void CheckChunksPosition()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            // If we passed the first chunk, we put the first chunk after the last
            if(_camera.transform.position.z > tiles[i].transform.position.z + distance)
            {
                tiles[i].transform.position = SpawnPosition + _origin;
                SpawnPosition = SpawnPosition + _offSet; // update the spawn to the last chunk position
                SpawnManager.Instance.UpdateSpawnerPosition(); // update the spawner position of the obstacle with the SpawnPosition of the last chunk
            }
        }
    }
}
