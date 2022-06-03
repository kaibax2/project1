using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public GameObject ChaseObj;
    private EnemyNav enemynav;

    // Start is called before the first frame update
    void Start()
    {
        //enemynav = transform.root.Find("Enemy").GetComponent<EnemyNav>();
        enemynav = transform.parent.GetComponent<EnemyNav>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        //transform.parent.GetComponent<SphereCollider>().enabled = false;
        ChaseObj.GetComponent<SphereCollider>().enabled = false;
        //EnemyNav.status = 3;
        enemynav.status = 3;
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("追跡開始");
        //transform.parent.GetComponent<SphereCollider>().enabled = true;
        ChaseObj.GetComponent<SphereCollider>().enabled = true;
        //EnemyNav.status = 2;
        enemynav.status = 2;
    }
}
