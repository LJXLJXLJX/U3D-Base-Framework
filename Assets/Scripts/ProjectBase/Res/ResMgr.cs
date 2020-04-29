using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 资源加载模块
/// </summary>
public class ResMgr : BaseManager<ResMgr>
{
    //同步加载资源
    public T Load<T>(string name) where T : Object
    {
        T res = Resources.Load<T>(name);
        //如果资源是一个GameObject对象，直接实例化之后返回给外部使用即可
        if (res is GameObject)
            return GameObject.Instantiate(res);

        else
            return res;
    }

    //异步加载资源
    public void LoadAsync<T>(string name, UnityAction<T> callback) where T : Object
    {
        MonoMgr.GetInstance().StartCoroutine(ReallyLoadAsync<T>(name, callback));
    }

    private IEnumerator ReallyLoadAsync<T>(string name, UnityAction<T> callback) where T : Object
    {
        ResourceRequest request = Resources.LoadAsync<T>(name);
        yield return request;
        if (request.asset is GameObject)
            callback(GameObject.Instantiate(request.asset) as T);
        else
            callback(request.asset as T);
    }
}
