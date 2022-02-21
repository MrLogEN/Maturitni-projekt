using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.PlayCoconutFallSfx();
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerActions>().TakeHit();
        }
        Destroy(gameObject);
    }
}
