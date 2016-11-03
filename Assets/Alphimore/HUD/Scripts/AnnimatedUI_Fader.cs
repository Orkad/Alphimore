using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class AnnimatedUI_Fader : AnnimatedUI {
	public bool drivenBlocksRaycasts = true;
	public bool drivenInteractable = true;
	protected RectTransform rectTransform;
	protected CanvasGroup canvasGroup;

	void Awake(){
		canvasGroup = gameObject.GetOrAddComponent<CanvasGroup> ();
		rectTransform = gameObject.GetComponent<RectTransform> ();
		canvasGroup.alpha = Convert.ToSingle(show);
	}

	void Update(){
		if(show)
			canvasGroup.alpha +=  Time.deltaTime / transitionDuration;
		else
			canvasGroup.alpha -=  Time.deltaTime / transitionDuration;
		canvasGroup.blocksRaycasts = InterractableCondition();
		canvasGroup.interactable = InterractableCondition();
		canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha);
	}

	bool InterractableCondition()
	{
		return IsShown();
	}

	public override bool IsHidden(){
		return canvasGroup.alpha <= 0f;
	}

	public override bool IsShown(){
		return canvasGroup.alpha >= 1f;
	}
}
