#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Game))]
public class GameInspector : Editor {

    public Game _target;

    override public void OnInspectorGUI()
    {
        if(_target == null)
        {
            _target = target as Game;
        }

        DrawDefaultInspector();

        if(GUILayout.Button("Ligar"))
        {
            _target.filtro.SetActive(true);
            _target.nevoa.SetActive(true);
        }
        if(GUILayout.Button("Desliga"))
        {
            _target.filtro.SetActive(false);
            _target.nevoa.SetActive(false);
        }
        if(GUILayout.Button("Teste"))
        {
            _target.Messages("teste");
        }

    }
    
}
#endif