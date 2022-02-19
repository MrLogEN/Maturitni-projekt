﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectileGameobject;  // prefab(střela), který se klonuje do scény
    private GameObject projectileClone; // instance objektu 
    private Rigidbody2D projectile; // Rigidbody2D komponent objektu
    public Transform target; // cíl, na který se střílí
    public Animator animator; //animátor
    public float height = 5;  // maximální výška trajektorie střely
    //public float gravity = -18; // hodnota gravitace
    public float timeToLive = 3; // čas, po kterém se odstraní instance objektu ze scény
    public float fireRate = 4; // čas, za který se jednou vystřelí
    private float nextFire = 4; // čas, ve který proběhne další výstřel

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time + fireRate + nextFire;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            print(nextFire + "pro");
            nextFire = Time.time + fireRate;
            animator.SetTrigger("projectileLaunched");
            Invoke("Launch", 0.917f);
        }
        Destroy(projectileClone, timeToLive); // zničení objektu ze scény za určitý čas
    }

    void Launch()
    {
        projectileClone = Instantiate(projectileGameobject, transform.position, transform.rotation); // vytvoření instance objektu ve scéně
        projectile = projectileClone.GetComponent<Rigidbody2D>(); // získání komponenty Rigidbody2D z vytvořené instance
                                                                  //Physics2D.gravity = Vector2.up * Physics2D.gravity; // přiřazení gravitace
        projectile.velocity = CalculateLaunchVelocity(); // přiřazení vypočítané rychlosti komponentě Rigidbody2D
        print(CalculateLaunchVelocity());
    }

    // metoda na výpočet trajektorie pohybu
    Vector2 CalculateLaunchVelocity()
    {
        float displacementY = target.position.y - projectile.position.y;
        Vector2 displacementX = new Vector2(target.position.x - projectile.position.x, 0);
        Vector2 velocityY = Vector2.up * Mathf.Sqrt(-2 * Physics2D.gravity.y * height);
        Vector2 velocityX = displacementX / (Mathf.Sqrt(-2 * height / Physics2D.gravity.y) + Mathf.Sqrt(2 * (displacementY - height) / Physics2D.gravity.y));
        return velocityX + velocityY;
    }
}
