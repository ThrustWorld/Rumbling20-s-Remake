using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Side
{
    Left,
    Mid,
    Right
}
public class MovementManager : MonoBehaviour
{
    internal Side side;

    // X axis update
    internal float newX;
    internal  float X;
    
    //Lerp
    internal float lerpX;
    internal  float LerpSpeed;

    internal void MoveLeft(InputManager input, GameObject go, Animator animator, string name)
    {
        input.Delay();
        if (input.isLeft && !input.isPressed)
        {
            input.isPressed = true;
            
            if (side == Side.Right)
            {
                newX = 0; // towards left(mid side)
                animator.Play(name);
                side = Side.Mid;
            }
            else if (side == Side.Mid)
            {
                newX = X * -1f; // towards left(left side)
                animator.Play(name);
                side = Side.Left;
            }
        }
        lerpX = Mathf.Lerp(lerpX, newX, Time.deltaTime * LerpSpeed);
        go.transform.position = new Vector3(lerpX, go.transform.position.y, go.transform.position.z);
    }

    internal void MoveRight(InputManager input, GameObject go, Animator animator, string name)
    {
        input.Delay();
        if (input.isRight && !input.isPressed)
        {
            input.isPressed = true;
            
            if (side == Side.Left)
            {
                newX = 0; // towards right(mid side)
                animator.Play(name);
                side = Side.Mid;
            }
            else if (side == Side.Mid)
            {
                newX = X * 1f; // towards right(right side)
                animator.Play(name);
                side = Side.Right;
            }
        }
        lerpX = Mathf.Lerp(lerpX, newX, Time.deltaTime * LerpSpeed);
        go.transform.position = new Vector3(lerpX, go.transform.position.y, go.transform.position.z);
    }
}
