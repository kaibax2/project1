using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    //プレイヤーの体力
    public float PHP;
    private float maxHP;
    public GameObject HPtext;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        PHP = 100f;
        maxHP = PHP;
        text = HPtext.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PHP + "/" + maxHP;
        if (PHP <= 0)
        {
            Debug.Log("がめおべら");    
        }
    }
}
