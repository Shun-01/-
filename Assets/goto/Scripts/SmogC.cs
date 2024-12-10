using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogC : MonoBehaviour
{
    //private Vector3 _scaOwn, _scaDelta;

    private SpriteRenderer _srOwn;

    // Start is called before the first frame update
    void Start()
    {
        _srOwn = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x <= 0 || transform.localScale.y <= 0 || transform.localScale.z <= 0)
        {
            Destroy(gameObject);
        }
        _srOwn.color = new Color(255, 255, 255, _srOwn.color.a - 0.03f);

    }

    public void SetSize(float size)
    {
        transform.localScale=new Vector3(size,size,size);
    }
}
