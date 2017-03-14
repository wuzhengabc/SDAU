using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using System;

public class UIEvent : MonoBehaviour
{
    #region 公共变量
    public Terrain terrain;
    public GameObject treeObj;
    public GameObject effect_click_prefab;
    public GameObject[] panels;
    public GameObject character;
    public Text textInfo;
    public Slider BGM;
    public Slider music;
    public Slider quality;
    public Slider shadow;
    public Slider grass;
    public Slider tree;

    public Toggle toggleWindow;
    public Toggle toggleFullScreen;
    public Dropdown setResolution;
    public Toggle[] toggleGroup;
    public Light lighting;    
    public Slider siderBGM;
    public Slider sliderMusic;
    public Slider sliderQuality;
    public Slider sliderShadow;
    public Slider sliderGrass;
    public GameObject[] target;
    public AudioSource soundSource;
    #endregion

    #region 私有变量
    private LineRenderer lineRenderer;
    private AudioSource musicSource;
    private NavMeshAgent agent;
    private bool isArrive = false;
    private bool canArrive = false;
    private string targetName = "";
    private bool isShow = false;
    private bool hasDestination = false;
    private Vector3 targetPosition;
    private int preIndex;
    Transform flag;
    #endregion

    void CreatPanelTween(GameObject obj)
    {
        Tweener tweenerScale = obj.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
        tweenerScale.SetAutoKill(false);
        tweenerScale.Pause();
    }

    void Start()
    {
        flag = GameObject.Find("flags").transform;
        lineRenderer = GameObject.Find("NavigationLine").GetComponent<LineRenderer>();
        setResolution.ClearOptions();
        Resolution[] resolutions = Screen.resolutions;
        for ( int i = 0; i < resolutions.Length; i++)
        {
            Dropdown.OptionData item = new Dropdown.OptionData();
            item.text = resolutions[i].width + "x" + resolutions[i].height;
            setResolution.options.Add(item);
        }
        for (int j = 0; j < setResolution.options.Count; j++)
        {
            Dropdown.OptionData item = setResolution.options[j];
            if (item.text == Screen.width + "x" + Screen.height)
                setResolution.value = j;
        }
        
        musicSource = GetComponent<AudioSource>();
        agent = character.GetComponent<NavMeshAgent>();

        for (int i = 0; i < panels.Length; i++)
        {
            CreatPanelTween(panels[i]);
        }
    }

    void Update()
    {
        if (flag != null && flag.transform.childCount <= 0 && MiniMapController.isEnterMiniMap && !hasDestination)
        {
            lineRenderer.enabled = false;
        }

        if (MiniMapController.canMove)
        {
            targetPosition = MiniMapController.clickPosition;
            DrawNavigationLine(MiniMapController.clickPosition, false, true);
            MiniMapController.canMove = false;
        }
        //自动寻路
        if (!MiniMapController.isEnterMiniMap && Input.GetMouseButtonDown(2))
        {
            agent.enabled = true;            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                targetName = "";
                textInfo.text = "欢迎来到山东农业大学";
                targetPosition = hit.point;
                ShowClickEffect(hit.point);
                DrawNavigationLine(hit.point, true, false);
            }
        }
        if (isArrive)
        {
            lineRenderer.enabled = false;
            textInfo.text = "已到达目的地\n" + targetName;
            if (flag != null && flag.transform.childCount > 0)
            {
                Destroy(flag.transform.GetChild(0).gameObject);
            }
        }
        isArrive = Vector3.Distance(character.transform.position, targetPosition) < 2;
        //设置图像质量        
        if (quality.value == 1)
        {
            int sliderValue = (int)sliderQuality.value;
            sliderQuality.gameObject.SetActive(true);

            QualitySettings.anisotropicFiltering = (AnisotropicFiltering)sliderValue;
            QualitySettings.SetQualityLevel((int)(sliderQuality.value * 5), true);
            QualitySettings.antiAliasing = (int)(sliderQuality.value * 8);                           
        }
        else
        {
            sliderQuality.gameObject.SetActive(false);
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            QualitySettings.SetQualityLevel(3, true);
            QualitySettings.antiAliasing = 2;
        }

