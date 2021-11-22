using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balloon;
    private float spawnRate = 5f;
    private float t;
    void Start()
    {
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= t)
        {
            Instantiate(balloon, transform.position,Quaternion.identity);
            t = Time.time + spawnRate;
        }
        
    }
}
