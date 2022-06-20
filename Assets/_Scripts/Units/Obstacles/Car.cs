using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// class for my obstacle type "Car"
public class Car : ObstacleUnitBase
{
    public override void Movement(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
            Damage(0);
        }
    }
    
    public override void Damage(int dmg)
    {
        Debug.Log("GameOver!");
    }
}
