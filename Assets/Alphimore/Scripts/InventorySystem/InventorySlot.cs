using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerEnterHandler,IPointerExitHandler {
	public Vector2 itemSize = new Vector2(30,30);
	private RectTransform rectTransform;
	private Item item;
	public int index;
	public GameObject itemGraphics;

	void Awake(){
		rectTransform = GetComponent<RectTransform> ();
	}

	void CreateItemGraphics(){
		if (item == null)
			return;
		GameObject itemGraphics = new GameObject ();
		Image image = itemGraphics.AddComponent<Image> ();
		itemGraphics.transform.SetParent (transform, false);
		image.rectTransform.sizeDelta = new Vector2 (itemSize.x, itemSize.y);
		image.sprite = item.sprite;
		image.preserveAspect = true;
		this.itemGraphics = itemGraphics;
	}

	public void SetItem(Item newItem){
		if (item != null)
			Destroy (itemGraphics);
		this.item = newItem;
		CreateItemGraphics ();
	}

	public Item getItem(){
		return item;
	}

	public void SwapWith(InventorySlot slot){
		Item swapped = slot.item;
		slot.SetItem (item);
		SetItem (swapped);
	}

	public void OnBeginDrag (PointerEventData eventData){
		if (item == null)
			return;
		itemGraphics.transform.position = eventData.position;
		itemGraphics.transform.SetParent (transform.parent.parent.parent);
		itemGraphics.transform.SetAsLastSibling ();
	}

	public void OnDrag(PointerEventData eventData){
		if (item == null)
			return;
		itemGraphics.transform.position = eventData.position;
		itemGraphics.AddComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnEndDrag(PointerEventData eventData){
		if (item == null)
			return;
		InventorySlot other = eventData.pointerEnter == null ? null : eventData.pointerEnter.GetComponentInParent<InventorySlot> ();
		// Si on rencontre un slot vide
		if (other != null) {
			itemGraphics.transform.SetParent (transform);
			other.SwapWith (this);
		} 
		// Si on ne rencontre rien
		else {
			itemGraphics.transform.SetParent (transform);
			itemGraphics.transform.localPosition = new Vector2 (0, 0);
		}
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		if (item != null) {
			InventoryItemTooltip.instance.ShowItemTooltip (item);
			InventoryItemTooltip.instance.transform.position = eventData.position;
		}
	}
	public void OnPointerExit (PointerEventData eventData)
	{
		InventoryItemTooltip.instance.HideTooltip ();
	}
}
