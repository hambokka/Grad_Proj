using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instanceinventory;

    private void Awake()
    {
        if (instanceinventory != null)
        {
            Debug.LogWarning("More than one player inventory");
            return;
        }
        instanceinventory = this;
    }

    public int numberSlots;
}