using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Locale {

	public static int currentLanguageIndex { get { return PlayerPrefs.GetInt ("LanguageIndex", 0); } set { PlayerPrefs.SetInt ("LanguageIndex", value); } }

	private static SystemLanguage currentLanguage {get{return availableLanguages [currentLanguageIndex];}}

	public static List<SystemLanguage> availableLanguages = new List<SystemLanguage> () {
		SystemLanguage.French,
		SystemLanguage.English
	};

	public static List<string> availableLanguagesString(){
		List<string> str = new List<string>();
		foreach(SystemLanguage l in availableLanguages)
			str.Add(GetLanguageString(l));
		return str;
	}

	public static string GetLanguageString(SystemLanguage languageToShow){
		switch (currentLanguage) {
		case SystemLanguage.French:
			switch (languageToShow) {
			case SystemLanguage.French:
				return "Français";
			case SystemLanguage.English:
				return "Anglais";
			default:
				return "???";
			}
		case SystemLanguage.English:
			switch (languageToShow) {
			case SystemLanguage.French:
				return "French";
			case SystemLanguage.English:
				return "English";
			default:
				return "???";
			}
		default:
			return "???";
		}
	}

	public static SystemLanguage GetLanguageByString(string languageStr){
		foreach (SystemLanguage language in availableLanguages) {
			if (GetLanguageString (language) == languageStr)
				return language;
		}
		return SystemLanguage.English;
	}
}
