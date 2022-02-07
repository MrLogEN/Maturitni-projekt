using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int sc;
    BindingObject bo;
    public Transform player;
    SaveObject so;
    private void Awake()
    {

        bo = new BindingObject();
        bo = ControlBinding.Load();
        so = SaveLoad.Load();
        player.position = so.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CollisionCheck(collision.gameObject);
    }
    void CollisionCheck(GameObject col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            so.position = player.position;
            SaveLoad.Save(so);
            if (Input.GetKey(bo.selectSelect))
            {
                Debug.Log("Loading...");
                switch (sc)
                {
                    case 0:
                        SceneManager.LoadScene("main_menu");
                        break;
                    case 1:
                        SceneManager.LoadScene("level_select");
                        break;
                    case 2:
                        SceneManager.LoadScene("level_tutorial");
                        break;
                    case 3:
                        SceneManager.LoadScene("level_1");
                        break;
                    case 4:
                        SceneManager.LoadScene("level_2");
                        break;
                    case 5:
                        SceneManager.LoadScene("level_3");
                        break;
                    case 6:
                        SceneManager.LoadScene("level_4");
                        break;
                    case 7:
                        SceneManager.LoadScene("level_5");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
