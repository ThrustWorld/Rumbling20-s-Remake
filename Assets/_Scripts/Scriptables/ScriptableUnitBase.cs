using System;
using UnityEngine;

[Serializable]
public enum Faction
{
    Player = 0,
    PowerUps = 1,
    Enemies = 2
}

// Easily editable
[Serializable]
public struct Stats
{
    public int Health;
    public int AttackPower;
    public int TravelDistance;
}

// Taking information about a unit without instantiating the unit prefab
public class ScriptableUnitBase : ScriptableObject
{
    public Faction Faction;

    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;

    // game
    public Player Prefab;

    // menu
    public string Description;
    public Sprite MenuSprite;
}