using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputMgr.GetInstance().StartOrEndCheck(true);

        EventCenter.GetInstance().AddEventListener<KeyCode>("按下某键", CheckInputDown);
        EventCenter.GetInstance().AddEventListener<KeyCode>("抬起某键", CheckInputUp);
    }

    private void CheckInputDown(KeyCode code)
    {
        switch (code)
        {
            case KeyCode.W:
                Debug.Log("前进");
                break;
            case KeyCode.A:
                Debug.Log("左移");
                break;
            case KeyCode.S:
                Debug.Log("后退");
                break;
            case KeyCode.D:
                Debug.Log("右移");
                break;
        }
    }

    private void CheckInputUp(KeyCode code)
    {
        switch (code)
        {
            case KeyCode.W:
                Debug.Log("停止前进");
                break;
            case KeyCode.A:
                Debug.Log("停止左移");
                break;
            case KeyCode.S:
                Debug.Log("停止后退");
                break;
            case KeyCode.D:
                Debug.Log("停止右移");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
