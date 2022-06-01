using UnityEditor;
using UnityEngine;
using SoummySDK.Systems.SceneManagement;

[CustomEditor(typeof(GameSceneManager))]
public class GameSceneManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        #region Game Scene Manager Custom GUILayout
        GUILayout.Space(5);
        GUI.skin.label.fontSize = 17;
        GUI.skin.label.alignment = TextAnchor.UpperCenter;
        GUILayout.Label("GAME SCENE MANAGER");
        GUILayout.Space(10);
        DrawDefaultInspector();
        #endregion
    }
}
