using UnityEngine;
using UnityEngine.Events;


public abstract class AnnimatedUI : MonoBehaviour {
	public bool show = false;
	public float transitionDuration = 0.2f;

	public void Show(){
		show = true;
		OnShow.Invoke();
	}

	public void Hide(){
		show = false;
		OnHide.Invoke();
	}

	public void Toogle(){
		if(IsShown())
			Hide();
		else
			Show();
	}

	public UnityEvent OnShow;
	public UnityEvent OnHide;

	public abstract bool IsShown();
	public abstract bool IsHidden();

}