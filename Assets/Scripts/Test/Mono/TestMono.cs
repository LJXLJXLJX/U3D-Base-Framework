using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomethingNotMonoButNeedUpdateAndCoroutine
{
    public void Update()
    {
        Debug.Log("Custom Update");
    }

    public IEnumerator TellYouThisIsIE()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("There is a coroutine");
    }
}

public class TestMono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SomethingNotMonoButNeedUpdateAndCoroutine not_mono = new SomethingNotMonoButNeedUpdateAndCoroutine();
        //MonoMgr.GetInstance().AddUpdateListener(not_mono.Update);
        MonoMgr.GetInstance().StartCoroutine(not_mono.TellYouThisIsIE());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
