using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
     // 控制角色移动的速度
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float jumpForce = 6f;
    public int jumpCount = 2; // 二段跳次数
    public LayerMask groundLayer; // 地面图层
    private bool isGrounded = true; // 是否在地面

    // Update是每帧调用一次
    void Update()
    {
        // 获取水平和垂直方向的输入
        float horizontal = Input.GetAxis("Horizontal"); // A/D 或 左/右箭头
        float vertical = Input.GetAxis("Vertical");     // W/S 或 上/下箭头

        // 根据输入计算移动向量
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        // 移动角色
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);  
        
        if (Input.GetButtonDown("Jump") && isGrounded && jumpCount > 0)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce));
            jumpCount--;
        }
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.1f), 0.1f, groundLayer);
    }
}
