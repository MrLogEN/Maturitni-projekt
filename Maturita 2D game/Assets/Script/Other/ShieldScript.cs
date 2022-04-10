using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ShieldScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public GameObject balloon;
    private bool ds;
    Boss3Script boss;
    float ttl = 7f;
    float ttlCurrent;
    bool setTime = false;
    void Start()
    {
        boss = FindObjectOfType<Boss3Script>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (balloon != null)
        {
            ds = balloon.GetComponent<BalloonScript>().isDestroyed;
            ttlCurrent = Time.time + ttl;
        }
        else
        {
            if (!setTime)
            {
                setTime = true;
                ttlCurrent = Time.time + ttl;
            }
        }
        if (ds == true)
        {
            rb.gravityScale = 1;
        }
        if (ttlCurrent < Time.time)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerActions>().TakeHit();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss3Script>().isInvincible = false;
            ChangeForm();
        }
    }
    private async void ChangeForm()
    {
        boss = FindObjectOfType<Boss3Script>();
        AudioManager.instance.StopSwordCharge();
        Destroy(this.gameObject);
        await Task.Delay(100);
        boss.ChangeAnimationState("boss3_ChangeFormBack");
        await Task.Delay(460);
        boss.transform.position = new Vector3(6.71f, -2.67f, boss.transform.position.z);
        boss.transform.localScale = new Vector3(Mathf.Abs(boss.transform.localScale.x), boss.transform.localScale.y, boss.transform.localScale.z);
        boss.ChangeAnimationState(boss.CHANGE);
        await Task.Delay(460);
        boss.ChangeAnimationState(boss.IDLE_BOW);

    }
}
