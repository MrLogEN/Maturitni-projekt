using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balloon;
    private float spawnRate = 15f;
    private float t;
    public GameObject boss;
    void Start()
    {
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.GetComponent<Boss3Script>().isInvincible)
        {
            ShieldScript ss = FindObjectOfType<ShieldScript>();
            if (Time.time >= t && ss==null)
            {
                Instantiate(balloon, transform.position, Quaternion.identity);
                t = Time.time + spawnRate;
            }
        }

    }
}
