﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //References
    [SerializeField]
    internal InputManager Input;

    [SerializeField]
    internal MovementManager Movement;
   
    //Player properties
    Animator animator;


    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        //Input
        Input.CustomStart();
        Input.delay = 1.2f;
        // Player's values for Movement properties
        Movement.side = Side.Mid;
        Movement.newX = 0f;
        Movement.LerpSpeed = 2f;
        Movement.X = 0.08f;
    }

    // Update is called once per frame
    private  void Update()
    {
        // Input Update
        Input.CustomUpdate();
        // Movement Update
        Movement.MoveLeft(Input,gameObject,animator,"LeftTurn");
        Movement.MoveRight(Input, gameObject, animator, "RightTurn");
    }
}
