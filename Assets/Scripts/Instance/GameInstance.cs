using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
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

    private void Awake()
    {
        _instance = this;
    }
}