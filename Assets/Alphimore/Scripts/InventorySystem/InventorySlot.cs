using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour {
	public InventoryItem inventoryItem;

	public void ReceiveInventoryItem(InventoryItem item){
		item.transform.SetParent (transform);
		item.transform.localPosition = new Vector3 (0, 0);
		inventoryItem = item;
		item.slot = this;
	}

	public void SwapWith(InventorySlot slot){
		InventoryItem swapped = slot.inventoryItem;
		if (inventoryItem != null)
			slot.ReceiveInventoryItem (inventoryItem);
		else
			slot.inventoryItem = null;
		ReceiveInventoryItem (swapped);
	}
}
