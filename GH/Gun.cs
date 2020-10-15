using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public bool isPlayerEnter;
	public bool isEquip = false;
	
	GameObject player;
	GameObject playerEquipPoint;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Person");
		playerEquipPoint = GameObject.FindGameObjectWithTag("EquipPoint");
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKey(KeyCode.G)){
			if(isEquip){
				playerEquipPoint.transform.DetachChildren();
				//print("hello");
				isEquip = false;
			}
			else if(isPlayerEnter){
				transform.SetParent(playerEquipPoint.transform);
				transform.localPosition = Vector2.zero;
				//transform.rotation = new Quaternion(0,0,0);
				
				isPlayerEnter = false;
				isEquip = true;
			}
		}
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == player){
			isPlayerEnter = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == player){
			isPlayerEnter = false;
		}
	}
}
