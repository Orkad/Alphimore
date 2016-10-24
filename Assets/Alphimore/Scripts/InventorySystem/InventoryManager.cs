using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	public GridLayoutGroup container;
	public Character character;
	public InventorySlot slotPrefab;
	public InventoryItem itemPrefab;
	public List<InventorySlot> slots;

	void Start(){
		for (int i = 0; i < character.inventorySize; i++) {
			InventorySlot slot = GameObject.Instantiate(slotPrefab);
			slot.transform.SetParent (container.transform);
			slot.index = i;
			slots.Add(slot);
			if (i < character.items.Count) {
				InventoryItem inventoryItem = GameObject.Instantiate (itemPrefab);
				inventoryItem.item = character.items [i];
				slot.ReceiveInventoryItem (inventoryItem);
			}
		}
	}
}
