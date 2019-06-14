using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilTubby : MonoBehaviour
{

    public Animator animation;
    public GameObject player;
    public AudioSource scream;
    public AudioSource walk;
    // Start is called before the first frame update

    bool collided = false;

    void Start()
    {

        scream.time = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(player.transform.position.x - this.gameObject.transform.position.x) < 7 && Math.Abs(player.transform.position.y - this.gameObject.transform.position.y) < 4 && !collided) {
            animation.SetInteger("state", 1);
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(-1f, this.GetComponent<Rigidbody2D>().velocity.y, 0f);
            if (!walk.isPlaying) {
                walk.Play();
            }
        }
        else if(!collided) {
            animation.SetInteger("state", 0);
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, this.GetComponent<Rigidbody2D>().velocity.y, 0f);
            if (walk.isPlaying) {
                walk.Stop();
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.tag == "Player" && !collided) {
                scream.Play();
                walk.Stop();
                animation.SetInteger("state", 2);
            collided = true;
        }
        else if(collision.collider.tag == "Player") {
            this.GetComponent<CapsuleCollider2D>().enabled = false;
          }
    }
}
