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
       
    }
    void Start()
    {
        bo = new BindingObject();
        bo = ControlBinding.Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(bo.selectLeft)) //Moving to the left
        {
            transform.position -= transform.right * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(bo.selectRight)) //Moving to ther right
        {
            transform.position += transform.right * (Time.deltaTime * moveSpeed); 
        }
        if (Input.GetKey(bo.selectUp)) //Moving up
        {
            transform.position += transform.up * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(bo.selectDown)) //Moving down
        {
            transform.position -= transform.up * (Time.deltaTime * moveSpeed);
        }
    }
}
