using UnityEngine;
using UnityEngine.UI;

public class InventrySlotUi : MonoBehaviour
{
    public Text itemNameText;
    public Image iconImage;

    public void DisplayItem(InventryItem item)
    {
        if (item != null)
        {
            itemNameText.text = item.itemName;
            iconImage.sprite = item.icon;
        }
        else
        {
            itemNameText.text = "";
            iconImage.sprite = null;
        }
    }
}
