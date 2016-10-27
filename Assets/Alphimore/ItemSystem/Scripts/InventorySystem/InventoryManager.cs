using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class InventoryManager : MonoBehaviour {
	public GridLayoutGroup container;
	public Character character;
	public InventorySlot slotPrefab;
	public InventoryItemTooltip tooltip;
	public List<InventorySlot> slots;
	public ItemAsset itemAsset;
	[TextArea]
	public string json;

	void Start(){
		for (int i = 0; i < character.inventorySize; i++) {
			InventorySlot slot = GameObject.Instantiate(slotPrefab);
			slot.transform.SetParent (container.transform);
			slot.index = i;
			slots.Add(slot);
		}
		ItemInventoryCollection lst = JsonUtility.FromJson <ItemInventoryCollection> (json);
		foreach (ItemInventory i in lst.items) {
			Item item = itemAsset.itemList[i.item + 1];
			if (i.inventory_position < slots.Count && slots [i.inventory_position].getItem () == null)
				slots [i.inventory_position].SetItem (item);
			else
				GetEmptySlot ().SetItem (item);
		}
		/*
		foreach (Item item in character.items) {
			if (item.inventoryOrder < slots.Count && slots [item.inventoryOrder].getItem() == null)
				slots [item.inventoryOrder].SetItem (item);
			else
				GetEmptySlot ().SetItem(item);
		}*/
	}

	InventorySlot GetEmptySlot(){
		foreach (InventorySlot slot in slots)
			if (slot.getItem() == null)
				return slot;
		return null;
	}
}

[Serializable]
public class ItemInventory{
	public int item;
	public int inventory_position;
	public int amount;
}

[Serializable]
public class ItemInventoryCollection{
	public ItemInventory[] items;
}