        //设置阴影质量
        if (shadow.value == 1)
        {
            sliderShadow.gameObject.SetActive(true);
            if (sliderShadow.value <= 0.5f)
                lighting.shadows = LightShadows.Hard;
            else
                lighting.shadows = LightShadows.Soft;
        }
        else
        {
            sliderShadow.gameObject.SetActive(false);
            lighting.shadows = LightShadows.None;
        }

        //设置背景音乐
        if (BGM.value == 1)
        {
            siderBGM.gameObject.SetActive(true);          
            //调节音量
            musicSource.volume = siderBGM.value;
        }
        else
        {
            siderBGM.gameObject.SetActive(false);           
        }
        //设置音效
        if (music.value == 1)
        {
            sliderMusic.gameObject.SetActive(true);
            //调节音量
            soundSource.volume = sliderMusic.value;
        }
        else
        {
            sliderMusic.gameObject.SetActive(false);
        }
        //设置草地密度
        if (grass.value == 1)
        {
            sliderGrass.gameObject.SetActive(true);
            //调节密度
            terrain.detailObjectDensity = sliderGrass.value;
        }
        else
        {
            terrain.detailObjectDensity = 0;
            sliderGrass.gameObject.SetActive(false);
        }

        treeObj.SetActive(tree.value == 1);

        //显示模式设置
        if (toggleFullScreen.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
    
    void DrawNavigationLine(Vector3 targetPos, bool needArrive, bool isMiniMap)
    {
        if(!isMiniMap)
        {
            if (flag != null && flag.transform.childCount > 0)
            {
                Destroy(flag.transform.GetChild(0).gameObject);
            }
        }
        isArrive = false;
        lineRenderer.enabled = true;
        NavMeshPath path = new NavMeshPath();
        bool hasFoundPath = agent.CalculatePath(targetPos, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            print("可以到达目的地！");
            canArrive = true;
            lineRenderer.numPositions = path.corners.Length;
            for (int i = 0; i < path.corners.Length; i++)
            {
                lineRenderer.SetPosition(i, path.corners[i]);
            }
        }
        else if (path.status == NavMeshPathStatus.PathPartial)
        {
            canArrive = false;
            print("只能到达目的地附近！");
        }
        else if (path.status == NavMeshPathStatus.PathInvalid)
        {
            canArrive = false;
            print("无法到达目的地！");
        }
        //if (needArrive)
        //{
        //    ShowClickEffect(targetPos);
        //}
        if (needArrive && canArrive && !isMiniMap)
        {
            agent.path = path;
            agent.destination = targetPosition;
            hasDestination = true;
        }
        else
        {
            hasDestination = false;
        }
    }

    //计算到达目的地的路径    
    public void CalculateRoute(bool needArrive)
    {
        agent.enabled = true;
        for (int i = 0; i < toggleGroup.Length; i++)
        {
            if (toggleGroup[i].isOn)
            {
                isArrive = false;
                targetName = toggleGroup[i].GetComponentInChildren<Text>().text;
                textInfo.text = "目的地：" + targetName;
                targetPosition = target[i].transform.position;
                DrawNavigationLine(targetPosition, needArrive, false);
                break;
            }
        }
        ShowPanel(1);
    }

    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
        GameObject.Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }
    //退出
    public void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// 显示窗口
    /// </summary>
    /// <param name="index">0：设置；1：地点；2：帮助；3：关于；4：退出</param>
    public void ShowPanel(int index)
    {
        if (!isShow)
            preIndex = index;
        if(preIndex != index)
        {
            return;
        } 
        if (!isShow)
        {
            panels[index].transform.DOPlayForward();
            isShow = true;
        }
        else
        {
            panels[index].transform.DOPlayBackwards();
            isShow = false;
        }
    }
    //音乐控制
    public void Music()
    {
        if (BGM.value == 1)
        {            
            musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }
    }
    public void Sound()
    {
        if (music.value == 1)
        {
            soundSource.volume = 1;
        }
        else
        {
            soundSource.volume = 0;
        }
    }

    //设置分辨率
    public void SaveDisplayResolution()
    {
        string[] selectes = setResolution.captionText.text.Split('x');
        int width = int.Parse(selectes[0]);
        int height = int.Parse(selectes[1]);
        Screen.SetResolution(width, height, toggleFullScreen.isOn);
    }
}
