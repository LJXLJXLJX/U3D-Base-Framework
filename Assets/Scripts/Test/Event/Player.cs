using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        EventCenter.GetInstance().AddEventListener<Monster>("MonsterDead", MonsterDeadDo);
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener<Monster>("MonsterDead", MonsterDeadDo);
    }

    public void MonsterDeadDo(Monster info)
    {
        Debug.Log("玩家杀死了 " + info.name + " 得到奖励 "+ info.bonus);
    }
}
