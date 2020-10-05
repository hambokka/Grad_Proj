using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialSpeed = 1f;
    public float maxSpeed= 2f;
    public float JumpForce = 2;
    Rigidbody2D rigid; 

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(initialSpeed, 0, 0) * Time.deltaTime * initialSpeed;

        if(Input.GetButtonDown("Jump")&& Mathf.Abs(rigid.velocity.y)< 0.001f)
        {
            rigid.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        if (rigid.velocity.x < -1*maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
    }
}
