using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallLauncher : MonoBehaviour
{
    public GameObject cannonBallGameObject;
    private GameObject cannonBallClone;
    private Rigidbody2D cannonBall;
    public Transform target;
    public Transform hand;
    public Animator animator;
    private Vector2 direction;
    public float speed = 15;
    public float timeToLive = 2;
    public float fireRate = 2;
    private float nextFire = 1;
    // Start is called before the first frame update
    void Start()
    {

        nextFire = Time.time + nextFire + fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = target.position - transform.position;
        float angle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
        hand.rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward);

        if (Time.time > nextFire)
        {
            print(nextFire + "can");
            nextFire = Time.time + fireRate;
            animator.SetTrigger("cannonBallLaunched");
            Invoke("Launch", 0.5f);
        }
        Destroy(cannonBallClone, timeToLive);
    }

    void Launch()
    {
        cannonBallClone = Instantiate(cannonBallGameObject, transform.position, transform.rotation);
        cannonBall = cannonBallClone.GetComponent<Rigidbody2D>();
        direction = (target.transform.position - transform.position).normalized * speed;
        //hand.position = direction;
        cannonBall.velocity = new Vector2(direction.x, direction.y);
    }
}
