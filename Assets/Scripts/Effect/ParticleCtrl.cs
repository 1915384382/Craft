using UnityEngine;
using System.Collections.Generic;
using System;

[ExecuteInEditMode]
public class ParticleCtrl : MonoBehaviour 
{
    public GameObject destroyGO;
    public Transform rootTr;
    public float destroyTime = 2;
    [System.NonSerialized]
    public Transform trans;
    //[System.NonSerialized]
    //public UIEffect uieffect;

    [HideInInspector]
    [SerializeField]
    public List<ParticleCtrl> mListChildParticleControl = new List<ParticleCtrl>();
    [HideInInspector]
    [SerializeField]
    public List<ParticleSystem> mListChildParticle = new List<ParticleSystem>();
    [HideInInspector]
    [SerializeField]
    public List<Animation> mListChildAnimation = new List<Animation>();
    [HideInInspector]
    [SerializeField]
    public List<MeshRenderer> mListChildMeshRenderer = new List<MeshRenderer>();
    [HideInInspector]
    [SerializeField]
    public List<Animator> mListChildAnimatorList = new List<Animator>();

    public Action<ParticleCtrl> actionDestroy;
    public bool destroy = false;

    public float duration;
    private float start;
    private float pauseDuration = 0f;

    protected bool turnOn;
    public string path;
    public PoolPathType pooltype;
    public bool TurnOn
    {
        get { return turnOn; }
        set
        {
            turnOn = value;
            if (value == true)
            {
                start = Time.time;
                PlayParticle();
            }
            else
                StopParticle(true);
        }
    }

