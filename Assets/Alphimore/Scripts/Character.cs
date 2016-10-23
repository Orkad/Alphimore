using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {
	public static Character me;
	public string characterName;
	public List<Item> items;
	public int inventorySize = 10;

	void Start(){
		me = this;
	}
}
