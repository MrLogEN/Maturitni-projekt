using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRigid : MonoBehaviour
{
    // Start is called before the first frame update
    private float estTime;
    private float ttl = 6f;
    void Start()
    {
        estTime = Time.time+ttl;
    }

    // Update is called once per frame
    void Update()
    {
        
        float y = GetComponent<Rigidbody2D>().velocity.y;
        float z;
        if (y <0)
        {
            z = Vector2.Angle(new Vector2(-1, 0), GetComponent<Rigidbody2D>().velocity);
        }
        else
        {
            z = Vector2.Angle(new Vector2(1, 0), GetComponent<Rigidbody2D>().velocity);
        }
        
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,z));
        if (Time.time > estTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerActions>().TakeHit();
        }
    }
}
