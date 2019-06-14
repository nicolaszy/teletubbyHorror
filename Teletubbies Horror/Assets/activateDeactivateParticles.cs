using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateDeactivateParticles : MonoBehaviour
{

    ParticleSystem p;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<ParticleSystem>();
        p.Stop();
    }


    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        print("collision");
        p.Play();
        print("particles activated");

    }
}

