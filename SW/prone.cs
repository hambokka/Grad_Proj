using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prone : MonoBehaviour
{
    public Sprite[] stand;
    public Sprite[] pronesprite;
    public Sprite[] crouch;
    private BoxCollider2D boxCollider;
    private SpriteRenderer renderer;


    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            boxCollider.size = new Vector2(0.836f, 0.3f);
            boxCollider.offset = new Vector2(0f, 0f);
            renderer.sprite = pronesprite[0];
        }

        else if(Input.GetKey(KeyCode.C))
        {
            boxCollider.size = new Vector2(0.3f, 0.6f);
            renderer.sprite = crouch[0];
        }

        else
        {
            boxCollider.size = new Vector2(0.3f, 0.836f);
            boxCollider.offset = new Vector2(0.05f, 0.02f);
            renderer.sprite = stand[0];
        }
    }
}
