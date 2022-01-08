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
            none
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

    private async Task Boolich()
    {
        await Task.Delay(160);
        handAnim.SetBool("isFiring", false);
    }

    void Update()
    {
        Debug.Log(rb.velocity);
        if (Health <= 0)
        {
            //Changes the state isDead to true;
            IsDead = true;
            //Debug.Log("You are dead");
        }
        if (Input.GetKey(KeyCode.X) )
        {
            nextFire = Time.time + fireRate;
            handAnim.SetBool("isFiring", true);
            //Shoot();
            //Boolich();
            //handAnim.SetBool("isFiring", false);
        }
        else
        {
            handAnim.SetBool("isFiring", false);
        }


        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) //up
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.up));
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) //left diagonal
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.leftDiagonal));
        }
        else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) //right diagonal
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.rightDiagonal));
        }
        else if (transform.localScale == new Vector3(1, 1, 1) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow)) //right not pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.rightNotPressed));
        }
        else if (transform.localScale == new Vector3(-1, 1, 1) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow)) //left not pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.leftNotPressed));
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow)) //right pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.rightPressed));
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow)) //left pressed
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.leftPressed));
        }
        else
        {
            OnChangeLook?.Invoke(this, new OnChangeLookArgs(OnChangeLookArgs.Direction.none));
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
        GameObject go;
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) //up
        {
            go = Instantiate(bullet, transform.position + new Vector3(-0, 1f, 0), Quaternion.Euler(0, 0, 90));
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1f) * bulletVelocity, ForceMode2D.Impulse);

        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) //left diagonal
        {
            go = Instantiate(bullet, transform.position + new Vector3(-0, 1f, 0), Quaternion.Euler(0, 0, 135));
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 1f) * bulletVelocity, ForceMode2D.Impulse);


        }
        else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) //right diagonal
        {
            go = Instantiate(bullet, transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(0, 0, 45));
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 1f) * bulletVelocity, ForceMode2D.Impulse);

        }
        else if (transform.localScale == new Vector3(1, 1, 1) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow)) //right not pressed
        {
            go = Instantiate(bullet, transform.position + new Vector3(1f, .6f, 0), Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0) * bulletVelocity, ForceMode2D.Impulse);

        }
        else if (transform.localScale == new Vector3(-1, 1, 1) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow)) //left not pressed
        {
            go = Instantiate(bullet, transform.position + new Vector3(-1f, .6f, 0), Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 0) * bulletVelocity, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow)) //right pressed
        {
            go = Instantiate(bullet, transform.position + new Vector3(1f, .6f, 0), Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0) * bulletVelocity, ForceMode2D.Impulse);

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow)) //left pressed
        {
            go = Instantiate(bullet, transform.position + new Vector3(-1f, .6f, 0), Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 0) * bulletVelocity, ForceMode2D.Impulse);
        }


    }
    public void HandleDir(object sender, OnChangeLookArgs e)
    {
        switch (e.direction)
        {

            case OnChangeLookArgs.Direction.up:
                //Debug.Log(OnChangeLookArgs.Direction.up);
                break;
            case OnChangeLookArgs.Direction.leftDiagonal:
                //Debug.Log(OnChangeLookArgs.Direction.leftDiagonal);
                handParent.transform.rotation = Quaternion.Euler(0, 0, -45f);
                break;
            case OnChangeLookArgs.Direction.rightDiagonal:
                //Debug.Log(OnChangeLookArgs.Direction.rightDiagonal);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 45f);
                break;
            case OnChangeLookArgs.Direction.rightNotPressed:
                //Debug.Log(OnChangeLookArgs.Direction.rightNotPressed);
                break;
            case OnChangeLookArgs.Direction.leftNotPressed:
                //Debug.Log(OnChangeLookArgs.Direction.leftNotPressed);
                break;
            case OnChangeLookArgs.Direction.rightPressed:
                //Debug.Log(OnChangeLookArgs.Direction.rightPressed);
                break;
            case OnChangeLookArgs.Direction.leftPressed:
                //Debug.Log(OnChangeLookArgs.Direction.leftPressed);
                break;
            case OnChangeLookArgs.Direction.none:
                //Debug.Log(OnChangeLookArgs.Direction.none);
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            default:
                handParent.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
        //handParent.transform.rotation = Quaternion.Euler();
    }
}
