using System;
using System.Collections.Generic;
using UnityEngine;

public class AllFuncClass 
{
    //Drag drag = new Drag();//拖动物体旋转
    //HPSlider hPSlider = new HPSlider();//血条跟随
    //Ox2Ox4 x = new Ox2Ox4();//二进制
    //Foreach Foreach = new Foreach();//for循环用法
    //AnyClass anyClass = new AnyClass();//获得任意属性的相关类
    //Methods methods = new Methods();//多种算法
    //ParticleCtrl particleCtrl = new ParticleCtrl();//特效控制
    //ActorAnimation actorAnimation = new ActorAnimation();//动画控制
    //AStar aStar = new AStar();//A*算法
    //ClickTargetRotate clickTargetRotate = new ClickTargetRotate();//点击一个物体 然后移动鼠标会旋转物体 旋转角度不确定 有点问题 不完美
    //loadScene 场景跳转
    //cameraRotate
    //asdasdsaasdasd
}
public class Drag
{
    //drag旋转！！！！
    //1.using UnityEngine.EventSystems;
    //2. 继承 IDragHandler
    //3. 方法
    // public void OnDrag(PointerEventData eventData)
    //    {
    //        TargetObj.Rotate(0, eventData.delta.x * scrollRate, 0);
    //    }
}
public class HPSlider
{
    //血条跟随！！！！
    //1.
    //RectTransform rect;
    //if (rect!=null)
    //{
    //    rect.transform.position = Camera.main.WorldToScreenPoint(target.transform.position);
    //}
    //2.
    //Vector3 screenPoint = Camera.main.WorldToScreenPoint(target.transform.position);
    //screenPoint.z = 0;
    //        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
    //worldPos.z = 0;
    //        transform.localPosition = worldPos;

}
public class Ox2Ox4
{
    //public bool HasSoldierFlag(WinSoldierFlag _flag) { return (soldierFlag & (int)_flag) > 0; }
 //public void SetSoldierFlag(WinSoldierFlag _flag, bool _note)
 //{
 //    if (_note) soldierFlag |= (int)_flag;
 //    else
 //    {
 //        if ((soldierFlag & (int)_flag) > 0)
 //            soldierFlag ^= (int)_flag;
 //    }
 //}
}
public class Foreach
{
    //for (int i = 0; i<cmdList.Count;)
    //{
    //    ActionResult actionResult = cmdList[i].RunNode();
    //    if (actionResult == ActionResult.Success || actionResult == ActionResult.Failure)
    //    {
    //        PerformNode node = cmdList[i];
    //    NodePool.ReplacePool(node);
    //        cmdList.RemoveAt(i);
    //        continue;
    //     }
    //i++;
    //}
}
public class AnyClass
{
    List<a> GetDatas<a>(int num) where a : MonoBehaviour
    {
        return null;
    }
}
public class Methods
{
    public delegate void NewMethos();
    public event NewMethos showme;
    /// <summary>
    /// 洗牌算法
    /// </summary>
    /// <param name="targetList"></param>
    /// <returns></returns>
    public List<int> XiPai(List<int> targetList)
    {
        for (int i = 0; i < targetList.Count; i++)
        {
            int random = UnityEngine.Random.Range(i, targetList.Count);

            int num = targetList[random];
            targetList[random] = targetList[i];
            targetList[i] = num;
        }
        return targetList;
    }
}
#region /////////// 特效控制
//[ExecuteInEditMode]
//public class ParticleCtrl : MonoBehaviour
//{
//    public GameObject destroyGO;
//    public Transform rootTr;
//    public float destroyTime = 2;
//    [System.NonSerialized]
//    public Transform trans;

//    [HideInInspector]
//    [SerializeField]
//    public List<ParticleCtrl> mListChildParticleControl = new List<ParticleCtrl>();
//    [HideInInspector]
//    [SerializeField]
//    public List<ParticleSystem> mListChildParticle = new List<ParticleSystem>();
//    [HideInInspector]
//    [SerializeField]
//    public List<Animation> mListChildAnimation = new List<Animation>();
//    [HideInInspector]
//    [SerializeField]
//    public List<MeshRenderer> mListChildMeshRenderer = new List<MeshRenderer>();
//    [HideInInspector]
//    [SerializeField]
//    public List<Animator> mListChildAnimatorList = new List<Animator>();

//    public Action<ParticleCtrl> actionDestroy;
//    public bool destroy = false;

//    public float duration;
//    private float start;
//    private float pauseDuration = 0f;

//    protected bool turnOn;
//    public bool TurnOn
//    {
//        get { return turnOn; }
//        set
//        {
//            turnOn = value;
//            if (value == true)
//            {
//                start = Time.time;
//                PlayParticle();
//            }
//            else
//                StopParticle(true);
//        }
//    }
//    [HideInInspector]
//    public string path;
//    protected void Awake()
//    {
//        trans = transform;

//#if UNITY_EDITOR
//        if (!Application.isPlaying)
//            Init();                 // add child game objects into lists
//#endif

//#if UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)
//        Renderer[] rs = gameObject.GetComponentsInChildren<Renderer>();
//		foreach (Renderer r in rs) {
//			if (r != null && r.sharedMaterial != null) {
//				r.sharedMaterial.shader = Shader.Find(r.sharedMaterial.shader.name);
//			}
//		}
//#endif
//    }

//    protected void Update()
//    {
//        if (destroyGO == null)
//        {
//            if (TurnOn && duration > Mathf.Epsilon && Time.time - start > duration + pauseDuration)
//            {
//                TurnOn = false;
//                DestroyParticle();
//            }
//        }
//        else
//        {
//            if (!destroyGO.gameObject.activeSelf)
//            {
//                if (TurnOn && duration > Mathf.Epsilon && Time.time - start > duration + pauseDuration)
//                {
//                    TurnOn = false;
//                    DestroyParticle();
//                }
//            }
//        }
//    }


//    public void Init()
//    {
//#if UNITY_EDITOR
//        UnityEngine.Profiling.Profiler.BeginSample("ParticleCtrl init");
//#endif
//        mListChildParticleControl.Clear();
//        mListChildAnimation.Clear();
//        mListChildParticle.Clear();
//        mListChildMeshRenderer.Clear();
//        trans.GetComponentsInChildren(mListChildParticleControl);
//        trans.GetComponentsInChildren(mListChildAnimation);
//        trans.GetComponentsInChildren(mListChildParticle);
//        trans.GetComponentsInChildren(mListChildMeshRenderer);
//        trans.GetComponentsInChildren(mListChildAnimatorList);
//#if UNITY_EDITOR
//        UnityEngine.Profiling.Profiler.EndSample();
//#endif
//    }

//    void PlayParticle()
//    {
//        for (int i = 0; i < mListChildParticleControl.Count; i++)
//            mListChildParticleControl[i].turnOn = true;

//        for (int i = 0; i < mListChildParticle.Count; i++)
//        {
//            if (mListChildParticle[i] != null)
//            {
//                SwitchParticleRender(mListChildParticle[i], true);
//                mListChildParticle[i].Stop();
//                mListChildParticle[i].Play();
//            }
//        }

//        for (int i = 0; i < mListChildAnimation.Count; i++)
//        {
//            if (mListChildAnimation[i] != null)
//            {
//                mListChildAnimation[i].Stop();
//                foreach (AnimationState state in mListChildAnimation[i])
//                {
//                    state.time = 0f;
//                }
//                mListChildAnimation[i].Play();
//            }
//        }

//        for (int i = 0; i < mListChildMeshRenderer.Count; i++)
//        {
//            if (mListChildMeshRenderer[i] != null)
//                mListChildMeshRenderer[i].enabled = true;
//        }

//        for (int i = 0; i < mListChildAnimatorList.Count; i++)
//        {
//            if (mListChildAnimatorList[i] != null)
//            {
//                mListChildAnimatorList[i].StopPlayback();
//                mListChildAnimatorList[i].Play(0);
//            }
//        }
//    }

