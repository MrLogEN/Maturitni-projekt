using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStats //Basic player's stats
{
    public int Health { get; set; }
    
    public int Damage { get; set; }
    
}
public interface IPlayerSkills //skill tree related to movement
{
    public float Speed { get; set; }
    public bool HasDoubleJump { get; set; }
}
