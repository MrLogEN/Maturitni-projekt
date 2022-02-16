using System.Collections.Generic;
using UnityEngine;

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

    public GameObject handParent;
    Rigidbody2D rb;
    public GameObject spawnerPlayer;
    public GameObject spawnerHand;
    public GameObject heartPrefab;
    public List<GameObject> heartList;

    public Animator playerAnim;
    public Animator handAnim;

    private string currentState;
    const string IDLE = "Player_Idle";
    const string STANDING_SHOOT = "Player_StandingShoot";
    const string RUN = "Player_Run";
    const string LOOK_UP = "Player_LookUp";
    const string LOOK_UP_SHOOT = "Player_LookUpShoot";
    const string CROUCH = "Player_Crouch";
    const string CROUCH_CONSTATNT = "Player_CrouchConstant";
    const string CROUCH_SHOOT = "Player_CrouchShoot";
    const string UNCROUCH = "Player_Uncrouch";
    const string JUMP = "Player_Jump";
    const string JUMP_UP_CONTINOUS = "Player_JumpUpContinous";
    const string JUMP_DOWN_CONTINOUS = "Player_JumpDownContinous";
    const string JUMP_DOWN = "Player_JumpDown";

    private bool isCrouching = false;
    const float crouchTime = .15f;
    float timeInCrouch;
    #region inputs
    KeyCode left, right, up, jump, crouch, shoot, special;
    #endregion

    void Start()
    {

        Health = 3; // default settings
        Damage = 1;
        rb = GetComponent<Rigidbody2D>();

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
        handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        //Debug.Log(rb.velocity);
        if (Health <= 0)
        {
            //Changes the state isDead to true;
            HandleDeath();
            //Debug.Log("You are dead");
        }
        //CheckInputs();
        if (Input.GetKey(shoot) && Time.time > nextFire)
        {
            if (isCrouching)
            {
                ChangeAnimationState(CROUCH_SHOOT);
                spawnerPlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (!Input.GetKey(left) && !Input.GetKey(right) && Input.GetKey(up))
            {
                spawnerPlayer.transform.rotation = Quaternion.Euler(0, 0, 90);
                ChangeAnimationState(LOOK_UP_SHOOT);
            }
            else
            {
                handAnim.SetBool("isFiring", true);
            }

            nextFire = Time.time + fireRate;
            Shoot();
            //handAnim.SetBool("isFiring", false);

        }
        else
        {
            handAnim.SetBool("isFiring", false);

        }





        if (!Input.GetKey(crouch) && !Input.GetKey(up) && (Input.GetKey(left) || Input.GetKey(right)))
        {
            ChangeAnimationState(RUN);
        }
        else if (Input.GetKey(left) && Input.GetKey(up))
        {
            ChangeAnimationState(STANDING_SHOOT);
            handParent.transform.rotation = Quaternion.Euler(0, 0, -45f);
            //handParent.transform.localRotation = Quaternion.Euler(0, 0, -45f);


        }
        else if (Input.GetKey(right) && Input.GetKey(up))
        {
            ChangeAnimationState(STANDING_SHOOT);
            handParent.transform.rotation = Quaternion.Euler(0, 0, 45f);
            //handParent.transform.localRotation = Quaternion.Euler(0, 0, -45f);


        }
        else if (!Input.GetKey(left) && !Input.GetKey(right) && Input.GetKey(up) && !Input.GetKey(shoot) && !Input.GetKey(crouch) && !Input.GetKey(special) && !Input.GetKey(jump))
        {
            ChangeAnimationState(LOOK_UP);
        }

        else if (isCrouching == false && Input.GetKeyDown(crouch))
        {
            timeInCrouch = Time.time + crouchTime;
            ChangeAnimationState(CROUCH);
            isCrouching = true;
        }
        else if (Time.time >= timeInCrouch && isCrouching == true && Input.GetKey(crouch))
        {
            ChangeAnimationState(CROUCH_CONSTATNT);
        }

        else if (Time.time >= timeInCrouch && isCrouching == true && Input.GetKeyUp(crouch))
        {
            ChangeAnimationState(UNCROUCH);
            isCrouching = false;
        }
        else if (!Input.GetKey(left) && !Input.GetKey(right) && !Input.GetKey(up) && !Input.GetKey(shoot) && Input.GetKey(crouch) && !Input.GetKey(special) && !Input.GetKey(jump))
        {
            ChangeAnimationState(STANDING_SHOOT);
        }

        else if (!Input.GetKey(left) && !Input.GetKey(right) && !Input.GetKey(up) && !Input.GetKey(shoot) && !Input.GetKey(crouch) && !Input.GetKey(special) && !Input.GetKey(jump))
        {
            ChangeAnimationState(IDLE);
        }



    }
    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        playerAnim.Play(newState);
        currentState = newState;

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
