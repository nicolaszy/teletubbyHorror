using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatUpAndDown : MonoBehaviour
{
    bool goingUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -14.5 && goingUp) {
            this.transform.position += new Vector3(0, 0.01f, 0);
            goingUp = true;
        }
        else if(this.transform.position.y > -15.5) {
            this.transform.position -= new Vector3(0, 0.01f, 0);
            goingUp = false;
        }
        else {
            goingUp = !goingUp;
        }
    }
}
