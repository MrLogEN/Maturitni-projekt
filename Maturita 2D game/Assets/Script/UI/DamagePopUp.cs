using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    // Start is called before the first frame update
    public static DamagePopUp Create(Vector3 position, float damage)
    {
        Transform damagePopupTransform = Instantiate(PlayerActions.instance.damagePopupPref,position,Quaternion.identity);

        DamagePopUp damagePopup = damagePopupTransform.GetComponent<DamagePopUp>();
        return damagePopup;
    }
    private TextMeshPro textMesh;
    private float dissapearTimer;
    private Color textColor;
    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(float damage)
    {
        textMesh.color = Color.red;
        textMesh.SetText("100");
        textColor = textMesh.color;
        dissapearTimer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float upSpeed = 10f;
        transform.position += new Vector3(0, upSpeed) * Time.deltaTime;
        dissapearTimer -= Time.deltaTime;
        if (dissapearTimer < 0)
        {
            //float dissaperSpeed = .001f;
            //textColor.a -= dissaperSpeed * Time.deltaTime;
            //textMesh.color = textColor;
            //if (textColor.a < 0)
            //{
            //    //Destroy(gameObject);
            //}
        }
    }
}
