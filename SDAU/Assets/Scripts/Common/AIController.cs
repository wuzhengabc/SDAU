using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public GameObject effect_click_prefab;
    public GameObject player;
    public GameObject mapIcon;
    public GameObject locateIcon;

    [HideInInspector]
    public Vector3 targetPosition;
    [HideInInspector]
    public bool isArrive = false;

    private LineRenderer lineRenderer;
    private NavMeshAgent agent;
    private bool canArrive = false;
    private bool hasDestination = false;
    private Transform flag;
    private GameObject icon;

    private static AIController instance;

    public static AIController GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }

	void Start () 
    {
        icon = GameObject.Instantiate(locateIcon, Vector3.zero, Quaternion.identity);
        icon.SetActive(false);

        flag = GameObject.Find("flags").transform;
        lineRenderer = GameObject.Find("NavigationLine").GetComponent<LineRenderer>();
        agent = player.GetComponent<NavMeshAgent>();
	}
	
	void Update () 
    {
        if (flag != null && flag.transform.childCount <= 0 && MiniMapController.GetInstance().isEnterMiniMap && !hasDestination)
        {
            lineRenderer.enabled = false;
        }
        if (MiniMapController.GetInstance().canMove)
        {
            targetPosition = MiniMapController.GetInstance().clickPosition;
            DrawNavigationLine(MiniMapController.GetInstance().clickPosition, false, true);
            MiniMapController.GetInstance().canMove = false;
        }
        //自动寻路
        if (!MiniMapController.GetInstance().isEnterMiniMap && Input.GetMouseButtonDown(2))
        {
            agent.enabled = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                targetPosition = hit.point;
                ShowClickEffect(hit.point);
                DrawNavigationLine(hit.point, true, false);
            }
        }
        if (isArrive)
        {
            icon.SetActive(false);
            lineRenderer.enabled = false;
            if (flag != null && flag.transform.childCount > 0)
            {
                Destroy(flag.transform.GetChild(0).gameObject);
            }
        }
        isArrive = Vector3.Distance(player.transform.position, targetPosition) < 2;
	}

    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
        GameObject.Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }

    public void DrawNavigationLine(Vector3 targetPos, bool needArrive, bool isMiniMap)
    {
        if (!isMiniMap)
        {
            if (flag != null && flag.transform.childCount > 0)
            {
                Destroy(flag.transform.GetChild(0).gameObject);
            }
        }
        isArrive = false;
        NavMeshPath path = new NavMeshPath();
        bool hasFoundPath = agent.CalculatePath(targetPos, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            lineRenderer.enabled = true;
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
            lineRenderer.enabled = false;
            canArrive = false;
            print("只能到达目的地附近！");
        }
        else if (path.status == NavMeshPathStatus.PathInvalid)
        {
            lineRenderer.enabled = false;
            canArrive = false;
            print("无法到达目的地！");
        }

        if (needArrive && canArrive && !isMiniMap)
        {
            agent.path = path;
            agent.destination = targetPosition;
            hasDestination = true;
            GameObject.Instantiate(mapIcon, targetPosition, Quaternion.identity, flag);
            Vector3 lacateIconPosition = new Vector3(targetPosition.x, 1.5f, targetPosition.z);
            icon.transform.localPosition = lacateIconPosition;
            icon.SetActive(true);
        }
        else
        {
            hasDestination = false;
        }
    }
}
