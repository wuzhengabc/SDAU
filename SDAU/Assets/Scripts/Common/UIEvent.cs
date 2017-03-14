using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIEvent : MonoBehaviour
{
    #region 公共变量
    public Terrain terrain;
    public GameObject treeObj;
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
    private AudioSource musicSource;
    private string targetName = "";
    private bool isShow = false;
    private int preIndex;
    private Vector3 targetPosition;
    #endregion

    void CreatPanelTween(GameObject obj)
    {
        Tweener tweenerScale = obj.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
        tweenerScale.SetAutoKill(false);
        tweenerScale.Pause();
    }

    void Start()
    {
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

        for (int i = 0; i < panels.Length; i++)
        {
            CreatPanelTween(panels[i]);
        }
    }

    void Update()
    {        
        if(AIController.GetInstance().isArrive && AIController.GetInstance().targetPosition == targetPosition)
        {
            textInfo.text = "到达目的地\n" + targetName;
        }
        else if(AIController.GetInstance().targetPosition != targetPosition)
        {
            textInfo.text = "欢迎来到山东农业大学";
        }
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

    //计算到达目的地的路径    
    public void CalculateRoute(bool needArrive)
    {
        for (int i = 0; i < toggleGroup.Length; i++)
        {
            if (toggleGroup[i].isOn)
            {
                AIController.GetInstance().isArrive = false;
                targetName = toggleGroup[i].GetComponentInChildren<Text>().text;
                targetPosition = target[i].transform.position;
                AIController.GetInstance().targetPosition = targetPosition;
                AIController.GetInstance().DrawNavigationLine(targetPosition, needArrive, false);
                textInfo.text = "已设置目的地\n" + targetName;
                break;
            }
        }
        ShowPanel(1);
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
