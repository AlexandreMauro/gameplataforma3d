using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using System;



[CustomEditor(typeof(FSMExample))]
public class StateMachineEditor : Editor
{
    public bool ShowFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FSMExample fsm = (FSMExample)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine Editor");
        //
        if (fsm.stateMachine == null) return;

        if (fsm.stateMachine.currentState != null)
        {
            EditorGUILayout.LabelField("CurrentState:", fsm.stateMachine.currentState.ToString());
        }

        ShowFoldout = EditorGUILayout.Foldout(ShowFoldout, "States Avaliable");
                if (ShowFoldout)
                {
                   if(fsm.stateMachine.dicionaryStates != null)
                    {
                        var keys = fsm.stateMachine.dicionaryStates.Keys.ToArray();
                        var vals = fsm.stateMachine.dicionaryStates.Values.ToArray();

                        for (int i = 0; i < keys.Length; i++)
                        {
                            EditorGUILayout.LabelField(string.Format("State: {0} :: {1}", keys[i], vals[i]));
                        }
                    }
                }
    }
}

