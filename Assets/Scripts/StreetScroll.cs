using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetScroll : MonoBehaviour
{
    public Transform Street;
    public Transform Street1;
    public Transform Street2;
    public float speed;
    Vector3 position;
    float timeToStart;
    public float timeCheck;
    public float speedMultiplier;
    public float MaxSpeed;
    void Start()
    {
        position = Street2.position;
    }

    void Update()
    {
        timeToStart += Time.deltaTime;
        if(timeToStart > timeCheck && speed < MaxSpeed)
        {
            speed *= speedMultiplier;
            timeToStart = 0;
        }
        if(speed > MaxSpeed)
        {
            speed = MaxSpeed;
        }

        //Debug.Log("time "+ timeToStart);
        //Debug.Log("speed " + speed);
        Street.position -= new Vector3(0, 0, speed) * Time.deltaTime;
        Street1.position -= new Vector3(0, 0, speed) * Time.deltaTime;
        Street2.position -= new Vector3(0, 0, speed) * Time.deltaTime;

        if (Street.position.z <= -11f)
        {
            Street.position = Street2.position + new Vector3(0, 0, 18f);
        }
        if (Street1.position.z < -11f)
        {
            Street1.position = Street.position + new Vector3(0, 0, 18f);
        }
        if (Street2.position.z < -11f)
        {
            Street2.position = Street1.position + new Vector3(0, 0, 18f);
        }
    }
}
