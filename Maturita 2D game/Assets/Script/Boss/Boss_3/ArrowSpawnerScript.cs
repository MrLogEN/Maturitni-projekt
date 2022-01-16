using UnityEngine;
using System.Linq;

public class ArrowSpawnerScript : MonoBehaviour
{
    public GameObject arrow;
    private System.Random rn;
    private float spawnRate = 2.5f;
    private float t;
    public Transform player;

    public GameObject projectileGameobject;
    public Transform target; // cíl, na který se støílí
    







    // Start is called before the first frame update
    void Start()
    {
        rn = new System.Random();
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<IBoss>().CurrentPhase == 2)
        {
            if (Time.time >= t)
            {
                int randomAttack = rn.Next(3);
                switch (randomAttack)
                {
                    case 0:
                        SpawnArrow(1);
                        break;
                    case 1:
                        SpawnArrow(1);

                        break;
                    case 2:
                        SpawnArrow(3);

                        break;
                    default:
                        break;
                }
                t = Time.time + spawnRate;
            }
        }

    }
    void SpawnArrow(int num)
    {
        //Debug.Log("Direction is: "+ dir + "Odchylka: " + dif + (char)0176);
        if (num == 1)
        {
            GameObject go;
            go = Instantiate(arrow, transform.position, Quaternion.identity, this.gameObject.transform);
        }
        if (num == 3)
        {

            Vector3 pos1 = target.position - new Vector3(4, 0, 0);
            Vector3 pos2 = target.position + new Vector3(4, 0, 0);

            Launch(pos1);
            Launch(target.position);
            Launch(pos2);
        }

    }

  
    private void Launch(Vector3 target)
    {
        Vector2 Vo = CalculateLaunchVelocity(target, transform.position, 3f);
        GameObject go = Instantiate(projectileGameobject, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = Vo;
    }
    private Vector2 CalculateLaunchVelocity(Vector2 target, Vector2 origin, float time)
    {
        //target.y = -4.8f;
        Vector2 distance = target - origin;
        Vector2 distanceX = new Vector2(distance.x,0);

        float Sy = distance.y;
        float Sx = distanceX.magnitude;

        float Vx = Sx / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 result = distanceX.normalized;
        result *= Vx;
        result.y = Vy;
        return result;
    }
}
