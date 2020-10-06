using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	public bool isTouchTop;
	public bool isTouchBottom;
	public bool isTouchRight;
	public bool isTouchLeft;
	
	public GameObject bulletObjA;
	public GameObject bulletObjB;
	
	public Transform pos;
	
	Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//transform.Rotate(0, 0, 360 * Time.deltaTime);
    }
	
}
