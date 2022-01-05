using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int sc;
    public Transform player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        CollisionCheck(collision.gameObject);;
    }

    void CollisionCheck(GameObject col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            if (Input.GetKey(KeyCode.X))
            {
                switch (sc)
                {
                    case 0:
                        SaveLoad.Save(player);
                        SceneManager.LoadScene("main_menu");
                        break;
                    case 1:
                        SaveLoad.Save(player);
                        SceneManager.LoadScene("level_select");
                        break;
                    case 2:
                        SaveLoad.Save(player);
                        SceneManager.LoadScene("level_tutorial");
                        break;
                    case 3:
                        SaveLoad.Save(player);
                        SceneManager.LoadScene("level_1");
                        break;
                    case 4:
                        SaveLoad.Save(player);
                        SceneManager.LoadScene("level_2");
                        break;
                    case 5:
                        SaveLoad.Save(player);
                        SceneManager.LoadScene("level_3");
                        break;
                    case 6:
                        SaveLoad.Save(player);
                        SceneManager.LoadScene("level_4");
                        break;
                    case 7:
                        SaveLoad.Save(player);
                        SceneManager.LoadScene("level_5");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
