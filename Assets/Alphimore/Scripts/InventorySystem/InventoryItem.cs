using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour {
	public Image image;
	public Text counter;
	public Item item;
	public InventorySlot slot;

	public bool IsEmpty(){
		return item.count == 0;
	}

	void Start(){
		gameObject.GetOrAddComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	void Update(){
		counter.enabled = image.enabled = !IsEmpty ();
		image.sprite = item.sprite;
		if(item.count != 1)
			counter.text = item.count.ToString();
	}
}
