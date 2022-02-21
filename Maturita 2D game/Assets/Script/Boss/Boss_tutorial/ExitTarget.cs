using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class ExitTarget : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text text;
    private PlayerActions pa;
    void Start()
    {
        pa = FindObjectOfType<PlayerActions>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hiiit neeee");
        if (collision.gameObject.tag == "PlayerAttack")
        {
            if (GameManagerTutorial.instance.GetState == GameManagerTutorial.TutorialState.End)
            {
                SaveObject so = SaveLoad.Load();
                so.tutorialCompleted = true;
                SaveLoad.Save(so);
                LoadingManager.instance.LoadScene("level_select");
            }


            if (GameManagerTutorial.instance.GetState == GameManagerTutorial.TutorialState.Special)
            {
                BulletScript ba;
                SpecialBullet sb;
                if (collision.gameObject.TryGetComponent<BulletScript>(out ba))
                {
                    print("normalis");
                    pa.specialLoad++;
                }
                if (collision.gameObject.TryGetComponent<SpecialBullet>(out sb))
                {
                    print("specialis");
                    GameManagerTutorial.instance.ChangeState(GameManagerTutorial.TutorialState.End);
                }
            }
            //OnExitTargetFinished?.Invoke(instance, EventArgs.Empty);

        }
    }
    private void Update()
    {
        if (GameManagerTutorial.instance.GetState == GameManagerTutorial.TutorialState.Special)
        {
            switch (LocalizationSettings.SelectedLocale.Identifier.Code)
            {
                case "en":
                    text.text = "Shoot the target";
                    break;
                case "cs":
                    text.text = "Střílej do cíle";
                    break;
                case "ru":
                    text.text = "Стрелай по цели";
                    break;
                default:
                    break;
            }

        }
        if (GameManagerTutorial.instance.GetState == GameManagerTutorial.TutorialState.End)
        {
            switch (LocalizationSettings.SelectedLocale.Identifier.Code)
            {
                case "en":
                    text.text = "Shoot the target to exit";
                    break;
                case "cs":
                    text.text = "Střílej na cíl a opusť tutoriál";
                    break;
                case "ru":
                    text.text = "Стрелай по цели для выхода из обучения";
                    break;
                default:
                    break;
            }
        }
    }
}
