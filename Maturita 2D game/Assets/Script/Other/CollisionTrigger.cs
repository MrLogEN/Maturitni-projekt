using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{

    private ICollisonHandler handler;
    private void Start()
    {
        handler = GetComponentInParent<ICollisonHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        handler.CollisionEnter(gameObject.name, collision.gameObject);
    }
}
