using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour,IBoss
{
    private float _health;
    private int _damage = 1;
    private int _phases;
    private int _maxHealth = 20;
    public float Health { get => _health; set => _health = value; }
    public int Damage => _damage;
    public int Phases { get => _phases; set => _phases = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    public PlayerActions pa;
    void Start()
    {
        _health = MaxHealth;
        _phases = 1;
    }
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        Health-=damage;
        pa.specialLoad++;
        Debug.Log("Boss health" + Health);
        if (Health <= 0)
        {
            Health = 0;
            Time.timeScale = 0;
            SaveObject so = SaveLoad.Load();
            if (!so.lvl2IsCompleted)
            {
                so.lvl2IsCompleted = true;
                so.skillPoints++;
            }
            SaveLoad.Save(so);
        }
    }
}
