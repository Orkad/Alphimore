using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerEnterHandler,IPointerExitHandler {
	public InventoryItem inventoryItem;
	public int index;

	public void ReceiveInventoryItem(InventoryItem invItem){
		invItem.transform.SetParent (transform);
		invItem.transform.localPosition = new Vector3 (0, 0);
		inventoryItem = invItem;
		inventoryItem.slot = this;
		inventoryItem.item.inventoryOrder = index;
	}

	public void SwapWith(InventorySlot slot){
		InventoryItem swapped = slot.inventoryItem;
		if (inventoryItem != null)
			slot.ReceiveInventoryItem (inventoryItem);
		else
			slot.inventoryItem = null;
		ReceiveInventoryItem (swapped);
	}

	public void OnBeginDrag (PointerEventData eventData){
		if (inventoryItem == null)
			return;
		inventoryItem.transform.position = eventData.position;
		inventoryItem.transform.SetParent (transform.parent.parent.parent);
		inventoryItem.transform.SetAsLastSibling ();
	}

	public void OnDrag(PointerEventData eventData){
		if (inventoryItem == null)
			return;
		inventoryItem.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData){
		if (inventoryItem == null)
			return;
		InventorySlot other = eventData.pointerEnter == null ? null : eventData.pointerEnter.GetComponentInParent<InventorySlot> ();
		// Si on rencontre un slot vide
		if (other != null) {
			other.SwapWith (this);
		} 
		// Si on ne rencontre rien
		else {
			ReceiveInventoryItem (inventoryItem);
		}
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		if (inventoryItem != null) {
			InventoryItemTooltip.instance.ShowItemTooltip (inventoryItem.item);
			InventoryItemTooltip.instance.transform.position = eventData.position;
		}
	}
	public void OnPointerExit (PointerEventData eventData)
	{
		InventoryItemTooltip.instance.HideTooltip ();
	}
}
