using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    int posX = 0;
    public AudioSource creepyBaby;
    bool babyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(posX < 580) {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,-3f);
            posX += 1;
        }
        else {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            if (!babyPlayed)
            {
                creepyBaby.Play();
                babyPlayed = true;
            }
        }
    }
}
