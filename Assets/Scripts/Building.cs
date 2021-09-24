using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //References
    [SerializeField]
    internal Scroll scroll;
    
    public List<GameObject> Buildings;

    private void Start()
    {
        scroll.speedMultiplier = 0.5f;
        scroll.speed = 1.5f;
        scroll.maxSpeed = 8f;
        scroll.counter = 0f;
        scroll.outOfScreen = -5f;
        scroll.newZ = 8f;
    }
    
    void Update()
    {
        scroll.ScrollUpdate(Buildings);
    }
}
