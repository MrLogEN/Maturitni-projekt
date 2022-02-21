using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale;
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime % 0.5f <= 0.05f)
        {
            scale = transform.localScale.x * -1;
            transform.localScale = new Vector3(scale, transform.localScale.y);
        }    
    }


}
