using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LocalizedText : MonoBehaviour {
	public string Before;
	public string After;
	public string Fr;
	public string En;


	void Update(){
		switch (Locale.currentLanguage) {
		case SystemLanguage.French:
			SetLabel (Fr);
			break;
		case SystemLanguage.English:
			SetLabel (En);
			break;
		default:
			SetLabel("Locale Error");
			break;
		}
	}

	private void SetLabel(string str){
		GetComponent<Text> ().text = Before + str + After;
	}
}
