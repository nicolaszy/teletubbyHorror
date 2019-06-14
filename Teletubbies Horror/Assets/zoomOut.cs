using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomOut : MonoBehaviour
{
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Camera>().fieldOfView < 175)
        {
            this.GetComponent<Camera>().fieldOfView += 0.3f;
        }
        else {
            p.SetActive(false);
        }
    }
}
