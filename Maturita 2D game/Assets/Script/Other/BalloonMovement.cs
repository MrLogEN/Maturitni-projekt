using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balloon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (!balloon.GetComponent<BalloonScript>().isDestroyed)
        {
            transform.position += new Vector3(10, 0, 0);
        }
    }
}
