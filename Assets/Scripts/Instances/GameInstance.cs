using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    public enum GameState { UIOnly, GameAndUI, GameOnly}
    
    #region Instance
    private static GameInstance _instance;
    
    public GameState currentGameState;

    public static GameInstance Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<GameInstance>();
            
            return _instance;
        }
    }
    #endregion

    [SerializeField] private InterfaceSO interfaceSO;

    private void Awake()
    {
        _instance = this;
    }

    public void LoadUIScene()
    {
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void SetGameUIState(GameState gameState)
    {
        currentGameState = gameState;
    }

    public GameState GetGameUIState() { return currentGameState; }
}
