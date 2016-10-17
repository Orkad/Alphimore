using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chat : MonoBehaviour {
	public Text messageContainer;
	public InputField messageInputField;
	public string author;
	public int maxMessages;

	void Start(){
		
	}

	public void Update(){
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (messageInputField.text == "") {
				messageInputField.Select ();
				return;
			}
			Write (messageInputField.text);
			messageInputField.text = "";
		}
			
	}

	public void Write(string something){
		messageContainer.text += "\n" + author + " : " + something;
	}
}
