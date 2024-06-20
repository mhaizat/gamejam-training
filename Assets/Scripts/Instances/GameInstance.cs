using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    #region Instance
    private static GameInstance _instance;
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
}
