using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public Item item;

    void Start()
    {
        Slot.instanceslot.Additem(item);
    }
}
