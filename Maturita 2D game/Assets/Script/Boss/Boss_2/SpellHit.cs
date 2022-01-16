using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerActions>().TakeHit();
            print("Andrej je noob");
        }
    }
}