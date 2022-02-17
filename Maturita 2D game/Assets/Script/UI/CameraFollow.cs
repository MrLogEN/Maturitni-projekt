using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private Transform target;
    private Vector3 offset = new Vector3(0,0,-10);
    private float smoothFactor = 3f;
    // Update is called once per frame
    private void Start()
    {
        transform.position = target.position + offset;
    }
    void Update()
    {

        //transform.position = new Vector3(
        //    Mathf.Clamp(target.position.x, -9.7f, 9.7f),
        //    Mathf.Clamp(target.position.y, -4.65f, 4.65f),
        //    transform.position.z);
        Vector3 posClamp = new Vector3(Mathf.Clamp(target.position.x, -9.7f, 9.7f), Mathf.Clamp(target.position.y, -4.65f, 4.65f), transform.position.z);
        Vector3 targetPos = posClamp;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPos;
    }
}
