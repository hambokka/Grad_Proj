using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1;
    public float maxSpeed= 2;
    public float JumpForce = 1;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    
     public void Update()
     {
        //stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //directional animation
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //walking animation transition
        if (Mathf.Abs(rigid.velocity.x) <= 0.05)
            animator.SetBool("isWalking", false);
        else
            animator.SetBool("isWalking", true);

        //jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigid.velocity.y) < 0.01f)
        {
            rigid.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        if (rigid.velocity.x < -1 * maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);

        //movement
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
    }
        

    public void FixedUpdate()
    {
        //horizontal movement
        //float h = Input.GetAxisRaw("Horizontal");

        //transform.position += new Vector3(h, 0, 0) * Time.deltaTime * initialSpeed;
        //rigid.AddForce(Vector2.right * h * Time.deltaTime, ForceMode2D.Impulse);

    }
}
