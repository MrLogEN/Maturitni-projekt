using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoss
{
    int Health { get; set; }
    int Damage { get;}
    int Phases { get; set; }
    int TakeDamage();
}
