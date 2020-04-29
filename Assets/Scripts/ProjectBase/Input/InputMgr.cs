using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : BaseManager<InputMgr>
{
    private bool isStart = false;

    public InputMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(MyUpdate);
    }


    public void StartOrEndCheck(bool isOpen)
    {
        isStart = isOpen;
    }

    /// <summary>
    /// 检测按键按下抬起 并分发事件
    /// </summary>
    /// <param name="key"></param>
    private void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            //事件中心分发按下w事件
            EventCenter.GetInstance().EventTriggle("按下某键", key);
        }
        if (Input.GetKeyUp(key))
        {
            EventCenter.GetInstance().EventTriggle("抬起某键", key);
        }
    }


    private void MyUpdate()
    {
        //若未开启输入检测 就不检测
        if (!isStart)
            return;
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.D);
    }
}
