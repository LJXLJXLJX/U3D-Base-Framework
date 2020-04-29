using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener<Monster>("MonsterDead", OhterWaitMonsterDeadDo);
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener<Monster>("MonsterDead", OhterWaitMonsterDeadDo);
    }

    public void OhterWaitMonsterDeadDo(Monster info)
    {
        Debug.Log("其他各个对象要做的事");
    }
}
