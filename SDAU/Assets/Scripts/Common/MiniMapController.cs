using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour 
{
    public bool isMiniMapFullScreen;
    public bool isEnterMiniMap;
    public string clickIconToolTip;
    public Vector3 clickPosition;
    public bool canMove;
    private KGFMapSystem miniMap;

    private static MiniMapController instance;

    public static MiniMapController GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }

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

    //全屏变换
    void OnFullscreenModeChanged(object theSender, EventArgs theArgs)
    {
        isMiniMapFullScreen = miniMap.GetFullscreen();
    }
    //鼠标进入小地图
    void OnMouseMapEntered(object theSender, EventArgs theArgs)
    {
        isEnterMiniMap = true;
    }
	//鼠标退出小地图
    void OnMouseMapLeft(object theSender, EventArgs theArgs)
    {
        isEnterMiniMap = false;
    }
    //鼠标点击小地图图标
    void OnMouseMapIconClicked(object theSender, EventArgs theArgs)
    {        
        KGFMapSystem.KGFMarkerEventArgs aMarkerArgs = (KGFMapSystem.KGFMarkerEventArgs)theArgs;
        clickIconToolTip = aMarkerArgs.itsMarker.GetToolTipText();
    }    
    //鼠标点击小地图
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
    //在小地图创建标志
    void OnUserFlagCreated(object theSender, EventArgs theArgs)
    {       
        //canMove = true;
        //KGFMapSystem.KGFFlagEventArgs aFlagArgs = (KGFMapSystem.KGFFlagEventArgs)theArgs;
        //clickPosition = aFlagArgs.itsPosition;        
    }
    //标志状态改变
    void OnVisibilityOnMinimapChanged(object theSender, EventArgs theArgs)
    {
        canMove = false;
        KGFMapSystem.KGFMarkerEventArgs aMarkerArgs = (KGFMapSystem.KGFMarkerEventArgs)theArgs;
        KGFMapIcon aMapIcon = (KGFMapIcon)aMarkerArgs.itsMarker;
    }
}
