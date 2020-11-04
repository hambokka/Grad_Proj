using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class layeredTrigger : MonoBehaviour
{

    
    bool isOutside = true;
    public GameObject player;
    public GameObject terrain;
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update() {
        
        //if (Input.GetButtonDown("Fire2"))
        if (Input.GetKey(KeyCode.K))
        {
            isOutside = !isOutside; //toggle
            Debug.Log(isOutside);
        }
        
        if(isOutside == true)
        {
            //collision off
            //GetComponent<TilemapCollider2D>().enabled = false;
            
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), terrain.GetComponent<Collider2D>(),true);
        }
        else
        {
            //collision on
            //GetComponent<TilemapCollider2D>().enabled = true;
            
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), terrain.GetComponent<Collider2D>(), false);
        }
    }
}