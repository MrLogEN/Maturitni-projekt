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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, 5*Time.deltaTime);
        if (transform.position == pos)
        {
            Vector3 fpos = new Vector3(pos.x,-4,0);
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
