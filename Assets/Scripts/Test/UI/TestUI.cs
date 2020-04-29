using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.GetInstance().ShowPanel<LoginPanel>("LoginPanel", E_UI_Layer.Mid, null);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
