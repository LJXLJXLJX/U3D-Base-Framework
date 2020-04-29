using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : BaseManager<SceneMgr>
{

    /// <summary>
    /// 场景加载 同步
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(string name,UnityAction action)
    {
        SceneManager.LoadScene(name);

        //加载完成后，执行动作
        action();
    }

    /// <summary>
    /// 提供给外部的 异步加载场景的接口方法
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void LoadSceneAsyn(string name,UnityAction action)
    {
        MonoMgr.GetInstance().StartCoroutine(ReallyLoadSceneAsyn(name, action));
    }

    /// <summary>
    /// 协程异步加载场景
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    private IEnumerator ReallyLoadSceneAsyn(string name,UnityAction action)
    {
        AsyncOperation ao= SceneManager.LoadSceneAsync(name);
        //得到加载进度
        while (!ao.isDone)
        {
            //事件中心向外部分发加载进度 
            EventCenter.GetInstance().EventTriggle("进度条更新", ao.progress);
            yield return ao.progress;
        }
        yield return ao;
    }
}
