using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using EasyRoads3D;
public class OOCCODOCQQ{

static public void OCQDOQQOQQ(RoadObjectScript target){


ODDQQCODQO.OCQCQDDQQD(target.transform);

List<ODODDQQO> arr = ODDQQCODQO.OOQDQCCQDQ(false);
target.OOQQQCODCQ(arr, ODDQQCODQO.ODQQOCCOQC(arr), ODDQQCODQO.OCQCOCOODD(arr));
Transform mySideObject = ODOCQDQQCO(target);
OQDCCDCOCC(target.OOCQCQDOQO, target.transform, target.OQDCCCOCOD(), target.OOQDOOQQ, target.OOQQQOQO, target.raise, target, mySideObject);



target.ODODDDOO = true;

}
static public void OQDCCDCOCC(ODDDQCOOOD OOCQCQDOQO, Transform obj , List<SideObjectParams> param , bool OOQDOOQQ ,  int[] activeODODDQQO , float raise, RoadObjectScript target , Transform mySideObject){
List<ODQOQCDQQC> pnts  = target.OOCQCQDOQO.OQDQCDDCOC;
List<ODODDQQO> arr  = ODDQQCODQO.OOQDQCCQDQ(false);
for(int i = 0; i < activeODODDQQO.Length; i++){  
ODODDQQO so = (ODODDQQO)arr[activeODODDQQO[i]];

GameObject goi  = null;
if(so.ODOQQCQDOO != "") goi =  (GameObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(so.ODOQQCQDOO), typeof(GameObject));
GameObject ODOOCCODOC = null;
if(so.ODCDOOQDDD != "") ODOOCCODOC = (GameObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(so.ODCDOOQDDD), typeof(GameObject));
GameObject ODDDDCOCDD = null;
if(so.ODCCOCQQOD != "") ODDDDCOCDD =  (GameObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(so.ODCCOCQQOD), typeof(GameObject));
ODDQQCODQO.OODQQCDDDD(so, pnts, obj, OOCQCQDOQO, param, OOQDOOQQ, activeODODDQQO[i], raise, goi, ODOOCCODOC, ODDDDCOCDD);
if(so.terrainTree > 0){

if(EditorUtility.DisplayDialog("Side Objects", "Side Object " + so.name + " in " + target.gameObject.name + " includes an asset part of the terrain vegetation data.\n\nWould you like to add this side object to the terrain vegetation data?", "yes","no")){
foreach(Transform child in mySideObject){
if(child.gameObject.name == so.name){
ODDQQCODQO.OOQOQODDQO(activeODODDQQO[i], child);
MonoBehaviour.DestroyImmediate(child.gameObject);
break;
}
}
}
}
foreach(Transform child in mySideObject)if(child.gameObject.GetComponent(typeof(sideObjectScript)) != null) MonoBehaviour.DestroyImmediate(child.gameObject.GetComponent(typeof(sideObjectScript)));
}
}

static public void OQOQQDQOQQ(sideObjectScript scr, int index, RoadObjectScript target, Transform go){
string n = go.gameObject.name;
Transform p = go.parent;

if(go != null){
MonoBehaviour.DestroyImmediate(go.gameObject);
}
List<ODODDQQO> arr = ODDQQCODQO.OOQDQCCQDQ(false);
ODODDQQO so = (ODODDQQO)arr[index];

OCOCDDQDQQ(n, p, so, index, target);

GameObject goi  = null;
if(so.ODOQQCQDOO != "") goi =  (GameObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(so.ODOQQCQDOO), typeof(GameObject));
GameObject ODOOCCODOC = null;
if(so.ODCDOOQDDD != "") ODOOCCODOC = (GameObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(so.ODCDOOQDDD), typeof(GameObject));
GameObject ODDDDCOCDD = null;
if(so.ODCCOCQQOD != "") ODDDDCOCDD =  (GameObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(so.ODCCOCQQOD), typeof(GameObject));

ODDQQCODQO.ODQDQQQCOD(target.OOCQCQDOQO, target.transform, target.OQDCCCOCOD(), target.OOQDOOQQ, index, target.raise, goi, ODOOCCODOC, ODDDDCOCDD);
arr = null;
}

static public Transform ODOCQDQQCO(RoadObjectScript target){

GameObject go  =  new GameObject("Side Objects");

go.transform.parent = target.transform;
List<ODODDQQO> arr = ODDQQCODQO.OOQDQCCQDQ(false);
for(int i = 0; i < target.OOQQQOQO.Length; i++){  
ODODDQQO so = (ODODDQQO)arr[target.OOQQQOQO[i]];
OCOCDDQDQQ(so.name, go.transform, so, target.OOQQQOQO[i], target);
}
return go.transform;
}
static public void OCOCDDQDQQ(string objectname, Transform obj, ODODDQQO so, int index, RoadObjectScript target){



Transform rootObject = null;

foreach(Transform child1 in obj)
{
if(child1.name == objectname){
rootObject = child1;

if(so.textureGUID !=""){
MeshRenderer mr  = (MeshRenderer)rootObject.transform.GetComponent(typeof(MeshRenderer));
Material mat =  (Material)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(so.textureGUID), typeof(Material));
mr.material = mat;

}
}
}
if(rootObject == null){
GameObject go  =  new GameObject(objectname);
go.name = objectname;
go.transform.parent = obj;
rootObject = go.transform;

go.AddComponent(typeof(MeshFilter));
go.AddComponent(typeof(MeshRenderer));
go.AddComponent(typeof(MeshCollider));
go.AddComponent(typeof(sideObjectScript));
sideObjectScript scr = (sideObjectScript)go.GetComponent(typeof(sideObjectScript));
if(so.textureGUID !=""){
MeshRenderer mr = (MeshRenderer)go.GetComponent(typeof(MeshRenderer));
Material mat =  (Material)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(so.textureGUID), typeof(Material));
mr.material = mat;
scr.mat = mat;
}
scr.soIndex = index;
scr.soName = so.name;

scr.soAlign = int.Parse(so.align);
scr.soUVx = so.uvx;
scr.soUVy = so.uvy;
scr.m_distance = so.m_distance;
scr.objectType = so.objectType;
scr.weld = so.weld;
scr.combine = so.combine;
scr.OQCODOQQOD = so.OQCODOQQOD;
scr.m_go = so.ODOQQCQDOO;
if(so.ODCDOOQDDD != ""){
scr.ODCDOOQDDD = so.ODCDOOQDDD;

}
if(so.ODCDOOQDDD != ""){
scr.ODCCOCQQOD = so.ODCCOCQQOD;

}
scr.selectedRotation = so.selectedRotation;
scr.position = so.position;
scr.uvInt = so.uvType;
scr.randomObjects = so.randomObjects;
scr.childOrder = so.childOrder;
scr.sidewaysOffset = so.sidewaysOffset;
scr.density = so.density;
scr.OQQCCDODCO = target;
scr.terrainTree = so.terrainTree;
scr.xPosition = so.xPosition;
scr.yPosition = so.yPosition;
scr.uvYRound = so.uvYRound;
scr.m_collider = so.collider;
scr.m_tangents = so.tangents;

}
}

}
