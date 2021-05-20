using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float delay;
    public Transform Cube;
    public Transform Lane00;
    public Transform Lane01;
    public Transform Lane02;
    Vector3 Target;
    
    bool isLerping;
    bool right;
    bool left;

    void Start()
    {
        Cube.position = Lane01.position;
        right = false;
        left = false;
        isLerping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(1))
        {
            right = true;
        }

        if (right == true)
        {
            if (Cube.position == Lane00.position)
            {
                Target = Lane01.position;
            }

            if (Cube.position == Lane01.position)
            {
                Target = Lane02.position;
            }

            isLerping = true;
            right = false;
        }



        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetMouseButtonDown(0))
        {
            left = true;
        }

        if (left == true)
        {
            if (Cube.position == Lane02.position)
            {
                Target = Lane01.position;
            }

            if (Cube.position == Lane01.position)
            {
                Target = Lane00.position;
            }

            isLerping = true;
            left = false;
        }


        if (isLerping)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetMouseButtonDown(0) && Cube.position.x < Lane02.position.x && Cube.position.x > Lane01.position.x) 
            {
                if(Target != Lane02.position)
                {
                    Target = Lane00.position;
                }
            }
            else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(1) && Cube.position.x > Lane00.position.x && Cube.position.x < Lane01.position.x) 
            {
                if(Target != Lane00.position)
                {
                    Target = Lane02.position;
                }
            }
            
            Cube.position = Vector3.Lerp(Cube.position, Target, speed * Time.deltaTime);
            if (Vector3.Distance(Cube.position, Target) < delay)
            {
                Cube.position = Target;
                isLerping = false;
            }
        }
    }
}

