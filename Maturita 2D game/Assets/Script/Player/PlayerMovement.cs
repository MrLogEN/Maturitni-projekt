using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerSkills
{
    [SerializeField] private LayerMask platformLayerMask; //Getting specific layer mask
    private Rigidbody2D rb;
    private float _moveSpeed;
    private KeyCode pressedKey;
    private BoxCollider2D boxCollider;
    private bool _hasDoubleJump;

    public float Speed { get => _moveSpeed; set => _moveSpeed = value; }
    public bool HasDoubleJump { get => _hasDoubleJump; set => _hasDoubleJump = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //Moving to the left
        {
            transform.position -= transform.right * (Time.deltaTime * _moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow)) //Moving to ther right
        {
            transform.position += transform.right * (Time.deltaTime * _moveSpeed);
        }

    }
    private void FixedUpdate()
    {
        bool isGrounded = CheckGroundStatus(); //Calling CheckGroundStatus()
        if (Input.GetKey(KeyCode.Z)&&isGrounded) //If the player is on the ground and Z key is being pressed, the player will jump
        {
            rb.AddForce(new Vector2(0, 12f), ForceMode2D.Impulse);
        }
    }
    private bool CheckGroundStatus()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f,platformLayerMask);
        return raycastHit;
    } //Function checking if the player is on the ground via BoxCast

   
}
