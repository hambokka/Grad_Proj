using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float moveSpeed;
    public float jumpPower;
    public bool isStand = true;
    public bool isProne = false;
    public bool isCrouch = false;

    private bool isGrounded = true;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    public Sprite[] stand;
    public Sprite[] pronesprite;
    public Sprite[] crouch;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "ground")
        {
            print("1");
            isGrounded = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigid.velocity.y) < 0.01f)
        {
            if(isStand == true)
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

        // Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // Direction Sprite
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        // Moving both side <-, ->
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            if (isStand)
            {
                transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f));
            }
            else if (isCrouch)
            {
                transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * 0.5f * Time.deltaTime, 0f));
            }
            else if (isProne)
            {
                transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * 0.2f * Time.deltaTime, 0f));
            }
        }

        // seat, prone
        if (Input.GetKey(KeyCode.Z))
        {
            boxCollider.size = new Vector2(0.836f, 0.3f);
            boxCollider.offset = new Vector2(0f, 0f);
            spriteRenderer.sprite = pronesprite[0];
            isProne = true; isStand = false; isCrouch = false;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            boxCollider.size = new Vector2(0.3f, 0.6f);
            spriteRenderer.sprite = crouch[0];
            isProne = false; isStand = false; isCrouch = true;
        }
        else
        {
            boxCollider.size = new Vector2(0.3f, 0.836f);
            boxCollider.offset = new Vector2(0.05f, 0.02f);
            spriteRenderer.sprite = stand[0];
            isProne = false; isStand = true; isCrouch = false;
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
