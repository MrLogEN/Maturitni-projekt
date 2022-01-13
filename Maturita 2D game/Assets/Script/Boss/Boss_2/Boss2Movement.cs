using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Boss2Movement : MonoBehaviour
{
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public bool spell1;
    public bool spell2;
    public float m;
    public Animator anim;


    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    void Start()
    {
        posOffset = transform.position;
        spell1 = false;
        spell2 = false;
        anim = GetComponent<Animator>();
}

    // Update is called once per frame
    public void Update()
    {
        if (Time.fixedTime % 5 == 0)
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
            if (tempPos.y !=-2.5f)
            {
                tempPos = posOffset;
                tempPos.y += 5f * Mathf.Sin((Time.fixedTime - m)* Mathf.PI * frequency * 0.5f) * amplitude;
                transform.position = tempPos;
            }
            else
            {
                //zapne animiaci
                //anim.SetBool("Attack2Start", true);
                anim.SetBool("Attack2Start", true);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2-End"))//èeká než dokonèí animaci
                {
                    anim.SetBool("Attack2Start", false);
                    SpellTwoEnd();
                    m = m + 2; 
                }
                
            }

        }
        else if (spell1 == true)
        {
            float player_postion = GameObject.Find("Player").transform.position.y;
            if (player_postion == tempPos.y)
            {

            }
            else
            {
                Debug.Log("nig");
                //zapne animaci
                SpellOneEnd();
            }

        }
        else
        {
            tempPos = posOffset;
            tempPos.y += 5f * Mathf.Sin((Time.fixedTime - m)* Mathf.PI * frequency * 0.5f) * amplitude;
            transform.position = tempPos;
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
    }
    public void SpellTwoEnd()
    {
        spell2 = false;
    }
}
