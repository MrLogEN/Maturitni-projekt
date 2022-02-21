using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4Stage2 : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    int random;
    Rigidbody rb;
    float force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime % 4 == 0)
        {
            System.Random rn = new System.Random();
            int random = rn.Next(0, 1);
        }
        if (random ==0)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
        else
        {

        }
    }

}
