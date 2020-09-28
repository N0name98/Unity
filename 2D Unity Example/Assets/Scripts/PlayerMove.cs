using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 4.5f;
    public float jumoPower = 20;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animate;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animate = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !animate.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumoPower, ForceMode2D.Impulse);
            animate.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Mathf.Abs(rigid.velocity.x) < 0.1)
        {
            animate.SetBool("isWalking", false);
        }
        else
        {
            animate.SetBool("isWalking", true);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        //Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rigid.velocity.y < 0)
        {
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    animate.SetBool("isJumping", false);
            }
        }

    }
}
