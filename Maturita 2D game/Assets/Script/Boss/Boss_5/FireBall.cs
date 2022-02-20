using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Vector3 pos;
    void Start()
    {
        player = FindObjectOfType<PlayerActions>().gameObject;
        pos = new Vector3(player.transform.position.x,-4.68f,0);
        //float ang = Vector3.Angle(transform.position, pos);
        //print("Angle is " + ang);

        Vector2 direction = pos - transform.position;
        direction.Normalize();
        float ang = Vector3.Cross(direction, transform.up).z;


        transform.rotation = Quaternion.Euler(0,0,ang);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, 5*Time.deltaTime);

        if (transform.position == pos)
        {
            Vector3 fpos = new Vector3(pos.x,-0.83f,0);
            Instantiate(Level5Manager.instance.groundFlamesPrefab, fpos, Quaternion.identity);

            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerActions>().TakeHit();
            Destroy(gameObject);
        }
    }
}
