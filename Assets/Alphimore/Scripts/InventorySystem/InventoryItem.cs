using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {
	public Image image;
	public Text counter;
	public Item item;

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
	}

	public void OnDrag(PointerEventData eventData){
		transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData){
		if (eventData.pointerEnter.GetComponent<InventorySlot> () != null) {
			eventData.pointerEnter.GetComponent<InventorySlot> ().ReceiveInventoryItem (this);
		} else {
			transform.localPosition = new Vector3 (0, 0);
		}
		image.gameObject.GetOrAddComponent<CanvasGroup> ().blocksRaycasts = true;
		counter.gameObject.GetOrAddComponent<CanvasGroup> ().blocksRaycasts = true;
	}
}
