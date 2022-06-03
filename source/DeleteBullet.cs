using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    //プレイヤーの攻撃力
    private float P_AttackDmg;
    //敵の攻撃力
    private float E_AttackDmg;

    public GameObject damageController;

    // Start is called before the first frame update
    void Start()
    {
        P_AttackDmg = damageController.GetComponent<DamageController>().PlayerAttackDamage;
        E_AttackDmg = damageController.GetComponent<DamageController>().EnemyAttackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    //Debug.Log("Hit"); // ログを表示する
    //    switch (other.gameObject.tag)
    //    {
    //        case "Enemy":
    //            Debug.Log("敵に当たった");
    //            Destroy(this.gameObject);
    //            break;
    //        case "Object":
    //            Debug.Log("地面に当たった");
    //            Destroy(this.gameObject);
    //            break;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        // 物体がトリガーに接触しとき、１度だけ呼ばれる

        switch (other.gameObject.tag)
        {
            case "Enemy":
                //Debug.Log(other.gameObject.name + "：HIT");
                other.GetComponent<Collider>().transform.root.GetComponent<EnemyPOP>().numberOfEnemys -= 1;
                other.GetComponent<EnemyHP>().EHP -= P_AttackDmg;
                other.GetComponent<TakeDamage>().Damage(other);
                Destroy(this.gameObject);
                break;
            case "Object":
                //Debug.Log("地面に当たった");
                Destroy(this.gameObject);
                break;
            case "Player":
                Debug.Log("被弾しました");
                other.GetComponent<PlayerHP>().PHP -= E_AttackDmg;
                Destroy(this.gameObject);
                break;
        }
    }
}