//    void SwitchParticleRender(ParticleSystem x, bool on_off)
//    {
//        if (x != null && x.GetComponent<Renderer>() != null)
//            x.GetComponent<Renderer>().enabled = on_off;

//        return;
//    }

//    public void StopParticle(bool _stopRenderer = true)
//    {
//        if (this == null)
//        {
//            return;
//        }

//        for (int i = 0; i < mListChildParticleControl.Count; i++)
//        {
//            if (mListChildParticleControl[i] != null && mListChildParticleControl[i] != this)
//                mListChildParticleControl[i].StopParticle(_stopRenderer);
//        }

//        for (int i = 0; i < mListChildParticle.Count; i++)
//        {
//            if (mListChildParticle[i] != null)
//            {
//                SwitchParticleRender(mListChildParticle[i], false);
//                mListChildParticle[i].Stop(true);
//            }
//        }

//        for (int i = 0; i < mListChildAnimation.Count; i++)
//        {
//            if (mListChildAnimation[i] != null)
//            {
//                if (_stopRenderer)
//                {
//                    Renderer render = mListChildAnimation[i].GetComponent<Renderer>();
//                    if (render != null)
//                        render.enabled = false;
//                }
//                mListChildAnimation[i].Stop();
//            }
//        }

//        if (_stopRenderer)
//        {
//            for (int i = 0; i < mListChildMeshRenderer.Count; i++)
//            {
//                if (mListChildMeshRenderer[i] != null)
//                    mListChildMeshRenderer[i].enabled = false;
//            }
//        }

//        for (int i = 0; i < mListChildAnimatorList.Count; i++)
//        {
//            if (mListChildAnimatorList[i] != null)
//                mListChildAnimatorList[i].StopPlayback();
//        }
//    }

//    public void PauseParticle(float _duration)
//    {
//        if (this == null)
//        {
//            return;
//        }

//        pauseDuration = _duration;
//        for (int i = 0; i < mListChildParticleControl.Count; i++)
//        {
//            if (mListChildParticleControl[i] != null)
//                mListChildParticleControl[i].turnOn = false;
//        }

//        for (int i = 0; i < mListChildParticle.Count; i++)
//        {
//            if (mListChildParticle[i] != null)
//                mListChildParticle[i].Pause(true);
//        }

//        for (int i = 0; i < mListChildAnimation.Count; i++)
//        {
//            if (mListChildAnimation[i] != null)
//            {
//                foreach (AnimationState state in mListChildAnimation[i])
//                {
//                    if (state.enabled)
//                        state.speed = 0f;
//                }
//            }
//        }

//        for (int i = 0; i < mListChildAnimatorList.Count; i++)
//        {
//            if (mListChildAnimatorList[i] != null)
//                mListChildAnimatorList[i].speed = 0f;
//        }
//    }

//    public void ResumeParticle()
//    {
//        if (this == null)
//        {
//            return;
//        }

//        for (int i = 0; i < mListChildParticleControl.Count; i++)
//        {
//            if (mListChildParticleControl[i] != null)
//                mListChildParticleControl[i].turnOn = true;
//        }

//        for (int i = 0; i < mListChildParticle.Count; i++)
//        {
//            if (mListChildParticle[i] != null)
//            {
//                mListChildParticle[i].Play(true);
//            }
//        }

//        for (int i = 0; i < mListChildAnimation.Count; i++)
//        {
//            if (mListChildAnimation[i] != null)
//            {
//                foreach (AnimationState state in mListChildAnimation[i])
//                {
//                    if (state.enabled)
//                        state.speed = 1f;
//                }
//            }
//        }

//        for (int i = 0; i < mListChildAnimatorList.Count; i++)
//        {
//            if (mListChildAnimatorList[i] != null)
//                mListChildAnimatorList[i].speed = 1f;
//        }
//    }

//    public void DestroyParticle()
//    {
//        if (this == null)
//            return;
//        TurnOn = false;
//        actionDestroy?.Invoke(this);
//        if (destroy && gameObject != null)
//        {
//            GameObject.Destroy(gameObject);
//        }
//    }

//    public void Strike()
//    {
//        if (destroyGO != null)
//        {
//            destroyGO.gameObject.SetActive(false);
//            duration = destroyTime;
//            start = Time.time;
//        }
//        else
//        {
//            DestroyParticle();
//        }
//    }

//    public void SetOffPos(Vector3 _pos)
//    {
//        if (rootTr != null)
//            rootTr.localPosition = _pos;
//    }

//    public void ResetData()
//    {

//    }
//}
#endregion
#region   /////// Animation
public struct PlayAnimInfo
{
    public string name;
    public float speed;
    public bool crossFade;
    public WrapMode warp;
    public Action<string> eventTrigger;
    public Action<bool> finishTrigger;
    public Action<bool> idleTrigger;
}

public class PlayAnimState
{
    public string name;
    public float speed;
    public WrapMode warp;
    public Action<string> eventTrigger;
    public Action<bool> finishTrigger;
    public Action<bool> idleTrigger;

    public bool bFinish;

    public PlayAnimState(PlayAnimInfo info)
    {
        this.name = info.name;
        this.speed = info.speed;
        this.warp = info.warp;
        this.eventTrigger = info.eventTrigger;
        this.finishTrigger = info.finishTrigger;
        this.idleTrigger = info.idleTrigger;
    }


    public bool TryDoFinish(bool cancel)
    {
        if (!bFinish)
        {
            bFinish = true;
            finishTrigger?.Invoke(cancel);
            return true;
        }

        return false;
    }
    public void PlayIdle()
    {
        idleTrigger?.Invoke(true);
    }
}

public class ActorAnimation : MonoBehaviour
{

    public const string IDLE_DEFAULT_NAME = "stand";

    string mIdleName;
    public string IdleAnimation
    {
        get
        {
            return mIdleName;
        }
    }

    public string CurrAnimation
    {
        get
        {
            if (mLastAnimState != null && !mLastAnimState.bFinish)
            {
                return mLastAnimState.name;
            }
            return IdleAnimation;
        }
    }

    //public static ActorAnimation Create(Animation ani, ActorModel actor)
    //{
    //    ActorAnimation ctr = ani.gameObject.GetOrAddComponent<ActorAnimation>();
    //    ctr.Init(ani, actor);
    //    return ctr;
    //}


    Animation mAnimation;
    PlayAnimState mLastAnimState;
    bool bIdleFreeze = false;

    HashSet<string> emptyAnimName;

    //ActorModel mActor;

    //void Init(Animation ani, ActorModel actor)
    //{
    //    mAnimation = ani;
    //    mActor = actor;
    //    ResetIdleName();
    //}

    public void SetIdleName(string idleName)
    {
        mIdleName = idleName;

        if (mAnimation != null)
        {
            CheckClipExist(mIdleName);
            if (mAnimation[mIdleName] != null && mAnimation[mIdleName].clip != null)
            {
                mAnimation[mIdleName].wrapMode = WrapMode.Loop;
            }
        }
    }

    void CheckClipExist(string aniName)
    {
        if (mAnimation != null && mAnimation[aniName] == null)
        {
            //AnimationClip clip = mActor.LoadAnimClip(aniName);
            //if (clip != null)
            //{
            //    mAnimation.AddClip(clip, clip.name);
            //}
        }
    }


    public void ResetIdleName()
    {
        SetIdleName(IDLE_DEFAULT_NAME);
    }

    public float GetAnimClipTime(string aniName)
    {
        CheckClipExist(aniName);
        if (mAnimation != null && mAnimation[aniName] != null)
        {
            return mAnimation[aniName].length;
        }

        return 0;
    }

