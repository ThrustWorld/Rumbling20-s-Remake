using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    Left,
    Mid,
    Right
}

public class InputManager : MonoBehaviour
{
    GameObject go;
    Animator animator;
    Side side;
    float newX;
    float lerpX;
    
    public float LerpSpeed;
    public float X;
    public string LeftAnimation;
    public string RightAnimation;

    // Start is called before the first frame update
    void Start()
    {
        go = this.gameObject;
        animator = go.GetComponent<Animator>();
        side = Side.Mid;
        newX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMoveWithAnimation();
    }


    void HorizontalMove()
    {
        bool left = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        if (left)
        {
            if(side == Side.Right)
            {
                newX = 0; // towards left(mid side)
                side = Side.Mid;
            }
            else if(side == Side.Mid)
            {
                newX = X * -1; // towards left(left side)
                side = Side.Left;
            }
        }
        else if (right)
        {
            if (side == Side.Left)
            {
                newX = 0; // towards right(mid side)
                side = Side.Mid;
            }
            else if (side == Side.Mid)
            {
                newX = X * 1; // towards right(right side)
                side = Side.Right;
            }
        }

        lerpX = Mathf.Lerp(lerpX, newX, Time.deltaTime * 10f);
        go.transform.position = new Vector3(lerpX, go.transform.position.y, go.transform.position.z);
    }

    void HorizontalMoveWithAnimation()
    {
        
        bool left = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        if (left)
        {
            if (side == Side.Right)
            {
                newX = 0; // towards left(mid side)
                animator.Play(LeftAnimation);
                side = Side.Mid;
            }
            else if (side == Side.Mid)
            {
                newX = X * -1; // towards left(left side)
                animator.Play(LeftAnimation);
                side = Side.Left;
            }
            
        }
        else if (right)
        {
            if (side == Side.Left)
            {
                newX = 0; // towards right(mid side)
                animator.Play(RightAnimation);
                side = Side.Mid;
            }
            else if (side == Side.Mid)
            {
                newX = X * 1; // towards right(right side)
                animator.Play(RightAnimation);
                side = Side.Right;
            }
            
        }

        lerpX = Mathf.Lerp(lerpX,newX,Time.deltaTime * LerpSpeed);
        go.transform.position = new Vector3(lerpX, go.transform.position.y, go.transform.position.z);
    }
}
