using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MarkUI : MonoBehaviour
{
    private Transform canvas;
    private GameObject markUI;
    private GameObject mark = null;
    private Vector3 position = Vector3.zero;
    private Text text;
    private bool isUI = false;
	void Start ()
    {
        canvas = GameObject.Find("MainUI").transform;
        markUI = Resources.Load("MarkUI") as GameObject;
        mark = Instantiate(markUI, position, Quaternion.identity, canvas) as GameObject;
        text = mark.GetComponentInChildren<Text>();
        mark.SetActive(false);
        
	}
	
	void Update () 
    {
        isUI = EventSystem.current.IsPointerOverGameObject();
        //显示鼠标划过的物体名称
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.parent != null && hit.transform.parent.CompareTag("canClick") && !isUI && !MiniMapController.GetInstance().isEnterMiniMap && !Loading.isLoading)
            {
                mark.transform.position = Input.mousePosition;
                mark.SetActive(true);
                text.text = hit.transform.parent.name;
            }
            else
            {
                mark.SetActive(false);
            }
        }
        if (hit.transform == null)
        {
            mark.SetActive(false);
        }
	}
}
