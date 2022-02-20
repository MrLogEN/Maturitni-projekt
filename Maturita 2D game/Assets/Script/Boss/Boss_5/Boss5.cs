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
    public void TakeDamage(float damage)
    {
        Health -= damage;
        pa.specialLoad++;
        //print(pa.specialLoad);
        if (Health <= 0)
        {
            SaveObject so = SaveLoad.Load();
            Health = 0;
            //Time.timeScale = 0f;
            Level5Manager.instance.ChangeState(Level5Manager.Level5State.End);
            //so = SaveLoad.Load();
            if (!so.lvl5IsCompleted)
            {
                so.lvl5IsCompleted = true;
                so.skillPoints++;
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
                            //grab
                            break;
                        case 2:
                            //head slam

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
                            StartCoroutine(SpawnCoconuts());
                            break;
                        case 1:
                            SpawnCarrot();
                            break;
                        case 2:
                            SpawnBouncing();
                            break;
                        default:
                            break;
                    }
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
}
