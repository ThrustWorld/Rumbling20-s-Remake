using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField]
    internal Rotation rotation;

    float speed;
    float outOfScreen;
    float pastTime;
    // Start is called before the first frame update
    void Start()
    {
        rotation.y = 180f;
        speed = 2f;
        outOfScreen = -12f;
        pastTime = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.AutoRotateY();
        PositionUpdate();
        SpeedUpdate();
    }

    void PositionUpdate()
    {
        transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;

        if(transform.position.z < outOfScreen)
        {
            Destroy(gameObject);
        }
    }


    void SpeedUpdate()
    {
        if (Time.realtimeSinceStartup > pastTime)
        {
            speed = 3;
        }
    }
}
