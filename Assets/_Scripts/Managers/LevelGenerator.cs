using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : Singleton<LevelGenerator>
{
    [SerializeField] private GameObject _groundTile;
    [SerializeField] Transform _spawner;
    [SerializeField] Vector3 _origin;
    [SerializeField] int _spawnedTiles;
   
    private Vector3 spawnPosition;
    private List<GameObject> tiles;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<GameObject>();
        
        for (int i = 0; i < _spawnedTiles; i++)
        {
            SpawnGroundTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
            SpawnGroundTile();
    }

    void SpawnGroundTile()
    {
        GameObject tmp = Instantiate(_groundTile, spawnPosition + _origin, Quaternion.identity,_spawner);
        spawnPosition = spawnPosition + new Vector3(0,0,1.8f);
        tiles.Add(tmp);
        
        if(tiles.Count > _spawnedTiles + 1)
        {
            Destroy(tiles[0]);
            tiles.RemoveAt(0);
        }
    }
}
