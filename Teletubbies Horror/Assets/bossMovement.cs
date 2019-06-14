using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : MonoBehaviour
{
    public ParticleSystem burp;
    public GameObject player;
    public Animator animation;

    int lives = 3;
    bool lifeLost = false;
    int timer = 100;
    bool dead = false;
    bool turnMusicDown = false;

    public GameObject doorOut;

    bool goLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!lifeLost && collision.collider.tag == "Player") {
            lives -= 1;
            this.transform.position -= new Vector3(0, 1f, 0);
            lifeLost = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (turnMusicDown && GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().volume > 0) {
            GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().volume -= 0.1f;
        }
        if (dead) {
            this.transform.position -= new Vector3(0, 1f, 0);
        }
        if (lives < 2)
        {
            //change to crying animation
            animation.SetInteger("state", 1);
        }
        if (lives < 1)
        {
            animation.SetInteger("state", 2);
            print("you won!");
            this.GetComponent<Rigidbody2D>().gravityScale = 3;
            doorOut.GetComponent<Rigidbody2D>().gravityScale = -2;
            dead = true;
            burp.Stop();
            turnMusicDown = true;
        }
        if (lifeLost && timer > 0)
        {
            timer -= 1;
        }
        else if (lifeLost) {
            lifeLost = false;
            timer = 100;
        }
        burp.transform.position = this.transform.position - new Vector3(0,1,0);

        if (player.GetComponent<playerMovement>().bossState == "going_left" && this.transform.position.x > 143 && goLeft && !dead)
        {
            this.transform.position = this.transform.position + new Vector3(-0.08f, 0, 0);
            this.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        else if(player.GetComponent<playerMovement>().bossState == "going_left" && this.transform.position.x < 167 && !dead)
        {
            goLeft = false;
            this.transform.position = this.transform.position + new Vector3(+0.08f, 0, 0);
            this.transform.rotation = new Quaternion(0, 180, 0, 1);
        }
        else {
            goLeft = true;
        }
    }
}