    internal void PlayAnimation(PlayAnimInfo playInfo)
    {
        if (mLastAnimState != null)
        {
            mLastAnimState.TryDoFinish(true);
        }

        mLastAnimState = new PlayAnimState(playInfo);
        CheckClipExist(mLastAnimState.name);

        if (mAnimation[mLastAnimState.name] != null)
        {
            mAnimation[mLastAnimState.name].speed = mLastAnimState.speed;
            mAnimation[mLastAnimState.name].wrapMode = playInfo.warp;
            if (playInfo.warp == WrapMode.Once)
            {
                mAnimation[mLastAnimState.name].time = 0;
            }
            if (playInfo.speed < 0 && mAnimation[mLastAnimState.name].time == 0)
            {//倒放时将时间点移到最后
                mAnimation[mLastAnimState.name].time = mAnimation[mLastAnimState.name].length;
            }

            if (!playInfo.crossFade)
            {
                mAnimation.Play(mLastAnimState.name);
            }
            else
            {
                mAnimation.CrossFade(mLastAnimState.name, 0.1f);
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log(this.name + " not have ani:"+mLastAnimState.name);
#endif
        }

    }

    public void SetFreeze(bool bFreeze)
    {
        this.bIdleFreeze = bFreeze;
    }

    internal void Stop()
    {
        if (mLastAnimState != null)
        {
            mAnimation.Stop(mLastAnimState.name);
            mLastAnimState.TryDoFinish(true);
            mLastAnimState = null;
        }
    }

    internal void StopAll()
    {
        if (mLastAnimState != null)
        {
            mAnimation.Stop();
            mLastAnimState.TryDoFinish(true);
            mLastAnimState = null;
        }
        else//冰冻 或者石化 被异界之门带走之后因为mLastAnimState == null 也停止动画
            mAnimation.Stop();
    }


    private void Update()
    {
        if (mLastAnimState != null && !mLastAnimState.bFinish)
        {
            CheckAninFinish(mLastAnimState.name);
        }
    }

    void CheckAninFinish(string state)
    {
        if (!mAnimation.IsPlaying(state))
        {
            if (mLastAnimState.warp == WrapMode.Once && !bIdleFreeze)
            {//warp mode once 的动画在结束前使用回插入之前的动画
                if (mLastAnimState.idleTrigger != null)
                    mLastAnimState.PlayIdle();
                else
                    mAnimation.CrossFade(IdleAnimation, 0.1f);
            }
            mLastAnimState.TryDoFinish(false);

        }
    }

    public void AnimComplete(AnimationEvent _animationEvent)
    {
        if (mLastAnimState != null && !mLastAnimState.bFinish)
        {
            CheckAninFinish(mLastAnimState.name);
        }
    }

    public void EventTrigger(AnimationEvent animationEvent)
    {
        if (mLastAnimState != null && !mLastAnimState.bFinish && mLastAnimState.eventTrigger != null)
        {
            mLastAnimState.eventTrigger(animationEvent.stringParameter);
        }
    }

    internal bool HasAnim(string aniName)
    {
        if (emptyAnimName != null && emptyAnimName.Contains(aniName))
        {
            return false;
        }


        if (mAnimation.GetClip(aniName) != null)
        {
            return true;
        }

        //AnimationClip clip = mActor.LoadAnimClip(aniName);
        //if (clip != null)
        //{
        //    return true;
        //}
        //else
        //{
        //    if (emptyAnimName == null)
        //    {
        //        emptyAnimName = new HashSet<string>();
        //    }
        //    emptyAnimName.Add(aniName);
        //}

        return false;
    }

    public bool IsPlayAnim(string aniName)
    {
        return mAnimation.IsPlaying(aniName);
    }

    public void UpdateAnimSpeed(string animName, float speed)
    {
        if (mAnimation != null && mAnimation.GetClip(animName) != null)
        {
            mAnimation[animName].speed = speed;
        }
    }

    public void ResetAnimSpeed(string animName)
    {
        UpdateAnimSpeed(animName, 1);
    }

    internal void Clear()
    {
        this.bIdleFreeze = false;
        this.mIdleName = IDLE_DEFAULT_NAME;
    }

    internal void ClearAnimCallback(string aniName)
    {
        if (mLastAnimState != null && mLastAnimState.name == aniName)
        {
            mLastAnimState.finishTrigger = null;
            mLastAnimState.eventTrigger = null;
            mLastAnimState = null;
        }

    }
}
#endregion
#region //////// A*算法

public class AStar
{
    public class PriorityQueue 
    {
        Dictionary<PathNode, int> nodeList = new Dictionary<PathNode, int>();
        public void Put(PathNode node,int index) 
        {
            nodeList[node] = index;
        }
        public PathNode Get() 
        {
            int min = int.MaxValue;
            PathNode node = null;
            foreach (var item in nodeList.Keys)
            {
                if (nodeList[item]< min)
                {
                    node = item;
                    break;
                }
            }
            if (node!=null)
            {
                nodeList.Remove(node);
            }
            return node;
        }
        public bool IsEmpty() 
        {
            return nodeList.Count <= 0;
        }
    }

