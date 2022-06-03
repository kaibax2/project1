using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Rayの飛ばせる距離(射程)
    [SerializeField] int distance = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        Debug.DrawRay(transform.position, ray.direction * distance, Color.red);

        //左クリックを受け付ける
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pressed primary button.");
            //Ray ray = new Ray(transform.position, transform.forward);

            //RaycastHit hit;

            //Debug.DrawRay(transform.position, ray.direction * distance, Color.red);

            if (Physics.Raycast(ray, out hit, distance))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("敵を撃った");
                    Destroy(hit.collider.gameObject);
                    //Rayが当たった敵のPOPエリアから敵の現在の出現数を１減らす
                    hit.collider.transform.root.GetComponent<EnemyPOP>().numberOfEnemys -= 1;
                    //EnemyNav.status = 2;
                    //enemynav.status = 2;
                }
            }

            //    RaycastHit[] hits = Physics.RaycastAll(ray, distance);
            //    foreach (var obj in hits)
            //    {
            //        //Debug.Log(obj.collider.tag);
            //        Debug.Log(obj.collider.name);
            //        switch (obj.collider.tag)
            //        {
            //            case "Enemy":
            //                Debug.Log("敵を撃った");
            //                Destroy(obj.collider.gameObject);
            //                goto END;
            //                break;

            //            case "Object":
            //                goto END;
            //                break;

            //            default:
            //                break;
            //        }
            //    }
            //END:;

        }

    }
}
