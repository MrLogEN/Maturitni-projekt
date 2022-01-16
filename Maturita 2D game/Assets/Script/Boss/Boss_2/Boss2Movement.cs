using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Boss2Movement : MonoBehaviour
{
    public bool spell1;
    public bool spell2;
    public float m;
    public Animator anim;
    public GameObject spikePrefab;
    public GameObject rootPrefab;
    List<GameObject> spikes = new List<GameObject>();
    void Start()
    {
        spell1 = false;
        spell2 = false;
        anim = GetComponent<Animator>();
}

    // Update is called once per frame
    public void Update()
    {
        if (Time.fixedTime % 8 == 0)
        {
            System.Random rn = new System.Random();
            int random = rn.Next(0, 2);
            if (random == 0)
            {
                SpellOne();
            }
            else if (random == 1)
            {
                SpellTwo();
            }
        }
        if (spell2 == true)
        {
            if (transform.position.y == -2.5f)
            {
                anim.SetBool("Attack2Start", true);
                if (spikes.Count == 0)
                {
                    GameObject a = Instantiate(spikePrefab) as GameObject;
                    a.transform.position = new Vector2(GameObject.Find("Player").transform.position.x, -4.5f);
                    spikes.Add(a);
                }
            }

        }
        else if (spell1 == true)
        {
            float player_postion = GameObject.Find("Player").transform.position.y;
            if (player_postion - transform.position.y <= 0.1f)
            {
                anim.SetBool("Attack1Start", true);
            }
        }
    }
    public void SpellOne()
    {
        spell1 = true;
    }
    public void SpellTwo()
    {
        spell2 = true;
    }
    public void SpellOneEnd()
    {
        spell1 = false;
        anim.SetBool("Attack1Start", false);
    }
    public void SpellTwoEnd()
    {
        spell2 = false;
        anim.SetBool("Attack2Start", false);
        Destroy(spikes[0]);
        spikes.Clear();
    }
}
