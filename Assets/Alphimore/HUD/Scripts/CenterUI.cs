using UnityEngine;
using System.Collections;

public class CenterUI : MonoBehaviour {
	
	void Start(){
		GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
	}
}
