using System.Collections;
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
            Damage(1);
            PlayerController.Instance.Speed /= slow;
        }
    }

    public override void Damage(int dmg)
    {
        Debug.Log("Hole dmg: " + dmg);
    }
}
