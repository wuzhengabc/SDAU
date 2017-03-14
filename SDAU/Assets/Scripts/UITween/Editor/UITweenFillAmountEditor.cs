using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(UITweenFillAmount))]
[CanEditMultipleObjects]
public class UITweenFillAmountEditor : UITweenEditor {

    private UITweenFillAmount _uiTweenFillAmount;
    private Image _image;
    public override void OnEnable()
    {
        base.OnEnable();

        _uiTweenFillAmount = target as UITweenFillAmount;

        _image = _uiTweenFillAmount.GetComponent<Image>();
    }

    public override void OnInspectorGUI()
    {
        if (_image == null)
        {
            EditorGUILayout.HelpBox("this gameObject has't Image", MessageType.Error);
        }

        EditorGUILayout.BeginVertical("box");

        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            if (_image.type != Image.Type.Filled)
            {
                _image.type = Image.Type.Filled;
            }
            _uiTweenFillAmount.from = _image.fillAmount;
        }
        GUILayout.Space(5);

        _uiTweenFillAmount.from = EditorGUILayout.FloatField("From", _uiTweenFillAmount.from);
        _uiTweenFillAmount.to = EditorGUILayout.FloatField("To", _uiTweenFillAmount.to);
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
