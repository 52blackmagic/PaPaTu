using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal.XR.WSA;

public class MouseMovement : MonoBehaviour
{
   public float moveSpeed;
   public float jumpForce;
   private float moveInput;

   private Rigidbody2D rb;

   private bool facingRight = true;

   private bool isGrounded;
   public Transform groundCheck;
   public float checkRadius;
   public LayerMask whatIsGround;


   void Start()
   {
      rb=GetComponent<Rigidbody2D>();
   }

   void Update()
   {
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
      
      moveInput = Input.GetAxis("Horizontal");
      rb.velocity = new Vector2(moveInput * moveSpeed , rb.velocity.y);

      if(facingRight == false && moveInput > 0)
      {
        Flip();
      }
      else if(facingRight == true && moveInput < 0)
      {
        Flip();
      }

      if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
      {
         rb.velocity = Vector2.up*jumpForce;
      }
   }

   void Flip()
   {
      facingRight = !facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x*=-1;
      transform.localScale = Scaler;
   }
}
