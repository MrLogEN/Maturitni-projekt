using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    // Start is called before the first frame update
    float ttl = 6f;
    private void Start()
    {
        ttl += Time.time;
    }
    private void Update()
    {
        if (ttl < Time.time)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Ground")
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerActions>().TakeHit();
            }
            AudioManager.instance.PlayTomatoSplashSfx();
            Destroy(gameObject);
        }
    }
}
