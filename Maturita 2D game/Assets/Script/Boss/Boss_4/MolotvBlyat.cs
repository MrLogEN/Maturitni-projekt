using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotvBlyat : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public float speed = 10f;
    private float bossX;
    private float playerX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    public GameObject fire;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        playerX = player.transform.position.x;
        bossX = boss.transform.position.x;
    }

    void Update()
    {
        dist = playerX - bossX;

        nextX = Mathf.MoveTowards(transform.position.x, playerX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(boss.transform.position.y, -4.5f, (nextX - bossX) / dist);
        height = 2 * (nextX - bossX) * (nextX - playerX) / (-0.25f * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;

        if (transform.position.y == -4.5f)
        {
            //AudioManager.instance.PlayMolotovSplashSfx();
            Destroy(gameObject);
            Instantiate(fire, transform.position, Quaternion.identity);

            //if (!GameObject.FindGameObjectWithTag("BossAttack"))
            //{
            //    Instantiate(fire, transform.position, Quaternion.identity);
            //}
            
        }

    }

    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
}
