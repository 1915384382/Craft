using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.Collections;
using System;
using DG.Tweening;
public class Loading : MonoBehaviour
{
    public Image ImageLoading;



    //目的是对场景进行控制 获取进度值 和允许显示
    private AsyncOperation _async;
    //UI应该达到的进度
    private int _currProgress;
    void Start()
    {
        _currProgress = 0;
        _async = null;
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        //BulletPool.Instance.GetBulletObj(BulletType.PlayerNormalBullet.ToString());
        //BulletPool.Instance.GetBulletObj(BulletType.Bullet.ToString());
        //BulletPool.Instance.GetBulletObj(BulletType.FollowBullet.ToString());
        //AirCraftPool.Instance.GetAirCraft();
        //BulletPool.Instance.GetBulletObj(BulletType.PlayerNormalBullet.ToString());

        //临时的进度
        int tmp;
        //异步加载
        _async = SceneManager.LoadSceneAsync("Main");  //跳转场景为S3.
        //卸载无用资源
        AsyncOperation async = Resources.UnloadUnusedAssets();
        //垃圾回收
        yield return async;
        GC.WaitForPendingFinalizers();
        GC.Collect();
        //先不显示场景 等到进度为100%的时候显示场景 必须的!!!!
        _async.allowSceneActivation = false;
        #region 优化进度的 
        while (_async.progress < 0.9f)
        {
            //相当于滑动条应该到的位置
            tmp = (int)_async.progress * 100;

            //当滑动条 < tmp 就意味着滑动条应该变化
            while (_currProgress < tmp)
            {
                ++_currProgress;
                yield return new WaitForEndOfFrame();
            }
        }//while end   进度为90%

        tmp = 100;
        while (_currProgress < tmp)
        {

            ++_currProgress;
            yield return new WaitForEndOfFrame();
        }
        #endregion
        //处理进度为0 ~0.9的0

        //进度条完成 允许显示

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("_async.progress=====" + _async.progress);
        //ImageLoading.fillAmount = _currProgress / 100.0f;
        ImageLoading.fillAmount += Time.deltaTime;
        if (ImageLoading.fillAmount>=0.99f && _currProgress >99)
        {
            _async.allowSceneActivation = true;
        }
    }



}
