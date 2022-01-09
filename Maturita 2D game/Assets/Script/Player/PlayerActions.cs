using System;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerActions : MonoBehaviour, IPlayerStats
{

    private int _health;
    private int _damage;
    private bool _isDead;
    public int Health { get => _health; set => _health = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public bool IsDead { get => _isDead; set => _isDead = value; }

    private bool isInvincible = false;
    private float invincibilityTime = 2f;

    private float fireRate = .5f;
    private float nextFire = 0f;
    private float bulletVelocity = 30f;

    public GameObject bullet;
    public Animator playerAnim;
    public Animator handAnim;
    public GameObject handParent;
    Rigidbody2D rb;
    public GameObject spawnerPlayer;
    public GameObject spawnerHand;

    public event EventHandler<OnChangeLookArgs> OnChangeLook;
    public class OnChangeLookArgs : EventArgs
    {
        public enum Direction
        {
            up,
            leftDiagonal,
            rightDiagonal,
            rightNotPressed,
            leftNotPressed,
            rightPressed,
            leftPressed,
            jumpUpLeft,
            jumpUpRight,
            jumpUpLeftDiagonal,
            jumpUpRightDiagonal,
            jumpDown,
            jumpDownLeftDiagonal,
            jumpDownRightDiagonal,
            jumpDownLeft,
            jumpDownRight,
            crouchLeft,
            crouchRight,
            none,
        }
        public Direction direction;
        public OnChangeLookArgs(Direction direction)
        {
            this.direction = direction;
        }
    }

    void Start()
    {
        Health = 3; // default settings
        Damage = 1;
        rb = GetComponent<Rigidbody2D>();
        OnChangeLook += HandleDir;
    }

    void Update()
    {
        //Debug.Log(rb.velocity);
        if (Health <= 0)
        {
            //Changes the state isDead to true;
            IsDead = true;
            //Debug.Log("You are dead");
        }
        CheckInputs();
        if (Input.GetKey(KeyCode.X) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            handAnim.SetBool("isFiring", true);
            playerAnim.SetBool("isShooting", true);
            
            Shoot();
            //Boolich();
        }
        else
        {
            handAnim.SetBool("isFiring", false);
            playerAnim.SetBool("isShooting", false);
            //CheckInputs();
        }
        
    }
    private void CheckInputs()
    {
        float vel = GetComponent<Rigidbody2D>().velocity.y;
        if (!Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow)) OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.none));
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)) OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.none));
        #region directions
        else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && vel == 0) //up
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.up));
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && vel == 0 && !Input.GetKey(KeyCode.C)) //left diagonal
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.leftDiagonal));
        }
        else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && vel == 0 && !Input.GetKey(KeyCode.C)) //right diagonal
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.rightDiagonal));
        }
        else if (transform.localScale == new Vector3(1, 1, 1) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && vel == 0 && !Input.GetKey(KeyCode.C)) //right not pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.rightNotPressed));
        }
        else if (transform.localScale == new Vector3(-1, 1, 1) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && vel == 0 && !Input.GetKey(KeyCode.C)) //left not pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.leftNotPressed));
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && vel == 0 && !Input.GetKey(KeyCode.C)) //right pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.rightPressed));
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && vel == 0 && !Input.GetKey(KeyCode.C)) //left pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.leftPressed));
        }

        #endregion

        //jump Up
        #region jumpUp
        else if (vel > 0 && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.localScale.x > 0)
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpUpRight));
            }
            else
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpUpLeft));
            }

        }
        else if (vel > 0 && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {

            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpUpLeftDiagonal));
        }
        else if (vel > 0 && !Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {

            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpUpRightDiagonal));
        }
        #endregion

        //jump Down
        #region jumpDown
        else if (vel < 0 && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.localScale.x > 0)
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpDownRight));
            }
            else
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpDownLeft));
            }

        }
        else if (vel < 0 && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {

            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpDownLeftDiagonal));
        }
        else if (vel < 0 && !Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {

            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpDownRightDiagonal));
        }
        #endregion

        #region crouch
        else if (Input.GetKey(KeyCode.C) && vel == 0 && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localScale.x > 0)
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchRight));
            }
            else
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchLeft));
            }
        }
        else if (Input.GetKey(KeyCode.C) && vel == 0 && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchLeft));
        }
        else if (Input.GetKey(KeyCode.C) && vel == 0 && !Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchRight));
        }
        else if (Input.GetKey(KeyCode.C) && vel == 0)
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchRight));
        }
        #endregion
        else
        {
            //OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.none));
        }
    }
    public void TakeHit()
    {
        if (isInvincible == false)
        {
            isInvincible = true;
            Health--;
            Debug.Log(Health);
            Invoke("Invincibility", invincibilityTime);
        }

    }
    public void Invincibility()
    {
        isInvincible = false;
    }
    public void Shoot()
    {
        float sc = gameObject.transform.localScale.x;
        if (spawnerPlayer.active)
        {
            //GameObject bulletInstace = Instantiate(bullet, spawnerPlayer.transform.position, Quaternion.identity);
        }
        else if (spawnerHand.active)
        {
            float xCon = 0;
            if (sc > 0)
            {
                xCon = 1;
            }
            else
            {
                xCon = -1;
            }
            GameObject bulletInstace = Instantiate(bullet, spawnerHand.transform.position, handParent.transform.rotation);
            float cal = Mathf.Sin(handParent.transform.rotation.eulerAngles.z);
            Vector2 angle = new Vector2(xCon,cal);
            bulletInstace.GetComponent<Rigidbody2D>().AddForce(angle*bulletVelocity, ForceMode2D.Impulse);
            print(angle + " " + handParent.transform.rotation.eulerAngles.z);
        }
       
    }
    public void HandleDir(object sender, OnChangeLookArgs e)
    {
        float sc = Mathf.Abs(transform.localScale.x);
        switch (e.direction)
        {
            case OnChangeLookArgs.Direction.up:
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isNoMovementPressed", true);
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isLookingUp", true);

                break;
            case OnChangeLookArgs.Direction.leftDiagonal:
                playerAnim.SetBool("isNoMovementPressed", true);
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, -45f);
                break;
            case OnChangeLookArgs.Direction.rightDiagonal:
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isNoMovementPressed", true);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 45f);
                spawnerHand.transform.rotation = Quaternion.Euler(0, 0, 45f);
                break;
            case OnChangeLookArgs.Direction.rightNotPressed:
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.leftNotPressed:
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.rightPressed:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.leftPressed:
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isWalking", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpUpLeft:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpUpRight:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpUpLeftDiagonal:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, -45f);
                break;
            case OnChangeLookArgs.Direction.jumpUpRightDiagonal:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 45f);
                break;
            case OnChangeLookArgs.Direction.jumpDown:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpDownLeftDiagonal:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, -45f);
                break;
            case OnChangeLookArgs.Direction.jumpDownRightDiagonal:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 45f);
                break;
            case OnChangeLookArgs.Direction.jumpDownLeft:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpDownRight:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.crouchLeft:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isCrouching", true);
                transform.localScale = new Vector3(-sc, sc, sc);
                break;
            case OnChangeLookArgs.Direction.crouchRight:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isCrouching", true);
                transform.localScale = new Vector3(sc, sc, sc);
                break;
            case OnChangeLookArgs.Direction.none:
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isNoMovementPressed", true);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isCrouching", false);

                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            default:
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isNoMovementPressed", true);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isCrouching", false);

                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
        //handParent.transform.rotation = Quaternion.Euler();
    }
}
