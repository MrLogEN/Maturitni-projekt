using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour,IBoss
{
    int _health;
    int _damage;
    int _phases;
    public int Health { get => _health; set => _health = value; }

    public int Damage => _damage;

    public int Phases { get => _phases; set => _phases = value; }

    public void TakeDamage()
    {
        Health--;
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
