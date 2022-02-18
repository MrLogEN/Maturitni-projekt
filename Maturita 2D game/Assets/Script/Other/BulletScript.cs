using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float ttl = 3f;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 10);
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
        
        if (collision.gameObject.tag == "Boss")
        {
            SaveObject so = SaveLoad.Load();
            float damage;
            if (so.hasDamage)
            {
                damage = 1.3f;
            }
            else
            {
                damage = 1;
            }
            //CollisionEnter(gameObject.name, collision.gameObject);
            collision.gameObject.GetComponent<IBoss>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

    }
}
