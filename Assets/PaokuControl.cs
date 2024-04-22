using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PaokuControl : MonoBehaviour
{
    public bool stopMoverment = false;

    public bool moving { get; set; }

    private Rigidbody m_Rigidbody;

    [HideInInspector]
    public Animator m_Animator;

    //初始速度
    public float initialSpeed = 5f;  // 初始速度
    public float speedIncrement = 0.05f;  // 速度增量
    private float currentSpeed;  // 当前速度

    //跳跃设置
    public float jumpSpeed = 5f;
    public float fallSpeed = 5f;
    public float jumpHeight = 2f;
    public float jumpTarget;
    public bool IsJump = false;
    public AudioSource JumpSound; //跳跃声
    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("Move", true);
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //初始化
        float x = Input.GetAxis("Horizontal");
        transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        if(currentSpeed < 20f)
        {
            currentSpeed += speedIncrement * Time.deltaTime;
        }
        if (x != 0)
        {
            //左右移动
            if (x < 0)
            {
                if (transform.position.x == 0f)
                {
                    transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x == 2.5f)
                {
                    transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                }
            }
            else if (x > 0)
            {
                if (transform.position.x == 0f)
                {
                    transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x == -2.5f)
                {
                    transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                }
            }
            Input.ResetInputAxes();
        }


        //跳跃
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y <= 0.1f)
            {
                IsJump = true;
                jumpTarget = jumpHeight;
                JumpSound.Play();
            }
            Input.ResetInputAxes();
        }

        if (IsJump == true)
        {
            if (jumpTarget != 0f)
            {
                transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
                if (transform.position.y >= jumpTarget)
                {
                    jumpTarget = 0f;
                }
            }
            else if (transform.position.y > 0f)
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
                if (transform.position.y < 0.1f)
                {
                    Vector3 newPos = transform.position;
                    newPos.y = 0f;
                    transform.position = newPos;
                    IsJump = false;
                }
            }
        }

    }

}
