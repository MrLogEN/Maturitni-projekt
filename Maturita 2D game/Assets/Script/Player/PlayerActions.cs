using System;
using UnityEngine;
using System.Collections.Generic;

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
    public GameObject heartPrefab;
    public List<GameObject> heartList;
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

    #region inputs
    KeyCode left, right, up, jump, crouch, shoot, special;
    #endregion

    void Start()
    {
        
        Health = 3; // default settings
        Damage = 1;
        rb = GetComponent<Rigidbody2D>();
        OnChangeLook += HandleDir;

        left = KeyCode.LeftArrow;
        right = KeyCode.RightArrow;
        up = KeyCode.UpArrow;
        jump = KeyCode.Z;
        crouch = KeyCode.C;
        shoot = KeyCode.X;
        special = KeyCode.V;

        heartList = new List<GameObject>();
        SpawnHearts();
    }

    void Update()
    {
        //Debug.Log(rb.velocity);
        if (Health <= 0)
        {
            //Changes the state isDead to true;
            HandleDeath();
            //Debug.Log("You are dead");
        }
        CheckInputs();
        if (Input.GetKey(shoot) && Time.time > nextFire)
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
        if (!Input.GetKey(crouch) && !Input.GetKey(jump) && !Input.GetKey(left) && !Input.GetKey(right) && !Input.GetKey(up)) OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.none));
        else if (Input.GetKey(right) && Input.GetKey(left)) OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.none));
        #region directions
        else if (Input.GetKey(up) && !Input.GetKey(crouch) && !Input.GetKey(left) && !Input.GetKey(right) && vel == 0) //up
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.up));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
        else if (Input.GetKey(up) && Input.GetKey(left) && !Input.GetKey(right) && vel == 0 && !Input.GetKey(crouch)) //left diagonal
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.leftDiagonal));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
        else if (Input.GetKey(up) && !Input.GetKey(left) && Input.GetKey(right) && vel == 0 && !Input.GetKey(crouch)) //right diagonal
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.rightDiagonal));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
        else if (transform.localScale == new Vector3(1, 1, 1) && !Input.GetKey(right) && !Input.GetKey(up) && vel == 0 && !Input.GetKey(crouch)) //right not pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.rightNotPressed));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
        else if (transform.localScale == new Vector3(-1, 1, 1) && !Input.GetKey(left) && !Input.GetKey(up) && vel == 0 && !Input.GetKey(crouch)) //left not pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.leftNotPressed));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
        else if (Input.GetKey(right) && !Input.GetKey(up) && vel == 0 && !Input.GetKey(crouch)) //right pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.rightPressed));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
        else if (Input.GetKey(left) && !Input.GetKey(up) && vel == 0 && !Input.GetKey(crouch)) //left pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.leftPressed));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }

        #endregion
        //jump Up
        #region jumpUp
        else if (vel > 0 && !Input.GetKey(left) && !Input.GetKey(right) && !Input.GetKey(up))
        {
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", true);
            if (transform.localScale.x > 0)
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpUpRight));
            }
            else
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpUpLeft));
            }

        }
        else if (vel > 0 && Input.GetKey(left) && !Input.GetKey(right) && Input.GetKey(up))
        {
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", true);
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpUpLeftDiagonal));
        }
        else if (vel > 0 && !Input.GetKey(left) && Input.GetKey(right) && Input.GetKey(up))
        {
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", true);
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpUpRightDiagonal));
        }
        #endregion

        //jump Down
        #region jumpDown
        else if (vel < 0 && !Input.GetKey(left) && !Input.GetKey(right) && !Input.GetKey(up))
        {
            playerAnim.SetBool("isJumpingDown", true);
            playerAnim.SetBool("isJumpingUp", false);
            if (transform.localScale.x > 0)
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpDownRight));
            }
            else
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpDownLeft));
            }

        }
        else if (vel < 0 && Input.GetKey(left) && !Input.GetKey(right) && Input.GetKey(up))
        {
            playerAnim.SetBool("isJumpingDown", true);
            playerAnim.SetBool("isJumpingUp", false);
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpDownLeftDiagonal));
        }
        else if (vel < 0 && !Input.GetKey(left) && Input.GetKey(right) && Input.GetKey(up))
        {
            playerAnim.SetBool("isJumpingDown", true);
            playerAnim.SetBool("isJumpingUp", false);
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.jumpDownRightDiagonal));
        }
        #endregion

        #region crouch
        else if (Input.GetKey(crouch) && vel == 0 && !Input.GetKey(left) && !Input.GetKey(right))
        {
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
            if (transform.localScale.x > 0)
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchRight));
            }
            else
            {
                OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchLeft));
            }
        }
        else if (Input.GetKey(crouch) && vel == 0 && Input.GetKey(left) && !Input.GetKey(right))
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchLeft));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
        else if (Input.GetKey(crouch) && vel == 0 && !Input.GetKey(left) && Input.GetKey(right))
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchRight));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
        else if (Input.GetKey(crouch) && vel == 0)
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.crouchRight));
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
        #endregion
        else
        {
            //OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.none));
        }

        if (vel > 1.5f)
        {
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", true);
        }
        else if (vel < -3)
        {
            playerAnim.SetBool("isJumpingDown", true);
            playerAnim.SetBool("isJumpingUp", false);
        }
        else
        {
            playerAnim.SetBool("isJumpingDown", false);
            playerAnim.SetBool("isJumpingUp", false);
        }
    }
    public void TakeHit()
    {
        if (isInvincible == false)
        {
            isInvincible = true;
            Health--;
            Destroy(heartList[heartList.Count - 1]);
            heartList.RemoveAt(heartList.Count - 1);
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
            GameObject bulletInstace = Instantiate(bullet, spawnerPlayer.transform.position, spawnerPlayer.transform.rotation);
            Rigidbody2D rb = bulletInstace.GetComponent<Rigidbody2D>();
            float rot = spawnerPlayer.transform.rotation.eulerAngles.z;
            if (rot == 90)
            {
                rb.AddForce(new Vector2(0, 1) * bulletVelocity, ForceMode2D.Impulse);
            }
            else
            {
                if (sc > 0)
                {
                    rb.AddForce(new Vector2(1, 0) * bulletVelocity, ForceMode2D.Impulse);

                }
                else
                {
                    rb.AddForce(new Vector2(-1, 0) * bulletVelocity, ForceMode2D.Impulse);

                }
            }
            //GameObject bulletInstace = Instantiate(bullet, spawnerHand.transform.position, handParent.transform.rotation);

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
            Vector2 angle = new Vector2(xCon, cal);
            bulletInstace.GetComponent<Rigidbody2D>().AddForce(angle * bulletVelocity, ForceMode2D.Impulse);
            //print(angle + " " + handParent.transform.rotation.eulerAngles.z);
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
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", false);

                spawnerPlayer.transform.rotation = Quaternion.Euler(0, 0, 90f);

                break;
            case OnChangeLookArgs.Direction.leftDiagonal:
                playerAnim.SetBool("isNoMovementPressed", true);
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, -45f);
                break;
            case OnChangeLookArgs.Direction.rightDiagonal:
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isNoMovementPressed", true);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 45f);
                spawnerHand.transform.rotation = Quaternion.Euler(0, 0, 45f);
                break;
            case OnChangeLookArgs.Direction.rightNotPressed:
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isWalking", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.leftNotPressed:
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isWalking", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.rightPressed:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isWalking", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.leftPressed:
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isWalking", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpUpLeft:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isJumpingUp", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpUpRight:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isJumpingUp", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpUpLeftDiagonal:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", true);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, -45f);
                break;
            case OnChangeLookArgs.Direction.jumpUpRightDiagonal:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isJumpingUp", true);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 45f);
                break;
            case OnChangeLookArgs.Direction.jumpDown:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isJumpingDown", true);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpDownLeftDiagonal:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", true);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, -45f);
                break;
            case OnChangeLookArgs.Direction.jumpDownRightDiagonal:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", true);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 45f);
                break;
            case OnChangeLookArgs.Direction.jumpDownLeft:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", true);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.jumpDownRight:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", true);
                playerAnim.SetBool("isWalking", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case OnChangeLookArgs.Direction.crouchLeft:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isCrouching", true);
                transform.localScale = new Vector3(-sc, sc, sc);
                spawnerPlayer.transform.rotation = Quaternion.Euler(0, 0, 0f);

                break;
            case OnChangeLookArgs.Direction.crouchRight:
                playerAnim.SetBool("isNoMovementPressed", false);
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isCrouching", true);
                spawnerPlayer.transform.rotation = Quaternion.Euler(0, 0, 0f);
                transform.localScale = new Vector3(sc, sc, sc);
                break;
            case OnChangeLookArgs.Direction.none:
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isNoMovementPressed", true);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isJumpingUp", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isCrouching", false);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            default:
                playerAnim.SetBool("isWalking", false);
                playerAnim.SetBool("isNoMovementPressed", true);
                playerAnim.SetBool("isLookingUp", false);
                playerAnim.SetBool("isCrouching", false);
                playerAnim.SetBool("isJumpingDown", false);
                playerAnim.SetBool("isJumpingUp", false);

                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
        //handParent.transform.rotation = Quaternion.Euler();
    }

    private void SpawnHearts()
    {
        for (int i = 0; i < Health; i++)
        {
            GameObject hrt = Instantiate(heartPrefab, new Vector3(-8 + i * 0.8f, 4, 0), Quaternion.identity);
            heartList.Add(hrt);
        }
    }
    private void HandleDeath()
    {
        IsDead = true;
        Time.timeScale = 0;
        //nejake ty death screeny s menickem

    }
}
