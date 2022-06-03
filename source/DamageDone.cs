using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDone : MonoBehaviour
{
    private Text damageText;
    //フェードアウトするスピード
    private float fadeOutSpeed = 1f;
    [SerializeField]
    private float moveSpeed = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        damageText = GetComponent<Text>();   
    }

    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        damageText.color = Color.Lerp(damageText.color, new Color(1f, 0f, 0f, 0f), fadeOutSpeed * Time.deltaTime);

        if (damageText.color.a <= 0.1f)
        {
            Destroy(this.gameObject);
        }
    }
}
