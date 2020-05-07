using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager
{
    private static TaskManager _instance;
    public static TaskManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new TaskManager();
                _instance.Init();
            }
            return _instance;
        }
    }

    private Dictionary<int, TaskData> TaskDataDic = new Dictionary<int, TaskData>();


    private void Init()
    {
        TaskData data0 = new TaskData();
        data0.id = 0;
        data0.iconType = NPCData.IconType.characer;
        data0.taskDes="找爽人";
        data0.peopleName = "爽夫人";
        data0.taksName = "rua";
        data0.time = 72;
        data0.overTimeMoney = 10;
        data0.completMoney = 100;
        data0.taskSpriteName = 0.ToString();
        data0.speicalGift = "wu";
        data0.drawDes = "画爽粉";
        TaskDataDic.Add(data0.id, data0);
    }

    public TaskData GetDataById(int id)
    {
        TaskData data = null;
        if (!TaskDataDic.TryGetValue(id, out data))
        {
            Debug.LogError("id is null" + id);
        }
        return data;
    }

}
