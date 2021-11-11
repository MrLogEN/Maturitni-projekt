using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICollisonHandler
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }



    public void CollisionEnter(string colliderTag, GameObject other)
    {
        if (colliderTag == "BossAttack" && other.layer == 7)
        {
            other.GetComponent<PlayerActions>().TakeHit();
        }
    }
}
