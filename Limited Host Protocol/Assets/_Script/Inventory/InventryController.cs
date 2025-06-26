using System.Collections.Generic;
using UnityEngine;

public class InventryController : MonoBehaviour
{
    public List<InventryItem> items;
    public List<InventrySlotUi> slots;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].DisplayItem(items[i]);
        }
    }
}