    protected void Awake()
    {
        trans = transform;

#if UNITY_EDITOR
        if (!Application.isPlaying)
            Init();                 // add child game objects into lists
#endif

#if UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)
        Renderer[] rs = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer r in rs) {
			if (r != null && r.sharedMaterial != null) {
				r.sharedMaterial.shader = Shader.Find(r.sharedMaterial.shader.name);
			}
		}
#endif
    }

    protected void Update()
    {
        if (destroyGO == null)
        {
            if (TurnOn && duration > Mathf.Epsilon && Time.time - start > duration + pauseDuration)
            {
                TurnOn = false;
                DestroyParticle();
            }
        }
        else
        {
            if (!destroyGO.gameObject.activeSelf)
            {
                if (TurnOn && duration > Mathf.Epsilon && Time.time - start > duration + pauseDuration)
                {
                    TurnOn = false;
                    DestroyParticle();
                }
            }
        }
        if (start > 0 && Time.time - start > duration)
        {
            ParticlePool.Instance.RevertParticle(gameObject);
            start = -1;
        }
    }


    public void Init()
    {
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.BeginSample("ParticleCtrl init");
#endif
        mListChildParticleControl.Clear();
        mListChildAnimation.Clear();
        mListChildParticle.Clear();
        mListChildMeshRenderer.Clear();
        trans.GetComponentsInChildren(mListChildParticleControl);
        trans.GetComponentsInChildren(mListChildAnimation);
        trans.GetComponentsInChildren(mListChildParticle);
        trans.GetComponentsInChildren(mListChildMeshRenderer);
        trans.GetComponentsInChildren(mListChildAnimatorList);
#if UNITY_EDITOR
        UnityEngine.Profiling.Profiler.EndSample();
#endif
    }

    void PlayParticle()
    {
        for (int i = 0; i < mListChildParticleControl.Count; i ++ )
            mListChildParticleControl[i].turnOn = true;

        for (int i = 0; i < mListChildParticle.Count; i ++)
        {
            if (mListChildParticle[i] != null)
            {
                SwitchParticleRender(mListChildParticle[i], true);
                mListChildParticle[i].Stop();
                mListChildParticle[i].Play();
            }
        }

        for (int i = 0; i < mListChildAnimation.Count; i++)
        {
            if (mListChildAnimation[i] != null)
            {
                mListChildAnimation[i].Stop();
                foreach (AnimationState state in mListChildAnimation[i])
                {
                    state.time = 0f;
                }
                mListChildAnimation[i].Play();
            }
        }

        for (int i = 0; i < mListChildMeshRenderer.Count; i ++ )
        {
            if (mListChildMeshRenderer[i] != null)
                mListChildMeshRenderer[i].enabled = true;
        }

        for (int i = 0; i < mListChildAnimatorList.Count; i ++ )
        {
            if (mListChildAnimatorList[i] != null)
            {
                mListChildAnimatorList[i].StopPlayback();
                mListChildAnimatorList[i].Play(0);
            }
        }
    }

    void SwitchParticleRender(ParticleSystem x, bool on_off)
    {
        if (x != null && x.GetComponent<Renderer>() != null)
            x.GetComponent<Renderer>().enabled = on_off;

        return;
    }

    public void StopParticle(bool _stopRenderer = true)
    {
        if (this == null)
        {
            return;
        }

        for (int i = 0; i < mListChildParticleControl.Count; i++)
        {
            if (mListChildParticleControl[i] != null && mListChildParticleControl[i] != this)
                mListChildParticleControl[i].StopParticle(_stopRenderer);
        }

        for (int i = 0; i < mListChildParticle.Count; i ++ )
        {
            if (mListChildParticle[i] != null)
            {
                SwitchParticleRender(mListChildParticle[i], false);
                mListChildParticle[i].Stop(true);
            }
        }

        for (int i = 0; i < mListChildAnimation.Count; i++)
        {
            if (mListChildAnimation[i] != null)
            {
                if (_stopRenderer)
                {
                    Renderer render = mListChildAnimation[i].GetComponent<Renderer>();
                    if (render != null)
                        render.enabled = false;
                }
                mListChildAnimation[i].Stop();
            }
        }

        if (_stopRenderer)
        {
            for (int i = 0; i < mListChildMeshRenderer.Count; i ++ )
            {
                if (mListChildMeshRenderer[i] != null)
                    mListChildMeshRenderer[i].enabled = false;
            }
        }

        for (int i = 0; i < mListChildAnimatorList.Count; i++)
        {
            if (mListChildAnimatorList[i] != null)
                mListChildAnimatorList[i].StopPlayback();
        }
    }

    public void PauseParticle(float _duration)
    {
        if (this == null)
        {
            return;
        }

        pauseDuration = _duration;
        for (int i = 0; i < mListChildParticleControl.Count; i++)
        {
            if (mListChildParticleControl[i] != null)
                mListChildParticleControl[i].turnOn = false;
        }

        for (int i = 0; i < mListChildParticle.Count; i++)
        {
            if (mListChildParticle[i] != null)
                mListChildParticle[i].Pause(true);
        }

        for (int i = 0; i < mListChildAnimation.Count; i++)
        {
            if (mListChildAnimation[i] != null)
            {
                foreach (AnimationState state in mListChildAnimation[i])
                {
                    if (state.enabled)
                        state.speed = 0f;
                }
            }
        }

        for (int i = 0; i < mListChildAnimatorList.Count; i++)
        {
            if (mListChildAnimatorList[i] != null)
                mListChildAnimatorList[i].speed = 0f;
        }
    }

    public void ResumeParticle()
    {
        if (this == null)
        {
            return;
        }

        for (int i = 0; i < mListChildParticleControl.Count; i++)
        {
            if (mListChildParticleControl[i] != null)
                mListChildParticleControl[i].turnOn = true;
        }

        for (int i = 0; i < mListChildParticle.Count; i++)
        {
            if (mListChildParticle[i] != null)
            {
                mListChildParticle[i].Play(true);
            }
        }

        for (int i = 0; i < mListChildAnimation.Count; i++)
        {
            if (mListChildAnimation[i] != null)
            {
                foreach (AnimationState state in mListChildAnimation[i])
                {
                    if (state.enabled)
                        state.speed = 1f;
                }
            }
        }

        for (int i = 0; i < mListChildAnimatorList.Count; i++)
        {
            if (mListChildAnimatorList[i] != null)
                mListChildAnimatorList[i].speed = 1f;
        }
    }

    public void DestroyParticle()
    {
        if (this == null)
            return;
        TurnOn = false;
        actionDestroy?.Invoke(this);
        if (destroy && gameObject != null)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void Strike()
    {
        if (destroyGO != null)
        {
            destroyGO.gameObject.SetActive(false);
            duration = destroyTime;
            start = Time.time;
        }
        else
        {
            DestroyParticle();
        }
    }

    public void SetOffPos(Vector3 _pos)
    {
        if (rootTr != null)
            rootTr.localPosition = _pos;
    }

    public void ResetData()
    {
        //if (uieffect != null)
        //{
        //    uieffect.UpdateUIEffect();
        //    uieffect = null;
        //}
    }
    public void Setaction()
    {
        GameManager.Instance.actionResetGame += OnGameReset;
    }
    public void OnGameReset(int a)
    {
        ParticlePool.Instance.RevertParticle(this.gameObject);
        GameManager.Instance.actionResetGame -= OnGameReset;
    }
}
