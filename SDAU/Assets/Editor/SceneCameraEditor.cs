using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LookAtCamera))]
public class SceneCameraEditor : Editor
{
    void OnSceneGUI()
    {
        LookAtCamera lookAtCamera = (LookAtCamera)target;
        lookAtCamera.transform.LookAt(SceneView.lastActiveSceneView.camera.transform.position, Vector3.up);        
    }
}