using UnityEngine;

public class BouncingBombBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Collider2D col;
    private bool isHit = false;
    Transform hand;
    float ttl = 7f;
    private PlayerActions pa;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        col.enabled = true;
        hand = Level5Manager.instance.playerHandTransform;
        ttl += Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            transform.position = hand.position;

        }
        if (Time.time > ttl)
        {
            if (pa != null)
            {
                pa.TakeHit();
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pa = collision.GetComponent<PlayerActions>();
            //rb.gravityScale = 0;
            //rb.velocity = Vector3.zero;
            //col.enabled = false;
            ////gameObject.transform.SetParent(hand);
            //transform.position = hand.position;
            //isHit = true;
            Stick();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlayTomatoSplashSfx();
        if (collision.gameObject.tag == "Player")
        {
            pa = collision.gameObject.GetComponent<PlayerActions>();
            Stick();
        }
    }
    private void Stick()
    {
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        col.enabled = false;
        //gameObject.transform.SetParent(hand);
        transform.position = hand.position;
        isHit = true;
    }
}
