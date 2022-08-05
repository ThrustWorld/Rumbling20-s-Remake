﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for my obstacle type "Hole"
public class Hole : ObstacleUnitBase
{
    float slow = 1.25f;
    
    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // Apply damage and slow to the player after the collision
            Damage(ScriptableObstacle.BaseStats.AttackPower);
            PlayerController.Instance.Speed /= slow;
        }
    }

    public override void Damage(int dmg)
    {
        // Update player's health
        PlayerController.Instance.Health -= dmg;
        PlayerController.Instance.CheckHealth(PlayerController.Instance.Health);
    }
}
