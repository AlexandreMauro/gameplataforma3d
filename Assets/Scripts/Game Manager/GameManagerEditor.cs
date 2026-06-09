using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public bool ShowFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager gamemanager = (GameManager)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine Editor");
        //
        if (gamemanager.gameState == null) return;

        if (gamemanager.gameState.currentState != null)
        {
            EditorGUILayout.LabelField("CurrentState:", gamemanager.gameState.currentState.ToString());
        }

        ShowFoldout = EditorGUILayout.Foldout(ShowFoldout, "States Avaliable");
        if (ShowFoldout)
        {
            if (gamemanager.gameState.dicionaryStates != null)
            {
                var keys = gamemanager.gameState.dicionaryStates.Keys.ToArray();
                var vals = gamemanager.gameState.dicionaryStates.Values.ToArray();

                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("State: {0} :: {1}", keys[i], vals[i]));
                }
            }
        }
    }
}
