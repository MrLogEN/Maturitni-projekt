using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float ttl = 3f;
    void Start()
    {

        ttl = Time.time+ttl;
    }
    void Update()
    {
        if (Time.time > ttl )
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
