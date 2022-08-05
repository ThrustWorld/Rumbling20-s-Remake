using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    [SerializeField] GameObject _player;
    [SerializeField] Vector3 _offSet; // Constant distance from the Player
    // Update is called once per frame
    void LateUpdate()
    {
        // Camera follows the player based on his position + offSet
        transform.position = _player.transform.position + _offSet;
    }
}