    public class PathNode
    {
        public int x;
        public int y;
        public int mappos;
        public PathNode(int _x,int _y,int row) 
        {
            x = _x;
            y = _y;
            mappos = x / row + y;
        }
        public PathNode(int _mappos, int row)
        {
            mappos = _mappos;
            x = mappos / row;
            y = mappos % row;
        }
    }
    public Dictionary<PathNode, PathNode> cameFrom = new Dictionary<PathNode, PathNode>();
    public Dictionary<PathNode, int> costFar = new Dictionary<PathNode, int>();
    public delegate bool IsFindTarget(PathNode node);
    //public IsFindTarget IsFindTarget;
    public List<PathNode> FindPath(int x,int y,int row, int targetPos)
    {

        PathNode end = new PathNode(targetPos, row);

        PathNode start = new PathNode(x, y, row);
        PriorityQueue frontier = new PriorityQueue();
        frontier.Put(start, 0);
        cameFrom.Clear();
        costFar.Clear();

        cameFrom[start] = null;
        costFar[start] = 0;
        PathNode currentNode = null;
        while (!frontier.IsEmpty())
        {
            PathNode current = frontier.Get();
            //if (current == targetPos)
            //{
            //    currentNode = current;
            //    break;
            //}
            //if (IsFindTarget!=null && IsFindTarget(current))
            //{
            //    break;
            //}

            //邻居节点
            List<PathNode> neighbors = new List<PathNode>();

            for (int i = 0; i < neighbors.Count; i++)
            {
                PathNode next = neighbors[i];
                int newCost = costFar[current] + Math.Abs(next.x - current.x) + Math.Abs(next.y - current.y);
                if (!costFar.ContainsKey(next) || newCost < costFar[next])
                {
                    costFar[next] = newCost;
                    int priority = newCost + Math.Abs(end.x - next.x) + Math.Abs(end.y - next.y);
                    frontier.Put(next, priority);
                    cameFrom[next] = current;
                }
            }
        }
        List<PathNode> allNodes = new List<PathNode>();
        if (currentNode!=null)
        {
            allNodes.Add(currentNode);
            while (cameFrom[currentNode] != null)
            {
                PathNode fromNode = cameFrom[currentNode];
                allNodes.Add(fromNode);
                currentNode = fromNode;
            }
        }
        return allNodes;
    }
}



#endregion
#region //////ClickTargetRotate
public class ClickTargetRotate : MonoBehaviour
{
    Vector3 NowPosition;
    Vector3 LastPosition;
    public Transform target;
    public Vector3 offset;
    Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, int.MaxValue))
            {
                Debug.Log("检测到物体");
                if (hit.transform != null)
                {
                    target = hit.transform;
                    offset = ray.direction - target.eulerAngles;
                }
            }
            NowPosition = Input.mousePosition;
            LastPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            target = null;
        }
    }
    private void LateUpdate()
    {
        NowPosition = Input.mousePosition;
        if (NowPosition != LastPosition)
        {
            if (target != null)
            {
                Debug.Log("now===" + NowPosition + "       last" + LastPosition);
                Vector3 rotate = Vector3.zero;
                rotate.x = NowPosition.x - LastPosition.x;
                rotate.y = NowPosition.y - LastPosition.y;
                target.RotateAround(Vector3.up, -rotate.x * Time.deltaTime);
                target.RotateAround(new Vector3(1, 0, 1), rotate.y * Time.deltaTime);
            }
            LastPosition = NowPosition;
        }
    }
    float rotSpeed = 20;
    private void OnMouseDrag()
    {
        //float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        //float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        //transform.RotateAround(Vector3.up, -rotX);
        //transform.RotateAround(new Vector3(1,0,1), rotY);
    }
}
#endregion
#region ///////cameraRotate
/*
public class CameraRotate : MonoBehaviour
{

    public static CameraRotate Instance;

    public bool AllowRotateInTutorial = false;

    private float Speed;
    /// <summary>
    /// 当前帧鼠标位置和按下的位置的距离
    /// </summary>
    private float CurrentMousePos = 0;
    /// <summary>
    /// 上一次移动结束时的最终距离差
    /// </summary>
    private float LastMousePos = 0;
    /// <summary>
    /// 设置手指最大移动距离
    /// </summary>
    private float MaxDis = 500;
    /// <summary>
    /// 鼠标按下的位置
    /// </summary>
    private Vector3 mFingerDownPos;
    /// <summary>
    /// 上一帧鼠标位置，用于计算速度
    /// </summary>
    private Vector3 lastFingerPos;

    private float mFingerDownTime;

    private void Awake()
    {
        Instance = this;
        this.transform.localRotation = SetMousePos(NowPosition);
    }

    //static Quaternion NowQuatation;
    static float NowPosition;
    public void OnEnterTownStage()
    {
    }

    private void OnDestroy()
    {
        Instance = null;

    }
    public bool mstartMove;
    bool startMove
    {
        get { return mstartMove; }
        set { mstartMove = value; }
    }

    public bool mCityUIShow;
    bool CityUIShow
    {
        get { return mCityUIShow; }
        set
        {
            mCityUIShow = value;
            if (GameSetting.actionCityUIShowChange != null)
                GameSetting.actionCityUIShowChange(value);
        }
    }



    long timerID = Curve.GenerInstanceID();

    Quaternion mInitRot = Quaternion.identity;
    Quaternion mLeftRot = Quaternion.Euler(new Vector3(0, -12f, 7.5f));
    Quaternion mRightRot = Quaternion.Euler(new Vector3(1.4f, 11.2f, -6.7f));

    public Quaternion mTaretRot;

    // Use this for initialization
    void Start()
    {
        mTaretRot = this.transform.localRotation;
        LastMousePos = NowPosition;

        ////左右交换
        //mRightRot = mInitRot * Quaternion.Euler(new Vector3(1.4f, 11.2f, -6.7f));
        //mLeftRot = mInitRot * Quaternion.Euler(new Vector3(0, -12f, 7.5f));
        //if (NowQuatation != null)
        //    transform.localRotation = NowQuatation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UIManager.RaycastUI(Input.mousePosition))
        {
            if (TutorialManager.IsUIAllowModel())
            {
                if (!AllowRotateInTutorial)
                    return;
            }
            //RaycastHit hiinfo;
            //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hiinfo))
            //{
            //    if (hiinfo.transform.GetComponent<CityUINode>() != null)
            //        return;
            //}
            if (PlayerStage.Instance.stageType != StageType.TownStage)
                return;

            startMove = true;
            mFingerDownPos = Input.mousePosition;
            mFingerDownTime = Time.realtimeSinceStartup;
            lastFingerPos = mFingerDownPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            LastMousePos = CurrentMousePos;
            NowPosition = CurrentMousePos;
            startMove = false;
            //if (Speed == 0 || !CanCurve)
            //{
            //    NowQuatation = transform.localRotation;
            //    CityUIShow = true;
            //    return;
            //}
            //CanCurve = false;
            //Curve.RemoverCurve(timerID);
            //Speed = Mathf.Clamp(Speed, -50, 50);
            //Curve.StartCurve(timerID, Ease.Type.Linear, Speed, 0, 0.2f, (x) =>
            //{
            //    LastMousePos += x;
            //    LastMousePos = Mathf.Clamp(LastMousePos, -500, 500);
            //    if (Speed >= 0)
            //    {
            //        Quaternion newRot = Quaternion.Lerp(mInitRot, mLeftRot, Mathf.Abs(LastMousePos / MaxDis));
            //        transform.localRotation = newRot;

            //        //transform.localRotation = Quaternion.Euler(new Vector3(1.4f, 11.2f, -6.7f) * -LastMousePos / MaxDis);
            //    }
            //    else
            //    {
            //        Quaternion newRot = Quaternion.Lerp(mInitRot, mRightRot, Mathf.Abs(LastMousePos / MaxDis));
            //        transform.localRotation = newRot;

            //        //transform.localRotation = Quaternion.Euler(new Vector3(0, -12f, 7.5f) * LastMousePos / MaxDis);
            //    }
            //}, () => {
            //    NowQuatation = transform.localRotation;
            //    CityUIShow = true;
            //    Speed = 0;
            //});
        }
    }

    void LateUpdate()
    {
        if (startMove)
        {
            Speed = Input.mousePosition.x - lastFingerPos.x;
            if (Speed == 0)
                return;
            if (Time.realtimeSinceStartup - mFingerDownTime <= 0.1f)
                return;
            if (CityUIShow)
                CityUIShow = false;
            CurrentMousePos = Input.mousePosition.x - mFingerDownPos.x;
            CurrentMousePos = CurrentMousePos + LastMousePos;
            CurrentMousePos = Mathf.Clamp(CurrentMousePos, -500, 500);
            NowPosition = CurrentMousePos;
            mTaretRot = SetMousePos(CurrentMousePos);
            lastFingerPos = Input.mousePosition;
        }

        transform.localRotation = Quaternion.Lerp(transform.localRotation, mTaretRot, Time.deltaTime * LerpSpeed);
        if (Quaternion.Angle(this.transform.localRotation, mTaretRot) < 0.01f)
        {
            //            NowQuatation = transform.localRotation;
            if (!CityUIShow && Speed == 0)
                CityUIShow = true;
            Speed = 0;
            transform.localRotation = mTaretRot;
        }
    }

    Quaternion SetMousePos(float mousePos)
    {
        if (mousePos == 0)
        {
            return mInitRot;
        }
        else if (mousePos > 0)
        {
            return Quaternion.Lerp(mInitRot, mLeftRot, Mathf.Abs(mousePos / MaxDis));
        }
        else
        {
            return Quaternion.Lerp(mInitRot, mRightRot, Mathf.Abs(mousePos / MaxDis));
        }
    }


    public float LerpSpeed = 5;
}
*/
#endregion
#region 场景加载
/*
public interface ILoadingWatcher
{
    bool IsFinish();
    float GetProgress();
}
public class CombineWatcher : ILoadingWatcher
{
    List<ILoadingWatcher> mList = new List<ILoadingWatcher>();


    public bool IsFinish()
    {
        if (Utils.IsNullOrEmpty(mList)) return false;

        for (int i = 0; i < mList.Count; i++)
        {
            if (!mList[i].IsFinish())
            {
                return false;
            }
        }
        return true;
    }

    public void AddWatcher(ILoadingWatcher watcher)
    {
        if (watcher == null) return;

        mList.Add(watcher);
    }

    public float GetProgress()
    {
        if (Utils.IsNullOrEmpty(mList)) return 0;

        float count = 0;
        for (int i = 0; i < mList.Count; i++)
        {
            if (!mList[i].IsFinish())
            {
                count += mList[i].GetProgress();
            }
            else
            {
                count += 1;
            }
        }

        return count / mList.Count;
    }
}
public class AutoLoadingWatcher : ILoadingWatcher
{
    float mBeingTime;
    float progressTime = 0.5f;

    public AutoLoadingWatcher()
    {
        mBeingTime = Time.time;
    }

    public bool IsFinish()
    {
        return true;
    }


    public float GetProgress()
    {
        float progess = (Time.time - mBeingTime) / progressTime;
        progess = Mathf.Clamp(progess, 0, 1);

        return progressTime;
    }

}
public class BattleLoadingWatcher : ILoadingWatcher
{
    bool pubLoadEnd;
    bool bCancel;

    public bool IsFinish()
    {
        return pubLoadEnd || bCancel;
    }

    public void Init()
    {
        bCancel = false;
    }

    public void Clear()
    {
        bCancel = true;
    }


    /// <summary>
    /// 计算战斗loading进度
    /// </summary>
    /// <returns></returns>
    public float GetProgress()
    {
        CombatStage stage = Stage.GetStage<CombatStage>();
        if (stage != null)
        {
            float progress = 0.5f;
            progress += CombatManager.Instance.LoadActorProgress() * 0.5f;
            return progress;
        }
        else
        {
            return 0;
        }
    }

    public void Update()
    {
        if (!pubLoadEnd)
        {
            if (CombatManager.Instance.IsLoadEnd())
            {
                pubLoadEnd = true;
            };
        }
    }

}

public class Stage 
{
    string sceneName;

    IEnumerator UnloadUnusedAssets(SceneLoadingWatcher loading, System.Action _callback)
    {
        AsyncOperation async = Resources.UnloadUnusedAssets();
        loading.Init(async);
        yield return async;
        BundleLoadHelper.GetInst().UpdateUnusedTime();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        _callback?.Invoke();
    }


    public void LoadScene(string _name, System.Action _callback = null)
    {
        sceneName = _name;
        if (_name != lastSceneName)
        {
            StartCoroutine(LoadSceneCoroutine(_name, _callback));
        }
        else
        {
            SceneLoadingWatcher loading = new SceneLoadingWatcher();
            LoadingWindow.OpenLoadingWnd(loading);
            StartCoroutine(UnloadUnusedAssets(loading, () =>
            {
                OnBuildScene(() =>
                {
                    TimerManager.StartFramer(1, TimeMode.Once, () =>
                    {
                        LoadingWindow.NoticeCloseLoading();
                    });
                    _callback?.Invoke();
                });
            }));
        }
    }
    IEnumerator LoadSceneCoroutine(string _name, System.Action _callback)
    {
        if (Application.CanStreamedLevelBeLoaded(_name))
        {
            SceneLoadingWatcher loading = new SceneLoadingWatcher();
            if (IsSpeedLoad)
            {
                LoadingWindow.OpenLoadingWnd(loading);
            }
            else
            {
                SceneLoadingWatcher loadingEmpty = new SceneLoadingWatcher();
                CombineWatcher combineLoadingProgress = new CombineWatcher();
                combineLoadingProgress.AddWatcher(loadingEmpty);
                combineLoadingProgress.AddWatcher(loading);
                LoadingWindow.OpenLoadingWnd(combineLoadingProgress);

                AsyncOperation emptyAsync = SceneManager.LoadSceneAsync("Empty");
                loadingEmpty.Init(emptyAsync);
                while (!emptyAsync.isDone)
                {
                    yield return null;
                }
                Resources.UnloadUnusedAssets();
            }


            AsyncOperation async = SceneManager.LoadSceneAsync(_name);
            loading.Init(async);
            //LoadingWindow.OpenLoadingWnd(loading);

            while (!async.isDone)
            {
                //win.SetProgress(async.progress);
                yield return null;
            }
            yield return null;

            ///////////////删除当前场景的窗口/////////////////
            DestoryLastStageWnd(lastStage);

            OnChangeSceneComplete();
            yield return null;
            Resources.UnloadUnusedAssets();
            BundleLoadHelper.GetInst().UpdateUnusedTime();
            yield return null;
            OnBuildScene(() => {
                TimerManager.StartFramer(1, TimeMode.Once, () => {
                    LoadingWindow.NoticeCloseLoading();
                });
                _callback?.Invoke();
            });
        }
        else
        {
            LoadingWindow.OpenLoadingWnd(new AutoLoadingWatcher());
            bool hasdownload = false;
            //float curMaxProcess = 0.3f;

            ///////////////场景文件载入/////////////////
            BundleRef sceneRef = BundleLoadHelper.GetInst().PreLoadScene(_name);

            //hasdownload = false;
            //AssetBundle sceneasset = null;
            //AssetLoader.Instance.DownLoad("Scene/" + _name + ".unity3d", (_www, _result) => {
            //    hasdownload = true;
            //    sceneasset = _www.assetBundle;
            //}, (_process) => {

            //}, WWWExistType.AlwaysExist);

            //while (!hasdownload)
            //    yield return null;

            ///////////////预加载/////////////////
            //curMaxProcess = 0.6f;
            hasdownload = false;
            PreLoading((f) =>
            {

            }, () =>
            {
                hasdownload = true;
            });

            while (!hasdownload)
                yield return null;

            ///////////////加载场景/////////////////
            //curMaxProcess = 0.95f;
            AsyncOperation async = SceneManager.LoadSceneAsync(_name);
            SceneLoadingWatcher loading = new SceneLoadingWatcher();
            loading.Init(async);
            LoadingWindow.RegistProcess(loading);
            yield return null;

            ///////////////晚一帧删除当前场景的窗口/////////////////
            DestoryLastStageWnd(lastStage);

            while (!async.isDone)
            {
                yield return null;
            }
            yield return null;
            OnChangeSceneComplete();
            yield return null;
            async = Resources.UnloadUnusedAssets();
            yield return async;
            BundleLoadHelper.GetInst().UnLoadScene(sceneRef);
            OnBuildScene(() =>
            {
                TimerManager.StartFramer(1, TimeMode.Once, () =>
                {
                    //UIManager.Instance.DistoryWindow<LoadingWindow>();
                    LoadingWindow.NoticeCloseLoading();
                });
                _callback?.Invoke();
            });
        }
    }
    void DestoryLastStageWnd(StageType type)
    {
        UIManager.Instance.DestoryWndByFlagType(UIFlagType.LoadingWnd, false);
        //switch (type)
        //{
        //    case StageType.MercenaryStage:
        //        UIManager.Instance.DestoryWndByFlagType(UIFlagType.MercenaryWnd);
        //        break;
        //    case StageType.JiaLanStage:
        //        UIManager.Instance.DestoryWndByFlagType(UIFlagType.JialanWnd);
        //        break;
        //    case StageType.EternalStage:
        //        UIManager.Instance.DestoryWndByFlagType(UIFlagType.EternalWnd);
        //        break;
        //}
    }
}
/// <summary>
/// 加载界面
/// </summary>
public class LoadingWindow : MyWindow
{
    [SerializeField]
    UISlider mSlider;
    [SerializeField]
    UILabel mLabProceess;
    [SerializeField]
    UILabel mLabLoadingTip;

    float mLastProgress = 0;

    static bool bWaitProcessEnd = false;
    static List<ILoadingWatcher> mProcessList = new List<ILoadingWatcher>();

    protected override void OnInitWindow()
    {
        IsLockDepth = true;
        IsIndependent = true;
        SetUIFlag(UIFlagType.LoadingWnd, true);
    }
    protected override void OnCloseWindow()
    {
        mLastProgress = 0;
    }
    public void SetProgress(float _value)
    {
        mSlider.value = _value;
        mLabProceess.text = (_value * 100).ToString("0.00") + "%";
    }

    protected override void OnUpdate()
    {
        UpdateProgress();

        if (mLastProgress >= 1)
        {
            UpdateProcessEnd();
        }


    }

    void UpdateProgress()
    {
        if (IsProcessing())
        {
            float newProgress = CalProgress();
            if (newProgress > mLastProgress)
            {
                mLastProgress = Mathf.MoveTowards(mLastProgress, newProgress, 0.05f);
            }
        }
        else
        {
            mLastProgress = Mathf.MoveTowards(mLastProgress, 1, 0.1f);
        }
        SetProgress(mLastProgress);
    }

    public static float CalProgress()
    {
        if (Utils.IsNullOrEmpty(mProcessList)) return 0;

        float progress = 0;
        for (int i = 0; i < mProcessList.Count; i++)
        {
            progress += mProcessList[i].GetProgress();
            //Debug.LogError(mProcessList[i] + "  =>"  + mProcessList[i].GetProgress());
        }

        progress /= mProcessList.Count;
        return progress;
    }

    public static void UpdateProcessEnd()
    {
        if (bWaitProcessEnd && !IsProcessing())
        {
            bWaitProcessEnd = false;
            ProcessClear();
            UIManager.Instance.DistoryWindow<LoadingWindow>();
            EventGenerator.FireEvent(GeneratorType.LoadingEnd);
        }
    }

    public static bool IsProcessing()
    {
        if (Utils.IsNullOrEmpty(mProcessList)) return false;

        for (int i = 0; i < mProcessList.Count; i++)
        {
            if (!mProcessList[i].IsFinish())
            {
                return true;
            }
        }

        return false;
    }

    public static void SetWaitEnd()
    {
        bWaitProcessEnd = true;
    }


    public static void ProcessClear()
    {
        mProcessList.Clear();
    }

    public static void RegistProcess(ILoadingWatcher process)
    {
        mProcessList.Add(process);
    }

    public static void OpenLoadingWnd(ILoadingWatcher process)
    {
        if (process == null) return;

        UIManager.Instance.OpenWindow<LoadingWindow>();
        RegistProcess(process);
    }

    public static void NoticeCloseLoading()
    {
        if (!IsProcessing())
        {
            ProcessClear();
            UIManager.Instance.DistoryWindow<LoadingWindow>();
            EventGenerator.FireEvent(GeneratorType.LoadingEnd);
        }
        else
        {
            SetWaitEnd();
        }
    }
}
/// <summary>
/// 占用bundle引用的对象
/// </summary>
public interface IBundleRefHolder
{
    string GetHoldName();

}


/// <summary>
///  管理Assetbundle的引用对象
/// </summary>
public class BundleRef : IBundleRefHolder
{
    public enum UnLoadType
    {
        /// <summary>
        /// unload bundle以及bundle内的全部资源
        /// </summary>
        AllClear,

        /// <summary>
        /// unload bundle，保留引用的资源
        /// </summary>
        BundleOnly
    }

    /// <summary>
    /// bundle地址
    /// </summary>
    public string bundleName;

    /// <summary>
    /// 记录bundle引用的其他bundle
    /// </summary>
    public Dictionary<string, BundleRef> refs = new Dictionary<string, BundleRef>();

    /// <summary>
    /// 记录bundle被其他对象引用的情况
    /// </summary>
    public Dictionary<string, IBundleRefHolder> reverseRefs = new Dictionary<string, IBundleRefHolder>();

    /// <summary>
    /// TODO
    /// 保留
    /// </summary>
    public bool bPersist;

    /// <summary>
    /// bundle资源
    /// </summary>
    public AssetBundle bundle;


    /// <summary>
    /// 标记这个bundle在等待AllClear的卸载，但是因为有被引用所以并没有被真正卸载
    /// 当不在被引用时应该用AllClear的方式卸载相关资源
    /// </summary>
    public bool waitClear;


    /// <summary>
    /// 实现 IBundleRefHolder接口
    /// </summary>
    /// <returns></returns>
    public string GetHoldName()
    {
        return bundleName;
    }
}

/// <summary>
/// 管理assetbundle的资源加载和卸载
/// </summary>
public class BundleLoadHelper
{


    static BundleLoadHelper _inst;
    public static BundleLoadHelper GetInst()
    {
        if (_inst == null)
        {
            _inst = new BundleLoadHelper();
        }
        return _inst;
    }

    /// <summary>
    /// 所有load的assetbundle资源列表
    /// </summary>
    Dictionary<string, BundleRef> mTab = new Dictionary<string, BundleRef>();

    /// <summary>
    /// manifest
    /// </summary>
    AssetBundleManifest mManifest;

    private BundleLoadHelper()
    {
        ReloadManifest();
    }


    /// <summary>
    /// 读取manifest文件
    /// 获取assetbundle的依赖关系
    /// </summary>
    void ReloadManifest()
    {
        AssetBundle bundle = null;
        if (AssetLoader.Instance.IsLocalFile("chaos"))
        {
            if (HasBundleFile("chaos"))
            {
                bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(AssetConst.INTER_FILE_PAHT, "chaos"));
            }
            else
            {
                Debug.LogWarning("not use assetbundle root file");
                bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(AssetConst.INTER_FILE_PAHT, "StreamingAssets"));
            }
        }
        else
        {
            bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(AssetConst.CACHE_FILE_ROOT, "chaos"));
        }

        //var bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(mLoadRootPath, "chaos"));
        mManifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
    }

    /// <summary>
    /// 获取bundle需要依赖的前置bundle
    /// </summary>
    /// <param name="bundleName"></param>
    /// <returns></returns>
    public string[] GetDependencies(string bundleName)
    {
        return mManifest.GetAllDependencies(bundleName);
    }

    /// <summary>
    /// 当列表里有对应的bundle引用，返回引用
    /// 没有时生成新的bundle引用加入列表
    /// </summary>
    /// <param name="bundleName"></param>
    /// <returns></returns>
    BundleRef GetBundleRef(string bundleName)
    {
        BundleRef refInfo;
        if (mTab.TryGetValue(bundleName, out refInfo))
        {
            return refInfo;
        }
        else
        {
            refInfo = new BundleRef();
            refInfo.bundleName = bundleName;
            mTab[bundleName] = refInfo;
            return refInfo;
        }
    }

    /// <summary>
    /// 直接从硬盘读取assetbundle文件
    /// </summary>
    /// <param name="bundleRef"></param>
    /// <param name="checkEditorMat">编辑器里预览时处理一下bundle中的材质，避免出现紫色的问题，在runtime这个值应该永远为false</param>
    void LoadImmediately(BundleRef bundleRef, bool checkEditorMat = true)
    {
        if (bundleRef.bundle == null)
        {
            if (AssetLoader.Instance.IsLocalFile(bundleRef.bundleName))
            {//需要从包内获取bundle文件
                bundleRef.bundle = AssetBundle.LoadFromFile(AssetConst.INTER_FILE_PAHT + bundleRef.bundleName);
                //Debuger.Log("0 load bundle : " + AssetConst.INTER_FILE_PAHT + bundleRef.bundleName, Color.red, (int)DebugerLayer.AssentBundle);
            }
            else
            {//从欲下载文件的目录获取bundle文件
                bundleRef.bundle = AssetBundle.LoadFromFile(AssetConst.CACHE_FILE_ROOT + bundleRef.bundleName);
                //Debuger.Log("1 load bundle : " + AssetConst.CACHE_FILE_ROOT + bundleRef.bundleName, Color.red, (int)DebugerLayer.AssentBundle);
            }

            if (checkEditorMat)
            {//处理编辑器显示bug
                EDITOR_CHECK(bundleRef.bundle);
            }
        }
    }

    /// <summary>
    /// 传入原有bundle引用，能够卸载的进行卸载处理
    /// </summary>
    /// <param name="bundleRef"></param>
    /// <param name="holder"></param>
    /// <param name="unLoadType"></param>
    public void UnLoadRef(BundleRef bundleRef, IBundleRefHolder holder, BundleRef.UnLoadType unLoadType = BundleRef.UnLoadType.BundleOnly)
    {
        //首先清除反向引用
        if (bundleRef.reverseRefs.ContainsKey(holder.GetHoldName()))
        {
            bundleRef.reverseRefs.Remove(holder.GetHoldName());
        }

        //判断卸载
        UnLoadRef(bundleRef, unLoadType);
    }

    /// <summary>
    /// 判断bundle是否已经没有别其他对象引用
    /// 计算当所有反向引用都已经释放的情况下卸载bundle资源
    /// </summary>
    /// <param name="bundleRef"></param>
    /// <param name="unLoadType"></param>
    void UnLoadRef(BundleRef bundleRef, BundleRef.UnLoadType unLoadType = BundleRef.UnLoadType.BundleOnly)
    {
        if (!mTab.ContainsKey(bundleRef.bundleName)) return;

        if (bundleRef.reverseRefs.Count == 0)
        {
            if (bundleRef.refs.Count > 0)
            {   //把bundle自己从自身引用的bunle的反向列表中清除
                foreach (BundleRef depend in bundleRef.refs.Values)
                {
                    depend.reverseRefs.Remove(bundleRef.bundleName);
                    if (depend.reverseRefs.Count == 0)
                    {//当引用对象的反向引用列表被清空时，也卸载引用的对象bundle
                        UnLoadRef(depend, unLoadType);
                    }
                }
            }

            if (bundleRef.bundle != null)
            {
                bool clearUnload = !bundleRef.waitClear ? (unLoadType == BundleRef.UnLoadType.AllClear ? true : false) : true;
                //Debuger.Log("unload bundle:"+bundleRef.bundleName+" type:" + clearUnload, Color.green, (int)DebugerLayer.AssentBundle);
                bundleRef.bundle.Unload(clearUnload);
                bundleRef.bundle = null;
            }

            mTab.Remove(bundleRef.bundleName);
        }
        else
        {//反向引用列表不为空，说明此bundle还在被其他bundle所引用的途中，不能卸载

            if (unLoadType == BundleRef.UnLoadType.AllClear)
            {//标记为等待完全卸载
                bundleRef.waitClear = true;
            }
        }
    }

    /// <summary>
    /// 更新bundle的依赖关系列表，
    /// 查找所有bundle需要依赖的bundel引用
    /// 增加自己的引用列表和对方的反向引用列表
    /// </summary>
    /// <param name="mainRef"></param>
    public void TouchDependencies(BundleRef mainRef)
    {
        foreach (var DependName in GetDependencies(mainRef.bundleName))
        {
            BundleRef dependRef = GetBundleRef(DependName);
            dependRef.reverseRefs[mainRef.GetHoldName()] = mainRef;
            mainRef.refs[dependRef.bundleName] = dependRef;
            LoadImmediately(dependRef);
        }

    }

    /// <summary>
    /// 预加载场景的assetbunle
    /// 当场景的assetbunlde被load以后，SceneManager才可以正常LoadLevel
    /// 可以不需要利用bundle的引用本身
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    public BundleRef PreLoadScene(string sceneName)
    {
        string bundleName = "scene/" + sceneName.ToLower();
        string path = string.Empty;
        if (AssetLoader.Instance.IsLocalFile(bundleName))
        {
            path = AssetConst.INTER_FILE_PAHT + bundleName;
        }
        else
        {
            path = AssetConst.CACHE_FILE_ROOT + bundleName;
        }

        BundleRef sceneRef = GetBundleRef(bundleName);

        TouchDependencies(sceneRef);
        LoadImmediately(sceneRef, false);
        //EDITORCHECK(b);

        return sceneRef;
    }

    /// <summary>
    /// 当Scene加载以后
    /// 卸载Scene需要load的assetbundle
    /// </summary>
    /// <param name="sceneRef"></param>
    public void UnLoadScene(BundleRef sceneRef)
    {
        UnLoadRef(sceneRef);
    }

    /// <summary>
    /// 判断是否有可供加载的assetbundle文件
    /// </summary>
    /// <param name="bundleName"></param>
    /// <returns></returns>
    bool HasBundleFile(string bundleName)
    {
        BundleRef refInfo;
        if (mTab.TryGetValue(bundleName, out refInfo))
        {//已经被加载过的bundle直接返回true
            if (refInfo.bundle != null)
            {
                return true;
            }
        }

        //本地文件直接访问包内位置
        //非本地文件访问预下载文件夹
        if (AssetLoader.Instance.IsLocalFile(bundleName))
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return AssetFileCheck(bundleName);
#else
            return System.IO.File.Exists(AssetConst.INTER_FILE_PAHT + bundleName);
#endif
        }
        else
        {
            return System.IO.File.Exists(AssetConst.CACHE_FILE_ROOT + bundleName);
        }
    }

    /// <summary>
    /// 先判断是否存储器里有对应的bundle文件
    /// 有返回bundle引用，没有返回空
    /// </summary>
    /// <param name="bundleName"></param>
    /// <param name="holder"></param>
    /// <returns></returns>
    public BundleRef CheckLoadBundle(string bundleName, IBundleRefHolder holder)
    {
        if (HasBundleFile(bundleName))//检查是否有bundle文件
        {
            return LoadBundle(bundleName, holder);
        }

        return null;
    }

    //BundleRef CheckLoadBundle(string bundleName)
    //{
    //    if(HasBundleFile(bundleName))//检查是否有bundle文件
    //    {
    //        return LoadBundle(bundleName);
    //    }

    //    return null;
    //}


    /// <summary>
    /// 获取bundle引用
    /// 目前只允许继承IBundleRefHolder的类读取bundle
    /// 方便调查bundle具体的的引用关系，
    /// 避免bundle被乱用又没有被正确卸载且不可调查的问题
    /// </summary>
    /// <param name="bundleName"></param>
    /// <param name="holder"></param>
    /// <returns></returns>
    public BundleRef LoadBundle(string bundleName, IBundleRefHolder holder)
    {
        BundleRef refData = LoadBundle(bundleName);
        if (refData != null && refData.bundle != null)
        {
            if (!refData.reverseRefs.ContainsKey(holder.GetHoldName()))
            {
                refData.reverseRefs.Add(holder.GetHoldName(), holder);
            }
        }

        return refData;
    }

    /// <summary>
    /// loadbundle引用
    /// </summary>
    /// <param name="bundleName"></param>
    /// <returns></returns>
    BundleRef LoadBundle(string bundleName)
    {
        //得到bundle ref
        BundleRef sceneRef = GetBundleRef(bundleName);

        //增加依赖和反向依赖
        TouchDependencies(sceneRef);

        //load bundle
        LoadImmediately(sceneRef, true);

        return sceneRef;
    }

    /// <summary>
    /// 用于处理编辑器中材质显示错误
    /// 非编辑器模式下无效
    /// </summary>
    /// <param name="b"></param>
    static void EDITOR_CHECK(AssetBundle b)
    {
        //#if UNITY_EDITOR
        //        if (b != null)
        //        {
        //            foreach (var m in b.LoadAllAssets<Material>())
        //            {
        //                m.shader = Shader.Find(m.shader.name);
        //            }
        //        }
        //#endif
    }

    /// <summary>
    /// debug打印目前所有被load的bundle信息和互相引用依赖关系
    /// </summary>
    /// <returns></returns>
    public string DumpDebugInfo()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("==================================================================");
        foreach (var pair in this.mTab)
        {
            sb.AppendLine();
            sb.AppendLine(string.Format("======={0}=======", pair.Key));
            sb.Append("\t refs:");
            foreach (var r in pair.Value.refs)
            {
                sb.Append(r.Key).Append("|");
            }

            sb.AppendLine().Append("\t reverseRefs:");
            foreach (var r in pair.Value.reverseRefs)
            {
                sb.Append(r.Key).Append("|");
            }

        }

        return sb.ToString();
    }

#if UNITY_ANDROID
    AndroidJavaObject _assetManager;
    AndroidJavaObject AndroidAssetManager
    {
        get
        {
            if (_assetManager == null)
            {
                var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                //从Activity取得AssetManager实例
                _assetManager = activity.Call<AndroidJavaObject>("getAssets");
            }
            return _assetManager;
        }

    }
    
    /// <summary>
    /// 判断安卓包内是否有对应文件
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    bool AssetFileCheck(string filePath)
    {
        string path = filePath.Contains(@"/") ? filePath.Substring(0, filePath.IndexOf(@"/")) : "";
        string file = System.IO.Path.GetFileNameWithoutExtension(filePath);

        string[] allFileList = AndroidAssetManager.Call<string[]>("list", path);
        for (int i = 0; i < allFileList.Length; i++)
        {
            if (allFileList[i] == file)
            {
                return true;
            }
        }

        return false;
    }

#endif

    float mLastUnloadTime;
    AsyncOperation mUnloadOpt;
    public void UnloadUnusedAssets()
    {
        //光是destroy gameobject并不能释放内存，
        //手机上为了不爆内存需要调用UnloadUnusedAssets释放掉对象所用资源
        if (mUnloadOpt != null && mUnloadOpt.isDone)
        {
            mUnloadOpt = null;
        }
        //Debuger.Log("relase resouces unused !");
        if (mUnloadOpt == null && Time.time - mLastUnloadTime > 60)
        {
            Debuger.Log("relase resouces unused !22222222222");
            mUnloadOpt = Resources.UnloadUnusedAssets();
            mLastUnloadTime = Time.time;
        }
    }

    public void UpdateUnusedTime()
    {
        mLastUnloadTime = Time.time;
    }
}
*/
#endregion


