using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UITweenPosition))]
[CanEditMultipleObjects]
public class UITweenPositionEditor : UITweenEditor {

    private UITweenPosition _uiTweenPosition;

    private RectTransform _rectTransform;
    private Transform tr;

    public override void OnEnable()
    {
        base.OnEnable();

        _uiTweenPosition = target as UITweenPosition;

        _rectTransform = _uiTweenPosition.GetComponent<RectTransform>();
        tr = _uiTweenPosition.transform;
    }

    public override void OnInspectorGUI()
    {
        
        EditorGUILayout.BeginVertical("box");

        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            if (_rectTransform != null)
            {
                _uiTweenPosition.from = _rectTransform.anchoredPosition3D;
            }
            else
            {
                _uiTweenPosition.from = tr.localPosition;
            }
        }
        GUILayout.Space(5);

        _uiTweenPosition.from = EditorGUILayout.Vector3Field("From", _uiTweenPosition.from);
        _uiTweenPosition.to = EditorGUILayout.Vector3Field("To", _uiTweenPosition.to);
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
