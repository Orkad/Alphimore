using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance
    {
        get
        {
            return _instance ?? (_instance = FindObjectOfType<GameManager>() ?? new GameObject("GameManager").AddComponent<GameManager>());
        }
    }

    public int port;
    public string address;
    public string MenuSceneName;
    public string GameSceneName;

    internal void Connect(string username, string password)
    {
        _client.Connect(address,port);
    }

    private static GameManager _instance;
    private static readonly NetworkClient _client = new NetworkClient();

    internal void Disconnect()
    {
        _client.Disconnect();
    }

    internal Character CreateNewCharacter(string name)
    {
        return new Character() {name = name};
    }

    internal void JoinWith(Character character)
    {
        SceneManager.LoadSceneAsync(GameSceneName);
    }

    internal void BackToMenu()
    {
        SceneManager.LoadSceneAsync(MenuSceneName);
    }

    public void DeleteCharacter(Character character)
    {
        
    }
}
