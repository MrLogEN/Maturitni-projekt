using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour, IPlayerStats
{

    private int _health;
    private int _damage;
    private bool _isDead;
    public int Health { get => _health; set => _health = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public bool IsDead { get => _isDead; set => _isDead = value;  }

    private bool isInvincible = false;
    private float invincibilityTime = 2f;

    private float fireRate = .5f;
    private float nextFire = 0f;
    private float bulletVelocity = 30f;

    public GameObject bullet;
    BindingObject bo;
    private void Awake()
    {
        bo = new BindingObject();
        bo = ControlBinding.Load();
    }
    void Start()
    {
        Health = 3; // default settings
        Damage = 1;
    }

    void Update()
    {
        if (Health <= 0)
        {
            //Changes the state isDead to true;
            IsDead = true;
            //Debug.Log("You are dead");
        }
        
        if (Input.GetKey(KeyCode.X) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
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
        if (Input.GetKey((KeyCode)bo.up)&&!Input.GetKey((KeyCode)bo.left) && !Input.GetKey((KeyCode)bo.right)) //up
        {
            go = Instantiate(bullet, transform.position + new Vector3(-0, 1f, 0),Quaternion.Euler(0,0,90));
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1f)*bulletVelocity, ForceMode2D.Impulse);

        }
        else if (Input.GetKey((KeyCode)bo.up) && Input.GetKey((KeyCode)bo.left) && !Input.GetKey((KeyCode)bo.right)) //left diagonal
        {
            go = Instantiate(bullet, transform.position + new Vector3(-0, 1f, 0), Quaternion.Euler(0,0,135));
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 1f) * bulletVelocity, ForceMode2D.Impulse);
            

        }
        else if (Input.GetKey((KeyCode)bo.up) && !Input.GetKey((KeyCode)bo.left) && Input.GetKey((KeyCode)bo.right)) //right diagonal
        {
            go = Instantiate(bullet, transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(0,0,45));
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 1f) * bulletVelocity, ForceMode2D.Impulse);
            
        }
        else if (transform.localScale == new Vector3(1, 1, 1) && !Input.GetKey((KeyCode)bo.right) && !Input.GetKey((KeyCode)bo.up)) //right not pressed
        {
            go = Instantiate(bullet, transform.position + new Vector3(1f, .6f, 0), Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0) * bulletVelocity, ForceMode2D.Impulse);

        }
        else if (transform.localScale == new Vector3(-1, 1, 1) && !Input.GetKey((KeyCode)bo.left) && !Input.GetKey((KeyCode)bo.up)) //left not pressed
        {
            go = Instantiate(bullet, transform.position + new Vector3(-1f, .6f, 0), Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 0) * bulletVelocity, ForceMode2D.Impulse);
        }
        else if (Input.GetKey((KeyCode)bo.right)&&!Input.GetKey((KeyCode)bo.up)) //right pressed
        {
            go = Instantiate(bullet, transform.position + new Vector3(1f, .6f, 0), Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f,0) *bulletVelocity, ForceMode2D.Impulse);

        }
        else if (Input.GetKey((KeyCode)bo.left) && !Input.GetKey((KeyCode)bo.up)) //left pressed
        {
            go = Instantiate(bullet, transform.position + new Vector3(-1f, .6f, 0), Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f,0) * bulletVelocity, ForceMode2D.Impulse);
        }


    }
}
