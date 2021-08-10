using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxPlayer : MonoBehaviour
{
    #region 欄位

    [Header("移動速度"), Range(0, 50)]
    public float speed = 10.5f;
    [Header("重力"), Range(0, 10)]
    public float gravity = 0.5f;
    /// <summary>
    /// 使用 Input.GetAxisRaw API 偵測玩家左右按鍵
    /// </summary>
    //public float Horizontal;

    /// <summary>
    /// 使用 SpriteRenderer.flipX API 讓狐狸可以翻面
    /// </summary>
    public bool flipX;

    #endregion


    public Rigidbody2D Rig;
    public SpriteRenderer Sr;

    private float Horizontal;
    private float hValue;

    #region 事件

    public void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        /** 第一次嘗試
        //float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        //transform.Rotate(0, speed, 0);
        */

        /** 第二次嘗試
        //float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //float v = verticalSpeed * Input.GetAxis("Mouse Y");
        //transform.Rotate(v, h, 0);
        */

        /** 第三次嘗試
        // float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //float y = Input.GetAxis("Vertical") * Time.deltaTime * speed * gravity;
        //transform.Translate(x, y, 0);
        */

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * speed * gravity;

        transform.Translate(x, y, 0);

        GetPlayerInputHorizontal();
        TurnDirection();
    }

    private void FixedUpdate()
    {
        Move(hValue);

        Rig.AddForce(new Vector2(100f, 0f) * Time.deltaTime);
       
    }

    #endregion

    #region 方法

    private void GetPlayerInputHorizontal()
    {
        hValue = Input.GetAxis("Horizontal");
    }
    private void Move(float horizontal)
    {
        Vector2 posMove = transform.position + new Vector3(horizontal, -gravity, 0) * speed * Time.fixedDeltaTime;
        Rig.MovePosition(posMove);
    }

    private void TurnDirection()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    #endregion

}
