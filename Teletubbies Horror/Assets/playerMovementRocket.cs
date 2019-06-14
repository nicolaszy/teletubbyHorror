﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovementRocket : MonoBehaviour {

float moveHorizontal = 0f;

    public float moveSpeed = 40f;

    Vector2 jumpForce = new Vector2(0, 300);

    Vector2 leftForce = new Vector2(-500, 0);

    Vector2 rightForce = new Vector2(500, 0);

    bool jump = false;

    bool canStillJump = false;

    bool canJump = false;

    bool started = false;

    bool playing = false;

    public Rigidbody2D player;

    public Rigidbody2D ship;

    public ParticleSystem p;

    public Camera c;

    float timeLeft = 13;
    float timeInAir = 18;


    private void Start()
    {
        p.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if(player.velocity.y < -10) {
            player.velocity = new Vector2(player.velocity.x, -10);
        }
        p.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y,p.transform.position.z);
        timeLeft -= Time.deltaTime;
        timeInAir -= Time.deltaTime;
        if (timeLeft > 0)
        {
            player.transform.position = ship.transform.position;
            if (timeLeft < 5 && !playing) {
                p.Play();
                playing = true;
            }
        }
        else if(!started){
            //p.Stop();
            player.transform.position = player.transform.position + new Vector3(0f, 1.5f, 0f);
            player.velocity = new Vector2(0, 0);
            player.AddForce(new Vector2(400, 1000));
            player.mass = 1;
            player.gravityScale = 1;
            started = true;
            c.orthographicSize = 16;
        }

        if (Input.GetKeyDown("space") && canStillJump && canJump)
        {
            jump = true;
            canJump = false;
        }
        else if (Input.GetKeyDown("space") && canStillJump && !canJump)
        {
            jump = true;
            canStillJump = false;
        }
        if (Input.GetKey("left") && timeInAir<0)
        {
            player.velocity = new Vector2(0, player.velocity.y);
            player.AddForce(leftForce);
        }

        if (Input.GetKey("right") && timeInAir < 0)
        {
            player.velocity = new Vector2(0, player.velocity.y);
            player.AddForce(rightForce);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            canStillJump = true;
        }
        else if (collision.gameObject.tag == "Finish") {
            SceneManager.LoadScene("Level 1");
        }
        else if (collision.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene("Level 0");
        }
    }
    void FixedUpdate()
    {
        if (jump)
        {
            player.AddForce(jumpForce);
        }
        jump = false;
    }
}

