using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s")) {
            SceneManager.LoadScene("Prologue");
        }
        else if (Input.GetKeyDown("c")) {

            SceneManager.LoadScene(PlayerPrefs.GetString("Level", "Prologue"));
        }
        else if (Input.GetKeyDown("q")) {
            Application.Quit();
        }
        else if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("Level Teletubby 0");
        }
        else if (Input.GetKeyDown("2")) {
            SceneManager.LoadScene("Level 5");
        }
    }
}
