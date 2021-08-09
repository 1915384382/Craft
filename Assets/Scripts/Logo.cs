using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {
    IEnumerator JumpToNextScene()
    {
        SceneManager.LoadScene("Loading");//加载进度条场景
        yield return null;
    }
    public void Load() 
    {
        StartCoroutine("JumpToNextScene");
    }
}
