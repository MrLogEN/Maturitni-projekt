using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public GameObject balloon;
    private bool ds;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (balloon != null)
        {
            ds = balloon.GetComponent<BalloonScript>().isDestroyed;
        }
        if (ds == true)
        {
            rb.gravityScale = 1;
        }
    }
}
