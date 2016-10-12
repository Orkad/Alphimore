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
	public bool backOnEscape = true;
	private bool isOpen;
	private bool isActive;


	void Awake(){
		annimatedUI = gameObject.GetOrAddComponent<AnnimatedUI> ();
		rectTransform = gameObject.GetComponent<RectTransform> ();
		if(center)
			rectTransform.position = new Vector2(Screen.width / 2,Screen.height /2);
		if(backButton != null)
			backButton.onClick.AddListener(() => Back());
	}

	void Update(){
		if (!isActive || !isOpen)
			return;
		if (!backOnEscape)
			return;
		if(Input.GetKeyDown(KeyCode.Escape))
			Back();
	}

	public void Open(){
		this.annimatedUI.Show();
		isOpen = true;
		isActive = true;
	}

	public void Close(){
		Hide ();
		isOpen = false;
	}

	public void Hide(){
		annimatedUI.Hide ();
		isActive = false;
	}

	public void Toogle(){
		if (annimatedUI.IsShown ()) {
			if (isOpen && isActive)
				Close ();
		} else if (!isOpen && !isActive)
			Open ();
	}

	public void Stack(Menu nextMenu){
		Hide ();
		nextMenu.previousMenu = this;
		nextMenu.Open ();
	}

	public void Back(){
		Close ();
		if(previousMenu != null)
			previousMenu.Open();
	}
}
