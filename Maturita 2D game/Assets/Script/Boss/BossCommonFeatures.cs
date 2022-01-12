using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCommonFeatures : MonoBehaviour, IBoss
{
    private int _health;
    private int _damage = 1;
    private int _phases;
    public int Health { get => _health; set => _health = value; }

    public int Damage => _damage;

    public int Phases { get => _phases; set => _phases = value; }

    private void Start()
    {
        _health = 20;
    }
    public void TakeDamage()
    {
        Health--;
        Debug.Log("Boss health: "+ Health);
    }
}