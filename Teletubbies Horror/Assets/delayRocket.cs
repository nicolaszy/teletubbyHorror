using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayRocket : MonoBehaviour
{
    public int delay = 100;
    GameObject music;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("music");
        Destroy(music);   
    }

    // Update is called once per frame
    void Update()
    {
        if (i < 100) {
            i++;
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else {
            this.GetComponent<Rigidbody2D>().gravityScale = -0.2f;
        }
    }
}
