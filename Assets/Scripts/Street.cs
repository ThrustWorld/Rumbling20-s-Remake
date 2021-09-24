using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    //References
    [SerializeField]
    internal Scroll scroll;

    public List<GameObject> Streets;

    private void Start()
    {
        // Street values to scroll
        scroll.speedMultiplier = 0.5f;
        scroll.speed = 1.5f;
        scroll.maxSpeed = 8f;
        scroll.counter = 0f;
        scroll.outOfScreen = -2f;
        scroll.newZ = 7f;
    }
    
    void Update()
    {
        scroll.ScrollUpdate(Streets);
    }
}
