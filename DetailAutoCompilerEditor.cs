using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(DetailAutoCompiler))]
public class DetailAutoCompilerEditor : Editor
{
    private GameObject obj;
    private DetailAutoCompiler objScript;

    void OnEnable()
    {
        obj = Selection.activeGameObject;
        objScript = obj.GetComponent<DetailAutoCompiler>();
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        //
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("D : Paint Details", GUILayout.MinWidth(80), GUILayout.MaxWidth(350)))
        {
            objScript.PaintDetails();
        }

        EditorGUILayout.EndHorizontal();
    }

}
