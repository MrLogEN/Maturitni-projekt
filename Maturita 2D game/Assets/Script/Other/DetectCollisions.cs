using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
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
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerActions>().TakeHit();
            Destroy(gameObject);

        }
        else if (collision.CompareTag("Boss"))
        {

        }
        else if (collision.CompareTag("BossAttack"))
        {

        }
        else
        {
            Destroy(gameObject);
        }




    }
}
