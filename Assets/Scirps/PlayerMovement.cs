using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;
    public Animator anim;

    private float hInput;
    private float vInput;
    private bool IsGrounded;

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        UpdateMovement();
        UpdateFacing();
        UpdateJumping();
    }

    private void UpdateMovement()
    {
        rigid.velocity = new Vector2(hInput * speed, rigid.velocity.y);
        anim.SetBool("IsRunning", hInput !=0);
    }

    private void UpdateJumping()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, speed);
            IsGrounded = false;
        }
        anim.SetBool("IsGrounded", IsGrounded);
    }

    public void UpdateFacing()
    {
        if(hInput != 0)
        {
            spriteRenderer.flipX = hInput < 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if(colision.collider.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
}
