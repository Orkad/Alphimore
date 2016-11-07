using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;

public class InventoryManager : MonoBehaviour {
	[Header("Data Definition")]
	public List<ItemInventory> inventory;
	public int inventorySize = 20;

	[Header("Assets References")]
	public ItemAsset itemDatabase;
	public InventoryItemSlot ItemSlotPrefab;

	[Header("Scene References")]
	public GridLayoutGroup container;
	public InventoryItemTooltip tooltip;

	private readonly List<InventoryItemSlot> slots = new List<InventoryItemSlot> ();


	void Start(){
		for (int i = 0; i < inventorySize; i++) {
			InventoryItemSlot itemSlot = GameObject.Instantiate(ItemSlotPrefab);
			itemSlot.transform.SetParent (container.transform);
			slots.Add(itemSlot);
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

	InventoryItemSlot GetEmptySlot()
	{
	    return slots.FirstOrDefault(slot => slot.getItem() == null);
	}
}


[Serializable]
public class ItemInventoryCollection{
	public ItemInventory[] items;
}