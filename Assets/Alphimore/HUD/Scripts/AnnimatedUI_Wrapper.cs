using UnityEngine;
using System.Collections;

public class AnnimatedUI_Wrapper : AnnimatedUI {
	public bool horizontalAnnimated;
	public bool verticalAnnimated;

	RectTransform rectTransform;
	Vector2 size;

	void Awake(){
		rectTransform = gameObject.GetComponent<RectTransform> ();
		size = rectTransform.sizeDelta;
	}

	void Update(){
		if(show)
			rectTransform.sizeDelta += Time.deltaTime / transitionDuration * size;
		else
			rectTransform.sizeDelta -=  Time.deltaTime / transitionDuration * size;
		rectTransform.sizeDelta = new Vector2(horizontalAnnimated ? Mathf.Clamp (rectTransform.sizeDelta.x, 0, size.x) : size.x,
			verticalAnnimated ? Mathf.Clamp (rectTransform.sizeDelta.y, 0, size.y) : size.y);
	}
		

	public override bool IsHidden(){
		return rectTransform.sizeDelta.x <= 0;
	}

	public override bool IsShown(){
		return rectTransform.sizeDelta.x >= size.x;
	}
}
