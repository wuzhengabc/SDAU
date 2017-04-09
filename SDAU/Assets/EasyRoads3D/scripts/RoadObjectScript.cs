using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System;
using EasyRoads3D;

public class RoadObjectScript : MonoBehaviour {
static public string version = "";
public int objectType = 0;
public bool displayRoad = true;
public float roadWidth = 5.0f;
public float indent = 3.0f;
public float surrounding = 5.0f;
public float raise = 1.0f;
public float raiseMarkers = 0.5f;
public bool OOQDOOQQ = false;
public bool renderRoad = true;
public bool beveledRoad = false;
public bool applySplatmap = false;
public int splatmapLayer = 4;
public bool autoUpdate = true;
public float geoResolution = 5.0f;
public int roadResolution = 1;
public float tuw =  15.0f;
public int splatmapSmoothLevel;
public float opacity = 1.0f;
public int expand = 0;
public int offsetX = 0;
public int offsetY = 0;
private Material surfaceMaterial;
public float surfaceOpacity = 1.0f;
public float smoothDistance = 1.0f;
public float smoothSurDistance = 3.0f;
private bool handleInsertFlag;
public bool handleVegetation = true;
public float OQDODQCOQQ = 2.0f;
public float OCQOQOOOCD = 1f;
public int materialType = 0;
String[] materialStrings;
public string uname;
public string email;
private MarkerScript[] mSc;

private bool OQODODCQOD;
private bool[] OQOCOQQOCQ = null;
private bool[] ODCQOOQDQO = null;
public string[] OOCCDDOQCQ;
public string[] ODODQOQO;
public int[] ODODQOQOInt;
public int ODCDODOQQO = -1;
public int OCODOOCDCO = -1;
static public GUISkin OCDCDOQDOC;
static public GUISkin OOCQQCOQDD;
public bool OQODOCDQDD = false;
private Vector3 cPos;
private Vector3 ePos;
public bool OCOCQCQODD;
static public Texture2D OQQCQOOQCQ;
public int markers = 1;
public ODDDQCOOOD OOCQCQDOQO;
private GameObject ODOQDQOO;
public bool ODQDCQQQDO;
public bool doTerrain;
private Transform ODDODDCCDC = null;
public GameObject[] ODDODDCCDCs;
private static string OODCQDQQQC = null;
public Transform obj;
private string ODCCCOOCQQ;
public static string erInit = "";
static public Transform OQCOQQOCQD;
private RoadObjectScript OQQCCDODCO;
public bool flyby;


private Vector3 pos;
private float fl;
private float oldfl;
private bool ODQCCCDCCQ;
private bool ODCCDCQCDQ;
private bool OCQCDDODQO;
public Transform OCCQODODOD;
public int OdQODQOD = 1;
public float OOQQQDOD = 0f;
public float OOQQQDODOffset = 0f;
public float OOQQQDODLength = 0f;
public bool ODODDDOO = false;
static public string[] ODOQDOQO;
static public string[] ODODOQQO; 
static public string[] ODODQOOQ;
public int ODQDOOQO = 0;
public string[] ODQQQQQO;  
public string[] ODODDQOO; 
public bool[] ODODQQOD; 
public int[] OOQQQOQO; 
public int ODOQOOQO = 0; 

public bool forceY = false;
public float yChange = 0f;
public float floorDepth = 2f;
public float waterLevel = 1.5f; 
public bool lockWaterLevel = true;
public float lastY = 0f;
public string distance = "0";
public string markerDisplayStr = "Hide Markers";
static public string[] objectStrings;
public string objectText = "Road";
public bool applyAnimation = false;
public float waveSize = 1.5f;
public float waveHeight = 0.15f;
public bool snapY = true;

private TextAnchor origAnchor;
public bool autoODODDQQO;
public Texture2D roadTexture;
public Texture2D roadMaterial;
public string[] OCQODCQOCQ;
public string[] OQCODCDOQC;
public int selectedWaterMaterial;
public int selectedWaterScript;
private bool doRestore = false;
public bool doFlyOver;
public static GameObject tracer;
public Camera goCam;
public float speed = 1f;
public float offset = 0f;
public bool camInit;
public GameObject customMesh = null;
static public bool disableFreeAlerts = true;
public bool multipleTerrains;
public bool editRestore = true;
public Material roadMaterialEdit;
static public int backupLocation = 0;
public string[] backupStrings = new string[2]{"Outside Assets folder path","Inside Assets folder path"};
public Vector3[] leftVecs = new Vector3[0];
public Vector3[] rightVecs = new Vector3[0];
public bool applyTangents = false;
public bool sosBuild = false;
public float splinePos = 0;
public float camHeight = 3;
public Vector3 splinePosV3 = Vector3.zero;
public bool blendFlag; 
public float startBlendDistance = 5;
public float endBlendDistance = 5;
public bool iOS = false;
static public string extensionPath = "";
public void OCDCQQQCCQ(List<ODODDQQO> arr, String[] DOODQOQO, String[] OODDQOQO){

OQOQCQOOOQ(transform, arr, DOODQOQO, OODDQOQO);
}
public void OOOOCCOOOO(MarkerScript markerScript){

ODDODDCCDC = markerScript.transform;



List<GameObject> tmp = new List<GameObject>();
for(int i=0;i<ODDODDCCDCs.Length;i++){
if(ODDODDCCDCs[i] != markerScript.gameObject)tmp.Add(ODDODDCCDCs[i]);
}




tmp.Add(markerScript.gameObject);
ODDODDCCDCs = tmp.ToArray();
ODDODDCCDC = markerScript.transform;

OOCQCQDOQO.OOODCCQQDD(ODDODDCCDC, ODDODDCCDCs, markerScript.OODCCQOOOQ, markerScript.OODDCQQOOD, OCCQODODOD, out markerScript.ODDODDCCDCs, out markerScript.trperc, ODDODDCCDCs);

OCODOOCDCO = -1;
}
public void OCOOCQQCOO(MarkerScript markerScript){
if(markerScript.OODDCQQOOD != markerScript.ODOOQQOO || markerScript.OODDCQQOOD != markerScript.ODOOQQOO){
OOCQCQDOQO.OOODCCQQDD(ODDODDCCDC, ODDODDCCDCs, markerScript.OODCCQOOOQ, markerScript.OODDCQQOOD, OCCQODODOD, out markerScript.ODDODDCCDCs, out markerScript.trperc, ODDODDCCDCs);
markerScript.ODQDOQOO = markerScript.OODCCQOOOQ;
markerScript.ODOOQQOO = markerScript.OODDCQQOOD;
}
if(OQQCCDODCO.autoUpdate) OCOQDDCCDC(OQQCCDODCO.geoResolution, false, false);
}
public void ResetMaterials(MarkerScript markerScript){
if(OOCQCQDOQO != null)OOCQCQDOQO.OOODCCQQDD(ODDODDCCDC, ODDODDCCDCs, markerScript.OODCCQOOOQ, markerScript.OODDCQQOOD, OCCQODODOD, out markerScript.ODDODDCCDCs, out markerScript.trperc, ODDODDCCDCs);
}
public void OQODQCOOQC(MarkerScript markerScript){
if(markerScript.OODDCQQOOD != markerScript.ODOOQQOO){
OOCQCQDOQO.OOODCCQQDD(ODDODDCCDC, ODDODDCCDCs, markerScript.OODCCQOOOQ, markerScript.OODDCQQOOD, OCCQODODOD, out markerScript.ODDODDCCDCs, out markerScript.trperc, ODDODDCCDCs);
markerScript.ODOOQQOO = markerScript.OODDCQQOOD;
}
OCOQDDCCDC(OQQCCDODCO.geoResolution, false, false);
}
private void ODCDDODCQO(string ctrl, MarkerScript markerScript){
int i = 0;
foreach(Transform tr in markerScript.ODDODDCCDCs){
MarkerScript wsScript = (MarkerScript) tr.GetComponent<MarkerScript>();
if(ctrl == "rs") wsScript.LeftSurrounding(markerScript.rs - markerScript.ODOQQOOO, markerScript.trperc[i]);
else if(ctrl == "ls") wsScript.RightSurrounding(markerScript.ls - markerScript.DODOQQOO, markerScript.trperc[i]);
else if(ctrl == "ri") wsScript.LeftIndent(markerScript.ri - markerScript.OOQOQQOO, markerScript.trperc[i]);
else if(ctrl == "li") wsScript.RightIndent(markerScript.li - markerScript.ODODQQOO, markerScript.trperc[i]);
else if(ctrl == "rt") wsScript.LeftTilting(markerScript.rt - markerScript.ODDQODOO, markerScript.trperc[i]);
else if(ctrl == "lt") wsScript.RightTilting(markerScript.lt - markerScript.ODDOQOQQ, markerScript.trperc[i]);
else if(ctrl == "floorDepth") wsScript.FloorDepth(markerScript.floorDepth - markerScript.oldFloorDepth, markerScript.trperc[i]);
i++;
}
}
public void ODOQQOCOQO(){
if(markers > 1) OCOQDDCCDC(OQQCCDODCO.geoResolution, false, false);
}
public void OQOQCQOOOQ(Transform tr, List<ODODDQQO> arr, String[] DOODQOQO, String[] OODDQOQO){
version = "2.5.5";
OCDCDOQDOC = (GUISkin)Resources.Load("ER3DSkin", typeof(GUISkin));


OQQCQOOQCQ = (Texture2D)Resources.Load("ER3DLogo", typeof(Texture2D));
if(RoadObjectScript.objectStrings == null){
RoadObjectScript.objectStrings = new string[3];
RoadObjectScript.objectStrings[0] = "Road Object"; RoadObjectScript.objectStrings[1]="River Object";RoadObjectScript.objectStrings[2]="Procedural Mesh Object";
}
obj = tr;
OOCQCQDOQO = new ODDDQCOOOD();
OQQCCDODCO = obj.GetComponent<RoadObjectScript>();
foreach(Transform child in obj){
if(child.name == "Markers") OCCQODODOD = child;
}
RoadObjectScript[] rscrpts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
ODDDQCOOOD.terrainList.Clear();
Terrain[] terrains = (Terrain[])FindObjectsOfType(typeof(Terrain));
foreach(Terrain terrain in terrains) {
Terrains t = new Terrains();
t.terrain = terrain;
if(!terrain.gameObject.GetComponent<EasyRoads3DTerrainID>()){
EasyRoads3DTerrainID terrainscript = (EasyRoads3DTerrainID)terrain.gameObject.AddComponent<EasyRoads3DTerrainID>();
string id = UnityEngine.Random.Range(100000000,999999999).ToString();
terrainscript.terrainid = id;
t.id = id;
}else{
t.id = terrain.gameObject.GetComponent<EasyRoads3DTerrainID>().terrainid;
}
OOCQCQDOQO.OOQODOODCC(t);
}
ODQOOOQOQO.OOQODOODCC();
if(roadMaterialEdit == null){
roadMaterialEdit = (Material)Resources.Load("materials/roadMaterialEdit", typeof(Material));
}
if(objectType == 0 && GameObject.Find(gameObject.name + "/road") == null){
GameObject road = new GameObject("road");
road.transform.parent = transform;
}

OOCQCQDOQO.OOOCDOOQQD(obj, OODCQDQQQC, OQQCCDODCO.roadWidth, surfaceOpacity, out OCOCQCQODD, out indent, applyAnimation, waveSize, waveHeight);
OOCQCQDOQO.OCQOQOOOCD = OCQOQOOOCD;
OOCQCQDOQO.OQDODQCOQQ = OQDODQCOQQ;
OOCQCQDOQO.OdQODQOD = OdQODQOD + 1;
OOCQCQDOQO.OOQQQDOD = OOQQQDOD;
OOCQCQDOQO.OOQQQDODOffset = OOQQQDODOffset;
OOCQCQDOQO.OOQQQDODLength = OOQQQDODLength;
OOCQCQDOQO.objectType = objectType;
OOCQCQDOQO.snapY = snapY;
OOCQCQDOQO.terrainRendered = ODQDCQQQDO;
OOCQCQDOQO.handleVegetation = handleVegetation;
OOCQCQDOQO.raise = raise;
OOCQCQDOQO.roadResolution = roadResolution;
OOCQCQDOQO.multipleTerrains = multipleTerrains;
OOCQCQDOQO.editRestore = editRestore;
OOCQCQDOQO.roadMaterialEdit = roadMaterialEdit;
OOCQCQDOQO.renderRoad = renderRoad;
OOCQCQDOQO.rscrpts = rscrpts.Length;
OOCQCQDOQO.blendFlag = blendFlag; 
OOCQCQDOQO.startBlendDistance = startBlendDistance;
OOCQCQDOQO.endBlendDistance = endBlendDistance;

OOCQCQDOQO.iOS = iOS;

if(backupLocation == 0)OOOQODCODO.backupFolder = "/EasyRoads3D";
else OOOQODCODO.backupFolder =  OOOQODCODO.extensionPath + "/Backups";

ODODQOQO = OOCQCQDOQO.OCQDDDDCDO();
ODODQOQOInt = OOCQCQDOQO.OCODQCOODQ();


if(ODQDCQQQDO){




doRestore = true;
}


OOCDCCOCQD();

if(arr != null || ODODQOOQ == null) OOQQQCODCQ(arr, DOODQOQO, OODDQOQO);


if(doRestore) return;
}
public void UpdateBackupFolder(){
}
public void OCQQQOOOOC(){
if(!ODODDDOO || objectType == 2){
if(OQOCOQQOCQ != null){
for(int i = 0; i < OQOCOQQOCQ.Length; i++){
OQOCOQQOCQ[i] = false;
ODCQOOQDQO[i] = false;
}
}
}
}

public void OQQOODODDC(Vector3 pos){


if(!displayRoad){
displayRoad = true;
OOCQCQDOQO.OODQQOCCOO(displayRoad, OCCQODODOD);
}
pos.y += OQQCCDODCO.raiseMarkers;
if(forceY && ODOQDQOO != null){
float dist = Vector3.Distance(pos, ODOQDQOO.transform.position);
pos.y = ODOQDQOO.transform.position.y + (yChange * (dist / 100f));
}else if(forceY && markers == 0) lastY = pos.y;
GameObject go = null;
if(ODOQDQOO != null) go = (GameObject)Instantiate(ODOQDQOO);
else go = (GameObject)Instantiate(Resources.Load("marker", typeof(GameObject)));
Transform newnode = go.transform;
newnode.position = pos;
newnode.parent = OCCQODODOD;
markers++;
string n;
if(markers < 10) n = "Marker000" + markers.ToString();
else if (markers < 100) n = "Marker00" + markers.ToString();
else n = "Marker0" + markers.ToString();
newnode.gameObject.name = n;
MarkerScript scr = newnode.GetComponent<MarkerScript>();
scr.OCOCQCQODD = false;
scr.objectScript = obj.GetComponent<RoadObjectScript>();
if(ODOQDQOO == null){
scr.waterLevel = OQQCCDODCO.waterLevel;
scr.floorDepth = OQQCCDODCO.floorDepth;
scr.ri = OQQCCDODCO.indent;
scr.li = OQQCCDODCO.indent;
scr.rs = OQQCCDODCO.surrounding;
scr.ls = OQQCCDODCO.surrounding;
scr.tension = 0.5f;
if(objectType == 1){

pos.y -= waterLevel;
newnode.position = pos;
}
}
if(objectType == 2){
#if UNITY_3_5
if(scr.surface != null)scr.surface.gameObject.active = false;
#else
if(scr.surface != null)scr.surface.gameObject.SetActive(false);
#endif
}
ODOQDQOO = newnode.gameObject;
if(markers > 1){
OCOQDDCCDC(OQQCCDODCO.geoResolution, false, false);
if(materialType == 0){

OOCQCQDOQO.ODCCDODQOO(materialType);

}
}
}
public void OCOQDDCCDC(float geo, bool renderMode, bool camMode){
OOCQCQDOQO.OQDQCDDCOC.Clear();
int ii = 0;
ODQOQCDQQC k;
foreach(Transform child  in obj)
{
if(child.name == "Markers"){
foreach(Transform marker   in child) {
MarkerScript markerScript = marker.GetComponent<MarkerScript>();
markerScript.objectScript = obj.GetComponent<RoadObjectScript>();
if(!markerScript.OCOCQCQODD) markerScript.OCOCQCQODD = OOCQCQDOQO.OODCCDOQQO(marker);
k  = new ODQOQCDQQC();
k.position = marker.position;
k.num = OOCQCQDOQO.OQDQCDDCOC.Count;
k.object1 = marker;
k.object2 = markerScript.surface;
k.tension = markerScript.tension;
k.ri = markerScript.ri;
if(k.ri < 1)k.ri = 1f;
k.li =markerScript.li;
if(k.li < 1)k.li = 1f;
k.rt = markerScript.rt;
k.lt = markerScript.lt;
k.rs = markerScript.rs;
if(k.rs < 1)k.rs = 1f;
k.ODQQDQQCDD = markerScript.rs;
k.ls = markerScript.ls;
if(k.ls < 1)k.ls = 1f;
k.OCDQCQQQQQ = markerScript.ls;
k.renderFlag = markerScript.bridgeObject;
k.OODOCQCDQQ = markerScript.distHeights;
k.newSegment = markerScript.newSegment;
k.tunnelFlag = markerScript.tunnelFlag;
k.floorDepth = markerScript.floorDepth;
k.waterLevel = waterLevel;
k.lockWaterLevel = markerScript.lockWaterLevel;
k.sharpCorner = markerScript.sharpCorner;
k.ODQOOQQDOQ = OOCQCQDOQO;
markerScript.markerNum = ii;
markerScript.distance = "-1";
markerScript.OOCOCCDQOQ = "-1";
OOCQCQDOQO.OQDQCDDCOC.Add(k);
ii++;
}
}
}
distance = "-1";

OOCQCQDOQO.OQODCOCOOO = OQQCCDODCO.roadWidth;

OOCQCQDOQO.OOCDQCDQOC(geo, obj, OQQCCDODCO.OOQDOOQQ, renderMode, camMode, objectType);
if(OOCQCQDOQO.leftVecs.Count > 0){
leftVecs = OOCQCQDOQO.leftVecs.ToArray();
rightVecs = OOCQCQDOQO.rightVecs.ToArray();
}
}
public void StartCam(){

OCOQDDCCDC(0.5f, false, true);

}
public void OOCDCCOCQD(){
int i = 0;
foreach(Transform child  in obj)
{
if(child.name == "Markers"){
i = 1;
string n;
foreach(Transform marker in child) {
if(i < 10) n = "Marker000" + i.ToString();
else if (i < 100) n = "Marker00" + i.ToString();
else n = "Marker0" + i.ToString();
marker.name = n;
ODOQDQOO = marker.gameObject;
i++;
}
}
}
markers = i - 1;

OCOQDDCCDC(OQQCCDODCO.geoResolution, false, false);
}
public List<Transform> RebuildObjs(){
RoadObjectScript[] scripts = (RoadObjectScript[])FindObjectsOfType(typeof(RoadObjectScript));
List<Transform> rObj = new List<Transform>();
foreach (RoadObjectScript script in scripts) {
if(script.transform != transform) rObj.Add(script.transform);
}
return rObj;
}
public void RestoreTerrain1(){

OCOQDDCCDC(OQQCCDODCO.geoResolution, false, false);
if(OOCQCQDOQO != null) OOCQCQDOQO.ODDDCQDDDQ();
ODODDDOO = false;
}
public void OOCOOQDQQD(){
OOCQCQDOQO.OOCOOQDQQD(OQQCCDODCO.applySplatmap, OQQCCDODCO.splatmapSmoothLevel, OQQCCDODCO.renderRoad, OQQCCDODCO.tuw, OQQCCDODCO.roadResolution, OQQCCDODCO.raise, OQQCCDODCO.opacity, OQQCCDODCO.expand, OQQCCDODCO.offsetX, OQQCCDODCO.offsetY, OQQCCDODCO.beveledRoad, OQQCCDODCO.splatmapLayer, OQQCCDODCO.OdQODQOD, OOQQQDOD, OOQQQDODOffset, OOQQQDODLength);
}
public void OCQQCDOQQQ(){
OOCQCQDOQO.OCQQCDOQQQ(OQQCCDODCO.renderRoad, OQQCCDODCO.tuw, OQQCCDODCO.roadResolution, OQQCCDODCO.raise, OQQCCDODCO.beveledRoad, OQQCCDODCO.OdQODQOD, OOQQQDOD, OOQQQDODOffset, OOQQQDODLength);
}
public void OOQOCOCODD(Vector3 pos, bool doInsert){


if(!displayRoad){
displayRoad = true;
OOCQCQDOQO.OODQQOCCOO(displayRoad, OCCQODODOD);
}

int first = -1;
int second = -1;
float dist1 = 10000;
float dist2 = 10000;
Vector3 newpos = pos;
ODQOQCDQQC k;
ODQOQCDQQC k1 = (ODQOQCDQQC)OOCQCQDOQO.OQDQCDDCOC[0];
ODQOQCDQQC k2 = (ODQOQCDQQC)OOCQCQDOQO.OQDQCDDCOC[1];

OOCQCQDOQO.ODQOCDQODQ(pos, out first, out second, out dist1, out dist2, out k1, out k2, out newpos);
pos = newpos;
if(doInsert && first >= 0 && second >= 0){
if(OQQCCDODCO.OOQDOOQQ && second == OOCQCQDOQO.OQDQCDDCOC.Count - 1){
OQQOODODDC(pos);
}else{
k = (ODQOQCDQQC)OOCQCQDOQO.OQDQCDDCOC[second];
string name = k.object1.name;
string n;
int j = second + 2;
for(int i = second; i < OOCQCQDOQO.OQDQCDDCOC.Count - 1; i++){
k = (ODQOQCDQQC)OOCQCQDOQO.OQDQCDDCOC[i];
if(j < 10) n = "Marker000" + j.ToString();
else if (j < 100) n = "Marker00" + j.ToString();
else n = "Marker0" + j.ToString();
k.object1.name = n;
j++;
}
k = (ODQOQCDQQC)OOCQCQDOQO.OQDQCDDCOC[first];
Transform newnode = (Transform)Instantiate(k.object1.transform, pos, k.object1.rotation);
newnode.gameObject.name = name;
newnode.parent = OCCQODODOD;
MarkerScript scr = newnode.GetComponent<MarkerScript>();
scr.OCOCQCQODD = false;
float	totalDist = dist1 + dist2;
float perc1 = dist1 / totalDist;
float paramDif = k1.ri - k2.ri;
scr.ri = k1.ri - (paramDif * perc1);
paramDif = k1.li - k2.li;
scr.li = k1.li - (paramDif * perc1);
paramDif = k1.rt - k2.rt;
scr.rt = k1.rt - (paramDif * perc1);
paramDif = k1.lt - k2.lt;
scr.lt = k1.lt - (paramDif * perc1);
paramDif = k1.rs - k2.rs;
scr.rs = k1.rs - (paramDif * perc1);
paramDif = k1.ls - k2.ls;
scr.ls = k1.ls - (paramDif * perc1);
OCOQDDCCDC(OQQCCDODCO.geoResolution, false, false);
if(materialType == 0)OOCQCQDOQO.ODCCDODQOO(materialType);
#if UNITY_3_5
if(objectType == 2) scr.surface.gameObject.active = false;
#else
if(objectType == 2) scr.surface.gameObject.SetActive(false);
#endif
}
}
OOCDCCOCQD();
}
public void OOCDOCOCOC(){

DestroyImmediate(OQQCCDODCO.ODDODDCCDC.gameObject);
ODDODDCCDC = null;
OOCDCCOCQD();
}
public void ODOQDOCOOC(){

OOCQCQDOQO.OQQOQQDOQC(12);

}

public List<SideObjectParams> OQDCCCOCOD(){

List<SideObjectParams> param = new List<SideObjectParams>();
SideObjectParams sop;
foreach(Transform child in obj){
if(child.name == "Markers"){
foreach(Transform marker in child){
MarkerScript markerScript = marker.GetComponent<MarkerScript>();
sop  = new SideObjectParams();
sop.ODDGDOOO = markerScript.ODDGDOOO;
sop.ODDQOODO = markerScript.ODDQOODO;
sop.ODDQOOO = markerScript.ODDQOOO;
param.Add(sop);
}
}
}
return param;

}
public void OCCDDDOCDD(){

List<string> arrNames = new List<string>();
List<int> arrInts = new List<int>();
List<string> arrIDs = new List<string>();

for(int i=0;i<ODODOQQO.Length;i++){
if(ODODQQOD[i] == true){
arrNames.Add(ODODQOOQ[i]);
arrIDs.Add(ODODOQQO[i]);
arrInts.Add(i);
}
}
ODODDQOO = arrNames.ToArray();
OOQQQOQO = arrInts.ToArray();

}
public void OOQQQCODCQ(List<ODODDQQO> arr, String[] DOODQOQO, String[] OODDQOQO){




bool saveSOs = false;
ODODOQQO = DOODQOQO;
ODODQOOQ = OODDQOQO;






List<MarkerScript> markerArray = new List<MarkerScript>();
if(obj == null)OQOQCQOOOQ(transform, null, null, null);
foreach(Transform child  in obj) {
if(child.name == "Markers"){
foreach(Transform marker  in child) {
MarkerScript markerScript = marker.GetComponent<MarkerScript>();
markerScript.OQODQQDO.Clear();
markerScript.ODOQQQDO.Clear();
markerScript.OQQODQQOO.Clear();
markerScript.ODDOQQOO.Clear();
markerArray.Add(markerScript);
}
}
}
mSc = markerArray.ToArray();





List<bool> arBools = new List<bool>();



int counter1 = 0;
int counter2 = 0;

if(ODQQQQQO != null){

if(arr.Count == 0) return;



for(int i = 0; i < ODODOQQO.Length; i++){
ODODDQQO so = (ODODDQQO)arr[i];

for(int j = 0; j < ODQQQQQO.Length; j++){
if(ODODOQQO[i] == ODQQQQQO[j]){
counter1++;


if(ODODQQOD.Length > j ) arBools.Add(ODODQQOD[j]);
else arBools.Add(false);

foreach(MarkerScript scr  in mSc) {


int l = -1;
for(int k = 0; k < scr.ODDOOQDO.Length; k++){
if(so.id == scr.ODDOOQDO[k]){
l = k;
break;
}
}
if(l >= 0){
scr.OQODQQDO.Add(scr.ODDOOQDO[l]);
scr.ODOQQQDO.Add(scr.ODDGDOOO[l]);
scr.OQQODQQOO.Add(scr.ODDQOOO[l]);

if(so.sidewaysDistanceUpdate == 0 || (so.sidewaysDistanceUpdate == 2 && (float)scr.ODDQOODO[l] != so.oldSidwaysDistance)){
scr.ODDOQQOO.Add(scr.ODDQOODO[l]);

}else{
scr.ODDOQQOO.Add(so.splinePosition);

}




}else{
scr.OQODQQDO.Add(so.id);
scr.ODOQQQDO.Add(so.markerActive);
scr.OQQODQQOO.Add(true);
scr.ODDOQQOO.Add(so.splinePosition);
}

}
}
}
if(so.sidewaysDistanceUpdate != 0){



}
saveSOs = false;
}
}


for(int i = 0; i < ODODOQQO.Length; i++){
ODODDQQO so = (ODODDQQO)arr[i];
bool flag = false;
for(int j = 0; j < ODQQQQQO.Length; j++){

if(ODODOQQO[i] == ODQQQQQO[j])flag = true;
}
if(!flag){
counter2++;

arBools.Add(false);

foreach(MarkerScript scr  in mSc) {
scr.OQODQQDO.Add(so.id);
scr.ODOQQQDO.Add(so.markerActive);
scr.OQQODQQOO.Add(true);
scr.ODDOQQOO.Add(so.splinePosition);
}

}
}

ODODQQOD = arBools.ToArray();


ODQQQQQO = new String[ODODOQQO.Length];
ODODOQQO.CopyTo(ODQQQQQO,0);





List<int> arInt= new List<int>();
for(int i = 0; i < ODODQQOD.Length; i++){
if(ODODQQOD[i]) arInt.Add(i);
}
OOQQQOQO  = arInt.ToArray();


foreach(MarkerScript scr  in mSc) {
scr.ODDOOQDO = scr.OQODQQDO.ToArray();
scr.ODDGDOOO = scr.ODOQQQDO.ToArray();
scr.ODDQOOO = scr.OQQODQQOO.ToArray();
scr.ODDQOODO = scr.ODDOQQOO.ToArray();

}
if(saveSOs){

}




}
public bool CheckWaterHeights(){
if(ODQOOOQOQO.terrain == null) return false;
bool flag = true;

float y = ODQOOOQOQO.terrain.transform.position.y;
foreach(Transform child  in obj) {
if(child.name == "Markers"){
foreach(Transform marker  in child) {

if(marker.position.y - y <= 0.1f) flag = false;
}
}
}
return flag;
}
}
