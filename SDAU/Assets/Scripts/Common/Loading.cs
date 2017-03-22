using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public GameObject image;
    public static bool isLoading;
    KGFMapSystem miniMap;
    GameObject map;
    GameObject button;

    void Awake()
    {
        StartCoroutine(LoadScene());
    }

    void Update()
    {
        map = GameObject.Find("MiniMap");
        button = GameObject.Find("BottomButton");
        if (map != null && button != null)
        {
            miniMap = map.GetComponent<KGFMapSystem>();
            miniMap.SetMinimapSize(0f);
            button.transform.localScale = new Vector3(0,0,0);
            if (slider.value == 1)
            {
                isLoading = false;
                button.transform.localScale = new Vector3(1, 1, 1);
                miniMap.SetMinimapSize(0.25f);
            }
            else
                isLoading = true;
        }
    }

    //加载场景SDAU
    IEnumerator LoadScene()
    {        
        SceneManager.LoadSceneAsync("SDAU", LoadSceneMode.Additive);
        float i = 0;
        while (i <= 100)
        {
            i++;
            slider.value = i / 100;
            yield return new WaitForEndOfFrame();
        }
        image.SetActive(false);
    }

    public void ShowPercentage(float value)
    {
        text.text = Mathf.RoundToInt(value * 100) + "%";
    }
}