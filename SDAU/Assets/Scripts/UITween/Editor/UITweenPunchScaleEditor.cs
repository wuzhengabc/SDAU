using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UITweenPunchScale))]
[CanEditMultipleObjects]
public class UITweenPunchScaleEditor : UITweenEditor {

    private UITweenPunchScale _uiTweenPunchScale;
    private RectTransform _rectTransform;
    private Transform tr;

    public override void OnEnable()
    {
        base.OnEnable();

        _uiTweenPunchScale = target as UITweenPunchScale;

        _rectTransform = _uiTweenPunchScale.GetComponent<RectTransform>();
        tr = _uiTweenPunchScale.transform;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical("box");

        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            if (_rectTransform != null)
            {
                _uiTweenPunchScale.from = _rectTransform.localScale;
            }
            else
            {
                _uiTweenPunchScale.from = tr.localScale;
            }
        }
        GUILayout.Space(5);

        _uiTweenPunchScale.from = EditorGUILayout.Vector3Field("From", _uiTweenPunchScale.from);
        _uiTweenPunchScale.to = EditorGUILayout.Vector3Field("To", _uiTweenPunchScale.to);
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
