using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balloon;
    private bool ds;
    private Camera mCamera;
    private Vector2 screenBounds;
    void Start()
    {

        mCamera = Camera.main;
        
        screenBounds = mCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mCamera.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (balloon != null)
        {
            ds = balloon.GetComponent<BalloonScript>().isDestroyed;
        }
        if (ds == false)
        {
            transform.position += new Vector3(-2f, 0, 0) * Time.deltaTime; //movement of the balloon
        }
        if (gameObject.transform.position.x < -(screenBounds.x+2f)) //despawning the balloon
        {
            Destroy(this.gameObject);
        }
    }
}
