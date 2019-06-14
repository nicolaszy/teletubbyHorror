using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letTileMapDisappear : MonoBehaviour
{

    public GameObject player;
    public GameObject tileMap; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.x - this.transform.position.x) < 1) {
            tileMap.SetActive(false);
        }
    }
}
