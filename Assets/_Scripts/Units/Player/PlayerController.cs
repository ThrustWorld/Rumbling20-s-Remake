using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PlayerController : Singleton<PlayerController>
{
    public AudioSource Source;
    public AudioClip[] Clips;
    public float Speed { get; set; }
    public int Health { get; set; }

    [SerializeField] ScriptablePlayer _data; // Player stats
    [SerializeField] float _value; // X pos amount
    [SerializeField] Animator _animatorController;
    [SerializeField] GameObject _particles;
    [SerializeField] GameObject[] _hps;

    float x;
    
    float cooldown;
    float delay;

    float delaySpeed;
    float cooldownSpeed;

    int minSpeed;
    int maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        minSpeed = 1;
        maxSpeed = 10;
        Speed = Mathf.Clamp(_data.BaseStats.Speed, minSpeed, maxSpeed);
        Health = _data.BaseStats.Health;
        x = 0f;
        cooldown = 0.4f;
        delay = cooldown; // First input has no cooldown
        cooldownSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State != GameState.Flow) // Functions are called only if we are in a specific GameState
            return;
        Movement();
        UpdateSpeed();
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
                Rotation(false); // False = right
                delay = 0f;
            }
        }
        UpdatePosition();
    }

    void UpdateSpeed()
    {
        delaySpeed += Time.deltaTime;
        if(delaySpeed > cooldownSpeed)
        {
            Speed += 0.05f;
            delaySpeed = 0f;
        }
        Speed = Mathf.Clamp(Speed, minSpeed, maxSpeed);
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
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        // Update horizontal position based on player input
        transform.position = Vector3.Lerp(new Vector3(transform.position.x,transform.position.y,transform.position.z),new Vector3(x,transform.position.y,transform.position.z),_data.BaseStats.Rotation * Time.deltaTime);
    }

    public void CheckHealth(int value)
    {
        // Value = player's health
        switch(value)
        {
            case 3:
                foreach (var item in _hps)
                {
                    item.SetActive(true);
                }
                break;
            case 2: // - 1 Hp
                _hps[0].SetActive(true);
                _hps[1].SetActive(true);
                _hps[2].SetActive(false);
                _particles.SetActive(false); // engine smoke
                AudioSystem.Instance.PlaySound(Source,Clips[0]); // car engine sound
                break; 
            case 1: // - 2 Hp
                _hps[0].SetActive(true);
                _hps[1].SetActive(false);
                _hps[2].SetActive(false);
                _particles.SetActive(true);
                AudioSystem.Instance.PlaySound(Source,Clips[4]); // broken engine sound
                break;
            case 0: // Gameover
                _hps[0].SetActive(false);
                _hps[1].SetActive(false);
                _hps[2].SetActive(false);
                GameOver();
                break; 
            default: // If you go over 3 Hps
                Health = 3;
                Debug.LogError($"Failed because your health is already to the maximum of {Health}");
                break;
        }
    }

    void GameOver()
    {
        ScoreManager.Instance.SaveScore();
        GameManager.Instance.ChangeState(GameState.Lose);
    }
}
