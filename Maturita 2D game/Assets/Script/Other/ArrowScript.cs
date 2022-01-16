using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private float velocity = 5f;
    float ttl = 5f;
    float startTime;
    public Vector3 dir;
    private void Start()
    {
        //Debug.Log(transform.rotation.eulerAngles.z);
        startTime = Time.time;
    }
    void Update()
    {

        //transform.position -= new Vector3(1, 0, 0) * 2f * Time.deltaTime;
        if (transform.rotation.eulerAngles.z == 5f)
        {
            transform.position -= new Vector3(1,0.1f, 0) * velocity * Time.deltaTime;
        }
        if (transform.rotation.eulerAngles.z == 0f)
        {
            transform.position -= new Vector3(1f,0,0) * velocity * Time.deltaTime;
        }
        if (transform.rotation.eulerAngles.z == 355f)
        {
            transform.position -= new Vector3(1, -0.1f, 0) * velocity * Time.deltaTime;
        }
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
}
