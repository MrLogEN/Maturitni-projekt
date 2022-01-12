using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerSkills
{
    [SerializeField] private LayerMask platformLayerMask; //Getting specific layer mask
    private Rigidbody2D rb;
    private float _moveSpeed;
    //private KeyCode pressedKey;
    private BoxCollider2D boxCollider;
    private bool _hasDoubleJump;
    private bool isGrounded;
    private int extraJump = 1;
    public float jumpForce = 15f;

    private bool isJumping = false;
    public float Speed { get => _moveSpeed; set => _moveSpeed = value; }
    public bool HasDoubleJump { get => _hasDoubleJump; set => _hasDoubleJump = value; }
    KeyCode left, right, up, jump, crouch, shoot, special;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Speed = 5f;
        HasDoubleJump = true;
        left = KeyCode.LeftArrow;
        right = KeyCode.RightArrow;
        up = KeyCode.UpArrow;
        jump = KeyCode.Z;
        crouch = KeyCode.C;
        shoot = KeyCode.X;
        special = KeyCode.V;

    }
    void Update()
    {
        Vector3 characterScale = transform.localScale;
        float sc = Mathf.Abs(characterScale.x);
        #region Left and right movement

            if (Input.GetKey(left) && !Input.GetKey(up)&&!Input.GetKey(crouch)) //Moving to the left
            {
                transform.position -= transform.right * (Time.deltaTime * _moveSpeed);

                characterScale.x = -sc;
            }
            if (Input.GetKey(right) && !Input.GetKey(up)&& !Input.GetKey(crouch)) //Moving to ther right
            {
                transform.position += transform.right * (Time.deltaTime * _moveSpeed);
                characterScale.x = sc;
            }

        if (Input.GetKey(left) && Input.GetKey(up)) //Moving to the left
        {
            characterScale.x = -sc;
        }
        if (Input.GetKey(right) && Input.GetKey(up)) //Moving to ther right
        {
            characterScale.x = sc;
        }


        transform.localScale = characterScale;
        #endregion

        #region jump
        isGrounded = CheckGroundStatus(); //Calling CheckGroundStatus()
        if (isGrounded)
        {
            extraJump = 1;
        }
        if (_hasDoubleJump) //Checking if the player has Double jump skill unlocked
        {
            if (Input.GetKeyDown(jump) && extraJump > 0) //Checking for extra jumps
            {
                //rb.velocity = Vector2.up * jumpForce;
                isJumping = true;
                extraJump--;
                //isJumping = false;
            }
        }
        else
        {

            if (Input.GetKeyDown(jump) && isGrounded) //If the player is on the ground and Z key is being pressed, the player will jump
            {
                isJumping = true;
                //rb.velocity = Vector2.up * jumpForce;
            }
        }
        #endregion

    }
    private void FixedUpdate()
    {
        if (isJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = false;
        }
        
    }

    private bool CheckGroundStatus()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.15f,platformLayerMask);
        return raycastHit;
    } //Function checking if the player is on the ground via BoxCast

   
}
