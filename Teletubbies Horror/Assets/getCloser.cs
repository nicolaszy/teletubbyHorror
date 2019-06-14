using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getCloser : MonoBehaviour
{
    int counter = 0;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter < 600) {
            rb.position = rb.position + new Vector2(-0.1f,-0.1f);
            counter++;

        }
        else if(counter < 1200) {
            counter++;
        }
        else {
            SceneManager.LoadScene("Level 0");
        }
    }
}