#region JobSystem

//NativeList<JobHandle> handles = new NativeList<JobHandle>(Allocator.Temp);
//for (int i = 0; i < 10; i++)
//{
//    JobHandle jobHandle = GetToughJob(mesh, material);
//    handles.Add(jobHandle);
//}

//JobHandle.CompleteAll(handles);
//handles.Dispose();

//[BurstCompile]
//public struct ToughJob : IJob
//{
//    public void Execute()
//    {
//        float value = 0;
//        for (int i = 0; i < 10000; i++)
//        {
//            value = math.exp10(math.sqrt(value));
//        }
//    }
//}

//[BurstCompile]
//public struct ToughJobParallel : IJobParallelFor
//{
//    public NativeArray<float3> transforms;
//    public NativeArray<float> moveSpeed;
//    public void Execute(int index)
//    {
//        transforms[index] += new float3(0, 0, moveSpeed[index] * Time.deltaTime);
//        if (transforms[index].z >= 30)
//        {
//            moveSpeed[index] = -math.abs(moveSpeed[index]);
//        }
//        if (transforms[index].z <= 30)
//        {
//            moveSpeed[index] = math.abs(moveSpeed[index]);
//        }
//        float value = 0;
//        for (int i = 0; i < 10000; i++)
//        {
//            value = math.exp10(math.sqrt(value));
//        }
//    }
//}

