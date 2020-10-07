using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float moveSpeed;
    public float jumpPower;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void Update()
    {
        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        // Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            print("stop speed");
        }

        // Direction Sprite
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        // Moving both side <-, ->
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f));
        }

    }
    void FixedUpdate()
    {   /*
        // Move Speed
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // Max Speed
        if (rigid.velocity.x > maxSpeed)    // Right Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            print("right max speed");
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {    // Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            print("left max speed");
        }*/
    }
}
