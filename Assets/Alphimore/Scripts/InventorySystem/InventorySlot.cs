using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
	public Image image;
	public Text counter;
	public InventoryItem item;

	void Start(){
		
	}

	public bool IsEmpty(){
		return item.count == 0;
	}

	void Update(){
		counter.enabled = image.enabled = !IsEmpty ();
		image.sprite = item.sprite;
		counter.text = item.count.ToString();
	}
}