#endregion

#region 转换材质 透明
//public class Invisibility : MonoBehaviour
//{
//    public Material normalMat;
//    public Material invisibleMat;
//    public float value;
//    public float changeValue;
//    public float value2;
//    public float changeValue2;
//    public Color cloakColor = Color.white;
//    private bool changed = false;
//    private bool haschanged = true;
//    MeshRenderer[] meshes;
//    public bool ChangeRenderMode = false;
//    private void Awake()
//    {
//        meshes = GetComponentsInChildren<MeshRenderer>();
//        SetMat(normalMat);
//    }
//    void Update()
//    {
//        if (Input.GetButtonDown("Fire1"))
//        {
//            if (ChangeRenderMode)
//                StartCoroutine("OtherWay");
//            else
//                StartCoroutine("CloakCharacter");
//        }
//    }
//    void SetMat(Material mat)
//    {
//        for (int i = 0; i < meshes.Length; i++)
//        {
//            meshes[i].material = mat;
//        }
//    }
//    IEnumerator OtherWay()
//    {
//        if (!haschanged)
//            yield return null;
//        if (!changed && haschanged)
//        {
//            changed = true;
//            haschanged = false;
//            MaterialRenderMode.SetMaterialRenderingMode(normalMat, RenderingMode.Transparent);
//            Color matColor = normalMat.color;
//            Color color = new Color(matColor.r, matColor.g, matColor.b, 100);
//            color.a = value2;
//            normalMat.color = color;
//            while (color.a >= 0.1f)
//            {
//                color.a -= changeValue2;
//                normalMat.color = color;
//                yield return 0;
//            }
//            haschanged = true;
//        }
//        else if (changed && haschanged)
//        {
//            haschanged = false;
//            changed = false;

