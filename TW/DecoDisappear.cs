using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class DecoDisappear : MonoBehaviour
{


    bool isOutside = true;
    public GameObject outsideDeco;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            isOutside = !isOutside; //toggle
            Debug.Log(isOutside);
        }

        if (isOutside == true)
        {
            //collision off

            outsideDeco.GetComponent<TilemapRenderer>().enabled = true;
        }
        else
        {
            //collision on
            
            outsideDeco.GetComponent<TilemapRenderer>().enabled = false;
        }
    }
}