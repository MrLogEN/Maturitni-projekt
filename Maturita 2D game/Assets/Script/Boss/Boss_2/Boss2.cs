using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour,IBoss
{
    private int _health;
    private int _damage = 1;
    private int _phases;
    public int Health { get => _health; set => _health = value; }
    public int Damage => _damage;
    public int Phases { get => _phases; set => _phases = value; }
    void Start()
    {
        _health = 10;
        _phases = 1;
    }
    void Update()
    {
        
    }
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
}
