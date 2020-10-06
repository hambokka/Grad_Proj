using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public GameObject bulletObjA;
	public Transform pos;
	public float cooltime;
    private float curtime;
	
	//private float thrust = 10.0f;
	
    // Update is called once per frame
    void Update()
    {
		Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0,0,z);
		
		if(Input.GetKey(KeyCode.Z)){
			Fire();
		}
    }
	
	void Fire(){
		Instantiate(bulletObjA, transform.position, transform.rotation);
		//GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
		//Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
		//rigid.AddForce(transform.right * 10, ForceMode2D.Impulse);
	}
}
