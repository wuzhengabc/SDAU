@CustomEditor(EasyRoads3DTerrainID)
class TerrainEditorScript extends Editor
{
function OnSceneGUI()
{
if(Event.current.shift && RoadObjectScript.OQCOQQOCQD != null) Selection.activeGameObject = RoadObjectScript.OQCOQQOCQD.gameObject;
else RoadObjectScript.OQCOQQOCQD = null;
}
}
