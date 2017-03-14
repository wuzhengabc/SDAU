using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(UITweenPunchPosition))]
[CanEditMultipleObjects]
public class UITweenPunchPositionEditor : UITweenEditor {

    private UITweenPunchPosition _uiTweenPunchPosition;
    private RectTransform _rectTransform;
    private Transform tr;

    public override void OnEnable()
    {
        base.OnEnable();

        _uiTweenPunchPosition = target as UITweenPunchPosition;

        _rectTransform = _uiTweenPunchPosition.GetComponent<RectTransform>();
        tr = _uiTweenPunchPosition.transform;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical("box");

        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            if (_rectTransform != null)
            {
                _uiTweenPunchPosition.from = _rectTransform.anchoredPosition3D;
            }
            else
            {
                _uiTweenPunchPosition.from = tr.localPosition;
            }
        }
        GUILayout.Space(5);

        _uiTweenPunchPosition.from = EditorGUILayout.Vector3Field("From", _uiTweenPunchPosition.from);
        _uiTweenPunchPosition.to = EditorGUILayout.Vector3Field("To", _uiTweenPunchPosition.to);
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
