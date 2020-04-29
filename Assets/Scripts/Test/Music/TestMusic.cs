using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMusic : MonoBehaviour
{
    GUIStyle s;
    GUIStyle s1;
    float v = 1f;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "PlayBkMusic"))
        {
            MusicMgr.GetInstance().PlayBkMusic("yhx");
        }

        if (GUI.Button(new Rect(0, 100, 100, 100), "StopBkMusic"))
        {
            MusicMgr.GetInstance().StopBkMusic();
        }

        if (GUI.Button(new Rect(0, 200, 100, 100), "PauseBkMusic"))
        {
            MusicMgr.GetInstance().PauseBkMusic();
        }

        v = GUI.HorizontalSlider(new Rect(0, 300, 100, 30), v, 0.0F, 1.0F);
        MusicMgr.GetInstance().SetBkVolume(v);
        
    }
}
