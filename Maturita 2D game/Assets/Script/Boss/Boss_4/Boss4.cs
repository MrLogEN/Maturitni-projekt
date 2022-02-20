using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4 : MonoBehaviour, IBoss
{
    public int stage;
    public GameObject molotov;
    public GameObject bullet;
    public Animator anim;
    public GameObject Hand;
    public GameObject boom;
    public GameObject spike;
    public GameObject player;
    public bool attack4;
    static int random;
    static bool used;
    float postion_x;
    bool b;
    float playerX;
    void Start()
    {

        _health = 10;
        _phases = 2;
        stage = 1;
        Hand = GameObject.FindGameObjectWithTag("BossHand");
        player = GameObject.FindGameObjectWithTag("Player");
        used = true;
        InvokeRepeating("RandomNumber", 1f, 2f);
        b = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_health == 9)
        {
            if (b)
            {
                b = false;
                anim.Play("Drink");
                CancelInvoke();
                StartCoroutine(Wait2Seconds());
            }
        }
        if (attack4 == true)
        {
            if (transform.position.x == playerX)
            {
                print("noob");
                transform.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
                transform.position = new Vector3(playerX, transform.position.y, transform.position.z);
            }
        }
    }
     public void RandomNumber()
    {
        System.Random rn = new System.Random();
        int random = rn.Next(0, 2);
        print(random);
        if (stage == 1)
        {
                if (used == true)
                {
                    anim.SetBool("GunAnimation", false);
                    used = false;
                    if (random == 0)
                    {
                        if (!GameObject.FindGameObjectWithTag("Molotov"))
                        {
                            anim.Play("Molotov");
                            StartCoroutine(WaitSecond());
                        }
                    }
                    else
                    {
                        anim.Play("Putin-Gun");
                    }
                }
                else
                {
                    used = true;
                }
        }
        else if (stage == 2)
        {
            if (random == 0)
            {
                anim.Play("Stage2_Punch");
                StartCoroutine(Wait1Second());
            }
            else
            {
                attack4 = true;
                anim.Play("Stage2_Jump");
                Vector2 v = CalculateLaunchVelocity(player.transform.position ,transform.position, 1.25f);
                playerX = player.transform.position.x;
                transform.GetComponent<Rigidbody2D>().velocity = v;
                StartCoroutine(Wait2_5Seconds());
            }
        }
    }
    IEnumerator WaitSecond()
    {
        yield return new WaitForSeconds(1);
        Instantiate(molotov, transform.position, transform.rotation);
    }
    IEnumerator Wait1Second()
    {
        yield return new WaitForSeconds(1);
        postion_x = 5f;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(spike, new Vector3(postion_x, -3.7f, transform.position.z), transform.rotation);
            postion_x -= 1f;
        }
    }
    IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(2);
        Instantiate(boom, new Vector3(7.5f, transform.position.y, transform.position.z), transform.rotation);
        StartCoroutine(Wait3Seconds());
    }
    IEnumerator Wait3Seconds()
    {
        yield return new WaitForSeconds(3);
        InvokeRepeating("RandomNumber", 0f, 5f);
        stage = 2;
    }
    IEnumerator Wait2_5Seconds()
    {
        yield return new WaitForSeconds(3f);
        attack4 = false;
        anim.Play("Stage2_Jump");
        Vector2 v = CalculateLaunchVelocity(new Vector2(7.96f, -2.12f), transform.position, 1.25f);
        transform.GetComponent<Rigidbody2D>().velocity = v;
    }

    private int _health;
    private int _damage = 1;
    private int _phases;
    public int Health { get => _health; set => _health = value; }
    public int Damage => _damage;
    public int Phases { get => _phases; set => _phases = value; }
    public void TakeDamage()
    {
        Health--;
        Debug.Log("Boss health" + Health);
        if (Health <= 0)
        {
            Health = 0;
            Time.timeScale = 0;
            SaveObject so = SaveLoad.Load();
            so.lvl2IsCompleted = true;
            SaveLoad.Save(so);
        }
    }
    private Vector2 CalculateLaunchVelocity(Vector2 target, Vector2 origin, float time)
    {
        //target.y = -4.8f;
        Vector2 distance = target - origin;
        Vector2 distanceX = new Vector2(distance.x, 0);

        float Sy = distance.y;
        float Sx = distanceX.magnitude;

        float Vx = Sx / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 result = distanceX.normalized;
        result *= Vx;
        result.y = Vy;
        return result;
    }
   


}
