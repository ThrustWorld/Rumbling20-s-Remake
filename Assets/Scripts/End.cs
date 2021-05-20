using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class End : MonoBehaviour
{
    GUIStyle Guistyle;
    Menu script;
    // Start is called before the first frame update
    void Start()
    {
        Guistyle = new GUIStyle();
        Guistyle.fontSize = 25;
        script = GetComponent<Menu>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Time.timeScale = 1;
            Scene newScene = SceneManager.CreateScene("GGJ5.0");
            script.enabled = false;
        }
    }

    private void OnGUI()
    {
        GUIUtility.RotateAroundPivot(-90, new Vector3(Screen.width * 0.5f, Screen.height * 0.5f + 100, 0));
        GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.5f, 200, 100), "GAME OVER", Guistyle);
    }
}
