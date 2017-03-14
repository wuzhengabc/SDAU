using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(UITweenAlpha))]
[CanEditMultipleObjects]
public class UITweenAlphaEditor : UITweenEditor {


    private UITweenAlpha _uiTweenAlpha;
    private Image _image;
    private Text _text;

    public override void OnEnable()
    {
        base.OnEnable();
        _uiTweenAlpha = target as UITweenAlpha;

        _image = _uiTweenAlpha.GetComponent<Image>();
        _text = _uiTweenAlpha.GetComponent<Text>();
    }

    public override void OnInspectorGUI()
    {
        if (_image == null && _text == null)
        {
            EditorGUILayout.HelpBox("this gameObject has't Image or Text", MessageType.Error);
        }

        EditorGUILayout.BeginVertical("box");

        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            if (_image != null)
            {
                _uiTweenAlpha.from = _image.color.a;
            }
            else if (_text != null)
            {
                _uiTweenAlpha.from = _text.color.a;
            }
        }
        GUILayout.Space(5);

        _uiTweenAlpha.from = EditorGUILayout.FloatField("From", _uiTweenAlpha.from);
        _uiTweenAlpha.to = EditorGUILayout.FloatField("To", _uiTweenAlpha.to);
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
