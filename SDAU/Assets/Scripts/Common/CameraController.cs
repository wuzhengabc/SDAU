using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //观察目标
    public Transform Target;
    //观察距离
    public float Distance = 6F;
    public float yDistance = 3f;
    //旋转速度
    private float SpeedX = 240;
    private float SpeedY = 120;
    //角度限制
    private float MinLimitY = -15.0f;
    private float MaxLimitY = 90f;

    //旋转角度
    private float mX = 0.0F;
    private float mY = 0.0F;

    //鼠标缩放距离最值
    private float MaxDistance = 50f;
    private float MinDistance = -1.0F;
    //鼠标缩放速率
    private float ZoomSpeed = 2F;

    //是否启用差值
    public bool isNeedDamping = true;
    //速度
    public float Damping = 3F;
    //是否在寻路过程中
    private bool isAutoMove = false;

    private PlayerController controller;

    Quaternion mRotation;
    Vector3 mPosition;
    void Start()
    {        
        //初始化旋转角度
        mX = transform.eulerAngles.x;
        mY = transform.eulerAngles.y;

        controller = Target.GetComponent<PlayerController>();
    }
    void Update()
    {
        if (Distance > 8f)
        {
            MinLimitY = -3.0f;
        }
        else if (Distance < 3f)
        {
            MinLimitY = -30.0f;
        }
        else if(Distance < 3f)
        {
            MinLimitY = -30.0f;
        }
    }
    void LateUpdate()
    { 
        isAutoMove = controller.agent.hasPath && controller.agent.remainingDistance > controller.agent.radius;
        if (isAutoMove)
        {
            yDistance = 3;
            Distance = 6;
            mY = Target.localEulerAngles.x;
            mX = Target.localEulerAngles.y;
        }
        else if (!MiniMapController.GetInstance().isEnterMiniMap)
        {
            //鼠标右键旋转
            if (Input.GetMouseButton(1))
            {
                //获取鼠标输入
                mX += Input.GetAxis("Mouse X") * SpeedX * 0.02F;
                mY -= Input.GetAxis("Mouse Y") * SpeedY * 0.02F;
                //范围限制
                mY = ClampAngle(mY, MinLimitY, MaxLimitY);
            }

            //鼠标滚轮缩放
            Distance -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
            Distance = Mathf.Clamp(Distance, MinDistance, MaxDistance);
        }

        //重新计算位置和角度
        mRotation = Quaternion.Euler(mY, mX, 0);
        mPosition = mRotation * new Vector3(0.0F, yDistance, -Distance) + Target.position;

        if (isNeedDamping)
        {
            //球形插值
            transform.rotation = Quaternion.Lerp(transform.rotation, mRotation, Time.deltaTime * Damping);
            //线性插值
            transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * Damping);
        }
        else
        {
            transform.rotation = mRotation;
            transform.position = mPosition;
        }

        //将玩家转到和相机对应的位置上
        if (!isAutoMove && (controller.State == PlayerController.PlayerState.Walk || controller.State == PlayerController.PlayerState.Run))
        {
            Target.rotation = Quaternion.Slerp(Target.rotation, Quaternion.Euler(0, mX, 0), Time.deltaTime);
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}

