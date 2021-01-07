using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public GameObject[] prefabs;
    public List<Item> items = new List<Item>();
    void Start()
    {
        for (int i = 0; i < prefabs.Length; i++)
            items.Add(prefabs[i].GetComponent<Loot>().item);
    }
}
