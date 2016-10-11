using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Menu used for stack a linked AnnimatedUI
/// </summary>
public class Menu : MonoBehaviour {
	private AnnimatedUI annimatedUI;
	private RectTransform rectTransform;
	private Menu previousMenu;
	public Button backButton;
	public bool center = true;
	private bool isCurrent;

	void Awake(){
		annimatedUI = gameObject.GetOrAddComponent<AnnimatedUI> ();
		rectTransform = gameObject.GetComponent<RectTransform> ();
		if(center)
			rectTransform.position = new Vector2(Screen.width / 2,Screen.height /2);
		if(backButton != null)
			backButton.onClick.AddListener(() => Back());
	}

	public void Open(){
		this.annimatedUI.Show();
		isCurrent = true;
	}

	public void Close(){
		annimatedUI.Hide ();
		isCurrent = false;
	}

	public void Toogle(){
		if (annimatedUI.IsShown ()) {
			if (isCurrent)
				Close ();
		} else
			Open ();
	}

	public void Stack(Menu nextMenu){
		Close ();
		nextMenu.previousMenu = this;
		nextMenu.Open ();
	}

	public void Back(){
		Close ();
		previousMenu.annimatedUI.Show();
	}
}
