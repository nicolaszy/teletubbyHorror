using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveRight : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying) {
            SceneManager.LoadScene("Main Menu");
        }
        this.transform.position += new Vector3(0.3f, 0, 0);
    }
}
