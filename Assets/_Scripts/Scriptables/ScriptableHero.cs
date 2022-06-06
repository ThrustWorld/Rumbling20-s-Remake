using System;
using UnityEngine;

[Serializable]
public enum HeroType
{
    Warrior = 0,
    Sorcerer = 1
}

// Create a scriptable hero in the Asset Menu
[CreateAssetMenu(fileName = "New Scriptable Hero")]
public class ScriptableHero : ScriptableUnitBase
{
    public HeroType HeroType;
}