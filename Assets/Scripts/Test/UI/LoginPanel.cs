using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePannel
{
    // Start is called before the first frame update
    void Start()
    {
        GetControl<Button>("StartBtn").onClick.AddListener(StartClick);
        GetControl<Button>("QuitBtn").onClick.AddListener(QuitClick);
    }

    
    void StartClick()
    {
        Debug.Log("start");
    }

    void QuitClick()
    {
        Debug.Log("quit");
    }
}
