using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evil_tubby_fast : MonoBehaviour
{

    public Animator animation;
    public GameObject player;
    public AudioSource scream;
    public AudioSource walk;
    bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        scream.time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(player.transform.position.x - this.gameObject.transform.position.x) < 7 && Math.Abs(player.transform.position.y - this.gameObject.transform.position.y) < 4 &&!collided)
        {
            animation.SetInteger("state", 1);
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(-3f, this.GetComponent<Rigidbody2D>().velocity.y, 0f);
            if (!walk.isPlaying)
            {
                walk.Play();
                walk.pitch = 5;
            }
        }
        else if(!collided)
        {
            animation.SetInteger("state", 0);
            walk.Stop();
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, this.GetComponent<Rigidbody2D>().velocity.y, 0f);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player" && !collided)
        {
            scream.Play();
            walk.Stop();
            animation.SetInteger("state", 2);
            collided = true;
        }
        else if (collision.collider.tag == "Player")
        {
            this.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}

