using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //移動スピード
    public float speed = 3.0f;
    //ダッシュ時の移動倍率
    public float dash = 1.5f;
    //重力値
    public float gravity = 9.81f;
    //ジャンプ時の高さ
    public float jump = 6;
    
    private Vector3 moveDirection = Vector3.zero;

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            //ダッシュ
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= speed * dash;
            }
            else
            {
                moveDirection *= speed;
            }

            //ジャンプ
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jump;
            }
        }
        //常に重力値分をY方向へ
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
