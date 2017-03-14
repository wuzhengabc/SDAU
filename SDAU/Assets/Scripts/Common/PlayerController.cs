using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //音效相关
    public AudioClip walkSound;
    public AudioClip runSound;
    public AudioSource mySource;
    public NavMeshAgent agent;
    private float walkFireRate = 0.54f;
    private float runFireRate = 0.32f;
    private float nextFire = 0.0f;
    /*自由视角下的角色控制*/
    // 使用字符串变量保存当前状态，避免多处引用写错
    private static readonly string idleState = "BaseLayer.idle";
    private static readonly string walkState = "BaseLayer.walk";
    private static readonly string runState = "BaseLayer.run";
    private static readonly string jumpState = "BaseLayer.jump";
    //动画状态机参数Key
    private static readonly string actionId = "actionId";
    //玩家的行走速度
    public float WalkSpeed = 1.5F;
    public float RunSpeed = 3.5F;
    //重力
    public float Gravity = 20;

    //角色控制器
    private CharacterController mController;
    //动画组件
    private Animator mAnim;
    //玩家方向，默认向前
    private DirectionType mType = DirectionType.Direction_Forward;

    [HideInInspector]
    //玩家状态，默认为Idle
    public PlayerState State = PlayerState.Idle;

    //定义玩家的状态枚举
    public enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Jump
    }

    //定义四个方向的枚举值，按照逆时针方向计算
    protected enum DirectionType
    {
        Direction_Forward = 0,
        Direction_Backward = 179,
        Direction_Left = 270,
        Direction_Right = 90
    }

    void Start()
    {
        //获取角色控制器
        mController = GetComponent<CharacterController>();
        //获取动画组件
        mAnim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        MoveManager();
    }

    //玩家移动控制
    void MoveManager()
    {
        float v = 0;
        float h = 0;
        if (!(agent.hasPath && agent.remainingDistance > agent.radius))
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
        }
            
        //移动方向        
        Vector3 mDir = Vector3.zero;
        if (mController.isGrounded && agent.remainingDistance <= agent.radius)
        {
            //将角色旋转到对应的方向
            AnimatorStateInfo stateInfo = mAnim.GetCurrentAnimatorStateInfo(0);
            if (!stateInfo.IsName(idleState))
            {
                //每次设置完参数之后，都应该在下一帧开始时将参数设置清空，避免连续切换
                mAnim.SetInteger(actionId, 0);
                State = PlayerState.Idle;
            }

            if (v == 1)
                SetDirection(DirectionType.Direction_Forward);
            else if (v == -1)
                SetDirection(DirectionType.Direction_Backward);
            if (h == 1)
                SetDirection(DirectionType.Direction_Right);
            else if (h == -1)
                SetDirection(DirectionType.Direction_Left);
            if (v >= 0)
            {
                agent.ResetPath();
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    mDir = Vector3.forward * Time.deltaTime * RunSpeed * v;
                }
                else
                {
                    mDir = Vector3.forward * Time.deltaTime * WalkSpeed * v;
                }
            }
        }
        //考虑重力因素
        mDir = transform.TransformDirection(mDir);
        float y = mDir.y - Gravity * Time.deltaTime;
        mDir = new Vector3(mDir.x, y, mDir.z);
        mController.Move(mDir);

        PlayAnimatoin(h,v);
    }

    void PlaySound(float fireRate, AudioClip sound)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            mySource.PlayOneShot(sound);
        }
    }

    void PlayAnimatoin(float h, float v)
    {
        if (mController.velocity.z <= 0.1f)
        {
            mAnim.SetInteger(actionId, 0);
            State = PlayerState.Idle;
        }
        else if (mController.velocity.z > 0.1f && mController.velocity.z <= (WalkSpeed + 0.1f))
        {
            mAnim.SetInteger(actionId, 1);
            State = PlayerState.Walk;
            PlaySound(walkFireRate, walkSound);
        }
        else if (mController.velocity.z > (WalkSpeed + 0.1f))
        {
            mAnim.SetInteger(actionId, 2);
            State = PlayerState.Run;
            PlaySound(runFireRate, walkSound);
        }
        if (agent.hasPath && agent.remainingDistance > agent.radius)
        {
            mAnim.SetInteger(actionId, 2);
            State = PlayerState.Run;
            PlaySound(runFireRate, walkSound);
        }
        if (h != 0 && mController.velocity.z <= 0.1f)
        {
            mAnim.SetInteger(actionId, 1);
            State = PlayerState.Walk;
            PlaySound(walkFireRate, walkSound);
        }
    }

    //设置角色的方向
    void SetDirection(DirectionType dir)
    {   
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.eulerAngles.y + (int)dir, 0), Time.deltaTime);
    }
}