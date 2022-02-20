using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    // Start is called before the first frame update
    public static DamagePopUp Create(Vector3 position, float damage, bool isCritical)
    {
        Transform damagePopupTransform = Instantiate(PlayerActions.instance.damagePopupPref,position,Quaternion.identity);

        DamagePopUp damagePopup = damagePopupTransform.GetComponent<DamagePopUp>();
        damagePopup.Setup(damage,isCritical);
        return damagePopup;
    }
    private TextMeshPro textMesh;
    private float dissapearTimer;
    private Color textColor;
    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(float damage, bool isCritical)
    {
        if (isCritical)
        {
            textMesh.color = Color.red;

        }
        else
        {
            textMesh.color = Color.yellow;
        }

        if (damage == 0)
        {
            textMesh.color = Color.grey;
        }
        textMesh.SetText("-"+damage.ToString());
        textColor = textMesh.color;
        dissapearTimer = .6f;
    }

    // Update is called once per frame
    void Update()
    {
        float upSpeed = 5f;
        transform.position += new Vector3(0, upSpeed) * Time.deltaTime;
        dissapearTimer -= Time.deltaTime;
        if (dissapearTimer <0)
        {
            float dissaperSpeed = 20f;
            textColor.a -= dissaperSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
