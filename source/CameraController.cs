using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform verRot;
    public Transform horRot;

    private Vector3 newAngle = new Vector3(0, 0, 0);

    //回転速度
    public float rotationspeed = 1.0f;

    //X軸回転角度の最大角(縦回転)
    public float max_rotation = 40;

    //カメラの初期値
    private Vector3 mXAxiz;

    // Start is called before the first frame update
    void Start()
    {
        verRot = transform.parent;
        horRot = GetComponent<Transform>();
        mXAxiz = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        float Rotation_X = Input.GetAxis("Mouse X");
        float Rotation_Y = Input.GetAxis("Mouse Y");

        verRot.transform.Rotate(0, Rotation_X * rotationspeed, 0);

        var x = mXAxiz.x - Rotation_Y * rotationspeed;
        if(x >= -max_rotation && x <= max_rotation)
        {
            mXAxiz.x = x;
            transform.localEulerAngles = mXAxiz;
        }

    }
}
