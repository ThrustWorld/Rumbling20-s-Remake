using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rotation : MonoBehaviour
{
    internal float y;

    internal void AutoRotateY()
    {
        transform.Rotate(new Vector3(0f,y,0f) * Time.deltaTime);
    }
}
