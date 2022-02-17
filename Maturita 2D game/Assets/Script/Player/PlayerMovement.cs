using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public ButtonsActions ba;

    private bool isJumping = false;
    public float Speed { get => _moveSpeed; set => _moveSpeed = value; }
    public bool HasDoubleJump { get => _hasDoubleJump; set => _hasDoubleJump = value; }
    KeyCode left, right, up, jump, crouch, shoot, special;
    BindingObject bo;
    SaveObject so;

    void BindigChanged(object sender, EventArgs e)
    {
        bo = ControlBinding.Load();
        left = bo.left;
        right = bo.right;
        up = bo.up;
        jump = bo.jump;
        crouch = bo.crouch;
        shoot = bo.shoot;
        special = bo.specialAbility;
    }
    void Start()
    {
        ba = FindObjectOfType<ButtonsActions>();
        if (ba != null)
        {
            ba.OnBindingChange += BindigChanged;

        }
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        so = SaveLoad.Load();
        bo = ControlBinding.Load();

        HasDoubleJump = so.hasDoubleJump;
        if (so.hasSwiftness)
        {
            Speed = 7f;

        }
        else
        {
            Speed = 5f;

        }

        left = bo.left;
        right = bo.right;
        up = bo.up;
        jump = bo.jump;
        crouch = bo.crouch;
        shoot = bo.shoot;
        special = bo.specialAbility;

    }
    void Update()
    {
        Vector3 characterScale = transform.localScale;
        float sc = Mathf.Abs(characterScale.x);
        #region Left and right movement
        if (Time.timeScale == 1)
        {
            if (Input.GetKey(left) && !Input.GetKey(up) && !Input.GetKey(crouch)) //Moving to the left
            {
                transform.position -= transform.right * (Time.deltaTime * _moveSpeed);

                characterScale.x = -sc;
            }
            if (Input.GetKey(right) && !Input.GetKey(up) && !Input.GetKey(crouch)) //Moving to ther right
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
            if (Input.GetKeyDown(jump) && extraJump > 0 && !Input.GetKey(crouch)) //Checking for extra jumps
            {
                //rb.velocity = Vector2.up * jumpForce;
                isJumping = true;
                extraJump--;
                //isJumping = false;
            }
        }
        else
        {

            if (Input.GetKeyDown(jump) && isGrounded && !Input.GetKey(crouch)) //If the player is on the ground and Z key is being pressed, the player will jump
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
