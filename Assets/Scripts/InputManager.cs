using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InputManager : MonoBehaviour
{
    internal  bool isLeft;
    internal  bool isRight;
    internal bool isPressed;

    internal float counter;
    internal float delay;

    internal void CustomStart()
    {
        counter = delay;
    }

    internal void CustomUpdate()
    {
        isLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        isRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
    }

    internal void Delay()
    {
        if (isPressed)
        {
            counter -= Time.deltaTime;
        }

        if(counter <= 0f)
        {
            counter = delay;
            isPressed = false;
        }
    }
}
