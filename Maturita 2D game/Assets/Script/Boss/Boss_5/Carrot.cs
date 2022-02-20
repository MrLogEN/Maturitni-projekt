using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Carrot : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    private Rigidbody2D rb;
    private float speed = 3f;
    private float rotateSpeed = 100f;
    float ttl = 6f;
    void Start()
    {
        player = FindObjectOfType<PlayerActions>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        ttl += Time.time;
    }
    private void Update()
    {
        if (Time.time > ttl)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 direction = (Vector2)player.transform.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerActions>().TakeHit();
            Destroy(gameObject);
        }
    }
}
