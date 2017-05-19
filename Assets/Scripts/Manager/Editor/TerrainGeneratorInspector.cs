#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainGenerator))]
public class TerrainGeneratorInspector : Editor {

    override public void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(GUILayout.Button("Generate"))
        {
            var _target = target as TerrainGenerator;
            _target.Generate();
        }
        if(GUILayout.Button("Clear"))
        {
            var _target = target as TerrainGenerator;
            _target.ClearAllrooms();
        }
    }


}
#endif
