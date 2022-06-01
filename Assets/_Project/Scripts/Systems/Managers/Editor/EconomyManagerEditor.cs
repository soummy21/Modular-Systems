using UnityEditor;
using UnityEngine;
//Third Party Libraries
using SoummySDK.Systems.Economy;

[CustomEditor(typeof(EconomyManager))]
public class EconomyManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {             
        #region Economy Custom GUILayout
        GUILayout.Space(5);
        GUI.skin.label.fontSize = 17;
        GUI.skin.label.alignment = TextAnchor.UpperCenter;
        GUILayout.Label("ECONOMY MANAGER");
        GUILayout.Space(10);
        DrawDefaultInspector();
        #endregion
    }

}


