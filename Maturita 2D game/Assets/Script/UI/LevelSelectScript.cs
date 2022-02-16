using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelSelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ButtonsActions ba;
    public TextMesh tm;
    public int sc;
    BindingObject bo;
    public Transform player;
    private bool tutorialC, level1C, level2C, level3C, level4C, level5C;
    private void Awake()
    {
        Time.timeScale = 1f;
        ba.OnBindingChange += BindingChange;
        bo = new BindingObject();
        bo = ControlBinding.Load();
        SaveObject so = SaveLoad.Load();
        player.position = so.position;
        tutorialC = so.tutorialCompleted;
        level1C = so.lvl1IsCompleted;
        level2C = so.lvl2IsCompleted;
        level3C = so.lvl3IsCompleted;
        level4C = so.lvl4IsCompleted;
        level5C = so.lvl5IsCompleted;
        
    }
    void BindingChange(object sender, EventArgs e)
    {
        bo = ControlBinding.Load();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CollisionCheck(collision.gameObject);
    }
    void CollisionCheck(GameObject col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //PopUpButton();
            ShowLocked();
            SaveObject so = SaveLoad.Load();
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
                        if (tutorialC)
                        {
                            SceneManager.LoadScene("level_1");
                        }
                        break;
                    case 4:
                        if (level1C)
                        {
                            SceneManager.LoadScene("level_2");
                        }
                        break;
                    case 5:
                        if (level2C)
                        {
                            SceneManager.LoadScene("level_3");
                        }
                        break;
                    case 6:
                        if (level3C)
                        {
                            SceneManager.LoadScene("level_4");
                        }
                        break;
                    case 7:
                        if (level4C)
                        {
                            SceneManager.LoadScene("level_5");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }
    void PopUpButton()
    {
        tm.gameObject.SetActive(true);
        tm.text = "Press " + bo.selectSelect + "\n to start the level";
    }
    void ShowLocked()
    {
        switch (sc)
        {
            case 3:
                if (tutorialC)
                {
                    PopUpButton();
                }
                else
                {
                    tm.gameObject.SetActive(true);
                    tm.text = "Level locked";
                }
                break;
            case 4:
                if (level1C)
                {
                    PopUpButton();
                }
                else
                {
                    tm.gameObject.SetActive(true);
                    tm.text = "Level locked";
                }
                break;
            case 5:
                if (level2C)
                {
                    PopUpButton();
                }
                else
                {
                    tm.gameObject.SetActive(true);
                    tm.text = "Level locked";
                }
                break;
            case 6:
                if (level3C)
                {
                    PopUpButton();
                }
                else
                {
                    tm.gameObject.SetActive(true);
                    tm.text = "Level locked";
                }
                break;
            case 7:
                if (level4C)
                {
                    PopUpButton();
                }
                else
                {
                    tm.gameObject.SetActive(true);
                    tm.text = "Level locked";
                }
                break;
            default:
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tm.gameObject.SetActive(false);
    }

}
