using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontStopTheMusicUnless : MonoBehaviour
{

    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("music").Length > 1)
            Destroy(GameObject.FindGameObjectWithTag("music"));
        if (GameObject.FindGameObjectsWithTag("music").Length > 1)
            Destroy(GameObject.FindGameObjectWithTag("music"));
        if (GameObject.FindGameObjectsWithTag("music").Length > 1)
            Destroy(GameObject.FindGameObjectWithTag("music"));
        DontDestroyOnLoad(music);
    }
}
