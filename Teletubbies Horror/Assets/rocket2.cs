using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class rocket2 : MonoBehaviour
{
    Vector3 flyForce = new Vector3(700, 0, 0);
    bool controlsDisabled;
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(flyForce);
    }


    // Update is called once per frame
    void Update()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("colliding");
        if (collision.gameObject.tag == "Finish")
        {
            controlsDisabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Respawn") {
            SceneManager.LoadScene("Level 1");
        }
        if (collision.gameObject.tag == "Finish")
        {
            controlsDisabled = true;
            Destroy(collision.gameObject);
            rb2D.velocity = new Vector2(0,0);
            rb2D.AddForce(flyForce*0.7f);
            rb2D.gameObject.GetComponents<ParticleSystem>()[0].Stop();
        }
    }
}
