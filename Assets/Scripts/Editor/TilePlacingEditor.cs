using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TilePlacing))]
public class TilePlacingEditor : Editor
{
    SerializedProperty x;
    SerializedProperty y;
    SerializedProperty z;
    SerializedProperty tileRadius;

    void OnEnable()
    {
        x = serializedObject.FindProperty("x");
        y = serializedObject.FindProperty("y");
        z = serializedObject.FindProperty("z");
        tileRadius = serializedObject.FindProperty("tileRadius");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(x);
        EditorGUILayout.PropertyField(y);
        EditorGUILayout.PropertyField(z);
        EditorGUILayout.PropertyField(tileRadius);
        if (tileRadius.floatValue < 0)
        {
            tileRadius.floatValue = 0;
        }

        serializedObject.ApplyModifiedProperties();
        if (GUILayout.Button("Snap"))
        {
            Debug.Log("Snapping");
            if (x.intValue + y.intValue + z.intValue == 0)
            {
                TilePlacing tilePlacing = (TilePlacing)target;
                tilePlacing.PlaceTile();
            }
        }
    }
}
