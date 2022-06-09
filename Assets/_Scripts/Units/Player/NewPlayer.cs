using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : UnitBase
{
    [SerializeField] ScriptablePlayer data;
    [SerializeField] float _value;
    
    Rigidbody rb;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State != GameState.Flow)
            return;
        Movement();
    }


    void FixedUpdate()
    {
         if(GameManager.Instance.State != GameState.Flow)
            return;
        UpdateRBPosition();
    }

    void Movement()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(x == -_value)
                return;
            x += - _value;
            Rotation(true);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if(x == _value)
                return;
            x += _value;
            Rotation(false);
        }
    }

    void Rotation(bool left)
    {
        if(left)
        {
            //LeftAnimation
            Debug.Log("Left");
        }

        if(!left)
        {
            //RightAnimation
            Debug.Log("Right");
        }
    }

    void UpdateRBPosition()
    {
        rb.MovePosition(Vector3.Lerp(new Vector3(rb.position.x,rb.position.y,rb.position.z),new Vector3(x,rb.position.y,rb.position.z), Time.deltaTime * data.BaseStats.Speed));
        rb.AddForce(0,0,0.1F,ForceMode.Force);
    }
}
