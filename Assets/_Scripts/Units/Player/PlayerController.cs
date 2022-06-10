using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitBase
{
    [SerializeField] ScriptablePlayer data; // Player stats
    [SerializeField] float _value;
    [SerializeField] Animator _animatorController;
    
    float x;
    float cooldown;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
        x = 0f;
        cooldown = 0.4f;
        delay = cooldown; // first input has no cooldown
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State != GameState.Flow) // Functions are called only if we are in a specific GameState
            return;
        Movement();
    }

    void Movement()
    {
        // Time to wait before another input
        delay += Time.deltaTime;

        // Check if cooldown between inputs is over
        if(delay >= cooldown)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // If the extreme left has been reached, input is not applied
                if(x == -_value)
                    return;
                x += - _value; // Left movement = negative value
                Rotation(true); // True = left
                delay = 0f; // Reset to reapply cooldown between inputs
            }
            else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // If the extreme right has been reached, input is not applied
                if(x == _value)
                    return;
                // Right movement = positive value
                x += _value;
                Rotation(false); // false = right
                delay = 0f;
            }
        }
        UpdatePosition();
    }

    void Rotation(bool left)
    {
        if(left)
        {
            // LeftAnimation
            _animatorController.Play("LeftRotation");
        }

        if(!left)
        {
            // RightAnimation
            _animatorController.Play("RightRotation");
        }
    }

    void UpdatePosition()
    {
        // Automatic forward translation
        transform.Translate(Vector3.forward * Time.deltaTime * data.BaseStats.Speed);
        // Update horizontal position based on player input
        transform.position = Vector3.Lerp(new Vector3(transform.position.x,transform.position.y,transform.position.z),new Vector3(x,transform.position.y,transform.position.z),data.BaseStats.Rotation * Time.deltaTime);
    }
}
