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
    void Start()
    {
        
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
        PlayerController.Instance.Health += dmg;
        PlayerController.Instance.CheckHealth(PlayerController.Instance.Health);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.SetActive(false);
            Damage(1);
        }
    }
}
