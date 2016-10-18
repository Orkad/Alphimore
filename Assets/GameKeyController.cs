using UnityEngine;
using System.Collections;

public class GameKeyController : MonoBehaviour {
	public KeyCode gameMenuKeyCode;
	public Menu gameMenu;
	public KeyCode inventoryKeyCode;
	public AnnimatedUI_Fader inventory;

	void Update(){
		if (Input.GetKeyDown(gameMenuKeyCode)) {
			gameMenu.Toogle ();
		}
		if (Input.GetKeyDown (inventoryKeyCode)) {
			inventory.Toogle ();
		}
	}
}
