using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Locale {

	public static SystemLanguage currentLanguage = SystemLanguage.French;

	public static List<SystemLanguage> availableLanguages = new List<SystemLanguage> () {
		SystemLanguage.French,
		SystemLanguage.English
	};

	public static List<string> availableLanguagesString(SystemLanguage languageUsed){
		List<string> str = new List<string>();
		foreach(SystemLanguage l in availableLanguages)
			str.Add(GetLanguageString(l,languageUsed));
		return str;
	}

	public static string GetLanguageString(SystemLanguage languageToShow, SystemLanguage languageUsed){
		switch (languageUsed) {
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

	public static SystemLanguage GetLanguageByString(string languageStr, SystemLanguage languageUsed){
		foreach (SystemLanguage l in availableLanguages) {
			if (GetLanguageString (l, languageUsed) == languageStr)
				return l;
		}
		return SystemLanguage.English;
	}
}
