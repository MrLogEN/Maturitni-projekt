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



    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "BossAttack" && other.layer == 7)
        {
            other.GetComponent<PlayerTakeDamage>().TakeHit();
        }
    }
}
