using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MainMenuManager : MonoBehaviour
{
    public InputField usernameInputField;
    public InputField passwordInputField;
    public InputField characterNameInputField;

    public Character characterPrefab;

    public void Connect()
    {
        GameManager.instance.Connect(usernameInputField.text,passwordInputField.text);
    }

    public void Disconnect()
    {
        GameManager.instance.Disconnect();
    }

    public void CreateNewCharacter()
    {
        GameManager.instance.CreateNewCharacter(characterNameInputField.text);
    }

    public void DeleteCharacter(Character character)
    {
        GameManager.instance.DeleteCharacter(character);
    }


}