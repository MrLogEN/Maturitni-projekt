using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Script : MonoBehaviour, IBoss
{
    #region private
    private int _health;
    private int _damage;
    private readonly int _phases = 2;
    private int _currentPhase;
    private int bossMaxHealth = 2000;

    #endregion


   
    public int Health { get => _health; set => _health = value; }

    public int Damage => _damage;

    public int Phases => _phases;
    public int CurrentPhase { get => _currentPhase; set => _currentPhase=value; }

    public bool isInvincible;

    public void TakeDamage()
    {
        
        if (isInvincible)
        {
            CurrentPhase = 1;
            Debug.Log("Boss is invincible, health: " + Health);
        }
        if (!isInvincible)
        {
            CurrentPhase = 2;

            Health--;
            Debug.Log("Boss health: " + Health);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = bossMaxHealth;
        CurrentPhase = 1;
        isInvincible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPhase == 1)
        {
            //actions for phase 1
        }
        if (CurrentPhase == 2)
        {
            //actions for phase 2
        }
    }
}
