using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Reflection;

//使用反射机制获取脚本中的方法字段
public static class DelegateEventEditor {

    public static List<EventCallBackClass> GetMehtods(GameObject target)
    {
        List<EventCallBackClass> methodList = new List<EventCallBackClass>();

        MonoBehaviour[] comps = target.GetComponents<MonoBehaviour>();//获取该对象上挂载的所有脚本

        for (int i = 0; i < comps.Length; i ++ )
        {
            MonoBehaviour mb = comps[i];

            if (mb == null)
                continue;

            Type tt = mb.GetType();  //获取脚本类型
            MethodInfo[] methods = tt.GetMethods(BindingFlags.Instance | BindingFlags.Public); //获取脚本中的方法

            for (int j = 0; j < methods.Length; j++)
            {
                MethodInfo mi = methods[j];   //获取方法实体

                ParameterInfo[] pi = mi.GetParameters(); //获取方法中的参数

                if (pi.Length > 0)
                    continue;

                if (mi.ReturnType == typeof(void))
                {
                    string name = mi.Name;

                    if (name == "Invoke") continue;
                    if (name == "InvokeRepeating") continue;
                    if (name == "CancelInvoke") continue;
                    if (name == "StopCoroutine") continue;
                    if (name == "StopAllCoroutines") continue;
                    if (name == "BroadcastMessage") continue;
                    if (name.StartsWith( "SendMessage")) continue;
                    if (name.StartsWith( "set_")) continue;
                    if (name.StartsWith("Get")) continue;

                    EventCallBackClass delegateEntry = new EventCallBackClass();
                    delegateEntry._monoBehaviour = mb;
                    delegateEntry.eventName = name;

                    methodList.Add(delegateEntry);   //将需要的类型添加进列表          
                }
            }
        }
        
        return methodList;
    }

    public static Dictionary<Component, List<string>> delegateEntryDic = new Dictionary<Component, List<string>>();

    public static void GetDelegateDic(List<EventCallBackClass> delegateEntryList)
    {
        delegateEntryDic.Clear();

        for (int i = 0; i < delegateEntryList.Count; i ++)
        {
            if (delegateEntryDic.ContainsKey(delegateEntryList[i]._monoBehaviour))
            {
                delegateEntryDic[delegateEntryList[i]._monoBehaviour].Add(delegateEntryList[i].eventName);
            }
            else
            {
                List<string> nameList = new List<string>();
                nameList.Add(delegateEntryList[i].eventName);
                delegateEntryDic.Add(delegateEntryList[i]._monoBehaviour , nameList);
            }
        }
    }

}
