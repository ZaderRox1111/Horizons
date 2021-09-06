using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(TerrainAutoPaint))]
public class TerrainAutoPaintEditor : Editor
{
    private GameObject obj;
    private TerrainAutoPaint objScript;

    void OnEnable()
    {
        obj = Selection.activeGameObject;
        objScript = obj.GetComponent<TerrainAutoPaint>();
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        //
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("P : Paint Terrain", GUILayout.MinWidth(80), GUILayout.MaxWidth(350)))
        {
            objScript.PaintTerrain();
        }

        EditorGUILayout.EndHorizontal();
    }


    void OnSceneGUI()
    {
        Event e = Event.current;

        if (e.type == EventType.KeyDown)
        {
            switch (e.keyCode)
            {
                case KeyCode.P:
                    objScript.PaintTerrain();
                    break;

                default:

                    break;
            }
        }
    }
}
