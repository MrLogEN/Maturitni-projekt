using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Script : MonoBehaviour, IBoss
{
    #region private
    private float _health;
    private int _damage;
    private readonly int _phases = 2;
    private int _currentPhase;
    public int bossMaxHealth = 20;

    #endregion


    public float Health { get => _health; set => _health = value; }

    public int Damage => _damage;

    public int Phases => _phases;
    public int CurrentPhase { get => _currentPhase; set => _currentPhase=value; }
    int IBoss.Phases { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int MaxHealth { get => bossMaxHealth; set => bossMaxHealth = value; }

    public bool isInvincible;

    public GameObject player;
    SaveObject so;

    private PlayerActions pa;
    public void TakeDamage(float damage)
    {
        
        if (isInvincible)
        {
            //CurrentPhase = 1;
            Debug.Log("Boss is invincible, health: " + Health);
        }
        if (!isInvincible)
        {
            //CurrentPhase = 2;
            Health-=damage;
            pa.specialLoad++;
            print(pa.specialLoad);
        }
        if (Health <= 0)
        {
            Health = 0;
            CurrentPhase = 3;
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
        Health = bossMaxHealth;
        CurrentPhase = 1;
        isInvincible = true;
        pa = player.GetComponent<PlayerActions>();
        so = SaveLoad.Load();
    }
    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            CurrentPhase = 1;
        }
        if (!isInvincible&&Health>0)
        {
            CurrentPhase = 2;
        }

        if (CurrentPhase == 1)
        {
            //actions for phase 1

            //checking if the boss is not in animation is needed.
            float distance = (player.transform.position - gameObject.transform.position).magnitude;//checking how far is the player from the boss
            if (distance <= 3f) // if the player is far 3f or less - execute following code
            {
                Debug.Log("Slash");
                //Slash animation
            }
            
        }
        if (CurrentPhase == 2)
        {
            //actions for phase 2
            //random generator for deciding - straight arrow fire or 3 arrows fired at once
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerActions>().TakeHit();
        }
    }
}