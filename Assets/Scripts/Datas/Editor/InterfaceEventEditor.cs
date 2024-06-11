using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InterfaceSO), editorForChildClasses: true)]
public class InterfaceEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        InterfaceSO e = target as InterfaceSO;
        if (GUILayout.Button("Raise"))
            e.Raise();
    }
}
