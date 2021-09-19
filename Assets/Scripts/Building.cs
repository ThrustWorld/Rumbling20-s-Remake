using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public List<GameObject> Buildings;


    // speed >= maxSpeed ? speed = maxSpeed : speed *= speedMultiplier
    private float speed;
    private float maxSpeed;
    private float speedMultiplier;

    // Increase difficulty each tot seconds
    private float counter;

    private float outOfScreen;

    // Update is called once per frame
    private void Start()
    {
        speedMultiplier = 0.2f;
        speed = speedMultiplier;
        maxSpeed = 8f;
        counter = 0f;
        outOfScreen = -5f;
    }
    
    void Update()
    {
        Scroll();
    }

    private void ScrollSpeed()
    {
        counter += Time.deltaTime;
        if(counter > 4)
        {
            speed += speedMultiplier;
            counter = 0;
            if(speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
    }

    private void Scroll()
    {
        ScrollSpeed();
        for (int i = 0; i < Buildings.Count; i++)
        {
            if(Buildings[i].transform.position.z <= outOfScreen)
            {
                Buildings[i].transform.position = Buildings[i].transform.position + new Vector3 (0f,0f,8f);
            }
           
            Buildings[i].transform.position -= new Vector3(0f,0f,speed) * Time.deltaTime;
        }
    }
}
