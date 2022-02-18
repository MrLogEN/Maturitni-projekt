using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    private float ttl = 3f;
    private float specialDamage = 5f;
    void Start()
    {

        ttl = Time.time + ttl;
    }
    void Update()
    {
        if (Time.time > ttl)
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
                damage = 1.3f*specialDamage;
            }
            else
            {
                damage = 1*specialDamage;
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