using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseRange : MonoBehaviour
{
    private GameObject player;
    private EnemyNav enemynav;
    [SerializeField] int distance = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        enemynav = transform.parent.GetComponent<EnemyNav>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 PlayerPos = (player.transform.position - transform.position).normalized;

        Ray ray = new Ray(transform.position, PlayerPos);

        RaycastHit hit;

        //Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);
        Debug.DrawRay(transform.position, ray.direction * distance, Color.red);

        if (Physics.Raycast(ray, out hit, distance))
        {
            //Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Player")
            {
                //Debug.Log("感知範囲に入ってる");
                //EnemyNav.status = 2;
                enemynav.status = 2;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("逃げられた！");
        //EnemyNav.status = 1;
        enemynav.status = 1;
    }

}
