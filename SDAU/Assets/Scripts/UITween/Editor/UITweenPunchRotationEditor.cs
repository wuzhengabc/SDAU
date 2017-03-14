using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UITweenPunchRotation))]
[CanEditMultipleObjects]
public class UITweenPunchRotationEditor : UITweenEditor {

    private UITweenPunchRotation _uiTweenPunchRotation;
    private RectTransform _rectTransform;
    private Transform tr;

    public override void OnEnable()
    {
        base.OnEnable();

        _uiTweenPunchRotation = target as UITweenPunchRotation;

        _rectTransform = _uiTweenPunchRotation.GetComponent<RectTransform>();
        tr = _uiTweenPunchRotation.transform;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical("box");

        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            if (_rectTransform != null)
            {
                _uiTweenPunchRotation.from = _rectTransform.localRotation.eulerAngles;
            }
            else
            {
                _uiTweenPunchRotation.from = tr.localRotation.eulerAngles;
            }
        }
        GUILayout.Space(5);

        _uiTweenPunchRotation.from = EditorGUILayout.Vector3Field("From", _uiTweenPunchRotation.from);
        _uiTweenPunchRotation.to = EditorGUILayout.Vector3Field("To", _uiTweenPunchRotation.to);
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
