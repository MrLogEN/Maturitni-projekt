using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRigid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float y = GetComponent<Rigidbody2D>().velocity.y;
        float z;
        if (y <0)
        {
            z = Vector2.Angle(new Vector2(-1, 0), GetComponent<Rigidbody2D>().velocity);
        }
        else
        {
            z = Vector2.Angle(new Vector2(1, 0), GetComponent<Rigidbody2D>().velocity);
        }
        
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,z));
    }
}
