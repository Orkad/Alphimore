using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	public GridLayoutGroup container;
	public Character character;
	public InventorySlot slotPrefab;
	public List<InventorySlot> slots;

	void Start(){
		for (int i = 0; i < character.inventorySize; i++) {
			InventorySlot slot = GameObject.Instantiate(slotPrefab);
			slot.transform.SetParent (container.transform);
			slots.Add(slot);
			if(i < character.items.Count)
				slot.item = character.items [i];
		}
	}
}
