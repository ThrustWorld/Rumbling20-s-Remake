using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public enum ObstacleType
{
    Hole = 0,
    Car = 1,
    PowerUp = 2
}


[CreateAssetMenu(fileName = "Obstacles")]
public class ScriptableObstacles : ScriptableUnitBase
{
    public ObstacleType Type;
}
