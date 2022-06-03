using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //敵の体力
    public float EHP;

    // Start is called before the first frame update
    void Start()
    {
        EHP = 100f;    
    }

    // Update is called once per frame
    void Update()
    {
        if (EHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
