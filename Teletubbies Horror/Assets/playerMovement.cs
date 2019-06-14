using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    public GameObject infoText; 

    public static bool tripleJump = false;
    
    float moveHorizontal = 0f;

    public Camera mainCamera;

    public float moveSpeed = 40f;

    Vector2 jumpForce = new Vector2(0, 300);

    Vector2 leftForce = new Vector2(-140,0);

    Vector2 rightForce = new Vector2(140,0);

    public GameObject dark_circle;

    bool die = false;

    bool turned;

    public string bossState = "waiting";

    public string nextScene;

    public string currentScene;

    bool jump = false;

    bool canStillJumpTriple = false;

    bool canStillJump = false;

    bool canJump = false;

    bool looksLeft = false;

    bool zoomOut = false;

    public Rigidbody2D player;

    int timer = 0;

    public Animator animation;

    bool canWalkLeft = true;
    bool canWalkRight = true;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        if(currentScene != "Main Menu") {
            PlayerPrefs.SetString("Level", currentScene);
            print(currentScene);
            print(PlayerPrefs.GetString("Level", "Main Menu"));
        }
        if(currentScene=="Level 1") {
            PlayerPrefs.SetInt("tripleJump", 0);
        }
        if(currentScene=="Level gravity" || currentScene == "Level gravity 2") {
            float characterScale = transform.localScale.x;
            characterScale *= -1;
            transform.localScale = new Vector3(characterScale, transform.localScale.y, transform.localScale.z);
            looksLeft = true;
        }
        if (PlayerPrefs.GetInt("tripleJump", 0) == 1) {
            print("triple jump activated"+ PlayerPrefs.GetInt("tripleJump"));
            tripleJump = true;
        }
        else {
            tripleJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (die) {
            animation.SetInteger("state", 4);
            if (timer > 100) {
                SceneManager.LoadScene(currentScene);
            }
            timer += 1;
            return;
        }
        if (turned) {
            if (player.rotation > -90)
            {
                player.rotation = player.rotation - 5f;
            }
        }
        else {
            if (player.rotation < -0.0001)
            {
                player.rotation = player.rotation + 5f;
            }
        }
        moveHorizontal = Input.GetAxisRaw("Horizontal")*moveSpeed;

        if (player.velocity.y > 0.6)
        {
            animation.SetInteger("state", 1);
        }
        else if (player.velocity.y < -0.6)
        {
            animation.SetInteger("state", 2);
        }
        else
        {
            if (player.velocity.x > 0) 
            {
                animation.SetInteger("state", 3);
            }
            else if (player.velocity.x < 0)
            {
                animation.SetInteger("state", 3);
            }
            else
            {
                animation.SetInteger("state", 0);
            }
        }

        if (Input.GetKeyDown("space") && canStillJump && canJump)
        {
            jump = true;
            canJump = false;
        }

        else if (Input.GetKeyDown("space") && canStillJump && !canJump) {
            jump = true;
            canStillJump = false;
        }
        else if(Input.GetKeyDown("space") && !canStillJump && !canJump && canStillJumpTriple)
        {
            jump = true;
            canStillJump = false;
            canStillJumpTriple = false;
        }

        else if (Input.GetKey("left") && canWalkLeft) {
            if (!turned)
            {
                player.velocity = new Vector2(0.0001f, player.velocity.y);
            }
            else {
                player.velocity = new Vector2(player.velocity.x, 0.0001f);
            }
            player.AddForce(leftForce);
            if (!looksLeft)
            {
                float characterScale = transform.localScale.x;
                characterScale *= -1;
                transform.localScale = new Vector3(characterScale, transform.localScale.y, transform.localScale.z);
                looksLeft = true;
            }
        }

        else if (Input.GetKey("right") && canWalkRight)
        {
            if (!turned)
            {
                player.velocity = new Vector2(0.0001f, player.velocity.y);
            }
            else
            {
                player.velocity = new Vector2(player.velocity.x, 0.0001f);
            }
            player.AddForce(rightForce);

            if (looksLeft)
            {
                float characterScale = transform.localScale.x;
                characterScale *= -1;
                transform.localScale = new Vector3(characterScale, transform.localScale.y, transform.localScale.z);
                looksLeft = false;
            }
        }

        if(zoomOut && mainCamera.fieldOfView < 130) {
            mainCamera.fieldOfView += 1;
            dark_circle.transform.localScale = dark_circle.transform.localScale + new Vector3(0.01f,0.01f,0.01f);

        }
    }

    private void OnParticleCollision(GameObject other)
    {
        die = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Ground")) {
            if (turned)
            {
                Physics2D.gravity = new Vector2(0, -9.81f);

                jumpForce = new Vector2(0, 300);
                leftForce = new Vector2(-140, 0);
                rightForce = new Vector2(140, 0);

                turned = false;
            }

            canJump = true;
            canStillJump = true;
            if (tripleJump)
            {
                canStillJumpTriple = true;
            }

            if (collision.gameObject.tag == "Ground_slip"){
                canWalkLeft = false;
                canWalkRight = false;
            }
            else{
                canWalkLeft = true;
                canWalkRight = true;
            }
        }
        else if (collision.gameObject.tag == "Respawn")
        {
            die = true;
        }
        else if (collision.gameObject.tag == "enemy")
        {
            if (collision.transform.position.y > this.transform.position.y)
            {
                die = true;

            }
            else {
                collision.rigidbody.gravityScale = 10;
                collision.collider.tag = "Untagged";
                collision.rigidbody.mass = 1;
                collision.transform.localScale = new Vector3(0.5f, 0.2f, 0.5f);
                }
        }
        else if(collision.gameObject.tag == "Finish") {
            SceneManager.LoadScene(nextScene);
        }
        else if(collision.gameObject.tag == "vertical")
        {
            if (!turned) {
                Physics2D.gravity = new Vector2(-10, 0);

                jumpForce = new Vector2(420,0);
                leftForce = new Vector2(0,200);
                rightForce = new Vector2(0,-200);
                turned = true;
            }
            canJump = true;
            canStillJump = true;
            if (tripleJump) {
                canStillJumpTriple = true;
            }
        }
        else if(collision.gameObject.tag == "start_water") {
            waterController.start = true;
            waterController.end = false;
            collision.gameObject.SetActive(false);
            }
        else if (collision.gameObject.tag == "stop_water")
        {
            waterController.start = false;
            waterController.end = true;
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "unlockTripleJump") {
            tripleJump = true;
            PlayerPrefs.SetInt("tripleJump", 1);
            infoText.SetActive(true);
        }
        else if(collision.gameObject.tag == "camera_zoom_out") {
            //zoom out camera, close arena doors (activate strong gravity on doors) 

            //change camera distance by changing property that then in each update zooms out a bit
            zoomOut = true;
            bossState = "going_left";
            collision.gameObject.SetActive(false);

            //tag arena doors, get by tag, enable gravity
            GameObject.FindGameObjectsWithTag("door")[0].GetComponent<Rigidbody2D>().gravityScale = 1;
            GameObject.FindGameObjectsWithTag("door")[1].GetComponent<Rigidbody2D>().gravityScale = 1;

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
