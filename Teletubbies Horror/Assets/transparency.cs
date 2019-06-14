using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparency : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        s.color = new Vector4(s.color.r, s.color.g, s.color.b, 0.9f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
