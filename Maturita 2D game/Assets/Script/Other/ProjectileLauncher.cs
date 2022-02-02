using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectileGameobject;  // prefab(střela), který se klonuje do scény
    private GameObject projectileClone; // instance objektu 
    private Rigidbody2D projectile; // Rigidbody2D komponent objektu
    public Transform target; // cíl, na který se střílí
    public float height = 5;  // maximální výška trajektorie střely
    public float gravity = -18; // hodnota gravitace
    public float timeToLive = 3; // čas, po kterém se odstraní instance objektu ze scény
    public float fireRate = 4; // čas, za který se jednou vystřelí
    private float nextFire = 4; // čas, ve který proběhne další výstřel

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Launch();
        }
        Destroy(projectileClone, timeToLive); // zničení objektu ze scény za určitý čas
    }

    void Launch()
    {
        projectileClone = Instantiate(projectileGameobject, transform.position, transform.rotation); // vytvoření instance objektu ve scéně
        projectile = projectileClone.GetComponent<Rigidbody2D>(); // získání komponenty Rigidbody2D z vytvořené instance
        Physics2D.gravity = Vector2.up * gravity; // přiřazení gravitace
        projectile.velocity = CalculateLaunchVelocity(); // přiřazení vypočítané rychlosti komponentě Rigidbody2D
        print(CalculateLaunchVelocity());
    }

    // metoda na výpočet trajektorie pohybu
    Vector2 CalculateLaunchVelocity()
    {
        float displacementY = target.position.y - projectile.position.y;
        Vector2 displacementX = new Vector2(target.position.x - projectile.position.x, 0);
        Vector2 velocityY = Vector2.up * Mathf.Sqrt(-2 * gravity * height);
        Vector2 velocityX = displacementX / (Mathf.Sqrt(-2 * height / gravity) + Mathf.Sqrt(2 * (displacementY - height) / gravity));
        return velocityX + velocityY;
    }
}
