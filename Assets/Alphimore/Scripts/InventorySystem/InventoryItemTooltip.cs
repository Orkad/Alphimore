using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItemTooltip : MonoBehaviour{
	public static InventoryItemTooltip instance;
	public Text itemName;
	public Text itemDescription;

	void Awake(){
		instance = this;
	}

	public void ShowItemTooltip(Item item){
		itemName.text = item.name;
		itemDescription.text = item.description;
		GetComponent<AnnimatedUI_Fader> ().Show ();
	}

	public void HideTooltip(){
		GetComponent<AnnimatedUI_Fader> ().Hide ();
	}
}
