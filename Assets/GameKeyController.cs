using UnityEngine;
using System.Collections;

public class GameKeyController : MonoBehaviour {
	public KeyCode gameMenuKeyCode;
	public Menu gameMenu;

	void Update(){
		if (Input.GetKeyDown(gameMenuKeyCode)) {
			gameMenu.Toogle ();
		}
	}
}
