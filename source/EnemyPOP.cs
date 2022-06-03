using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPOP : MonoBehaviour
{
    //出現させる敵の格納場所
    [SerializeField] GameObject[] enemys;
    //敵のリポップ時間
    [SerializeField] float RepopTime;
    //敵のPOP上限
    [SerializeField] int maxEnemys;
    //POP範囲
    [SerializeField] int POPRange;
    //現在何体の敵を出現させたか
    public int numberOfEnemys;
    //待ち時間計測
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(elapsedTime);
        //出現する最大数を超えたら何もしない
        if (numberOfEnemys >= maxEnemys)
        {
            return;
        }
        //経過時間を足す
        elapsedTime += Time.deltaTime;

        //経過時間が経ったら
        if (elapsedTime > RepopTime)
        {
            elapsedTime = 0f;
            RepopEnemys();
        }

        
    }

    void RepopEnemys()
    {
        Debug.Log("エネミーリポップ");
        //出現させる敵をランダムに選択
        var randomValue = Random.Range(0, enemys.Length);
        //敵の向きをランダムに決定
        var randomRotationY = Random.value * 360f;

        Vector3 v1 = transform.position;
        Vector3 v2 = Random.insideUnitSphere * POPRange;
        Vector3 v3 = new Vector3(v1.x + v2.x, v1.y, v1.z + v2.z);

        //GameObject obj = GameObject.Instantiate(enemys[randomValue], transform.position, Quaternion.Euler(0f, randomRotationY, 0f));
        GameObject obj = GameObject.Instantiate(enemys[randomValue], v3, Quaternion.Euler(0f, randomRotationY, 0f));

        obj.transform.parent = transform;

        numberOfEnemys++;
        elapsedTime = 0f;
    }
}
