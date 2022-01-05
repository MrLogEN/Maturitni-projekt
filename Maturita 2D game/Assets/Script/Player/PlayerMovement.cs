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
    public float jumpForce = 10f;

    public float Speed { get => _moveSpeed; set => _moveSpeed = value; }
    public bool HasDoubleJump { get => _hasDoubleJump; set => _hasDoubleJump = value; }
    BindingObject bo;
    private void Awake()
    {
        bo = new BindingObject();
        bo = ControlBinding.Load();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Speed = 5f;
        HasDoubleJump = true;
    }
    void Update()
    {
        Vector3 characterScale = transform.localScale;
        #region Left and right movement
        if (Input.GetKey((KeyCode)bo.left) && !Input.GetKey((KeyCode)bo.up)) //Moving to the left
        {
            transform.position -= transform.right * (Time.deltaTime * _moveSpeed);
            characterScale.x = -1;
        }
        if (Input.GetKey((KeyCode)bo.right) && !Input.GetKey((KeyCode)bo.up)) //Moving to ther right
        {
            transform.position += transform.right * (Time.deltaTime * _moveSpeed);
            characterScale.x = 1;
        }

        if (Input.GetKey((KeyCode)bo.left) && Input.GetKey((KeyCode)bo.up)) //Moving to the left
        {
            characterScale.x = -1;
        }
        if (Input.GetKey((KeyCode)bo.right) && Input.GetKey((KeyCode)bo.up)) //Moving to ther right
        {
            characterScale.x = 1;
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
            if (Input.GetKeyDown((KeyCode)bo.jump) && extraJump > 0) //Checking for extra jumps
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJump--;
            }
        }
        else
        {

            if (Input.GetKeyDown((KeyCode)bo.jump) && isGrounded) //If the player is on the ground and Z key is being pressed, the player will jump
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        #endregion
    }

    private bool CheckGroundStatus()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.15f, platformLayerMask);
        return raycastHit;
    } //Function checking if the player is on the ground via BoxCast


}
