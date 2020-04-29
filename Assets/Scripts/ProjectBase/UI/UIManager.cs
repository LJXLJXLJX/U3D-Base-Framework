using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// UI层级
/// </summary>
public enum E_UI_Layer
{
    Bot,
    Mid,
    Top,
    System
}

public class UIManager : BaseManager<UIManager>
{
    public Dictionary<string, BasePannel> panelDic = new Dictionary<string, BasePannel>();

    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;

    public UIManager()
    {
        //创建Canvas 切换场景时不移除
        GameObject obj = ResMgr.GetInstance().Load<GameObject>("UI/Canvas");
        Transform canvas = obj.transform;
        GameObject.DontDestroyOnLoad(obj);

        //找到各层
        bot = canvas.Find("Bot");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");

        //创建EventSystem 切换场景时不移除
        obj = ResMgr.GetInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <param name="panelName">面板名</param>
    /// <param name="layer">显示在哪一层</param>
    /// <param name="callback">现实之后需要对面板做的操作</param>
    public void ShowPanel<T>(string panelName, E_UI_Layer layer = E_UI_Layer.Mid, UnityAction<T> callback = null) where T : BasePannel
    {
        ResMgr.GetInstance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
        {
            //把它作为canvas的子对象 并设置位置
            //找到父对象 显示在那一层
            Transform father = bot;
            switch (layer)
            {
                case E_UI_Layer.Mid:
                    father = mid;
                    break;
                case E_UI_Layer.Top:
                    father = top;
                    break;
                case E_UI_Layer.System:
                    father = system;
                    break;
            }
            obj.transform.SetParent(father);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            (obj.transform as RectTransform).offsetMin = Vector3.zero;
            (obj.transform as RectTransform).offsetMax = Vector3.zero;

            //得到预制件的面板脚本
            T panel = obj.GetComponent<T>();

            if (callback != null)
                callback(panel);
            panelDic.Add(panelName, panel);
        });
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="panelName"></param>
    public void HidePanel(string panelName)
    {
        if (panelDic.ContainsKey(panelName))
        {
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }
}
