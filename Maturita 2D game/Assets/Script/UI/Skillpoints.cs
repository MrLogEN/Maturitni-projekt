using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillpoints : MonoBehaviour
{
    // Start is called before the first frame update
    public Text pointCountText;
    private SaveObject so;
    public Button doubleBut, speedBut, damageBut;
    public Sprite djCan, djCant, djA, swCan, swCant, swA, dmgCan, dmgCant, dmgA;
    private SpriteState ssDouble = new SpriteState();
    private SpriteState ssSwiftness = new SpriteState();
    private SpriteState ssDamage = new SpriteState();
    public int doublePrice = 2;
    public int speedPrice = 2;
    public int damagePrice = 3;
    public Text dmgPriceText, swPriceText, djPriceText;
    void Start()
    {
        so = SaveLoad.Load();
        print(so.skillPoints);
        pointCountText.text = so.skillPoints.ToString() + " P";
    }

    // Update is called once per frame
    void Update()
    {
        dmgPriceText.text = "-" + damagePrice + " P";
        swPriceText.text = "-" + speedPrice + " P";
        djPriceText.text = "-" + doublePrice + " P";
        so = SaveLoad.Load();

        pointCountText.text = so.skillPoints.ToString() + " P";

        if (!so.hasDoubleJump)
        {
            if (so.skillPoints >= doublePrice)
            {
                doubleBut.interactable = true;
                doubleBut.GetComponent<Image>().sprite = djCan;
                djPriceText.gameObject.SetActive(true);
            }
            else
            {
                //doubleBut.GetComponent<Image>().sprite = djCant;
                ssDouble.disabledSprite = djCant;
                doubleBut.spriteState = ssDouble;
                doubleBut.interactable = false;
                djPriceText.gameObject.SetActive(true);

            }
        }
        else
        {
            ssDouble.disabledSprite = djA;
            doubleBut.interactable = false;
            doubleBut.spriteState = ssDouble;
            djPriceText.gameObject.SetActive(false);


        }



        if (!so.hasSwiftness)
        {
            if (so.skillPoints >= speedPrice)
            {
                speedBut.interactable = true;
                speedBut.GetComponent<Image>().sprite = swCan;
                swPriceText.gameObject.SetActive(true);

            }
            else
            {
                //doubleBut.GetComponent<Image>().sprite = djCant;
                ssSwiftness.disabledSprite = swCant;
                speedBut.spriteState = ssSwiftness;
                speedBut.interactable = false;
                swPriceText.gameObject.SetActive(true);

            }
        }
        else
        {
            ssSwiftness.disabledSprite = swA;
            speedBut.spriteState = ssSwiftness;
            speedBut.interactable = false;
            swPriceText.gameObject.SetActive(false);

        }

        if (!so.hasDamage)
        {
            if (so.skillPoints >= damagePrice)
            {
                damageBut.interactable = true;
                damageBut.GetComponent<Image>().sprite = dmgCan;
                dmgPriceText.gameObject.SetActive(true);

            }
            else
            {
                //doubleBut.GetComponent<Image>().sprite = djCant;
                ssDamage.disabledSprite = dmgCant;
                damageBut.spriteState = ssDamage;
                damageBut.interactable = false;
                dmgPriceText.gameObject.SetActive(true);

            }
        }
        else
        {
            ssDamage.disabledSprite = dmgA;
            damageBut.spriteState = ssDamage;
            damageBut.interactable = false;
            dmgPriceText.gameObject.SetActive(false);

        }

    }
}
