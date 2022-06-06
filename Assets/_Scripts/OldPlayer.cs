using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OldPlayer : MonoBehaviour
{
    //References
    [SerializeField]
    internal InputManager Input;

    [SerializeField]
    internal MovementManager Movement;

    //Player properties
    private Animator animator;

    public static int Hp;

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
        Movement.lerpSpeed = 2f;
        Movement.x = 0.08f;
        Movement.newX = 0;
        //Player prop
        Hp = 3;
    }

    // Update is called once per frame
    private  void Update()
    {
        // Input Update
        Input.CustomUpdate();
        // Movement Update
        Movement.MoveLeft(Input,gameObject,animator,"LeftTurn");
        Movement.MoveRight(Input, gameObject, animator, "RightTurn");
        Debug.Log(Hp);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hole" && gameObject.tag == "Player")
        {
            Score.CurrentScore -= 10;
            if(Hp > 0)
            {
                Hp--;
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "PowerUp" && gameObject.tag == "Player")
        {
            Score.CurrentScore += 5;
            if (Hp < 3)
            {
                Hp++;
            }
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "EnemyCar" && gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
        }
    }
}
