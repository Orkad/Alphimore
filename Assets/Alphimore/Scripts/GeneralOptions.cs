using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneralOptions : MonoBehaviour {
	public Dropdown languageDropDown;

	void Start () {
		RefreshDropDown ();
	}

	void RefreshDropDown(){
		languageDropDown.ClearOptions ();
		languageDropDown.AddOptions (Locale.availableLanguagesString(Locale.currentLanguage));
	}

	public void Validate(){
		Locale.currentLanguage = Locale.GetLanguageByString (languageDropDown.options [languageDropDown.value].text,Locale.currentLanguage);
		RefreshDropDown ();
	}
}
