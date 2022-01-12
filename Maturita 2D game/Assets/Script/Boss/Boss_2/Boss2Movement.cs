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

        
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    void Start()
    {
        posOffset = transform.position;
        spell1 = false;
        spell2 = false;
}

    // Update is called once per frame
    public void Update()
    {
        if (Time.fixedTime % 10 == 0)
        {
            System.Random rn = new System.Random();
            int random = rn.Next(0, 2);
            if (random == 0)
            {
                SpellOne();
            }
            else if (random == 1)
            {
                Thread.Sleep(1000);
                SpellTwo();
            }
        }
        if (spell1 == true)
        {
            if (tempPos.y !=-2.5f)
            {
                tempPos = posOffset;
                tempPos.y += 5f * Mathf.Sin(Time.fixedTime * Mathf.PI * frequency * 0.5f) * amplitude;
                transform.position = tempPos;
            }
            else
            {
                //zapne animiaci
                Thread.Sleep(1000);
                SpellOneEnd();
            }

        }
        else if (spell2 == true)
        {
            float player_postion = GameObject.Find("Player").transform.position.y;
            if (true)
            {

            }
            else
            {
                //zapne animaci
                SpellTwoEnd();
            }

        }
        else
        {
            tempPos = posOffset;
            tempPos.y += 5f * Mathf.Sin(Time.fixedTime * Mathf.PI * frequency * 0.5f) * amplitude;
            transform.position = tempPos;
        }
    }
    public void SpellOne()
    {
        spell1 = true;
    }
    public void SpellTwo()
    {
        spell1 = true;
    }
    public void SpellOneEnd()
    {
        spell1 = false;
    }
    public void SpellTwoEnd()
    {
        spell1 = false;
    }
}
