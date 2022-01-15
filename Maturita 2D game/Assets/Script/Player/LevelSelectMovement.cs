using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 5f;
    BindingObject bo;
    private void Awake()
    {
        bo = new BindingObject();
        bo = ControlBinding.Load();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey((KeyCode)bo.selectLeft)) //Moving to the left
        {
            transform.position -= transform.right * (Time.fixedDeltaTime * moveSpeed);
        }
        if (Input.GetKey((KeyCode)bo.selectRight)) //Moving to ther right
        {
            transform.position += transform.right * (Time.fixedDeltaTime * moveSpeed); 
        }
        if (Input.GetKey((KeyCode)bo.selectUp)) //Moving up
        {
            transform.position += transform.up * (Time.fixedDeltaTime * moveSpeed);
        }
        if (Input.GetKey((KeyCode)bo.selectDown)) //Moving down
        {
            transform.position -= transform.up * (Time.fixedDeltaTime * moveSpeed);
        }
    }
}
