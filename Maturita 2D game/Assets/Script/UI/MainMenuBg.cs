using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MainMenuBg : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3[] points;
    Vector3 pos;
    float nextPos;
    float nextPosTime = 10f;
    void Start()
    {
        points = new Vector3[4] { new Vector3(3.7f, 2f), new Vector3(-3.7f, 2f), new Vector3(3.7f, -2f), new Vector3(-3.7f, -2f) };
        nextPos = Time.time;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (nextPos < Time.time)
        {
            nextPos = Time.time + nextPosTime;
            GenerateNewPosition();
        }
        Vector3 bgP = Vector3.Lerp(transform.position, pos, .1f*Time.fixedDeltaTime);
        transform.position = bgP;
    }
    private void GenerateNewPosition()
    {
        pos = points[Random.Range(0, points.Length)];
        float x = Random.Range(-3.7f, 3.7f);
        float y = Random.Range(-2f, 2f);
        pos = new Vector3(x, y);
    }
}
