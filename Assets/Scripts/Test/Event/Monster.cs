using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public string name = "沙丁鱼怪人";
    public int bonus = 100;


    // Start is called before the first frame update
    void Start()
    {
        Dead();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Dead()
    {
        Debug.Log("怪物死亡");
        ////1.玩家得到奖励
        //GameObject.Find("Player").GetComponent<Player>().MonsterDeadDo();
        ////2.任务记录
        //GameObject.Find("Task").GetComponent<Task>().TaskWaitMonsterDeadDo();
        ////3.其他
        //GameObject.Find("Other").GetComponent<Other>().OhterWaitMonsterDeadDo();

        //触发事件
        EventCenter.GetInstance().EventTriggle("MonsterDead", this);

    }
}
