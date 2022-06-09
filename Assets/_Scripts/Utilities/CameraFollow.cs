using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    [SerializeField] GameObject _player;
    [SerializeField] Vector3 _offSet;
    // Update is called once per frame
    void Update()
    {
        transform.position = _player.transform.position + _offSet;
    }

    
}
