using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{

    private void Start()
    {
        EventCenter.GetInstance().AddEventListener<Monster>("MonsterDead", TaskWaitMonsterDeadDo);
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener<Monster>("MonsterDead", TaskWaitMonsterDeadDo);
    }

    public void TaskWaitMonsterDeadDo(Monster info)
    {
        Debug.Log("任务 记录");
    }
}
