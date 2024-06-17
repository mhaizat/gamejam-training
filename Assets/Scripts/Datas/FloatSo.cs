using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FloatVariable", order = 2)]
public class FloatSo : ScriptableObject
{
    public float floatVariable = .0f;

    public float GetFloatValue()
    {
        return floatVariable;
    }

}
