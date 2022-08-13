using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class for my obstacle type "Car"
public class Car : ObstacleUnitBase
{
    public override void Movement(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State != GameState.Flow)
            return;
        Movement(ScriptableObstacle.BaseStats.Speed);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            // Apply damage after the collision
            AudioSystem.Instance.PlaySound(PlayerController.Instance.Source,PlayerController.Instance.Clips[3]);
            if(PlayerController.Instance.Source.isPlaying)
            Damage(ScriptableObstacle.BaseStats.AttackPower);
        }
    }
    
    public override void Damage(int dmg)
    {
        // Update player's health 
        PlayerController.Instance.Health -= dmg;
        PlayerController.Instance.CheckHealth(PlayerController.Instance.Health);
    }
}
