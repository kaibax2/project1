using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    //徘徊時の初期位置基準
    //public Transform central;
    private GameObject central;
    //プレイヤー追跡時目的地
    private GameObject goal_player;
    //アクティブ変更用あたり判定
    public GameObject ChaseObj;
    //NavMeshコンポーネント取得用
    public NavMeshAgent agent;
    //スピード保存
    private float OldSpeed;

    //ランダムで決める数値の最大値
    [SerializeField] float radius = 3;
    [SerializeField] float randomMove = 10;
    //設定した待機時間
    [SerializeField] float waitTime = 2;
    //待機時間を数える
    [SerializeField] float time = 5;
    //敵がうろちょろする際の切り替えし時間
    [SerializeField] float switchTime = 5;

    //ステータス 1:ノンアクティブ　2:アクティブ 3:攻撃
    //[SerializeField] int status = 1;
    public int status = 1;



    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        //central = GameObject.Find("CentralPos");
        central = transform.root.gameObject;
        goal_player = GameObject.Find("Player");

        agent.autoBraking = false;
        OldSpeed = agent.speed;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        agent.isStopped = false;

        float posX = Random.Range(-1 * radius, radius);
        float posZ = Random.Range(-1 * radius, radius);

        Vector3 pos = central.transform.position;
        pos.x += posX;
        pos.z += posZ;

        //目的地設定
        agent.destination = pos;
    }

    void StopHere()
    {
        agent.isStopped = true;

        //待ち時間を数える
        time += Time.deltaTime;
        //待ち時間が初期値を超えたら次の目的地を設定
        if(time > waitTime)
        {
            GotoNextPoint();
            time = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (status) {
            case 1://徘徊
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    StopHere();
                break;
            case 2://プレイヤー発見時追跡
                    agent.destination = goal_player.transform.position;
                break;
            case 3://プレイヤーへ攻撃
                //agent.isStopped = true;
                agent.isStopped = false;


                Vector3 diff = -1 * (transform.position - goal_player.transform.position);
                //敵の向きをプレイヤー側へ固定
                transform.rotation = Quaternion.LookRotation(diff);

                //敵がうろちょろするために向きを切り返すタイミングを設定
                time += Time.deltaTime;

                if (time >= switchTime)
                {

                    Vector3 pos = goal_player.transform.position;
                    float posX = Random.Range(-1 * randomMove, randomMove);
                    float posZ = Random.Range(-1 * randomMove, randomMove);
                    pos.x += posX;
                    pos.z += posZ;

                    agent.destination = pos;
                    time = 0;
                }
                break;
        }
        
    }
}