//            Color matColor = normalMat.color;
//            Color color = new Color(matColor.r, matColor.g, matColor.b, 0);
//            color.a = 0;
//            normalMat.color = color;
//            while (color.a <= value2)
//            {
//                color.a += changeValue2;
//                normalMat.color = color;
//                yield return 0;
//                if (color.a >= value2)
//                {
//                    color.a = 100;
//                    normalMat.color = color;
//                    MaterialRenderMode.SetMaterialRenderingMode(normalMat, RenderingMode.Opaque);
//                    haschanged = true;
//                }
//            }
//        }
//        yield return null;
//    }

//    IEnumerator CloakCharacter()
//    {
//        if (!haschanged)
//            yield return null;
//        if (!changed && haschanged)
//        {
//            changed = true;
//            haschanged = false;
//            SetMat(invisibleMat);
//            float cloakFade = value;
//            cloakColor.r = cloakFade;
//            cloakColor.g = cloakFade;
//            cloakColor.b = cloakFade;
//            invisibleMat.SetColor("_Tint", cloakColor);
//            while (cloakFade >= 0.5f)
//            {

//                cloakFade -= changeValue;
//                cloakColor.r = cloakFade;
//                cloakColor.g = cloakFade;
//                cloakColor.b = cloakFade;
//                invisibleMat.SetColor("_Tint", cloakColor);
//                yield return 0;
//            }
//            haschanged = true;
//        }
//        else if (changed && haschanged)
//        {
//            haschanged = false;
//            changed = false;
//            float cloakFade = 0.5f;
//            cloakColor.r = cloakFade;
//            cloakColor.g = cloakFade;
//            cloakColor.b = cloakFade;
//            invisibleMat.SetColor("_Tint", cloakColor);
//            while (cloakFade <= value)
//            {

