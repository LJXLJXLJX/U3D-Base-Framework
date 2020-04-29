using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// poolDict中的value
/// </summary>
public class PoolData
{
    public GameObject fatherObj;
    public List<GameObject> poolList;


    public PoolData(GameObject obj, GameObject poolObj)
    {
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.parent = poolObj.transform;
        poolList = new List<GameObject>() { obj };
        obj.transform.parent = fatherObj.transform;
        obj.SetActive(false);
    }

    public void PushObj(GameObject obj)
    {
        poolList.Add(obj);
        obj.SetActive(false);
        obj.transform.parent = fatherObj.transform;
    }

    public GameObject GetObj()
    {
        GameObject obj = null;
        obj = poolList[0];
        poolList.RemoveAt(0);
        obj.SetActive(true);
        obj.transform.SetParent(null);
        return obj;
    }
}

/// <summary>
/// 缓存池模块
/// </summary>
public class PoolMgr : BaseManager<PoolMgr>
{

    public Dictionary<string, PoolData> poolDict = new Dictionary<string, PoolData>();

    private GameObject poolObj;

    public void GetObj(string name, UnityAction<GameObject> callback)
    {
        if (poolDict.ContainsKey(name) && poolDict[name].poolList.Count > 0)
        {
            callback(poolDict[name].GetObj());
        }
        else
        {
            ResMgr.GetInstance().LoadAsync<GameObject>(name, (o) =>
            {
                o.name = name;
                callback(o);
            });
        }
    }

    public void PushObj(string name, GameObject obj)
    {
        if (poolObj == null)
            poolObj = new GameObject("Pool");

        if (poolDict.ContainsKey(name))
        {
            poolDict[name].PushObj(obj);
        }
        else
        {
            poolDict.Add(name, new PoolData(obj, poolObj));
        }
    }

    /// <summary>
    /// 清空缓存池，主要用于场景切换
    /// </summary>
    private void Clear()
    {
        poolDict.Clear();
        poolObj = null;
    }
}
