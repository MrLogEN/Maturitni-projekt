using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour,ICollisonHandler
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
       
        if (collision.tag == "Boss")
        {
            CollisionEnter(gameObject.name, collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.tag != "Player")
        {
            Destroy(this.gameObject);
        }

    }

    public void CollisionEnter(string colliderName, GameObject other)
    {
            other.GetComponent<IBoss>().TakeDamage();
    }
}
