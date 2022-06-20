using System;
using UnityEngine;


// datas in common between my units(Player and obstacles)

[Serializable]
public enum Faction
{
    Player = 0,
    Obstacles = 1
}


[Serializable]
public struct Stats
{
    public int Health;
    public int AttackPower;
    public float Speed;
    public float Rotation;
    
}

// Taking information about a unit without instantiating the unit prefab
public class ScriptableUnitBase : ScriptableObject
{
    public Faction Faction;

    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;

    // game
    public GameObject Prefab;
}