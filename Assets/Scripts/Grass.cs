using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    //References
    [SerializeField]
    internal Scroll scroll;

    public List<GameObject> GrassTiles;

    // Start is called before the first frame update
    void Start()
    {
        scroll.speedMultiplier = 0.5f;
        scroll.speed = 1.5f;
        scroll.maxSpeed = 8f;
        scroll.counter = 0f;
        scroll.outOfScreen = -10f;
        scroll.newZ = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        scroll.ScrollUpdate(GrassTiles);
    }
}
