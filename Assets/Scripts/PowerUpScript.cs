using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    public AudioController controller;
    public AudioSource Audiosource;

    public List<CapsuleCollider> powerUpColliders;
    BoxCollider playerCollider;
    public Transform PowerUp;
    public float MaxPowerUps;
    public float MinRand;
    public float MaxRand;
    public float timeCheck;
    public float speedMultiplier;
    public float EndMaxRand;
    public float rotVelocity;
    public float xRot;
    public float yRot;
    public float zRot;
    float timeToStart;
    float Timer;
    float rand;
    int powerUpsCounter;

    Vector3 powerUpToObst;

    GameObject street;
    public List<GameObject> powerUps;
    StreetScroll streetScript;
    GameObject player;

    void Start()
    {
        Audiosource = gameObject.GetComponent<AudioSource>();

        street = GameObject.Find("SM_Street");
        player = GameObject.Find("SM_Car_WIP");
        streetScript = street.GetComponent<StreetScroll>();
        powerUps = new List<GameObject>();
        powerUpColliders = new List<CapsuleCollider>();
        playerCollider = player.GetComponent<BoxCollider>();
        //PowerUp.localScale *= 1.1f;

        for (int i = 0; i < MaxPowerUps; i++)
        {
            GameObject go;
            go = Instantiate(PowerUp.gameObject);
            go.SetActive(false);

            powerUps.Add(go);
        }
        Timer = Random.Range(MinRand, MaxRand);
    }

    void Update()
    {
        timeToStart += Time.deltaTime;
        if (timeToStart > timeCheck)
        {
            MaxRand *= speedMultiplier;
            timeToStart = 0;
        }
        if (MaxRand > EndMaxRand)
        {
            MaxRand = EndMaxRand;
        }

        Timer -= Time.deltaTime;
        rand = Random.Range(MinRand, MaxRand);

        if (Timer < 0)
        {
            int xPos = Random.Range(0, 3);
            Debug.Log(powerUpsCounter);
            if (xPos == 0)
            {
                powerUps[powerUpsCounter].transform.position = new Vector3(-0.8f, 0.01f, 20);
            }
            else if (xPos == 1)
            {
                powerUps[powerUpsCounter].transform.position = new Vector3(0.8f, 0.01f, 20);
            }
            else if (xPos == 2)
            {
                powerUps[powerUpsCounter].transform.position = new Vector3(0, 0.01f, 20);
            }
            powerUps[powerUpsCounter].SetActive(true);
            if (powerUpsCounter < MaxPowerUps - 1)
            {
                powerUpsCounter++;
            }
            else
            {
                powerUpsCounter = 0;
            }
            Timer = Random.Range(MinRand, MaxRand);
        }
        for (int i = 0; i < powerUps.Count; i++)
        {
            if (powerUps[i].activeSelf)
            {
                powerUps[i].transform.RotateAround(powerUps[i].transform.position, Vector3.right, xRot * rotVelocity);
                powerUps[i].transform.RotateAround(powerUps[i].transform.position, Vector3.up, yRot * rotVelocity);
                powerUps[i].transform.RotateAround(powerUps[i].transform.position, Vector3.forward, zRot * rotVelocity);
                powerUps[i].transform.position -= new Vector3(0, 0, streetScript.speed) * Time.deltaTime;
            }
            if (powerUpColliders.Count < MaxPowerUps)
            {
                powerUpColliders.Add(powerUps[i].GetComponent<CapsuleCollider>());

            }
            Debug.Log("powerups: " + powerUpColliders.Count);
        }

        

        for (int i = 0; i < powerUps.Count; i++)
        {

            if (powerUps[i].activeSelf)
            {
                if (playerCollider.bounds.Intersects(powerUpColliders[i].bounds) && playerCollider.bounds.Intersects(powerUpColliders[i].bounds))
                {
                    powerUps[i].SetActive(false);

                    if(NewBehaviourScript.lives < 3)
                    {
                        NewBehaviourScript.lives++;
                    }

                    controller.AudioSource.Stop();

                    if (!controller.AudioSource.isPlaying)
                    {
                        controller.PlayRepair();
                    }


                }
                /*if(playerCollider.bounds.Contains(powerUpColliders[i].bounds.min) && playerCollider.bounds.Contains(powerUpColliders[i].bounds.max))
                {
                    Debug.Log("colliso");
                }*/
            }
        }
    }

}
