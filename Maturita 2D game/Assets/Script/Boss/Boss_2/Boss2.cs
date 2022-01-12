using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    private int _health;
    private int _damage = 1;
    private int _phases;
    public int Health { get => _health; set => _health = value; }
    public int Damage => _damage;
    public int Phases { get => _phases; set => _phases = value; }
    void Start()
    {
        _health = 20;
        _phases = 1;
    }
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        Health--;
        Debug.Log("Boss health" + Health);
    }
}
