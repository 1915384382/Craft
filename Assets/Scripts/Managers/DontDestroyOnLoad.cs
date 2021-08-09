using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
	void Awake ()
    {
        //避免场景加载时该对象销毁
        DontDestroyOnLoad(gameObject);
    }
}
