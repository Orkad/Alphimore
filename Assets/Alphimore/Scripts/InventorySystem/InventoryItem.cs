using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {
	public Image image;
	public Text counter;
	public Item item;
	public InventorySlot slot;

	public bool IsEmpty(){
		return item.count == 0;
	}

	void Update(){
		counter.enabled = image.enabled = !IsEmpty ();
		image.sprite = item.sprite;
		counter.text = item.count.ToString();
	}

	public void OnBeginDrag (PointerEventData eventData){
		transform.position = eventData.position;
		image.gameObject.GetOrAddComponent<CanvasGroup> ().blocksRaycasts = false;
		counter.gameObject.GetOrAddComponent<CanvasGroup> ().blocksRaycasts = false;
		transform.SetParent (transform.parent.parent.parent);
		transform.SetAsLastSibling ();
	}

	public void OnDrag(PointerEventData eventData){
		transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData){
		InventorySlot slotEvent = eventData.pointerEnter == null ? null : eventData.pointerEnter.GetComponentInParent<InventorySlot> ();
		// Si on rencontre un slot vide
		if (slotEvent != null) {
			slotEvent.SwapWith (slot);
		} 
		// Si on ne rencontre rien
		else {
			slot.ReceiveInventoryItem (this);
		}
		image.gameObject.GetOrAddComponent<CanvasGroup> ().blocksRaycasts = true;
		counter.gameObject.GetOrAddComponent<CanvasGroup> ().blocksRaycasts = true;
	}
}
