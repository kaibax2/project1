using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // bullet prefab
    [SerializeField] GameObject bullet;

    // 弾丸発射点
    [SerializeField] Transform muzzle;

    // 弾丸の速度
    [SerializeField] float speed = 1000;

    //リキャストタイム
    [SerializeField] float ReCast = 2f;

    private float bulletelapsedTime;

    private EnemyNav enemynav;

    // Start is called before the first frame update
    void Start()
    {
        enemynav = transform.parent.GetComponent<EnemyNav>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemynav.status == 3)
        {
            //Debug.Log(bulletelapsedTime);
            if (bulletelapsedTime <= ReCast)
            {
                bulletelapsedTime += Time.deltaTime;
            }

            //攻撃しようとしたときCTが上がっているか
            if (ReCast <= bulletelapsedTime)
            {

                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force;

                force = this.gameObject.transform.forward * speed;

                // Rigidbodyに力を加えて発射
                bullets.GetComponent<Rigidbody>().AddForce(force);


                // 弾丸の位置を調整
                bullets.transform.position = muzzle.position;

                //リキャスト初期化
                bulletelapsedTime = 0f;
            }
        }
    }
}
