using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallLauncher : MonoBehaviour
{
    public GameObject cannonBallGameObject;
    private GameObject cannonBallClone;
    private Rigidbody2D cannonBall;
    public Transform target;
    private Vector2 direction;
    public float speed = 15;
    public float timeToLive = 2;
    public float timeBetweenShots = 1.5f;
    private float nextFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            Launch();
        }
        Destroy(cannonBallClone, timeToLive);
    }

    void Launch()
    {
        cannonBallClone = Instantiate(cannonBallGameObject, transform.position, transform.rotation);
        cannonBall = cannonBallClone.GetComponent<Rigidbody2D>();
        direction = (target.transform.position - transform.position).normalized * speed;
        cannonBall.velocity = new Vector2(direction.x, direction.y);

    }
}