using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class layeredTrigger : MonoBehaviour
{

    
    bool isOutside = true;
    public GameObject player;
    public GameObject insideTerrain;
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update() {
        
        //if (Input.GetButtonDown("Fire2"))
        if (Input.GetKeyDown(KeyCode.K))
        {
            isOutside = !isOutside; //toggle
            Debug.Log(isOutside);
        }
        
        if(isOutside == true)
        {
            //collision off
           
            
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), insideTerrain.GetComponent<Collider2D>(),true);

        }
        else
        {
            //collision on
      
            
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), insideTerrain.GetComponent<Collider2D>(), false);
        
        }
    }
}
