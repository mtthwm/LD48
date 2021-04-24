using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;

[CustomEditor(typeof(Generator))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Generator generator = (Generator)target;
        if (GUILayout.Button("Apply"))
        {
            generator.ApplyChanges();
        }
    }
}
