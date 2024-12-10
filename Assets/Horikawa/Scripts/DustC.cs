using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustC : ExpFlashC
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();
        transform.position -= Vector3.up;
    }
}
