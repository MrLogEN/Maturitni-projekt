using UnityEngine;
using System.Linq;
using System.Threading.Tasks;

public class ArrowSpawnerScript : MonoBehaviour
{
    public GameObject arrow;
    private System.Random rn;
    private float spawnRate = 2f;
    private float t;
    public Transform player;

    public GameObject projectileGameobject;
    public Transform target; // cíl, na který se støílí
    int i = 0;
    Boss3Script boss;



    // Start is called before the first frame update
    void Start()
    {
        rn = new System.Random();
        t = Time.time;
        boss = GetComponentInParent<Boss3Script>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(boss.CurrentPhase);
        if (boss.CurrentPhase == 2 && boss._currenState == boss.IDLE_BOW)
        {
            if (i==0)
            {
                t = Time.time + 2;
            }
            i++;

            if (Time.time >= t)
            {
                int randomAttack = rn.Next(4);
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
                    case 3:
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
            LaunchNormal();
        }
        if (num == 3)
        {


            Launch(target);
        }

    }
 
    private async void LaunchNormal()
    {
        boss.ChangeAnimationState(boss.SHOOT_STREIGHT);
        await Task.Delay(630);
        //AudioManager.instance.PlayArrowShootSfx();
        GameObject go = Instantiate(arrow, transform.position, Quaternion.identity);
        await Task.Delay(260);
        boss.ChangeAnimationState(boss.IDLE_BOW);
    }
    private async void Launch(Transform target)
    {
        boss.ChangeAnimationState(boss.SHOOT_UP);
        await Task.Delay(630);
        Vector3 pos1 = target.position - new Vector3(4, 0, 0);
        Vector3 pos2 = target.position + new Vector3(4, 0, 0);

        Vector2 Vo = CalculateLaunchVelocity(pos1, transform.position, 3f);
        Vector2 Vo1 = CalculateLaunchVelocity(target.position, transform.position, 3f);
        Vector2 Vo2 = CalculateLaunchVelocity(pos2, transform.position, 3f);

        GameObject go = Instantiate(projectileGameobject, transform.position,Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = Vo;

        GameObject go1 = Instantiate(projectileGameobject, transform.position, Quaternion.identity);
        go1.GetComponent<Rigidbody2D>().velocity = Vo1;

        GameObject go2 = Instantiate(projectileGameobject, transform.position, Quaternion.identity);
        go2.GetComponent<Rigidbody2D>().velocity = Vo2;
        //AudioManager.instance.PlayMultipleArrowShootSfx();
        await Task.Delay(260);
        boss.ChangeAnimationState(boss.IDLE_BOW);
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
