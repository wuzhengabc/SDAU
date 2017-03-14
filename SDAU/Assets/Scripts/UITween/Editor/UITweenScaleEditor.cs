using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(UITweenScale))]
[CanEditMultipleObjects]
public class UITweenScaleEditor : UITweenEditor {

    private UITweenScale _uiTweenScale;

    private RectTransform _rectTransform;
    private Transform tr;

    public override void OnEnable()
    {
        base.OnEnable();

        _uiTweenScale = target as UITweenScale;

        _rectTransform = _uiTweenScale.GetComponent<RectTransform>();
        tr = _uiTweenScale.transform;
    }

    public override void OnInspectorGUI()
    {
        UITweenScale _uiTweenScale = target as UITweenScale;

        EditorGUILayout.BeginVertical("box");

        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            if (_rectTransform != null)
            {
                _uiTweenScale.from = _rectTransform.localScale;
            }
            else
            {
                _uiTweenScale.from = tr.localScale;
            }
        }
        GUILayout.Space(5);

        _uiTweenScale.from = EditorGUILayout.Vector3Field("From", _uiTweenScale.from);
        _uiTweenScale.to = EditorGUILayout.Vector3Field("To", _uiTweenScale.to);
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
