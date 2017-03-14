using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using DG.Tweening;

[CustomEditor(typeof(UITween))]
[CanEditMultipleObjects]
public class UITweenEditor : Editor {

    private UITween _uiTween;

    public virtual void OnEnable()
    {
        _uiTween = target as UITween;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        _uiTween = target as UITween;

        GUILayout.Space(10);

        DrawCommonProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }

        serializedObject.ApplyModifiedProperties();
    }

    protected void DrawCommonProperties()
    {
        EditorGUILayout.BeginVertical("box");

        if (DrawHeadInspector.DrawHeader("Tween", false, 0))
        {
            GUILayout.Space(5);
            EditorGUI.indentLevel = 1;
            GUI.contentColor = Color.white;
            _uiTween.enablePlay = EditorGUILayout.Toggle("EnablePlay", _uiTween.enablePlay);
            _uiTween.loopType = (UITweenLoopType)EditorGUILayout.EnumPopup("LoopType", _uiTween.loopType);
            _uiTween.loopTimes = EditorGUILayout.IntField("LoopTimes", _uiTween.loopTimes);
            _uiTween.ease = (Ease)EditorGUILayout.EnumPopup("Ease", _uiTween.ease);

            _uiTween.ignoreTimeScale = EditorGUILayout.Toggle("IgnoreTimeScale", _uiTween.ignoreTimeScale);

            EditorGUILayout.BeginHorizontal();
            _uiTween.delay = EditorGUILayout.FloatField("Delay", _uiTween.delay);
            EditorGUILayout.LabelField("Second");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            _uiTween.duration = EditorGUILayout.FloatField("Duration", _uiTween.duration);
            EditorGUILayout.LabelField("Second");
            EditorGUILayout.EndHorizontal();
        }

        GUILayout.Space(5);

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box");
        if (DrawHeadInspector.DrawHeader("OnFinish", false, 0))
        {
            DrawOnFinish(_uiTween.eventCallBackClassList);
        }

        EditorGUILayout.EndVertical();
        GUILayout.Space(5);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }

    private List<EventCallBackClass> DrawOnFinish(List<EventCallBackClass> eventCallBackClassList)
    {
        for (int i = 0; i < eventCallBackClassList.Count; i++)
        {
            if (eventCallBackClassList[i] == null)
            {
                eventCallBackClassList.RemoveAt(i);
                return eventCallBackClassList;
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Notify", GUILayout.Width(60));

            GUI.contentColor = Color.red;

            if (GUILayout.Button("\u2014", GUILayout.Width(30)))
            {
                eventCallBackClassList.RemoveAt(i);
                return eventCallBackClassList;
            }

            GUI.contentColor = Color.white;
            eventCallBackClassList[i]._monoBehaviour = (MonoBehaviour)EditorGUILayout.ObjectField(eventCallBackClassList[i]._monoBehaviour, typeof(MonoBehaviour), true, GUILayout.ExpandWidth(true));

            EditorGUILayout.EndHorizontal();

            if (eventCallBackClassList[i]._monoBehaviour != null)
            {
                List<EventCallBackClass> mothedList = DelegateEventEditor.GetMehtods(eventCallBackClassList[i]._monoBehaviour.gameObject);

                List<string> nameList = new List<string>();
                nameList.Clear();

                for (int j = 0; j < mothedList.Count; j++)
                {
                    string name = mothedList[j]._monoBehaviour.GetType() + "/" + mothedList[j].eventName;
                    nameList.Add(name);
                }

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Method", GUILayout.Width(95));
                int isSelect = -1;

                string[] eventNameArr = nameList.ToArray();

                for (int k = 0; k < eventNameArr.Length; k++)
                {
                    if (eventNameArr[k].CompareTo(eventCallBackClassList[i].eventName) == 0)
                    {
                        isSelect = k;
                    }
                }

                isSelect = EditorGUILayout.Popup(isSelect, nameList.ToArray());

                if (isSelect >= 0)
                {
                    if (eventNameArr.Length > isSelect)
                    {
                        eventCallBackClassList[i]._monoBehaviour = (MonoBehaviour)mothedList[isSelect]._monoBehaviour;
                        eventCallBackClassList[i].eventName = eventNameArr[isSelect];
                    }
                }
                EditorGUILayout.LabelField("", GUILayout.Width(15));
                EditorGUILayout.EndHorizontal();      
            }      
        }

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Notify", GUILayout.Width(95));
        MonoBehaviour mono = (MonoBehaviour)EditorGUILayout.ObjectField(null, typeof(MonoBehaviour), true, GUILayout.ExpandWidth(true));

        EditorGUILayout.EndHorizontal();

        if (mono != null)
        {
            EventCallBackClass eventCallBackCla = new EventCallBackClass();
            eventCallBackCla._monoBehaviour = mono;
            eventCallBackClassList.Add(eventCallBackCla);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }

        return eventCallBackClassList;
    }

}
