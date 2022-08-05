using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// class for my obstacle type "PowerUp"
public class PowerUp : ObstacleUnitBase
{
    public override void Rotation(float rotationSpeed)
    {
       transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State != GameState.Flow)
            return;
        Rotation(ScriptableObstacle.BaseStats.Rotation);
    }

    public override void Damage(int dmg)
    {
        // Update player's health
        PlayerController.Instance.Health += dmg;
        PlayerController.Instance.CheckHealth(PlayerController.Instance.Health);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // Apply positive damage and disable powerup after the collision
            gameObject.SetActive(false);
            Damage(ScriptableObstacle.BaseStats.AttackPower);
        }
    }
}
