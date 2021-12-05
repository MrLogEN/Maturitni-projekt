using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawnerScript : MonoBehaviour
{
    public GameObject arrow;
    private System.Random rn;
    private float spawnRate = 5f;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        rn = new System.Random();
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<IBoss>().CurrentPhase == 2)
        {
            if (Time.time >= t)
            {
                int randomAttack = rn.Next(3);
                switch (randomAttack)
                {
                    case 0:
                        SpawnArrow(1);
                        break;
                    case 1:
                        SpawnArrow(1);

                        break;
                    case 2:
                        SpawnArrow(3);

                        break;
                    default:
                        break;
                }
                t = Time.time + spawnRate;
            }
        }
       
    }
    void SpawnArrow(int num)
    {
        if (num == 1)
        {
            GameObject go;
            go = Instantiate(arrow, transform.position, Quaternion.identity);
        }
        if (num == 3)
        {
            GameObject go, go1, go2;
            go = Instantiate(arrow, transform.position, Quaternion.Euler(0,0,5f));
            go1 = Instantiate(arrow, transform.position, Quaternion.Euler(0,0,0));
            go2 = Instantiate(arrow, transform.position, Quaternion.Euler(0,0,-5f));
        }
        
    }
}
