using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour 
{
    public static bool isMiniMapFullScreen;
    public static bool isEnterMiniMap;
    public static string clickIconToolTip;
    public static Vector3 clickPosition;
    public static bool canMove;
    private KGFMapSystem miniMap;
    void Start () 
    {
        miniMap = GameObject.Find("MiniMap").GetComponent<KGFMapSystem>();
        KGFAccessor.GetExternal<KGFMapSystem>(OnMapSystemRegistered);
	}
    
    void OnMapSystemRegistered(object theSender, EventArgs theArgs)
    {
        KGFAccessor.KGFAccessorEventargs anArgs = (KGFAccessor.KGFAccessorEventargs)theArgs;
        miniMap = (KGFMapSystem)anArgs.GetObject();
        //全屏变换
        miniMap.EventFullscreenModeChanged += OnFullscreenModeChanged;
        //鼠标进入小地图
        miniMap.EventMouseMapEntered += OnMouseMapEntered;
        //鼠标退出小地图
        miniMap.EventMouseMapLeft += OnMouseMapLeft;
        //鼠标点击小地图图标
        miniMap.EventMouseMapIconClicked += OnMouseMapIconClicked;
        //鼠标点击小地图
        miniMap.EventClickedOnMinimap += OnClickedOnMinimap;
        //在小地图创建标志
        miniMap.EventUserFlagCreated += OnUserFlagCreated;
        //标志状态改变
        miniMap.EventVisibilityOnMinimapChanged += OnVisibilityOnMinimapChanged;
    }

    void OnFullscreenModeChanged(object theSender, EventArgs theArgs)
    {
        isMiniMapFullScreen = miniMap.GetFullscreen();
    }

    void OnMouseMapEntered(object theSender, EventArgs theArgs)
    {
        isEnterMiniMap = true;
    }

    void OnMouseMapLeft(object theSender, EventArgs theArgs)
    {
        isEnterMiniMap = false;
    }
    void OnMouseMapIconClicked(object theSender, EventArgs theArgs)
    {        
        KGFMapSystem.KGFMarkerEventArgs aMarkerArgs = (KGFMapSystem.KGFMarkerEventArgs)theArgs;
        clickIconToolTip = aMarkerArgs.itsMarker.GetToolTipText();
    }    
        
    void OnClickedOnMinimap(object theSender, EventArgs theArgs)
    {
        Transform flag = GameObject.Find("flags").transform;
        if (flag != null && flag.transform.childCount > 0)
        {
            Destroy(flag.transform.GetChild(0).gameObject);
        }

        KGFMapSystem.KGFClickEventArgs aClickArgs = (KGFMapSystem.KGFClickEventArgs)theArgs;
        canMove = true;
        clickPosition = aClickArgs.itsPosition;
    }

    void OnUserFlagCreated(object theSender, EventArgs theArgs)
    {       
        //canMove = true;
        //KGFMapSystem.KGFFlagEventArgs aFlagArgs = (KGFMapSystem.KGFFlagEventArgs)theArgs;
        //clickPosition = aFlagArgs.itsPosition;        
    }
    void OnVisibilityOnMinimapChanged(object theSender, EventArgs theArgs)
    {
        canMove = false;
        KGFMapSystem.KGFMarkerEventArgs aMarkerArgs = (KGFMapSystem.KGFMarkerEventArgs)theArgs;
        KGFMapIcon aMapIcon = (KGFMapIcon)aMarkerArgs.itsMarker;
    }
}
