using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioController controller;
    public AudioSource Audiosource;

    public Transform Hole;
    public Transform Lamp;
    public Transform Building;
    public Transform Barrow;
    public Transform Player;
    public Transform HP;
    public Transform HP1;
    public Transform HP2;

    public float MinSpawnTime;
    public float MaxSpawnTime;
    public float speedToSubtract;
    public float probHole_Barrows;
    //public float probLamp;
    //public float probBarrow;

    int MaxHoles;
    int MaxLamp;
    int MaxBarrows;
    int MaxBuildings;

    public static int lives;
    //float timeToStart;
    //public float timeCheck;
    //public float speedMultiplier;
    //public float EndMaxRand;

    List<List<GameObject>> obstacles;
    List<GameObject> holes;
    List<GameObject> lampsLeft;
    List<GameObject> lampsRight;
    List<GameObject> buildingsLeft;
    List<GameObject> buildingsRight;
    List<GameObject> barrows;

    public float LampTimer;
    float lampSpawnCounter;
    float Timer;
    int RandObstacle;
    public float BuildingTimer;
    float buildingSpawnCounter;

    int holeCounter;
    int leftLampCounter;
    int rightLampCounter;
    int barrCounter;
    int leftBuildingCounter;
    int rightBuildingCounter;

    GameObject thePlayer;
    StreetScroll playerScript;
    public Vector3 width;

    //public Animation animation;
    //public string FallingLamp;
    int xPos;

    List<List<BoxCollider>> obstaclesColliders;
    List<BoxCollider> boxCollidersHoles;
    List<BoxCollider> boxCollidersLeftLamps;
    List<BoxCollider> boxCollidersRightLamps;
    List<BoxCollider> boxCollidersBarrow;
    BoxCollider playerCollider;


    GameObject LampTrigger;
    bool IsStarting;

    void Start()
    {
        IsStarting = true;
        Audiosource = gameObject.GetComponent<AudioSource>();

        thePlayer = GameObject.Find("SM_Street");
        playerScript = thePlayer.GetComponent<StreetScroll>();

        playerCollider = Player.GetComponent<BoxCollider>();
        boxCollidersBarrow = new List<BoxCollider>();
        boxCollidersHoles = new List<BoxCollider>();
        boxCollidersLeftLamps = new List<BoxCollider>();
        boxCollidersRightLamps = new List<BoxCollider>();
        obstaclesColliders = new List<List<BoxCollider>>();

        lives = 3;

        MaxLamp = 15;
        MaxBarrows = 15;
        MaxHoles = 15;
        MaxBuildings = 15;
        holes = new List<GameObject>();
        lampsLeft = new List<GameObject>();
        lampsRight = new List<GameObject>();
        buildingsLeft = new List<GameObject>();
        buildingsRight = new List<GameObject>();
        barrows = new List<GameObject>();
        obstacles = new List<List<GameObject>>();
        width = playerScript.Street.GetChild(0).transform.position - playerScript.Street.GetChild(1).transform.position;
        playerScript.Street.GetChild(1);

        //Holes Instantiate
        for (int i = 0; i < MaxHoles; i++)
        {
            GameObject go;
            go = Instantiate(Hole.gameObject);
            go.SetActive(false);
            //go.transform.localScale = new Vector3(playerScript.Street.localScale.x * width.magnitude / (width.magnitude / 3), playerScript.Street.localScale.x * width.magnitude / (width.magnitude / 3), playerScript.Street.localScale.x * width.magnitude / (width.magnitude / 3));
            go.transform.localScale *= 0.1f;

            boxCollidersHoles.Add(go.GetComponent<BoxCollider>());
            holes.Add(go);
        }
        Timer = Random.Range(MinSpawnTime, MaxSpawnTime);

        //Lamps Instantiate
        for (int i = 0; i < MaxLamp; i++)
        {
            GameObject go;
            go = Instantiate(Lamp.gameObject);
            go.SetActive(false);

            boxCollidersLeftLamps.Add(go.GetComponent<BoxCollider>());

            lampsLeft.Add(go);
        }
        for (int i = 0; i < MaxLamp; i++)
        {
            GameObject go;
            go = Instantiate(Lamp.gameObject);
            go.SetActive(false);
            lampsRight.Add(go);
            lampsRight[i].transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            boxCollidersRightLamps.Add(go.GetComponent<BoxCollider>());
        }

        //Barrow Instantiate
        for (int i = 0; i < MaxBarrows; i++)
        {
            GameObject go;
            go = Instantiate(Barrow.gameObject);
            go.SetActive(false);
            //go.transform.localScale = new Vector3(playerScript.Street.localScale.x * width.magnitude / (width.magnitude / 3), playerScript.Street.localScale.x * width.magnitude / (width.magnitude / 3) * 2, playerScript.Street.localScale.x * width.magnitude / (width.magnitude / 3));
            //go.transform.localScale = new Vector3(playerScript.Street.localScale.x / 10, playerScript.Street.localScale.x / 10, playerScript.Street.localScale.x / 10);

            boxCollidersBarrow.Add(go.GetComponent<BoxCollider>());

            barrows.Add(go);
        }

        //Buildings Instantiate
        for (int i = 0; i < MaxBuildings; i++)
        {
            GameObject go;
            go = Instantiate(Building.gameObject);
            go.SetActive(false);

            buildingsLeft.Add(go);
            buildingsLeft[i].transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        for (int i = 0; i < MaxBuildings; i++)
        {
            GameObject go;
            go = Instantiate(Building.gameObject);
            go.SetActive(false);
            buildingsRight.Add(go);
        }

        Timer = Random.Range(MinSpawnTime, MaxSpawnTime);

        obstacles.Add(holes);
        obstacles.Add(lampsLeft);
        obstacles.Add(lampsRight);
        obstacles.Add(barrows);

        obstaclesColliders.Add(boxCollidersHoles);
        obstaclesColliders.Add(boxCollidersLeftLamps);
        obstaclesColliders.Add(boxCollidersRightLamps);
        obstaclesColliders.Add(boxCollidersBarrow);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    //other.gameObject.GetComponent animator
    //    Debug.Log("OnTriggerEnter fired. Collider gameObject is: " + other.gameObject.name);

    //}
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.timeScale == 0)
        {
            //Scene newScene = SceneManager.GetSceneByName("GGJ5.0");
            SceneManager.LoadScene("GGJ5.0");
        }
        //timeToStart += Time.deltaTime;
        //if (timeToStart > timeCheck)
        //{
        //    playerScript.speed *= speedMultiplier;
        //    timeToStart = 0;
        //    Debug.Log(playerScript.speed);
        //}
        //if (MaxSpawnTime < EndMaxRand)
        //{
        //    MaxSpawnTime = EndMaxRand;
        //}

        //Debug.Log("End" + EndMaxRand);

        //GameObject thePlayer = GameObject.Find("SM_Street");
        //StreetScroll playerScript = thePlayer.GetComponent<StreetScroll>();

        Timer -= Time.deltaTime;
        RandObstacle = Random.Range(0, 100);

        if (Timer < 0)
        {
            //Hole
            if (RandObstacle <= probHole_Barrows)
            {
                int xPos = Random.Range(0, 3);
                if (xPos == 0)
                {
                    holes[holeCounter].transform.position = new Vector3(-(width.magnitude / 6) * 2, 0, 20);
                }
                else if (xPos == 1)
                {
                    holes[holeCounter].transform.position = new Vector3((width.magnitude / 6) * 2, 0, 20);
                }
                else if (xPos == 2)
                {
                    holes[holeCounter].transform.position = new Vector3(0, 0, 20);
                }
                holes[holeCounter].SetActive(true);
                if (holeCounter < MaxHoles - 1)
                {
                    holeCounter++;
                }
                else
                {
                    holeCounter = 0;
                }
                Timer = Random.Range(MinSpawnTime, MaxSpawnTime);
            }

            //Barrow
            else if (RandObstacle >= probHole_Barrows /*&& RandObstacle <= probBarrow*/)
            {
                int xPos = Random.Range(0, 3);
                if (xPos == 0)
                {
                    barrows[barrCounter].transform.position = new Vector3(-(width.magnitude / 6) * 2, 0, 20);
                }
                else if (xPos == 1)
                {
                    barrows[barrCounter].transform.position = new Vector3((width.magnitude / 6) * 2, 0, 20);
                }
                else if (xPos == 2)
                {
                    barrows[barrCounter].transform.position = new Vector3(0, 0, 20);
                }
                barrows[barrCounter].SetActive(true);
                if (barrCounter < MaxBarrows - 1)
                {
                    barrCounter++;
                }
                else
                {
                    barrCounter = 0;
                }
                Timer = Random.Range(MinSpawnTime, MaxSpawnTime);
            }

            //else if (RandObstacle >= probBarrow)
            //{
            //    LampTrigger.SetActive(true);
            //}
        }


        //Lamp
        lampSpawnCounter -= Time.deltaTime;
        if (lampSpawnCounter <= 0)
        {
            if (xPos == 0)
            {
                lampsLeft[leftLampCounter].transform.position = new Vector3(-(width.magnitude / 6) * 4, 0, 20);
                xPos = 1;
                lampsLeft[leftLampCounter].SetActive(true);
            }
            else if (xPos == 1)
            {
                lampsRight[rightLampCounter].transform.position = new Vector3((width.magnitude / 6) * 4, 0, 20);
                xPos = 0;
                lampsRight[rightLampCounter].SetActive(true);

            }
            if (leftLampCounter < MaxLamp - 1)
            {
                leftLampCounter++;
            }
            else
            {
                leftLampCounter = 0;
            }
            if (rightLampCounter < MaxLamp - 1)
            {
                rightLampCounter++;
            }
            else
            {
                rightLampCounter = 0;
            }
            lampSpawnCounter = LampTimer;
        }

        //Building
        buildingSpawnCounter -= Time.deltaTime;
        if (buildingSpawnCounter <= 0)
        {
            //if (xPos == 0)
            //{
            buildingsLeft[leftBuildingCounter].transform.position = new Vector3(-(width.magnitude / 6) * 6, 6.5f, 20);
            //xPos = 1;
            buildingsLeft[leftBuildingCounter].SetActive(true);
            //}
            //else if (xPos == 1)
            //{
            buildingsRight[rightBuildingCounter].transform.position = new Vector3((width.magnitude / 6) * 6, 6.5f, 20);
            //xPos = 0;
            buildingsRight[rightBuildingCounter].SetActive(true);

            //}
            if (leftBuildingCounter < MaxBuildings - 1)
            {
                leftBuildingCounter++;
            }
            else
            {
                leftBuildingCounter = 0;
            }
            if (rightBuildingCounter < MaxBuildings - 1)
            {
                rightBuildingCounter++;
            }
            else
            {
                rightBuildingCounter = 0;
            }
            buildingSpawnCounter = BuildingTimer;
        }

        for (int i = 0; i < holes.Count; i++)
        {
            if (holes[i].activeSelf)
            {
                holes[i].transform.position -= new Vector3(0, 0, playerScript.speed) * Time.deltaTime;
            }
        }
        for (int i = 0; i < lampsLeft.Count; i++)
        {
            if (lampsLeft[i].activeSelf)
            {
                lampsLeft[i].transform.position -= new Vector3(0, 0, playerScript.speed) * Time.deltaTime;
            }
        }
        for (int i = 0; i < lampsRight.Count; i++)
        {
            if (lampsRight[i].activeSelf)
            {
                lampsRight[i].transform.position -= new Vector3(0, 0, playerScript.speed) * Time.deltaTime;
            }
        }
        for (int i = 0; i < buildingsLeft.Count; i++)
        {
            if (buildingsLeft[i].activeSelf)
            {
                buildingsLeft[i].transform.position -= new Vector3(0, 0, playerScript.speed) * Time.deltaTime;
            }
        }
        for (int i = 0; i < buildingsRight.Count; i++)
        {
            if (buildingsRight[i].activeSelf)
            {
                buildingsRight[i].transform.position -= new Vector3(0, 0, playerScript.speed) * Time.deltaTime;
            }
        }
        for (int i = 0; i < barrows.Count; i++)
        {
            if (barrows[i].activeSelf)
            {
                barrows[i].transform.position -= new Vector3(0, 0, playerScript.speed * 1.5f) * Time.deltaTime;
            }
        }

        if (!controller.AudioSource.isPlaying)
        {
            if (lives == 3)
            {
                HP.gameObject.SetActive(true);
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(true);

                controller.AudioSource.Stop();
                controller.PlayEngine();

            }
            else if (lives == 2)
            {
                HP.gameObject.SetActive(true);
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(false);
                controller.AudioSource.Stop();

                controller.PlayEngine();

            }
            else if (lives == 1)
            {
                HP.gameObject.SetActive(true);
                HP1.gameObject.SetActive(false);
                HP2.gameObject.SetActive(false);
                controller.AudioSource.Stop();

                controller.PlayEngineRotto();

            }
            else if (lives == 0)
            {
                HP.gameObject.SetActive(false);
                HP1.gameObject.SetActive(false);
                HP2.gameObject.SetActive(false);
                Time.timeScale = 0;
            }
        }
        if (lives == 3)
        {
            HP.gameObject.SetActive(true);
            HP1.gameObject.SetActive(true);
            HP2.gameObject.SetActive(true);


        }
        else if (lives == 2)
        {
            HP.gameObject.SetActive(true);
            HP1.gameObject.SetActive(true);
            HP2.gameObject.SetActive(false);

        }
        else if (lives == 1)
        {
            HP.gameObject.SetActive(true);
            HP1.gameObject.SetActive(false);
            HP2.gameObject.SetActive(false);

        }
        else if (lives == 0)
        {
            HP.gameObject.SetActive(false);
            HP1.gameObject.SetActive(false);
            HP2.gameObject.SetActive(false);
            Time.timeScale = 0;
        }


        for (int i = 0; i < obstaclesColliders.Count; i++)
        {
            for (int j = 0; j < obstaclesColliders[i].Count; j++)
            {
                //Debug.Log("I :" + i);
                //Debug.Log("J :" + j);

                if (obstacles[i][j].activeSelf)
                {
                    if (playerCollider.bounds.Intersects(obstaclesColliders[i][j].bounds))
                    {
                        if (i < 3)
                        {
                            //Audiosource.PlayOneShot(controller.schianto, 1);
                            controller.AudioSource.Stop();
                            controller.PlayBuche();
                            obstacles[i][j].SetActive(false);
                            lives--;
                            playerScript.speed -= speedToSubtract;
                            //Debug.Log(playerScript.speed);
                            if (playerScript.speed <= 0)
                            {
                                playerScript.speed = 1;
                            }
                        }
                        else if (i == 3)
                        {
                            //controller.AudioSource.Stop();
                            controller.PlaySchianto();
                            lives = 0;
                            Time.timeScale = 0;

                            
                        }
                    }
                }
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("StreetLamp")) 
    //    {
    //        Debug.Log("in");
    //        Animator animator = new Animator();
    //        //animator.GetComponent<Animation>();
    //        animator.SetTrigger("LampFall");
    //    }
    //}
    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 100, 10, 100, 50), "Time: " + Time.time.ToString());
    }
}
