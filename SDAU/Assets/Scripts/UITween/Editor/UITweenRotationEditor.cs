using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(UITweenRotation))]
[CanEditMultipleObjects]
public class UITweenRotationEditor : UITweenEditor {

    private UITweenRotation _uiTweenRotation;
    private RectTransform _rectTransform;
    private Transform tr;

    public override void OnEnable()
    {
        base.OnEnable();

        _uiTweenRotation = target as UITweenRotation;

        _rectTransform = _uiTweenRotation.GetComponent<RectTransform>();
        tr = _uiTweenRotation.transform;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical("box");

        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            if (_rectTransform != null)
            {
                _uiTweenRotation.from = _rectTransform.localRotation.eulerAngles;
            }
            else
            {
                _uiTweenRotation.from = tr.localRotation.eulerAngles;
            }
        }
        GUILayout.Space(5);

        _uiTweenRotation.from = EditorGUILayout.Vector3Field("From", _uiTweenRotation.from);
        _uiTweenRotation.to = EditorGUILayout.Vector3Field("To", _uiTweenRotation.to);
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
