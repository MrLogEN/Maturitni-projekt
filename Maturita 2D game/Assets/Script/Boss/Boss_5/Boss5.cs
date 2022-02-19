using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5 : MonoBehaviour,IBoss
{
    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public int Damage => throw new System.NotImplementedException();

    public int Phases { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int MaxHealth { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    PlayerActions pa;
    [SerializeField] private GameObject flameSpawner;
    [SerializeField] private GameObject fireBall;
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
            Time.timeScale = 0f;
            //so = SaveLoad.Load();
            if (!so.lvl3IsCompleted)
            {
                so.lvl3IsCompleted = true;
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
        nextAttack = Time.time+nextAttackPeriod;
        Physics2D.IgnoreLayerCollision(10, 9);
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
                    nextAttack = Time.time+nextAttackPeriod;
                    int g = Random.Range(0, 3);
                    //print(g);
                    switch (g)
                    {
                        case 0:
                            SpawnFireBall();
                            break;
                        case 1:
                            break;
                        case 2:
                           

                            break;
                        default:
                            break;
                    }
                }
                break;
            case Level5Manager.Level5State.Phase2:
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
}
