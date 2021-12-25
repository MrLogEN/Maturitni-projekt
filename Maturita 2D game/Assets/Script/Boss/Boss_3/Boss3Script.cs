using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Script : MonoBehaviour, IBoss
{
    #region private
    private int _health;
    private int _damage;
    private readonly int _phases = 2;
    private int _currentPhase;
    private int bossMaxHealth = 2000;

    #endregion


   
    public int Health { get => _health; set => _health = value; }

    public int Damage => _damage;

    public int Phases => _phases;
    public int CurrentPhase { get => _currentPhase; set => _currentPhase=value; }

    public bool isInvincible;

    public GameObject player;
    public void TakeDamage()
    {
        
        if (isInvincible)
        {
            //CurrentPhase = 1;
            Debug.Log("Boss is invincible, health: " + Health);
        }
        if (!isInvincible)
        {
            //CurrentPhase = 2;

            Health--;
            Debug.Log("Boss health: " + Health);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = bossMaxHealth;
        CurrentPhase = 1;
        isInvincible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            CurrentPhase = 1;
        }
        if (!isInvincible)
        {
            CurrentPhase = 2;
        }

        if (CurrentPhase == 1)
        {
            //actions for phase 1

            //checking if the boss is not in animation is needed.
            Vector3 distance = DistanceCheck(player); //checking how far is the player from the boss
            if (distance.x <= 3f && distance.y<=3f) // if the player is far 3f or less - execute following code
            {
                Debug.Log("Slash");
                //Slash animation
            }
            
        }
        if (CurrentPhase == 2)
        {
            //actions for phase 2
            //random generator for deciding - straight arrow fire or 3 arrows fired at once
        }
    }
    Vector3 DistanceCheck(GameObject player)
    {
        float x = Mathf.Abs(player.transform.position.x - gameObject.transform.position.x); //absolute x value of substracted positions of the boss and of the player
        float y = Mathf.Abs(player.transform.position.y - gameObject.transform.position.y); //absolute y value of substracted positions of the boss and of the player
        float z = Mathf.Abs(player.transform.position.z - gameObject.transform.position.z); //absolute z value of substracted positions of the boss and of the player
        Vector3 sub = new Vector3(x, y, z); //Creating Vector3 from the differences
        return sub;
    }
}
