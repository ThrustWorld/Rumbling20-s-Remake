using UnityEngine;

// The same logic for any unit
public class UnitBase : MonoBehaviour
{
    public Stats Stats {get; private set;}

    public virtual void SetStats(Stats stats) => Stats = stats;
}