using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour,IBoss
{
    float _health;
    int _damage;
    int _phases;
    int _maxHealth = 10;
    public float Health { get => _health; set => _health = value; }

    public int Damage => _damage;

    public int Phases { get => _phases; set => _phases = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public PlayerActions pa;
    public void TakeDamage(float damage)
    {
        Health-=damage;
        pa.specialLoad++;
        if (Health <=0)
        {
            Health = 0;
            Time.timeScale = 0;
            SaveObject so = SaveLoad.Load();
            so.lvl1IsCompleted = true;
            SaveLoad.Save(so);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
