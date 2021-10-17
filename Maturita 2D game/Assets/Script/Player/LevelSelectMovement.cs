using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //Moving to the left
        {
            transform.position -= transform.right * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow)) //Moving to ther right
        {
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow)) //Moving up
        {
            transform.position += transform.up * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow)) //Moving down
        {
            transform.position -= transform.up * (Time.deltaTime * moveSpeed);
        }
    }
}
