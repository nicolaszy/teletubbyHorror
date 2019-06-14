using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterController : MonoBehaviour
{

    int level = 0;
    public static bool start = false;
    public static bool end = false;
    Rigidbody2D water;
    // Start is called before the first frame update
    void Start()
    {
        water = GetComponent<Rigidbody2D>();
        level = 0;
        start = false;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (level < 1800)
            {
                water.position = new Vector2(water.position.x, water.position.y + 0.002f);
                level += 1;
            }
        }
        else if (end) { 
            if(level > 0) {
                water.position = new Vector2(water.position.x, water.position.y - 0.002f);
                level -= 1;
            }
        }
    }
}
