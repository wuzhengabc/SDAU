using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using EasyRoads3D;
using EasyRoads3DEditor;
public class ProceduralObjectsEditor : EditorWindow
{

public static ProceduralObjectsEditor instance;
public ODDDDCDOCC so_editor;
public int sideObject;
private ODODDQQO so;

private GameObject so_go;

string[] traceStrings;

public ProceduralObjectsEditor() {
instance = this;
}
void OnDestroy(){
OQDOOCCDDD.OnDestroy1();
instance = null;
}
public void DisplayNodes (int index, ODODDQQO soi, GameObject sso_go)

{
so_go = sso_go;
List<Vector2> tmpNodes = new List<Vector2>();
if(soi != null) tmpNodes.AddRange(soi.nodeList);

if(so_go != null && tmpNodes.Count == 0){

List<Vector2> arr = ODDDDCDOCC.ODDDCCCQQQ(2, so_go, OQDOOCCDDD.traceOffset);
if(arr != null){
if(arr.Count > 1){
tmpNodes = arr;
}
}
}
bool clamped = false;
so = soi;
sideObject = index;
if (so_editor == null){
try{
so_editor = new ODDDDCDOCC(position, tmpNodes, clamped);
}catch{
}
}



if(so_editor.OODDDQCOCC.Count > 0){
if((Vector2)so_editor.OODDDQCOCC[0] == (Vector2)so_editor.OODDDQCOCC[so_editor.OODDDQCOCC.Count - 1]){

so_editor.closed = true;
so_editor.OODDDQCOCC.RemoveAt(so_editor.OODDDQCOCC.Count - 1);
}
}
if(tmpNodes.Count != 0){
Rect rect = new Rect(stageSelectionGridWidth, 0, Screen.width - stageSelectionGridWidth, Screen.height);
so_editor.FrameSelected(rect);
}
OQDOOCCDDD.ODDODOCQCC(index, soi, sso_go, so_editor);
return;
}
void OnGUI ()
{
Rect rect = new Rect(stageSelectionGridWidth, 0, Screen.width - stageSelectionGridWidth, Screen.height);
EditorGUILayout.BeginHorizontal();
GUILayout.Space(210);
GUILayout.Label(new GUIContent("Hit [r] to center the editor, hit [z] to zoom in on the nodes, click drag to move the canvas, Scrollwheel (or [shift] click drag) zoom in / out", ""), GUILayout.Width(800) );
EditorGUILayout.EndHorizontal();
GUILayout.Space(-15);
OQDOOCCDDD.ODQQDDOQDD(rect);
DoGUI ();
so_editor.OnGUI(rect);
}
float stageSelectionGridWidth = 200;
void DoGUI ()
{

EditorGUILayout.BeginHorizontal();
GUILayout.Space(60);
if(GUILayout.Button ("Apply", GUILayout.Width(65))){
OQDOOCCDDD.ODQOCCDDDD();
instance.Close();
}
if(GUILayout.Button ("Close", GUILayout.Width(65))){
instance.Close();
}
EditorGUILayout.EndHorizontal();
GUILayout.Space(5);
if(so_editor.isChanged == false) GUI.enabled = false;
EditorGUILayout.BeginHorizontal();
GUILayout.Space(60);
if(GUILayout.Button ("Update Scene", GUILayout.Width(135))){

so.nodeList.Clear();
if(so_editor.closed) so_editor.OODDDQCOCC.Add(so_editor.OODDDQCOCC[0]);
so.nodeList.AddRange(so_editor.OODDDQCOCC);
so_editor.isChanged = false;
ODQDQQOODQ.ODDQOOODQO(ODQDQQOODQ.selectedObject);
ODQDQQOODQ.OQQOOQQCQD();

List<ODODDQQO> arr = ODDQQCODQO.OOQDQCCQDQ(false);
RoadObjectScript.ODODOQQO = ODDQQCODQO.ODQQOCCOQC(arr);
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
foreach(RoadObjectScript scr in scripts){

if(scr.OOCQCQDOQO == null) {
List<ODODDQQO> arr1  = ODDQQCODQO.OOQDQCCQDQ(false);
scr.OCDCQQQCCQ(arr1, ODDQQCODQO.ODQQOCCOQC(arr1), ODDQQCODQO.OCQCOCOODD(arr1));
}
scr.OOQQQCODCQ(arr, ODDQQCODQO.ODQQOCCOQC(arr), ODDQQCODQO.OCQCOCOODD(arr));
if(scr.ODQDCQQQDO == true || scr.objectType == 2){
GameObject go = GameObject.Find(scr.gameObject.name+"/Side Objects/"+so.name);


if(go != null){
OOCCODOCQQ.OQOQQDQOQQ((sideObjectScript)go.GetComponent(typeof(sideObjectScript)), sideObject, scr, go.transform);
}
}
}
}
EditorGUILayout.EndHorizontal();
GUI.enabled = true;
if (GUI.changed)
{
so_editor.isChanged = true;

}
Handles.color = Color.black;
Handles.DrawLine(new Vector2 (stageSelectionGridWidth,0), new Vector2 (stageSelectionGridWidth,Screen.height));

Handles.DrawLine(new Vector2 (stageSelectionGridWidth - 1,0), new Vector2 (stageSelectionGridWidth - 1,Screen.height));

}

}
