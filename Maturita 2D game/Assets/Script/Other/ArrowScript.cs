using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float velocity = 5f;
    float ttl = 5f;
    float startTime;
    public Vector3 dir;
    Boss3Script boss;
    int health;
    private void Start()
    {
        //Debug.Log(transform.rotation.eulerAngles.z);
        startTime = Time.time;
        boss = FindObjectOfType<Boss3Script>();
        health = boss.bossMaxHealth;
        //print(boss.name);
        SetVelocityByHealth();
        Physics2D.IgnoreLayerCollision(9, 10);

    }
    void Update()
    {
        //transform.position -= new Vector3(1, 0, 0) * 2f * Time.deltaTime;
        //if (transform.rotation.eulerAngles.z == 5f)
        //{
        //    transform.position -= new Vector3(1,0.1f, 0) * velocity * Time.deltaTime;
        //}
        //if (transform.rotation.eulerAngles.z == 0f)
        //{

        //}
        //if (transform.rotation.eulerAngles.z == 355f)
        //{
        //    transform.position -= new Vector3(1, -0.1f, 0) * velocity * Time.deltaTime;
        //}
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position -= new Vector3(1f, 0, 0) * velocity * Time.deltaTime;
        if (Time.time > startTime + ttl)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerActions>().TakeHit();
        }
    }
    public Vector3 GetDirection(Vector3 direction)
    {
        return direction;
    }
    private void SetVelocityByHealth()
    {
        if (boss.Health > (health/ 2))
        {
            velocity = 5f;
            //print("k1");
        }
        else if (boss.Health <= (health/ 2) && boss.Health > health / 4)
        {
            velocity =7f;
            //print("k2");

        }
        else if (boss.Health <= health/ 4 && boss.Health > health/ 8)
        {
            velocity = 10f;
           // print("k3");

        }
        else if (boss.Health <= health/ 8)
        {
            velocity = 13f;
            //print("k4");

        }
    }
}
