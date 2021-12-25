using UnityEngine;
using System.Linq;

public class ArrowSpawnerScript : MonoBehaviour
{
    public GameObject arrow;
    private System.Random rn;
    private float spawnRate = 5f;
    private float t;
    public Transform player;

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
        Vector3 dir = CalculateDirection(player);
        float dif = CalculateAngle(dir);
        Debug.Log(dir);
        Debug.Log("Direction is: "+ dir + "Odchylka: " + dif + (char)0176);
        if (num == 1)
        {
            GameObject go;
            go = Instantiate(arrow, transform.position, Quaternion.identity, this.gameObject.transform);
        }
        if (num == 3)
        {

            GameObject go, go1, go2;
            go = Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, 5f),this.gameObject.transform);
            go1 = Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, 0), this.gameObject.transform);

            go2 = Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, -5f), this.gameObject.transform);

        }

    }

    private float CalculateAngle(Vector3 dir)
    {
        Vector3 defaulVector = new Vector3(1, 0, 0);

        float uv = defaulVector.x * dir.x + defaulVector.y * dir.y + defaulVector.z*dir.z;

        float uSize = Mathf.Sqrt(Mathf.Pow(defaulVector.x, 2f) + Mathf.Pow(defaulVector.y, 2f) + Mathf.Pow(defaulVector.z,2f));

        float vSize = Mathf.Sqrt(Mathf.Pow(dir.x, 2f) + Mathf.Pow(dir.y, 2f) + Mathf.Pow(dir.z,2f));
        float rad = uv / (uSize * vSize);
        float angle = Mathf.Acos(rad);
        Debug.Log($"The angle is: {uv} / ({uSize} * {vSize}) in rad {rad}");
        return angle;
    }

    private Vector3 CalculateDirection(Transform player)
    {
        Vector3 spawnerPosition = gameObject.transform.position;
        float x = player.position.x - spawnerPosition.x;
        float y = player.position.y - spawnerPosition.y;
        float z = player.position.z - spawnerPosition.z;
        float[] arr = new float[2] {x,y};
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Mathf.Abs(arr[i]);
        }
        float highest = arr.Max();
        Debug.Log("Max value: " + highest);
        Vector3 output = new Vector3(x/highest, y/highest, z/highest);
        return output;
    }
}
