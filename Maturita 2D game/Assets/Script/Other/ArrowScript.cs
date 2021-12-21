using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private float velocity = 4f; 
    private void Start()
    {
        //Debug.Log(transform.rotation.eulerAngles.z);
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerActions>().TakeHit();
        }
    }
}
