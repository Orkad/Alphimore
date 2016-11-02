using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class InventoryManager : MonoBehaviour {
	[Header("Data Definition")]
	public List<ItemInventory> inventory;
	public int inventorySize = 20;

	[Header("Assets References")]
	public ItemAsset itemDatabase;
	public InventorySlot slotPrefab;

	[Header("Scene References")]
	public GridLayoutGroup container;
	public InventoryItemTooltip tooltip;

	private List<InventorySlot> slots = new List<InventorySlot> ();


	void Start(){
		for (int i = 0; i < inventorySize; i++) {
			InventorySlot slot = GameObject.Instantiate(slotPrefab);
			slot.transform.SetParent (container.transform);
			slot.index = i;
			slots.Add(slot);
		}

		foreach (ItemInventory i in inventory) {
			Item item = itemDatabase.itemList[i.item - 1];
			if (i.inventory_position < slots.Count && slots [i.inventory_position].getItem () == null)
				slots [i.inventory_position].SetItem (item);
			else
				GetEmptySlot ().SetItem (item);
		}
	}

	static ItemInventoryCollection LoadItemInventoryCollectionFromJson(string json){
		return JsonUtility.FromJson <ItemInventoryCollection> (json);
	}

	InventorySlot GetEmptySlot(){
		foreach (InventorySlot slot in slots)
			if (slot.getItem() == null)
				return slot;
		return null;
	}
}


[Serializable]
public class ItemInventoryCollection{
	public ItemInventory[] items;
}