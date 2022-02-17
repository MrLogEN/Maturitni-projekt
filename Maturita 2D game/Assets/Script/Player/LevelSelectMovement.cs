using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSelectMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 3f;
    BindingObject bo;
    public ButtonsActions actions;
    public GameObject mapGo;
    private SpriteRenderer map;
    private float minX,maxX, minY, maxY;
    void Start()
    {
        bo = new BindingObject();
        bo = ControlBinding.Load();
        actions.OnBindingChange += ChangeBindings;
        map = mapGo.GetComponent<SpriteRenderer>();
        minX = map.bounds.min.x;
        maxX = map.bounds.max.x;
        minY = map.bounds.min.y;
        maxY = map.bounds.max.y;

    }

    // Update is called once per frame
    void Update()
    {
        PosClamp();
        if (Input.GetKey(bo.selectLeft)) //Moving to the left
        {
            transform.position -= transform.right.normalized * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(bo.selectRight)) //Moving to ther right
        {
            transform.position += transform.right.normalized * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(bo.selectUp)) //Moving up
        {
            transform.position += transform.up.normalized * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(bo.selectDown)) //Moving down
        {
            transform.position -= transform.up.normalized * (Time.deltaTime * moveSpeed);
        }
    }
    public void ChangeBindings(object sender, EventArgs e)
    {
        bo = ControlBinding.Load();
    }
    void PosClamp()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minX,maxX), Mathf.Clamp(transform.position.y, minY, maxY),transform.position.z);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
