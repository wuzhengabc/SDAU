using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using EasyRoads3D;
using EasyRoads3DEditor;
public class EasyRoadsEditorMenu : ScriptableObject {







[MenuItem( "GameObject/Create Other/EasyRoads3D/New EasyRoads3D Object" )]
public static void  CreateEasyRoads3DObject ()
{







Terrain[] terrains = (Terrain[]) FindObjectsOfType(typeof(Terrain));
if(terrains.Length == 0){
EditorUtility.DisplayDialog("Alert", "No Terrain objects found! EasyRoads3D objects requires a terrain object to interact with. Please create a Terrain object first", "Close");
return;
}



if(NewEasyRoads3D.instance == null){
NewEasyRoads3D window = (NewEasyRoads3D)ScriptableObject.CreateInstance(typeof(NewEasyRoads3D));
window.ShowUtility();
}



}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Back Up/Terrain Height Data" )]
public static void  GetTerrain ()
{
if(GetEasyRoads3DObjects()){

OQQOCQDCCQ.OOQOCOOCDO(Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Restore/Terrain Height Data" )]
public static void  SetTerrain ()
{
if(GetEasyRoads3DObjects()){

OQQOCQDCCQ.OOCDDCDCDO(Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Back Up/Terrain Splatmap Data" )]
public static void  OQOOOOCQQD()
{
if(GetEasyRoads3DObjects()){

ODQOOOQOQO.OQOOOOCQQD(Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Restore/Terrain Splatmap Data" )]
public static void  OODOCQOCCD ()
{
if(GetEasyRoads3DObjects()){
string path = "";
if(EditorUtility.DisplayDialog("Road Splatmap", "Would you like to merge the terrain splatmap(s) with a road splatmap?", "Yes", "No")){
path = EditorUtility.OpenFilePanel("Select png road splatmap texture", "", "png");
}


ODQOOOQOQO.ODQCODODCQ(true, 100, 4, path, Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Back Up/Terrain Vegetation Data" )]
public static void  OODQCQOOCO()
{
if(GetEasyRoads3DObjects()){

OQQOCQDCCQ.OODQCQOOCO(Selection.activeGameObject, null, "");
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Back Up/All Terrain Data" )]
public static void  GetAllData()
{
if(GetEasyRoads3DObjects()){

OQQOCQDCCQ.OOQOCOOCDO(Selection.activeGameObject);
ODQOOOQOQO.OQOOOOCQQD(Selection.activeGameObject);
OQQOCQDCCQ.OODQCQOOCO(Selection.activeGameObject, null,"");
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Restore/Terrain Vegetation Data" )]
public static void  OOQCCQDDCO()
{
if(GetEasyRoads3DObjects()){

OQQOCQDCCQ.OOQCCQDDCO(Selection.activeGameObject);
}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}
}
[MenuItem( "GameObject/Create Other/EasyRoads3D/Restore/All Terrain Data" )]
public static void  RestoreAllData()
{
if(GetEasyRoads3DObjects()){

OQQOCQDCCQ.OOCDDCDCDO(Selection.activeGameObject);
ODQOOOQOQO.ODQCODODCQ(true, 100, 4, "", Selection.activeGameObject);
OQQOCQDCCQ.OOQCCQDDCO(Selection.activeGameObject);

}else{
EditorUtility.DisplayDialog("Alert", "No EasyRoads3D objects found! Terrain functions cannot be accessed!", "Close");
}


}

[MenuItem ("GameObject/Create Other/EasyRoads3D/Side Objects/Object Manager")]
static void ShowObjectManager ()
{

if(RoadObjectScript.erInit == ""){
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
if(scripts != null) if(scripts.Length != 0) Selection.activeGameObject = scripts[0].gameObject;


}
if(ObjectManager.instance == null){

if(Terrain.activeTerrain != null)ODQDQQOODQ.terrainTrees = ODDDQCOOOD.OCODDDOCCO();
ObjectManager window =(ObjectManager)ScriptableObject.CreateInstance(typeof(ObjectManager));
window.ShowUtility();
}
}


[MenuItem( "GameObject/Create Other/EasyRoads3D/Build EasyRoads3D Objects" )]
public static void  FinalizeRoads ()
{

bool destroyTerrainScript = true;
if(EditorUtility.DisplayDialog("Build EasyRoads3D Objects", "This process includes destroying all EasyRoads3D control objects. Did you make a backup of the Scene? Do you want to continue?\n\nDepending on the number of EasyRoads3D objects in the Scene and used side objects, this process may take a while. Please be patient. ", "Yes", "No")){
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
foreach (RoadObjectScript script in scripts) {
bool renderflag = true;
bool renderAlreadyDone = false;
int num = 0;
if(!script.displayRoad){
num = EditorUtility.DisplayDialogComplex ("Disabled EasyRoads3D Object Detected:", script.gameObject.name + " is currently not displayed.\n\nWould you like to activate and finalize this object, destroy this object or skip it in this finalize procedure?", "Finalize", "Destroy", "Skip");
if(num == 0){
script.displayRoad = true;
if(script.OOCQCQDOQO == null){
List<ODODDQQO> arr = ODDQQCODQO.OOQDQCCQDQ(false);
script.OCDCQQQCCQ(arr, ODDQQCODQO.ODQQOCCOQC(arr), ODDQQCODQO.OCQCOCOODD(arr));
}
script.OOCQCQDOQO.OODQQOCCOO(script.displayRoad, script.OCCQODODOD);
}
if(num == 1){

renderflag = false;
}
if(num == 2){
renderflag = false;
destroyTerrainScript = false;
}
}
if(script.transform != null && renderflag && !script.ODQDCQQQDO){
if(script.OOCQCQDOQO == null){
List<ODODDQQO> arr = ODDQQCODQO.OOQDQCCQDQ(false);
script.OCDCQQQCCQ(arr, ODDQQCODQO.ODQQOCCOQC(arr), ODDQQCODQO.OCQCOCOODD(arr));
}

if(RoadObjectScript.erInit == ""){
RoadObjectScript.erInit = OQCODCODQD.OOOQCDQCOQ(RoadObjectScript.version); 
ODDDQCOOOD.erInit = RoadObjectScript.erInit;
}

if(script.OOCQCQDOQO == null){
script.OQOQCQOOOQ(script.transform, null, null, null);
}
ODDDQCOOOD.OOODCDQDDC = true;
if(!script.ODQDCQQQDO){
script.geoResolution = 0.5f;
script.OOCDCCOCQD();
if(script.objectType < 2) OCDOQOQQOC(script);
script.OOCQCQDOQO.terrainRendered = true;
script.OOCOOQDQQD();



}
if(script.displayRoad && script.objectType < 2){

if(script.objectType == 1){

SetWaterScript(script);
}
script.OOCQCQDOQO.road.transform.parent = null;
script.OOCQCQDOQO.road.layer = 0;
script.OOCQCQDOQO.road.name = script.gameObject.name;
}
else if(script.OOCQCQDOQO.road != null)DestroyImmediate(script.OOCQCQDOQO.road);



bool flag = false;
for(int i=0;i<script.ODODQQOD.Length;i++){
if(script.ODODQQOD[i]){
flag = true;
break;
}
}
if(flag){
OOCCODOCQQ.OCQDOQQOQQ(script);
}
foreach(Transform child in script.transform){
if(child.name == "Side Objects"){
child.name = script.gameObject.name + " - Side Objects ";
child.parent = null;
}
}
}else if(script.ODQDCQQQDO){
renderAlreadyDone = true;
destroyTerrainScript = false;
}
if((script.displayRoad || num != 2) && !renderAlreadyDone)DestroyImmediate(script.gameObject);
}

if(destroyTerrainScript){
EasyRoads3DTerrainID[] terrainscripts = (EasyRoads3DTerrainID[])FindObjectsOfType(typeof(EasyRoads3DTerrainID));
foreach (EasyRoads3DTerrainID script in terrainscripts) {
DestroyImmediate(script);
}
}
}
}

public static bool GetEasyRoads3DObjects(){
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
bool flag = false;
foreach (RoadObjectScript script in scripts) {
if(script.OOCQCQDOQO == null){

List<ODODDQQO> arr = ODDQQCODQO.OOQDQCCQDQ(false);
script.OQOQCQOOOQ(script.transform, arr, ODDQQCODQO.ODQQOCCOQC(arr), ODDQQCODQO.OCQCOCOODD(arr));


}
flag = true;
}
return flag;
}
static private void OCDOQOQQOC(RoadObjectScript target){
EditorUtility.DisplayProgressBar("Build EasyRoads3D Object - " + target.gameObject.name,"Initializing", 0);

RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
List<Transform> rObj = new List<Transform>();


#if UNITY_4_3

#else
Undo.RegisterUndo(ODQOOOQOQO.terrain.terrainData, "EasyRoads3D Terrain leveling");
#endif
foreach(RoadObjectScript script in scripts) {
if(script.transform != target.transform) rObj.Add(script.transform);
}
if(target.ODODQOQO == null){
target.ODODQOQO = target.OOCQCQDOQO.OCQDDDDCDO();
target.ODODQOQOInt = target.OOCQCQDOQO.OCODQCOODQ();
}
target.OCOQDDCCDC(0.5f, true, false);

List<tPoint> hitOODDDQCOCC = target.OOCQCQDOQO.OQQDDCQCOC(Vector3.zero, target.raise, target.obj, target.OOQDOOQQ, rObj, target.handleVegetation);
List<Vector3> changeArr = new List<Vector3>();
float stepsf = Mathf.Floor(hitOODDDQCOCC.Count / 10);
int steps = Mathf.RoundToInt(stepsf);
for(int i = 0; i < 10;i++){
changeArr = target.OOCQCQDOQO.OODQCCOCQO(hitOODDDQCOCC, i * steps, steps, changeArr);
EditorUtility.DisplayProgressBar("Build EasyRoads3D Object - " + target.gameObject.name,"Updating Terrain", i * 10);
}

changeArr = target.OOCQCQDOQO.OODQCCOCQO(hitOODDDQCOCC, 10 * steps, hitOODDDQCOCC.Count - (10 * steps), changeArr);
target.OOCQCQDOQO.OOODDODQQD(changeArr, rObj);

target.OOCOOQDQQD();
EditorUtility.ClearProgressBar();

}
private static void SetWaterScript(RoadObjectScript target){
for(int i = 0; i < target.OQCODCDOQC.Length; i++){
if(target.OOCQCQDOQO.road.GetComponent(target.OQCODCDOQC[i]) != null && i != target.selectedWaterScript)DestroyImmediate(target.OOCQCQDOQO.road.GetComponent(target.OQCODCDOQC[i]));
}
if(target.OQCODCDOQC[0] != "None Available!"  && target.OOCQCQDOQO.road.GetComponent(target.OQCODCDOQC[target.selectedWaterScript]) == null){
UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(target.OOCQCQDOQO.road, "Assets/EasyRoads3D/Editor/EasyRoadsEditorMenu.cs (314,1)", target.OQCODCDOQC[target.selectedWaterScript]);

}
}
public static Vector3 ReadFile(string file)
{
Vector3 pos = Vector3.zero;
if(File.Exists(file)){
StreamReader streamReader = File.OpenText(file);
string line = streamReader.ReadLine();
line = line.Replace(",",".");
string[] lines = line.Split("\n"[0]);
string[] arr = lines[0].Split("|"[0]);
float.TryParse(arr[0],System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out pos.x);
float.TryParse(arr[1],System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out pos.y);
float.TryParse(arr[2],System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out pos.z);
}
return pos;
}
}
