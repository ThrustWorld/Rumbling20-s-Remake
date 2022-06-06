using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    // speed >= maxSpeed ? speed = maxSpeed : speed += speedMultiplier
    internal float speed;
    internal float maxSpeed;
    internal float speedMultiplier;

    // Increase difficulty each tot seconds
    internal float counter;

    internal float outOfScreen;

    internal float newZ;

    private float pastTime;

    private void Start()
    {
        pastTime = 30f;    
    }

    private void ScrollSpeed()
    {
        counter += Time.deltaTime;
        if(counter > pastTime) // seconds passed
        {
            speed += speedMultiplier;
            counter = 0;
            if(speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
    }

    internal void ScrollUpdate(List<GameObject> GameObjects)
    {
        ScrollSpeed();
        for (int i = 0; i < GameObjects.Count; i++)
        {
            if(GameObjects[i].transform.position.z <= outOfScreen)
            {
                GameObjects[i].transform.position = GameObjects[i].transform.position + new Vector3 (0f,0f,newZ);
            }
           
            GameObjects[i].transform.position -= new Vector3(0f,0f,speed) * Time.deltaTime;
        }
    }
}
