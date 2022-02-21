using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

public class Boss5 : MonoBehaviour, IBoss
{
    private float _health;
    private int _maxHealth = 20;
    private int _damage;
    private int _phases;
    public float Health { get => _health; set => _health = value; }

    public int Damage => _damage;

    public int Phases { get => _phases; set => _phases = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    PlayerActions pa;
    [SerializeField] private GameObject flameSpawner;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform[] coconutSpawners;
    [SerializeField] private GameObject coconut;
    [SerializeField] private Transform carrotSpawner;
    [SerializeField] private GameObject carrot;
    [SerializeField] private Transform bouncingSpawner;
    [SerializeField] private GameObject bouncingBomb;
    System.Random rn = new System.Random();
    private Animator anim;
    public void TakeDamage(float damage)
    {
        Health -= damage;
        pa.specialLoad++;
        //print(pa.specialLoad);
        if (Health <= 0)
        {
            SaveObject so = SaveLoad.Load();
            Health = 0;
            Time.timeScale = 0f;
            
            //so = SaveLoad.Load();
            if (!so.lvl5IsCompleted)
            {
                Level5Manager.instance.ChangeState(Level5Manager.Level5State.End);
                so.lvl5IsCompleted = true;
                so.skillPoints++;
            }
            else
            {
                Level5Manager.instance.ChangeState(Level5Manager.Level5State.End2);
            }
            SaveLoad.Save(so);
        }
        Debug.Log("Boss health: " + Health);
    }

    // Start is called before the first frame update
    void Start()
    {
        pa = FindObjectOfType<PlayerActions>();
        nextAttack = Time.time + nextAttackPeriod;
        Physics2D.IgnoreLayerCollision(10, 9);
        Physics2D.IgnoreLayerCollision(10, 10);
        _health = _maxHealth;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame

    float nextAttack;
    float nextAttackPeriod = 5f;
    void Update()
    {
        switch (Level5Manager.instance.GetState)
        {
            case Level5Manager.Level5State.Phase1:
                if (nextAttack < Time.time)
                {
                    nextAttack = Time.time + nextAttackPeriod;
                    int g = Random.Range(0, 3);
                    //print(g);
                    switch (g)
                    {
                        case 0:
                            SpawnFireBall();
                            break;
                        case 1:
                            //anim.Play("boss5_torch");
                            StartCoroutine(SwingTorch());
                            //grab
                            break;
                        case 2:
                            //head slam
                            //anim.Play("boss5_headslam");
                            StartCoroutine(DoHeadSlam());
                            break;
                        default:
                            break;
                    }
                    
                   
                }
                if (Health <= MaxHealth * 0.5)
                {
                    //udelej animaci pichnuti
                    //chnage to phase 2
                    Level5Manager.instance.ChangeState(Level5Manager.Level5State.Phase2);
                }
                break;
            case Level5Manager.Level5State.Phase2:
                if (nextAttack < Time.time)
                {
                    nextAttack = Time.time + nextAttackPeriod;
                    int g = Random.Range(0, 3);
                    //print(g);
                    switch (g)
                    {
                        case 0:
                            StartCoroutine(DoButtonAnim());
                            StartCoroutine(SpawnCoconuts());
                            break;
                        case 1:
                            StartCoroutine(DoButtonAnim());
                            SpawnCarrot();
                            break;
                        case 2:
                            StartCoroutine(DoButtonAnim());
                            SpawnBouncing();
                            break;
                        default:
                            break;
                    }
                    //SpawnCarrot();
                }
                break;
            case Level5Manager.Level5State.End:
                break;
            default:
                break;
        }
    }
    void SpawnFireBall()
    {
        Instantiate(fireBall, flameSpawner.transform.position, Quaternion.identity);
        AudioManager.instance.PlayFireballShootSfx();
    }
    void SpawnCarrot()
    {
        Instantiate(carrot, carrotSpawner.transform.position, Quaternion.identity);
    }
    void SpawnBouncing()
    {
        float force = 5f;
        GameObject go = Instantiate(bouncingBomb,bouncingSpawner.transform.position,Quaternion.identity);
        Rigidbody2D rbBomb = go.GetComponent<Rigidbody2D>();
        rbBomb.AddForce(new Vector2(-force, -force),ForceMode2D.Impulse);

    }
    IEnumerator SwingTorch()
    {
        anim.Play("boss5_torch");
        yield return new WaitForSeconds(0.75f);
        AudioManager.instance.PlayWhooshSfx();
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.PlayWhooshSfx();
        yield return new WaitForSeconds(1f);
        anim.Play("boss5_idle");

    }
    IEnumerator SpawnCoconuts()
    {
        //int d = 200;
        print("kokot");
        for (int i = 0; i < 20; i++)
        {
            Transform t = coconutSpawners[Random.Range(0, coconutSpawners.Length)];
            Instantiate(coconut, t.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator DoHeadSlam()
    {
        anim.Play("boss5_headslam");
        yield return new WaitForSeconds(0.4f);
        AudioManager.instance.PlayGroundSlamSfx();
        yield return new WaitForSeconds(1.1f);
        anim.Play("boss5_idle");
    }
    IEnumerator DoButtonAnim()
    {
        anim.Play("boss5_button");
        yield return new WaitForSeconds(1f);
        anim.Play("boss5_idle2");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerActions>().TakeHit();
        }
    }
}
