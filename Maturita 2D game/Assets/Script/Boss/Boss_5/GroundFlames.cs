using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFlames : MonoBehaviour
{
    // Start is called before the first frame update
    private float ttl=5f;
    void Start()
    {
        ttl += Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ttl)
        {
            Destroy(gameObject);
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerActions>().TakeHit();
        }
    }
}
