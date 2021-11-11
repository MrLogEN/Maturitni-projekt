using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour, IPlayerStats
{

    private int _health;
    private int _damage;
    private bool _isDead;
    public int Health { get => _health; set => _health = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public bool IsDead { get => _isDead; set => _isDead = value;  }

    void Start()
    {
        Health = 3; // default settings
        Damage = 1;
    }

    void Update()
    {
        if (Health <= 0)
        {
            //An action executed upon death
            IsDead = true;
            Debug.Log("You are dead");
        }
    }
    public void TakeHit()
    {
        Health--;
        Debug.Log(Health);
    }
}
