using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    Player_state playerstate;

    void Start()
    {
        playerstate = gameObject.GetComponent<Player_state>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float moveSpeed = 10f;
        if(Input.GetButton("Horizontal"))
        {
            Vector3 movedir = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
            transform.position += movedir * moveSpeed * Time.deltaTime;
        }
    }
}
