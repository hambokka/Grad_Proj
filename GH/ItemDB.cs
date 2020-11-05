using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
	public static ItemDB instance;
	
    void Awake()
    {
        instance = this;
    }
	
	public List<Item>itemDB = new List<Item>();
	[Space(20)]
	public GameObject fieldItemPrefab;
	public Vector3[] pos;
	
	void Start()
	{
		for(int i=0; i<2; i++){
			GameObject go = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);
			go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0,3)]);
		}
	}
}
