using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {
	public ItemAsset itemAsset;
	public static Character me;
	public string characterName;
	public List<Item> items;
	public int inventorySize = 10;
	public Item headItem;
	public Item weaponItem;
	public Item corpseItem;
	public Item feetItem;
	public Item legItem;
	public Item specialItem;

	void Awake(){
		me = this;
		items = itemAsset.itemList;
	}
}
