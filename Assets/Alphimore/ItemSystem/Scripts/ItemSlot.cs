using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2 itemSize = new Vector2(30, 30);
    public bool filterByItemType;
    private Item item;
    private GameObject itemGraphics;

    public bool Validate(Item item)
    {
        return true;
    }

    void CreateItemGraphics()
    {
        if (item == null)
            return;
        GameObject itemGraphics = new GameObject();
        Image image = itemGraphics.AddComponent<Image>();
        itemGraphics.transform.SetParent(transform, false);
        image.rectTransform.sizeDelta = new Vector2(itemSize.x, itemSize.y);
        image.sprite = item.sprite;
        image.preserveAspect = true;
        this.itemGraphics = itemGraphics;
    }

    public void SetItem(Item newItem)
    {
        if (item != null)
            Destroy(itemGraphics);
        this.item = newItem;
        CreateItemGraphics();
    }

    public Item getItem()
    {
        return item;
    }

    public void SwapWith(ItemSlot itemSlot)
    {
        
        Item swapped = itemSlot.item;
        if (!Validate(swapped) || !itemSlot.Validate(item))
            return;
        itemSlot.SetItem(item);
        SetItem(swapped);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item == null)
            return;
        itemGraphics.transform.position = eventData.position;
        itemGraphics.transform.SetParent(transform.parent.parent.parent);
        itemGraphics.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item == null)
            return;
        itemGraphics.transform.position = eventData.position;
        itemGraphics.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (item == null)
            return;
        ItemSlot other = eventData.pointerEnter == null ? null : eventData.pointerEnter.GetComponentInParent<ItemSlot>();
        // Si on rencontre un slot vide
        if (other != null)
        {
            itemGraphics.transform.SetParent(transform);
            other.SwapWith(this);
        }
        // Si on ne rencontre rien
        else
        {
            itemGraphics.transform.SetParent(transform);
            itemGraphics.transform.localPosition = new Vector2(0, 0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            InventoryItemTooltip.instance.ShowItemTooltip(item);
            InventoryItemTooltip.instance.transform.position = eventData.position;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryItemTooltip.instance.HideTooltip();
    }
}