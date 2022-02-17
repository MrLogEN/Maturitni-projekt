using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsButtons : MonoBehaviour
{
    private SaveObject so;
    public Skillpoints sp;
    public void DoubleJumpClick()
    {
        so = SaveLoad.Load();
        so.hasDoubleJump = true;
        so.skillPoints -= sp.doublePrice;
        SaveLoad.Save(so);
    }
    public void SwiftnessClick()
    {
        so = SaveLoad.Load();
        so.hasSwiftness = true;
        so.skillPoints -= sp.speedPrice;
        SaveLoad.Save(so);
    }
    public void DamageClick()
    {
        so = SaveLoad.Load();
        so.hasDamage = true;
        so.skillPoints -= sp.damagePrice;
        SaveLoad.Save(so);
    }
}
