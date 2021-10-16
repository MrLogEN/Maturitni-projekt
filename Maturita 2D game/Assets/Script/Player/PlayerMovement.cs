using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private KeyCode pressedKey;
    private BoxCollider2D boxCollider;

   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
        }

    }
    private void FixedUpdate()
    {
        bool isGrounded = ChechGroundStatus();
        Debug.Log(isGrounded);
        if (Input.GetKey(KeyCode.Z)&&isGrounded)
        {
            rb.AddForce(new Vector2(0, 12f), ForceMode2D.Impulse);
        }
    }
    private bool ChechGroundStatus()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f,platformLayerMask);
        return raycastHit;
    }

   
}
