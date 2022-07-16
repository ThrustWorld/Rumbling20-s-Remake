using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Base class for my obstacles and what they have in common
public class ObstacleUnitBase : MonoBehaviour
{
    public ScriptableObstacles ScriptableObstacle; // datas about obstacles
    
    public virtual void Damage(int dmg)
    {

    }

    public virtual void Movement(float speed)
    {

    }

    public virtual void Rotation(float rotationSpeed)
    {
        
    }

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void OnCollisionEnter(Collision collision)
    {

    }
}