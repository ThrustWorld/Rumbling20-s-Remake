using UnityEngine;


// Specific manager for the units(heroes,minions, etc...) granning resources from the ResourceSystem class
public class UnitManager : Singleton<UnitManager>
{
    public void SpawnHeroes()
    {
        SpawnUnit(HeroType.Warrior, new Vector3(1,0,0));
    }

    void SpawnUnit(HeroType t, Vector3 pos){
        var scriptableHero = ResourceSystem.Instance.GetHero(t);

        var spawned = Instantiate(scriptableHero.Prefab, pos, Quaternion.identity);


        // modify unit stats based on synergy, buff, debuff, etc...
        var stats = scriptableHero.BaseStats;
        stats.Health += 40;

        spawned.SetStats(stats);
    }
}