//                cloakFade += changeValue;
//                cloakColor.r = cloakFade;
//                cloakColor.g = cloakFade;
//                cloakColor.b = cloakFade;
//                invisibleMat.SetColor("_Tint", cloakColor);
//                yield return 0;

//                if (cloakFade >= value)
//                {
//                    SetMat(normalMat);
//                    haschanged = true;
//                }

//            }
//        }
//        yield return null;
//    }
//}
//public enum RenderingMode
//{
//    Opaque,
//    Cutout,
//    Fade,
//    Transparent,
//}
////转换RenderingMode
//public class MaterialRenderMode
//{
//    public static void SetMaterialRenderingMode(Material material, RenderingMode renderingMode)
//    {
//        switch (renderingMode)
//        {
//            case RenderingMode.Opaque:
//                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
//                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
//                material.SetInt("_ZWrite", 1);
//                material.DisableKeyword("_ALPHATEST_ON");
//                material.DisableKeyword("_ALPHABLEND_ON");
//                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
//                material.renderQueue = -1;
//                break;
//            case RenderingMode.Cutout:
//                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
//                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
//                material.SetInt("_ZWrite", 1);
//                material.EnableKeyword("_ALPHATEST_ON");
//                material.DisableKeyword("_ALPHABLEND_ON");
//                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
//                material.renderQueue = 2450;
//                break;
//            case RenderingMode.Fade:
//                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
//                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
//                material.SetInt("_ZWrite", 0);
//                material.DisableKeyword("_ALPHATEST_ON");
//                material.EnableKeyword("_ALPHABLEND_ON");
//                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
//                material.renderQueue = 3000;
//                break;
//            case RenderingMode.Transparent:
//                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
//                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
//                material.SetInt("_ZWrite", 0);
//                material.DisableKeyword("_ALPHATEST_ON");
//                material.DisableKeyword("_ALPHABLEND_ON");
//                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
//                material.renderQueue = 3000;
//                break;
//        }
//    }
//}
#endregion


