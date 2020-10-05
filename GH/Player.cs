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
		if(Input.GetKey(KeyCode.Z)){
			Fire();
		}
        //
		
    }
	
	void Fire(){
		GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
		Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
		rigid.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
	}
}
