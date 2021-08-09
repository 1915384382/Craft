using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GameManager))]
public class GUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            DrawGUI();
        }
    }
    void DrawGUI() 
    {
        if (GUILayout.Button("播放BGM"))
        {
            //GameManager.Instance.BGM = EditorGUILayout.TextField("BGM名字");
            AudioManager.Instance.PlayBGM(GameManager.Instance.BGM);
        }
    }
}
