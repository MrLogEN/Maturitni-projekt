using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public Vector3 scale;
    private float ttl = 3f;
    void Start()
    {

        ttl = Time.time+ttl;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ttl )
        {
            Destroy(this.gameObject);
        }
    }

    
}
