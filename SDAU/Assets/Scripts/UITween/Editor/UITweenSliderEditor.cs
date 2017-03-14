using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(UITweenSlider))]
[CanEditMultipleObjects]
public class UITweenSliderEditor : UITweenEditor {

    private UITweenSlider _uiTweenSlider;
    private Slider _slider;

    public override void OnEnable()
    {
        base.OnEnable();

        _uiTweenSlider = target as UITweenSlider;
        _slider = _uiTweenSlider.GetComponent<Slider>();
    }

    public override void OnInspectorGUI()
    {
        if (_slider == null)
        {
            EditorGUILayout.HelpBox("this gameObject has't Slider", MessageType.Error);
        }

        EditorGUILayout.BeginVertical("box");

        GUILayout.Space(5);
        if (GUILayout.Button("GetFrom", GUILayout.ExpandWidth(true)))
        {
            _uiTweenSlider.from = _slider.value;
        }
        GUILayout.Space(5);

        _uiTweenSlider.from = EditorGUILayout.FloatField("From", _uiTweenSlider.from);
        _uiTweenSlider.to = EditorGUILayout.FloatField("To", _uiTweenSlider.to);
        EditorGUILayout.EndVertical();

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
