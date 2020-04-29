using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PoolMgr.GetInstance().GetObj("Test/Cube", (o) =>
            {
                o.transform.localScale = Vector3.one * 2;
                StartCoroutine(destroyObj("Test/Cube", o));
            });
            //GameObject obj = ResMgr.GetInstance().Load<GameObject>("Test/Cube");

        }

        if (Input.GetMouseButtonDown(1))
        {
            PoolMgr.GetInstance().GetObj("Test/Sphere", (o) =>
            {
                StartCoroutine(destroyObj("Test/Sphere", o));
            });

        }

    }

    static IEnumerator destroyObj(string name, GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        PoolMgr.GetInstance().PushObj(name, obj);
    }

}
