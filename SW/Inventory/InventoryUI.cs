using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory playerinventory;
    [SerializeField]
    GameObject slotprefab;

    // Update is called once per frame
    private void Start()
    {
        playerinventory = Inventory.instanceinventory;

        for (int i = 0; i < playerinventory.numberSlots; i++)
        {
            var itemUI = Instantiate(slotprefab, transform);
        }
    }
}
