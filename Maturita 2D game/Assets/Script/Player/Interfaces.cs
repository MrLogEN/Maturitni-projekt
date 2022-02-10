using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStats //Basic player's stats
{
    public int Health { get; set; }
    
    public int Damage { get; set; }
    public bool IsDead { get; set; }
    
}
public interface IPlayerSkills //skill tree related to movement
{
    public float Speed { get; set; }
    public bool HasDoubleJump { get; set; }
}
public interface ICollisonHandler //Collision handling structure
{
    public void CollisionEnter(string colliderName, GameObject other);
}
public interface IBoss
{
    int Health { get; set; }
    int Damage { get; }
    int Phases { get; set; }
    int MaxHealth { get; set; }
    void TakeDamage();
}

