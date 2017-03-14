using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(UITweenText))]
[CanEditMultipleObjects]
public class UITweenTextEditor : UITweenEditor {

    private UITweenText _uiTweenText;

    private Text _text;
    public override void OnEnable()
    {
        base.OnEnable();

        _uiTweenText = target as UITweenText;
        _text = _uiTweenText.GetComponent<Text>();
    }

    public override void OnInspectorGUI()
    {
        if (_text == null)
        {
            EditorGUILayout.HelpBox("this gameObject has't Text", MessageType.Error);
        }

        EditorGUILayout.BeginVertical("box");
        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            _uiTweenText.from = _text.text;
        }
        GUILayout.Space(5);

        EditorGUILayout.LabelField("From", GUILayout.Width(50));
            _uiTweenText.from = EditorGUILayout.TextArea(_uiTweenText.from, GUILayout.Height(40));
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("To", GUILayout.Width(50));
            _uiTweenText.to = EditorGUILayout.TextArea(_uiTweenText.to, GUILayout.Height(40));
        EditorGUILayout.EndVertical();

        GUILayout.Space(5);

        EditorGUILayout.BeginVertical("box");
        _uiTweenText.useSpeed = EditorGUILayout.Toggle("UseSpeed", _uiTweenText.useSpeed);
        if (_uiTweenText.useSpeed)
        {
            _uiTweenText.speed = EditorGUILayout.FloatField("Speed", _uiTweenText.speed);
        }
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
