using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(RectTransform))]
public class AnnimatedUI : MonoBehaviour {
	protected RectTransform rectTransform;
	protected CanvasGroup canvasGroup;
	public bool show = false;

	public float transitionDuration = 0.2f;
	public UnityEvent OnShow;
	public UnityEvent OnHide;

	protected virtual void UpdateShow(){}

	void Awake(){
		canvasGroup = gameObject.AddComponent<CanvasGroup> ();
		rectTransform = gameObject.GetComponent<RectTransform> ();
		canvasGroup.alpha = Convert.ToSingle(show);
	}

	void Update(){
		if(show){
			UpdateShow();
			canvasGroup.alpha +=  Time.deltaTime / transitionDuration;
		}
		else
			canvasGroup.alpha -=  Time.deltaTime / transitionDuration;
		canvasGroup.blocksRaycasts = IsShown();
		canvasGroup.interactable = InterractableCondition();
		canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha);
	}

	protected virtual bool InterractableCondition()
	{
		return IsShown();
	}

	public void StartHidden(){
		canvasGroup.alpha = 0f;
		show = false;
	}

	public void StartShown(){
		canvasGroup.alpha = 1f;
		show = true;
	}

	public void Show(){
		BeforeShow();
		show = true;
		OnShow.Invoke();
	}

	protected virtual void BeforeShow(){}

	public void Hide(){
		BeforeHide();
		show = false;
		OnHide.Invoke();
	}

	protected virtual void BeforeHide(){}

	public void Toogle(){
		if(IsShown())
			Hide();
		else
			Show();
	}

	public bool IsHidden(){
		return canvasGroup.alpha <= 0f;
	}

	public bool IsShown(){
		return canvasGroup.alpha >= 1f;
	}
}