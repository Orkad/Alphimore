using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	public GridLayoutGroup container;
	public Character character;
	public InventorySlot slotPrefab;
	public InventoryItem itemPrefab;
	public InventoryItemTooltip tooltip;
	public List<InventorySlot> slots;

	void Start(){
		for (int i = 0; i < character.inventorySize; i++) {
			InventorySlot slot = GameObject.Instantiate(slotPrefab);
			slot.transform.SetParent (container.transform);
			slot.index = i;
			slots.Add(slot);
		}
		foreach (Item item in character.items) {
			if (item.inventoryOrder < slots.Count && slots [item.inventoryOrder].inventoryItem == null)
				CreateInventoryItemForSlot (slots [item.inventoryOrder], item);
			else
				CreateInventoryItemForSlot (GetEmptySlot (), item);
		}
	}

	InventorySlot GetEmptySlot(){
		foreach (InventorySlot slot in slots)
			if (slot.inventoryItem == null)
				return slot;
		return null;
	}

	void CreateInventoryItemForSlot(InventorySlot slot, Item item){
		InventoryItem inventoryItem = GameObject.Instantiate (itemPrefab);
		inventoryItem.item = item;
		slot.ReceiveInventoryItem (inventoryItem);
	}
}
