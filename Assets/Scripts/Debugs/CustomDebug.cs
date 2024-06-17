using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDebug : MonoBehaviour
{
    public void SetText(string value)
    {
        Debug.Log($"{value}");
    }
}
