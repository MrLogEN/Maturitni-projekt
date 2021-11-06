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
    private bool isGrounded;
    private int extraJump = 1;
    public float jumpForce = 10f;

    public float Speed { get => _moveSpeed; set => _moveSpeed = value; }
    public bool HasDoubleJump { get => _hasDoubleJump; set => _hasDoubleJump = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Speed = 5f;
        HasDoubleJump = true;
    }
    void Update()
    {
        #region Left and right movement
        if (Input.GetKey(KeyCode.LeftArrow)) //Moving to the left
        {
            transform.position -= transform.right * (Time.deltaTime * _moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow)) //Moving to ther right
        {
            transform.position += transform.right * (Time.deltaTime * _moveSpeed);
        }
        #endregion

        #region jump
        isGrounded = CheckGroundStatus(); //Calling CheckGroundStatus()
        //Debug.Log(isGrounded);
        if (isGrounded)
        {
            extraJump = 1;
        }
        if (_hasDoubleJump) //Checking if the player has Double jump skill unlocked
        {
            if (Input.GetKeyDown(KeyCode.Z) && extraJump > 0) //Checking for extra jumps
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJump--;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z) && isGrounded) //If the player is on the ground and Z key is being pressed, the player will jump
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        #endregion

    }

    private bool CheckGroundStatus()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f,platformLayerMask);
        return raycastHit;
    } //Function checking if the player is on the ground via BoxCast

   
}
