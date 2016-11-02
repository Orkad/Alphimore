using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneralOptions : MonoBehaviour {
	public Dropdown languageDropDown;
	public Slider HudScaleSlider;
	public Text HudScaleText;
	public Canvas canvas;

	private static float scaleFactor { get { return PlayerPrefs.GetFloat ("ScaleFactor",1); } set { PlayerPrefs.SetFloat ("ScaleFactor", value); } }

	void Start(){
		canvas.scaleFactor = scaleFactor;
	}

	void Update(){
		HudScaleText.text = HudScaleSlider.value.ToString ("F2");
	}

	public void Load(){
		canvas.scaleFactor = HudScaleSlider.value = scaleFactor;
		languageDropDown.ClearOptions ();
		languageDropDown.AddOptions (Locale.availableLanguagesString());
		languageDropDown.value = Locale.currentLanguageIndex;
	}

	public void Save(){
		Locale.currentLanguageIndex = languageDropDown.value;
		canvas.scaleFactor = scaleFactor = HudScaleSlider.value;
	}
}
